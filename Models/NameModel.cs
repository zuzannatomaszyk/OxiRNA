using Npgsql;
namespace OxiRNA.Models {
  public class NameModel {
    public NameModel (NpgsqlDataReader reader) {
      this.name = reader.GetString (0);
    }
    public string name { get; set; }
  }
}