using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MapleMarket.Windows.InsertPrice
{
    /// <summary>
    /// Interaction logic for InsertPrice.xaml
    /// </summary>
    public partial class InsertPrice : BaseWindow
    {
        public InsertPrice(IViewModel vm) : base(vm)
        {
            InitializeComponent();
        }

        private void txtbPrice_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private void txtbPrice_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var txtb = (sender as TextBox);
            if (txtb == null || txtb.IsKeyboardFocusWithin) return;
            e.Handled = true;
            txtb.Focus();
        }
    }
}
