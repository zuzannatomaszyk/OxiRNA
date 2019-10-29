using System.IO;

namespace OxiRNA.Settings
{
    public class ConnectionSettings
    {
        private static string connString;

        public static string getConnectionString() {
            if(string.IsNullOrEmpty(connString)) {
                var file = "Settings\\connectionstring.txt";
                connString = System.IO.File.ReadAllText(file);

            }

            return connString;
        }
    }
}