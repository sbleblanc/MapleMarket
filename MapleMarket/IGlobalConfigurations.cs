using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleMarket
{
    public interface IGlobalConfigurations
    {
        string ConnectionString { get; set; }
    }
}
