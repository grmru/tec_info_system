using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient
{
    public class SettingsData
    {
        public string DataBaseServer { get; set; } = "localhost";
        public string DataBasePort { get; set; } = "3306";
        public string DataBaseName { get; set; } = "tec_data";
        public string DataBaseUsername { get; set; } = "root";
        public string DataBasePassword { get; set; } = "tec";

        public string DataBaseConnectionString
        {
            get
            {
                return $"Server={DataBaseServer};Port={DataBasePort};Database={DataBaseName};Uid={DataBaseUsername};Pwd={DataBasePassword};";
            }
        }
    }
}
