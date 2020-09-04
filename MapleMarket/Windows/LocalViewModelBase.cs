using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleMarket.Windows
{
    public class LocalViewModelBase : ViewModelBase
    {
        public static string ConnectionString { get; set; }
    }
}
