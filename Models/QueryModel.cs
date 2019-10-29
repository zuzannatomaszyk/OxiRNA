using System;
using Npgsql;
namespace OxiRNA.Models {
  public class QueryModel {
    public QueryModel (NpgsqlDataReader reader) {
      this.genbank = reader.GetString (0);
      this.sequenceName = reader.GetString (1);
      this.sequence = reader.GetString (2);
      this.species = reader.GetString (3);
      this.taxon = reader.GetString (4);
      this.article = reader.GetString (5);
      this.articleLink = reader.GetString (6);
      this.journal = reader.GetString (7);
      if (!reader.IsDBNull (8))
        this.about = reader.GetString (8);
    }
    public string genbank { get; set; }
    public string sequenceName { get; set; }
    public string sequence { get; set; }
    public string species { get; set; }
    public string taxon { get; set; }
    public string article { get; set; }
    public string articleLink { get; set; }
    public string journal { get; set; }
    public string about { get; set; }

  }
}