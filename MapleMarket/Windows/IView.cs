using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MapleMarket.Windows
{
    public interface IView
    {
        IViewModel ViewModel { get; set; }

        bool? ShowView(Window owner);
    }
}
