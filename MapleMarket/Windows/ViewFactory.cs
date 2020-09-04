using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleMarket.Windows
{
    public class ViewFactory : IViewFactory
    {
        private Dictionary<Type, Tuple<Type, IViewModel>> _RegisteredViews;

        public ViewFactory()
        {
            _RegisteredViews = new Dictionary<Type, Tuple<Type, IViewModel>>();
        }

        public Tuple<IView, VM> CreateView<VM>()
        {
            var vmType = typeof(VM);
            if (_RegisteredViews.ContainsKey(vmType))
            {
                var instanceTuple = _RegisteredViews[vmType];
                IView newView = (IView)Activator.CreateInstance(instanceTuple.Item1, instanceTuple.Item2);
                return new Tuple<IView, VM>(newView, (VM)instanceTuple.Item2);
            }
            else
            {
                return null;
            }
        }

        public void RegisterView<V, VM>(VM instance) where VM : IViewModel
        {
            Type viewType = typeof(V);
            Type vmType = typeof(VM);
            instance.ViewFactory = this;
            _RegisteredViews.Add(vmType, new Tuple<Type, IViewModel>(viewType, instance));
        }
    }
}
