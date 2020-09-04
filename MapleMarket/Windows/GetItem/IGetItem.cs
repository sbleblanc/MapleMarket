using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleMarket.Windows.GetItem
{
    interface IGetItem : IViewModel
    {
        Item SelectedItem { get; set; }
    }
}
