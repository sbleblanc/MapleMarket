using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MapleMarket.Windows
{
    public class BaseWindow : Window, IView
    {
        public bool IsClosing { get; set; }
        public IViewModel ViewModel { get; set; }

        public BaseWindow(IViewModel vm) : base()
        {
            ViewModel = vm;
            DataContext = vm;
            ViewModel.RequestWindowClose += ViewModel_RequestWindowClose;
            ViewModel.RequestViewOpening += ViewModel_RequestViewOpening;
            IsClosing = false;
        }

        public virtual bool? ShowView(Window owner)
        {
            Owner = owner;
            return ShowDialog();
        }

        private void ViewModel_RequestViewOpening(IView view)
        {
            view.ShowView(this);
        }

        private void ViewModel_RequestWindowClose()
        {
            if(!IsClosing)
            {
                Close();
            }
        }
    }
}
