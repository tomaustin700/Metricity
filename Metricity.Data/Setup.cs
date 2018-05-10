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
        public static string GetConnectionString()
        {
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Metricity")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Metricity"));

            if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Metricity") + @"\Connection.txt"))
                throw new InvalidOperationException("Connection.txt missing from " + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Metricity"));

            return System.IO.File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Metricity") + @"\Connection.txt");
        }
    }
}
