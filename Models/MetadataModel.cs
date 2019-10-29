using System;
using Npgsql;
namespace OxiRNA.Models {
  public class MetadataModel {
    public MetadataModel (NpgsqlDataReader reader) {
      this.genbank = reader.GetString (0);
      this.sequenceName = reader.GetString (1);
      this.species = reader.GetString (2);
      this.taxon = reader.GetString (3);
      this.article = reader.GetString (4);
      this.articleLink = reader.GetString (5);
      this.journal = reader.GetString (6);
      if (!reader.IsDBNull (7))
        this.about = reader.GetString (7);
    }
    public string genbank { get; set; }
    public string sequenceName { get; set; }
    public string species { get; set; }
    public string taxon { get; set; }
    public string article { get; set; }
    public string articleLink { get; set; }
    public string journal { get; set; }
    public string about { get; set; }
  }
}