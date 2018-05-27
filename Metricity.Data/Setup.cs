using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data
{
    public static class Setup
    {
        private static string _connectionString;
        private static string _apiKey;
        public static string GetConnectionString()
        {
            if (!string.IsNullOrEmpty(_apiKey))
            {
               // _connectionString = connectionstringofonlineportal
            }
            else if (string.IsNullOrEmpty(_connectionString))
            {
                if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Metricity")))
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Metricity"));

                if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Metricity") + @"\Connection.txt"))
                    throw new InvalidOperationException("No database connection string specified. Specify using Setup.SetConnectionString or add Connection.txt to " + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Metricity"));

                _connectionString = System.IO.File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Metricity") + @"\Connection.txt");
            }

            return _connectionString;
        }

        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static void SetAPIKey(string apiKey)
        {
            _apiKey = apiKey;
        }


    }
}
