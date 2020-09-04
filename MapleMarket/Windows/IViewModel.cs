using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleMarket.Windows
{
    public delegate void RequestWindowCloseHandler();

    public delegate void RequestViewOpeningHandler(IView view);
    public interface IViewModel
    {
        event RequestWindowCloseHandler RequestWindowClose;

        event RequestViewOpeningHandler RequestViewOpening;

        IViewFactory ViewFactory { get; set; }

        Task InitAsync();
    }
}
