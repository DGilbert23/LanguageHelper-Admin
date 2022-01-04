using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace LanguageHelper3._1.Classes
{
    class Variables
    {
        public static string connectionString { get; set; }
        public static bool validUser { get; set; }
        public static DataGrid mainGrid { get; set; }
        public static DBController dBController { get; set; }
    }
}
