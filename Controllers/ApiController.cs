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

namespace OxiRNA.Controllers {
  [Route ("api/")]
  [ApiController]
  public class ApiController : Controller {

    private JsonResult SimpleSearch (string anything) {
      List<QueryModel> result = new List<QueryModel> ();
      var connString = ConnectionSettings.getConnectionString ();
      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();
        string command =
          @"SELECT *
            FROM
              (SELECT
                sequence.genbank,
                sequence.name,
                sequence.seq AS sequence,
                Species.name AS species,
                Taxon.name AS taxon,
                Article.name AS article,
                Article.link AS link,
                Journal.name AS journal,
                Sequence.about
              FROM
                sequence INNER JOIN Article ON Article.article_id = sequence.article
                JOIN Species ON Species.species_id = sequence.species
                JOIN Taxon ON Taxon.taxon_id = Species.taxon
              JOIN Journal ON Journal.journal_id = Article.journal) short
              WHERE lower(short::text) LIKE lower(@p1);";

        using (var cmd = new NpgsqlCommand (command, conn)) {
          cmd.Parameters.AddWithValue ("p1", "%" + anything + "%");

          using (var reader = cmd.ExecuteReader ()) {

            while (reader.Read ()) {
              QueryModel query = new QueryModel (reader);
              result.Add (query);
            }
          }
        }

      }
      JsonResult js = Json (result);
      return js;
    }

    private JsonResult AdvancedSearch (
      string[] name, string[] genbank, string[] journal, string[] article, string[] taxon, string[] species) {

      List<KeyValuePair<string, string>> ands = new List<KeyValuePair<string, string>> ();
      List<KeyValuePair<string, string>> ors = new List<KeyValuePair<string, string>> ();

      Dictionary<string, string> columns = new Dictionary<string, string> ();
      columns.Add ("genbank", "sequence.genbank");
      columns.Add ("name", "sequence.name");
      columns.Add ("journal", "Journal.name");
      columns.Add ("article", "Article.name");
      columns.Add ("taxon", "Taxon.name");
      columns.Add ("species", "Species.name");

      foreach (var key in Request.Query.Keys) {
        string[] values = Request.Query[key];
        for (int i = 0; i < values.Length; i += 2) {
          if (values[i + 1] == "true") {
            ors.Add (new KeyValuePair<string, string> (key, values[i]));
          } else {
            ands.Add (new KeyValuePair<string, string> (key, values[i]));
          }
        }
      }

      List<KeyValuePair<string, string>> sqlParams = new List<KeyValuePair<string, string>> ();
      int paramsIterator = 0;
      string orsSQL = "";
      foreach (var pair in ors) {
        if (orsSQL != "") {
          orsSQL += " OR ";
        }
        string ValueParam = "p" + paramsIterator.ToString ();
        paramsIterator++;
        sqlParams.Add (new KeyValuePair<string, string> (ValueParam, pair.Value));
        orsSQL += columns[pair.Key] + " ~* " + "@" + ValueParam;
      }

      string andsSQL = "";
      foreach (var pair in ands) {
        if (andsSQL != "") {
          andsSQL += " AND ";
        }
        string ValueParam = "p" + paramsIterator.ToString ();
        paramsIterator++;
        sqlParams.Add (new KeyValuePair<string, string> (ValueParam, pair.Value));
        andsSQL += columns[pair.Key] + " !~* " + "@" + ValueParam;
      }
      string SQL = @"SELECT
                sequence.genbank AS genbank,
                sequence.name AS name,
                sequence.seq AS sequence,
                Species.name AS species,
                Taxon.name AS taxon,
                Article.name AS article,
                Article.link AS link,
                Journal.name AS journal,
                Sequence.about
              FROM
                sequence INNER JOIN Article ON Article.article_id = sequence.article
                JOIN Species ON Species.species_id = sequence.species
                JOIN Taxon ON Taxon.taxon_id = Species.taxon
                JOIN Journal ON Journal.journal_id = Article.journal";

      if (ands.Count > 0 && ors.Count > 0) {
        SQL += " WHERE (" + andsSQL + ") AND (" + orsSQL + ");";
      } else if (ands.Count == 0 && ors.Count == 0) {
        SQL += ";";
      } else {
        SQL += " WHERE " + andsSQL + orsSQL + ";";
      }

      List<QueryModel> result = new List<QueryModel> ();
      var connString = ConnectionSettings.getConnectionString ();
      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();

        using (var cmd = new NpgsqlCommand (SQL, conn)) {
          foreach (var pair in sqlParams) {
            cmd.Parameters.AddWithValue (pair.Key, pair.Value);
          }

          using (var reader = cmd.ExecuteReader ()) {

            while (reader.Read ()) {
              QueryModel query = new QueryModel (reader);
              result.Add (query);
            }
          }
        }
      }

      JsonResult js = Json (result);
      return js;
    }

    [HttpGet]
    [Route ("sequences")]
    public JsonResult getSequences (string anything, [FromQuery] string[] name, [FromQuery] string[] genbank, [FromQuery] string[] journal, [FromQuery] string[] article, [FromQuery] string[] taxon, [FromQuery] string[] species) {
      if (anything != null) {
        return SimpleSearch (anything);
      } else {
        return AdvancedSearch (name, genbank, journal, article, taxon, species);
      }
    }

    [HttpGet]
    [Route ("species")]
    public JsonResult getSpecies (string name) {
      List<NameModel> result = new List<NameModel> ();
      var connString = ConnectionSettings.getConnectionString ();
      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();
        string command =
          @"SELECT name
            FROM species
            WHERE lower(name) LIKE lower(@p1);";

        using (var cmd = new NpgsqlCommand (command, conn)) {
          cmd.Parameters.AddWithValue ("p1", "%" + (string.IsNullOrEmpty (name) ? "" : name) + "%");

          using (var reader = cmd.ExecuteReader ()) {

            while (reader.Read ()) {
              NameModel row = new NameModel (reader);
              result.Add (row);
            }
          }
        }

      }
      JsonResult js = Json (result);
      return js;

    }

    [HttpGet]
    [Route ("taxon")]
    public JsonResult getTaxon (string name) {
      List<NameModel> result = new List<NameModel> ();
      var connString = ConnectionSettings.getConnectionString ();
      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();
        string command =
          @"SELECT name
            FROM taxon
            WHERE lower(name) LIKE lower(@p1);";

        using (var cmd = new NpgsqlCommand (command, conn)) {
          cmd.Parameters.AddWithValue ("p1", "%" + (string.IsNullOrEmpty (name) ? "" : name) + "%");

          using (var reader = cmd.ExecuteReader ()) {

            while (reader.Read ()) {
              NameModel row = new NameModel (reader);
              result.Add (row);
            }
          }
        }

      }
      JsonResult js = Json (result);
      return js;

    }

    [HttpGet]
    [Route ("journal")]
    public JsonResult getJournal (string name) {
      List<NameModel> result = new List<NameModel> ();
      var connString = ConnectionSettings.getConnectionString ();
      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();
        string command =
          @"SELECT name
            FROM journal
            WHERE lower(name) LIKE lower(@p1);";

        using (var cmd = new NpgsqlCommand (command, conn)) {
          cmd.Parameters.AddWithValue ("p1", "%" + (string.IsNullOrEmpty (name) ? "" : name) + "%");

          using (var reader = cmd.ExecuteReader ()) {

            while (reader.Read ()) {
              NameModel row = new NameModel (reader);
              result.Add (row);
            }
          }
        }

      }
      JsonResult js = Json (result);
      return js;
    }

    [HttpGet]
    [Route ("article")]
    public JsonResult getArticle (string articleName, string journalName) {
      List<ArticleModel> result = new List<ArticleModel> ();
      var connString = ConnectionSettings.getConnectionString ();
      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();
        string command =
          @"SELECT article.name as articleName, article.link, journal.name as journalName
            FROM article join journal ON article.journal = journal.journal_id
            WHERE lower(article.name) LIKE lower(@p1) AND lower(journal.name) LIKE lower(@p2);";

        using (var cmd = new NpgsqlCommand (command, conn)) {
          cmd.Parameters.AddWithValue ("p1", "%" + (string.IsNullOrEmpty (articleName) ? "" : articleName) + "%");
          cmd.Parameters.AddWithValue ("p2", "%" + (string.IsNullOrEmpty (journalName) ? "" : journalName) + "%");

          using (var reader = cmd.ExecuteReader ()) {

            while (reader.Read ()) {
              ArticleModel row = new ArticleModel (reader);
              result.Add (row);
            }
          }
        }

      }
      JsonResult js = Json (result);
      return js;

    }

    [HttpGet ("download")]
    [Route ("getSequences")] public IActionResult getSequenceFunction (string sequenceGenbank) {

      var splittedGenbanks = sequenceGenbank.Split (",");
      Array.Sort (splittedGenbanks);
      string SQLstring = "(";

      foreach (var genbank in splittedGenbanks) {
        SQLstring += "'" + genbank + "',";
      }
      SQLstring = SQLstring.Remove (SQLstring.Length - 1);
      SQLstring += ")";

      var results = new ArrayList ();
      var connString = ConnectionSettings.getConnectionString ();
      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();
        string command = "SELECT Sequence.seq AS sequence FROM Sequence " +
          " WHERE Sequence.genbank in " + SQLstring + " ORDER BY Sequence.genbank;";

        using (var cmd = new NpgsqlCommand (command, conn))
        using (var reader = cmd.ExecuteReader ()) {
          while (reader.Read ()) {
            results.Add (reader.GetString (0));
          }
        }
      }
      if (splittedGenbanks.Length == 1) {
        var fileName = sequenceGenbank + ".fa";
        var file = Path.Combine ("~\\", fileName);

        Directory.CreateDirectory ("~\\");
        System.IO.File.WriteAllText (file, results[0].ToString ());

        var net = new System.Net.WebClient ();
        var data = net.DownloadData (file);
        var content = new System.IO.MemoryStream (data);
        var contentType = "APPLICATION/octet-stream";
        System.IO.File.Delete (file);
        Directory.Delete ("~\\");
        return File (content, contentType, fileName);
      } else {
        // Create temp directory for all the files
        Directory.CreateDirectory ("~\\");

        // Create all fasta files
        for (int i = 0; i < splittedGenbanks.Length; i++) {
          // foreach(var genbank in splittedGenbanks) {
          var fileName = splittedGenbanks[i] + ".fa";
          var file = Path.Combine ("~\\", fileName);
          System.IO.File.WriteAllText (file, results[i].ToString ());
        }
        // Create directory for zip file
        string folderToZip = "zip\\";
        Directory.CreateDirectory (folderToZip);

        string zipFileName = "ZippedFastas.zip";
        string zipFile = folderToZip + zipFileName;

        // Create zip file
        ZipFile.CreateFromDirectory ("~\\", zipFile);

        // Delete all the fasta files
        foreach (var genbank in splittedGenbanks) {
          var fileName = genbank + ".fa";
          var file = Path.Combine ("~\\", fileName);
          System.IO.File.Delete (file);
        }

        // Delete directory for fastas
        Directory.Delete ("~\\");

        // Load file into a memory to send it to client
        var net = new System.Net.WebClient ();
        var data = net.DownloadData (zipFile);
        var content = new System.IO.MemoryStream (data);
        var contentType = "APPLICATION/octet-stream";

        // Delete zip file and directory for zip file
        System.IO.File.Delete (zipFile);
        Directory.Delete (folderToZip);

        return File (content, contentType, zipFileName);

      }

    }

    [HttpGet ("download")]
    [Route ("getMetadata")] public IActionResult getMetadataFunction (string sequenceGenbank) {
      var splittedGenbanks = sequenceGenbank.Split (",");
      Array.Sort (splittedGenbanks);
      string SQLstring = "(";

      foreach (var genbank in splittedGenbanks) {
        SQLstring += "'" + genbank + "',";
      }
      SQLstring = SQLstring.Remove (SQLstring.Length - 1);
      SQLstring += ")";

      List<MetadataModel> result = new List<MetadataModel> ();
      var connString = ConnectionSettings.getConnectionString ();
      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();
        string command = "SELECT Sequence.genbank, Sequence.name, Species.name AS species, Taxon.name AS taxon, Article.name AS article, Article.link AS link, Journal.name AS journal, Sequence.about FROM Sequence" +
          " JOIN Article ON Article.article_id = Sequence.article JOIN Species ON Species.species_id = Sequence.species JOIN Taxon ON Taxon.taxon_id = Species.taxon JOIN Journal ON Journal.journal_id = Article.journal" +
          " WHERE Sequence.genbank in " + SQLstring + " ORDER BY Sequence.genbank;";

        using (var cmd = new NpgsqlCommand (command, conn))
        using (var reader = cmd.ExecuteReader ()) {

          while (reader.Read ()) {
            MetadataModel query = new MetadataModel (reader);
            result.Add (query);
          }
        }
      }
      var fileName = "metadata.csv";
      var file = Path.Combine ("~\\", fileName);

      Directory.CreateDirectory ("~\\");

      string lines = "genbank, sequence_name, species, taxon, article, article_link, journal, about\n";
      foreach (var seq in result) {
        lines += seq.genbank + ", \"" + seq.sequenceName + "\", " + seq.species + ", " + seq.taxon + ", \"" + seq.article + "\", " + seq.articleLink + ", \"" + seq.journal + ", \"" + seq.about + "\"\n";
      }
      System.IO.File.WriteAllText (file, lines);

      var net = new System.Net.WebClient ();
      var data = net.DownloadData (file);
      var content = new System.IO.MemoryStream (data);
      var contentType = "APPLICATION/octet-stream";
      System.IO.File.Delete (file);
      Directory.Delete ("~\\");
      return File (content, contentType, fileName);
    }

    [HttpPost]
    [Route ("SubmitData")] public IActionResult SubmitData ([FromForm] TemporaryTableModel sequenceData) {
      var connString = ConnectionSettings.getConnectionString ();

      Dictionary<string, string> valuesDictionary = new Dictionary<string, string> ();
      valuesDictionary.Add ("p0", "sequenceData.name");
      valuesDictionary.Add ("p1", "sequenceData.contact");
      valuesDictionary.Add ("p2", "sequenceData.sequenceName");
      valuesDictionary.Add ("p3", "sequenceData.genbank");
      valuesDictionary.Add ("p4", "sequenceData.sequence");
      valuesDictionary.Add ("p5", "sequenceData.about");
      valuesDictionary.Add ("p6", "sequenceData.taxon");
      valuesDictionary.Add ("p7", "sequenceData.species");
      valuesDictionary.Add ("p8", "sequenceData.journal");
      valuesDictionary.Add ("p9", " sequenceData.article");
      valuesDictionary.Add ("p10", " sequenceData.articleLink");

      string columns = "name, contact, seq_name, genbank, seq, about, taxon, species, journal, article_name, article_link";
      string values = "";
      for (int i = 0; i < valuesDictionary.Count; i++) {
        values += "@p" + i;
        if (i != valuesDictionary.Count - 1) {
          values += ",";
        }
      }

      string command = "INSERT INTO temporary (" + columns + ") VALUES (" + values + ");";
      string selectCommand = "SELECT genbank FROM sequence WHERE genbank = @p3;";

      var results = new List<string> ();

      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();
        using (var cmd = new NpgsqlCommand (selectCommand, conn)) {
          foreach (var pair in valuesDictionary) {
            cmd.Parameters.AddWithValue (pair.Key, pair.Value);
          }
          using (var reader = cmd.ExecuteReader ()) {
            while (reader.Read ()) {
              results.Add (reader.GetString (0));
            }
          }
        }
        if (results.Count == 0) {
          using (var cmd = new NpgsqlCommand (command, conn)) {
            foreach (var pair in valuesDictionary) {
              cmd.Parameters.AddWithValue (pair.Key, pair.Value);
            }
            cmd.ExecuteNonQuery ();
          }
          return RedirectToAction ("SubmitMessage", "Home", new { area = "Home" });
        } else {
          return RedirectToAction ("SubmitFail", "Home", new { area = "Home" });
        }
      }
    }
  }
}