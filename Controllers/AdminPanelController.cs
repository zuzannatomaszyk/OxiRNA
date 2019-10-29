using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using OxiRNA.Models;
using OxiRNA.Settings;

namespace OxiRNA.Controllers
{
     [Route ("AdminPanel/")] 
    [ApiController]
    public class AdminPanelController : Controller
    {
   
      private IActionResult getTemporaryTable () {
      List<TemporaryTableModel> result = new List<TemporaryTableModel> ();
      var connString = ConnectionSettings.getConnectionString ();
      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();
        string command = "SELECT * FROM temporary ORDER BY id;";

        using (var cmd = new NpgsqlCommand (command, conn))
        using (var reader = cmd.ExecuteReader ()) {

          while (reader.Read ()) {
            TemporaryTableModel query = new TemporaryTableModel (reader);
            result.Add (query);
          }
        }
      }
      return View ("AdminPanel", result);
    }

    [HttpPost]
    [Route ("Validate")] public IActionResult ValidateData ([FromForm] LoginModel loginData) {
      var results = new ArrayList ();
      var connString = ConnectionSettings.getConnectionString ();
      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();
        string command = "SELECT email FROM admin WHERE email = '" + loginData.email + "' AND password = crypt('" + loginData.password + "', password);";

        using (var cmd = new NpgsqlCommand (command, conn))
        using (var reader = cmd.ExecuteReader ()) {
          while (reader.Read ()) {
            results.Add (reader.GetString (0));
          }
        }
      }
      if (results.Count > 0) {
        return getTemporaryTable ();
      } else {
        return RedirectToAction ("Login", "Home", new { area = "Home" });
      }

    }
    private void DeleteFromTable (string id) {
      var connString = ConnectionSettings.getConnectionString ();
      string command = "";
      if (id == null) {
        command = "DELETE FROM temporary;";
      } else {
        command = "DELETE FROM temporary WHERE id = " + id + ";";
      }

      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();
        var cmd = new NpgsqlCommand (command, conn);
        cmd.ExecuteNonQuery ();
      }
    }
    private TemporaryTableModel getRowFromTemporaryTable (int id) {
      List<TemporaryTableModel> result = new List<TemporaryTableModel> ();
      var connString = ConnectionSettings.getConnectionString ();
      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();
        string command = "SELECT * FROM temporary WHERE id = " + id + "ORDER BY id;";

        using (var cmd = new NpgsqlCommand (command, conn))
        using (var reader = cmd.ExecuteReader ()) {

          while (reader.Read ()) {
            TemporaryTableModel query = new TemporaryTableModel (reader);
            result.Add (query);
          }
        }
      }
      return result[0];
    }

    private List<int> getIDsFromTemporaryTable () {
      var connString = ConnectionSettings.getConnectionString ();
      List<int> result = new List<int> ();
      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();
        string command = "SELECT id FROM temporary ORDER BY id;";

        using (var cmd = new NpgsqlCommand (command, conn))
        using (var reader = cmd.ExecuteReader ()) {

          while (reader.Read ()) {
            int query = reader.GetInt32 (0);
            result.Add (query);
          }
        }
      }
      return result;
    }

    private void AcceptRow (string id) {
      var connString = ConnectionSettings.getConnectionString ();

      TemporaryTableModel sequenceData = getRowFromTemporaryTable (Convert.ToInt32 (id));
      //dodać do funkcji get niezwracanie uwagi na wielkość liter 
      int taxonID = sequenceData.getTaxonID (connString);
      int speciesID = sequenceData.getSpeciesID (connString, taxonID);
      int journalID = sequenceData.getJournalID (connString);
      int articleID = sequenceData.getArticleID (connString, journalID);

      string insert = "INSERT INTO sequence (article, species, name, genbank, seq, about) VALUES ";
      string values = " (" + articleID + ", " + speciesID + ", '" + sequenceData.sequenceName + "', '" + sequenceData.genbank +
        "', '" + sequenceData.sequence + "', '" + sequenceData.about + "');";
      string command = insert + values;

      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();
        var cmd = new NpgsqlCommand (command, conn);
        cmd.ExecuteNonQuery ();
      }
      DeleteFromTable (id);
    }
    public void AcceptAllData () {
      List<int> TempTableIDs = getIDsFromTemporaryTable ();
      foreach (int id in TempTableIDs) {
        AcceptRow (id.ToString ());
      }
    }

    [HttpGet]
    [Route ("RejectData")] public IActionResult RejectData (string id) {
      DeleteFromTable (id);
      return getTemporaryTable ();
    }

    [HttpGet]
    [Route ("AcceptData")] public IActionResult AcceptData (string id) {
      if (id == null) {
        AcceptAllData ();
      } else {
        AcceptRow (id);
      }
      return getTemporaryTable ();
    }
    }
}