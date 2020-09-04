using MapleMarket.Utils;
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
            GlobalConfig.Instance.ConnectionString = @"metadata=res://*/MapleMarketModel.csdl|res://*/MapleMarketModel.ssdl|res://*/MapleMarketModel.msl;provider=MySql.Data.MySqlClient;provider connection string='server=belandls.ca;user id=maplemarket;password=Maple!Market123;database=maple_market'";

            ViewFactory = new ViewFactory();
            ViewFactory.RegisterView<MainWindow, MainWindowViewModel>(new MainWindowViewModel(GlobalConfig.Instance));
            ViewFactory.RegisterView<GetItem, IGetItem>(new GetItemViewModel(GlobalConfig.Instance));
            ViewFactory.RegisterView<InsertPrice, IInsertPrice>(new InsertPriceViewModel(GlobalConfig.Instance));
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainView = ViewFactory.CreateView<MainWindowViewModel>();
            mainView.Item2.InitAsync().Wait();
            mainView.Item1.ShowView(null);
        }
    }
}
