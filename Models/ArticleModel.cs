using Npgsql;

namespace OxiRNA.Models {
  public class ArticleModel {

    public ArticleModel (NpgsqlDataReader reader) {
      this.articleName = reader.GetString (0);
      this.link = reader.GetString (1);
      this.journalName = reader.GetString (2);
    }
    public string articleName { get; set; }
    public string journalName { get; set; }
    public string link { get; set; }

  }
}