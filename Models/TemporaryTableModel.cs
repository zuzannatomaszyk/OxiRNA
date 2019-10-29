using System;
using System.Collections;
using Npgsql;
namespace OxiRNA.Models {
  public class TemporaryTableModel {
    public TemporaryTableModel (NpgsqlDataReader reader) {
      this.id = reader.GetInt32 (0).ToString ();
      this.name = reader.GetString (1).Replace ("'", "''");
      this.contact = reader.GetString (2).Replace ("'", "''");
      this.sequenceName = reader.GetString (3).Replace ("'", "''");
      this.genbank = reader.GetString (4).Replace ("'", "''");
      this.sequence = reader.GetString (5).Replace ("'", "''");
      this.about = reader.GetString (6).Replace ("'", "''");
      this.taxon = reader.GetString (7).Replace ("'", "''");
      this.species = reader.GetString (8).Replace ("'", "''");
      this.journal = reader.GetString (9).Replace ("'", "''");
      this.article = reader.GetString (10).Replace ("'", "''");
      this.articleLink = reader.GetString (11).Replace ("'", "''");
    }
    public TemporaryTableModel () { }
    public string id { get; set; }
    public string name { get; set; }
    public string contact { get; set; }
    public string genbank { get; set; }
    public string sequenceName { get; set; }
    public string sequence { get; set; }
    public string about { get; set; }
    public string species { get; set; }
    public string taxon { get; set; }
    public string article { get; set; }
    public string articleLink { get; set; }
    public string journal { get; set; }

    public int getTaxonID (string connString) {
      var results = new ArrayList ();
      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();
        string command = "SELECT taxon_id FROM taxon WHERE name = '" + this.taxon + "';";

        using (var cmd = new NpgsqlCommand (command, conn))
        using (var reader = cmd.ExecuteReader ()) {
          while (reader.Read ()) {
            results.Add (reader.GetInt32 (0));
          }
        }
      }
      return Convert.ToInt32 (results[0]);
    }

    public int getSpeciesID (string connString, int taxon_id) {
      var results = new ArrayList ();
      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();
        string command = "SELECT species_id FROM species WHERE name ~* '" + this.species + "';";

        using (var cmd = new NpgsqlCommand (command, conn))
        using (var reader = cmd.ExecuteReader ()) {
          while (reader.Read ()) {
            results.Add (reader.GetInt32 (0));
          }
        }
        if (results.Count == 0) {
          string insertCommand = "INSERT INTO species (name, taxon) VALUES ('" + this.species + "', " + taxon_id + ");";
          using (var cmd = new NpgsqlCommand (insertCommand, conn))
          cmd.ExecuteNonQuery ();

          using (var cmd = new NpgsqlCommand (command, conn))
          using (var reader = cmd.ExecuteReader ()) {
            while (reader.Read ()) {
              results.Add (reader.GetInt32 (0));
            }
          }

        }
      }
      return Convert.ToInt32 (results[0]);
    }

    public int getJournalID (string connString) {
      var results = new ArrayList ();
      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();
        string command = "SELECT journal_id FROM journal WHERE name ~* '" + this.journal + "';";

        using (var cmd = new NpgsqlCommand (command, conn))
        using (var reader = cmd.ExecuteReader ()) {
          while (reader.Read ()) {
            results.Add (reader.GetInt32 (0));
          }
        }
        if (results.Count == 0) {
          string insertCommand = "INSERT INTO journal (name) VALUES ('" + this.journal + "');";
          using (var cmd = new NpgsqlCommand (insertCommand, conn))
          cmd.ExecuteNonQuery ();

          using (var cmd = new NpgsqlCommand (command, conn))
          using (var reader = cmd.ExecuteReader ()) {
            while (reader.Read ()) {
              results.Add (reader.GetInt32 (0));
            }
          }

        }
      }
      return Convert.ToInt32 (results[0]);
    }

    public int getArticleID (string connString, int journal_id) {
      var results = new ArrayList ();
      using (var conn = new NpgsqlConnection (connString)) {
        conn.Open ();
        string command = "SELECT article_id FROM article WHERE name ~* '" + this.article + "';";

        using (var cmd = new NpgsqlCommand (command, conn))
        using (var reader = cmd.ExecuteReader ()) {
          while (reader.Read ()) {
            results.Add (reader.GetInt32 (0));
          }
        }
        if (results.Count == 0) {
          string insertCommand = "INSERT INTO article (name, link, journal) VALUES ('" + this.article + "', '" + this.articleLink + "', " + journal_id + ");";
          using (var cmd = new NpgsqlCommand (insertCommand, conn))
          cmd.ExecuteNonQuery ();

          using (var cmd = new NpgsqlCommand (command, conn))
          using (var reader = cmd.ExecuteReader ()) {
            while (reader.Read ()) {
              results.Add (reader.GetInt32 (0));
            }
          }

        }
      }
      return Convert.ToInt32 (results[0]);
    }
  }
}