using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleMarket.Windows
{
    public interface IViewFactory
    {
        void RegisterView<V, VM>(VM instance) where VM : IViewModel;
        Tuple<IView, VM> CreateView<VM>();
    }
}
