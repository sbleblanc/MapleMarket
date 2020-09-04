using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleMarket.Utils
{
    public class GlobalConfig : IGlobalConfigurations
    {
        private static GlobalConfig _Instance;

        public static GlobalConfig Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new GlobalConfig();
                }
                return _Instance;
            }
        }

        public string ConnectionString { get; set; }

        private GlobalConfig()
        {
            ConnectionString = "";
        }

    }
}
