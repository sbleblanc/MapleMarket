using MapleMarket.ViewModels;
using MapleMarket.Windows;
using MapleMarket.Windows.GetItem;
using MapleMarket.Windows.InsertPrice;
using MapleMarket.Windows.MainWindow;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MapleMarket
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IViewFactory ViewFactory { get; set; }

        public App()
        {
            ViewFactory = new ViewFactory();
            ViewFactory.RegisterView<MainWindow, MainWindowViewModel>(new MainWindowViewModel());
            ViewFactory.RegisterView<GetItem, IGetItem>(new GetItemViewModel());
            ViewFactory.RegisterView<InsertPrice, IInsertPrice>(new InsertPriceViewModel());
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainView = ViewFactory.CreateView<MainWindowViewModel>();
            mainView.Item2.InitAsync().Wait();
            mainView.Item1.ShowView(null);
        }
    }
}
