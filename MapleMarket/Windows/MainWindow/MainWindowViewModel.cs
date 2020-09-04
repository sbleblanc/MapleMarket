using AsyncAwaitBestPractices.MVVM;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MapleMarket.Windows.GetItem;
using MapleMarket.Windows.InsertPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MapleMarket.Windows.MainWindow
{
    public class MainWindowViewModel : ViewModelBase, IViewModel
    {

        public IViewFactory ViewFactory { get; set; }
        public event RequestWindowCloseHandler RequestWindowClose;
        public event RequestViewOpeningHandler RequestViewOpening;

        private ICommand _CmdSelectItem;
        private IGlobalConfigurations _GlobalConf;

        public ICommand CmdSelectItem
        {
            get
            {
                return _CmdSelectItem;
            }
            set
            {
                _CmdSelectItem = value;
                RaisePropertyChanged();
            }
        }

        public MainWindowViewModel(IGlobalConfigurations globalConf)
        {
            _GlobalConf = globalConf;
            _CmdSelectItem = new AsyncCommand(() => SelectMapleItem(), (o) => true);
        }

        private async Task SelectMapleItem()
        {
            var selectMIView = ViewFactory.CreateView<IInsertPrice>();
            await selectMIView.Item2.InitAsync();
            RequestViewOpening?.Invoke(selectMIView.Item1);
        }

        public Task InitAsync()
        {
            return Task.CompletedTask;
        }
    }
}
