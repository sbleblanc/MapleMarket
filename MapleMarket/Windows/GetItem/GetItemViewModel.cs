using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapleMarket.ViewModels;
using System.Timers;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight;
using System.Windows;
using System.Data.Entity;
using AsyncAwaitBestPractices.MVVM;

namespace MapleMarket.Windows.GetItem
{
    public class GetItemViewModel : ViewModelBase, IGetItem
    {
        //Commands
        private ICommand _CmdUpdateResearchTimer;
        private ICommand _CmdAcceptSelection;
        private ICommand _CmdCancelSelection;
        private ICommand _CmdLoadInitialData;

        private IGlobalConfigurations _GlobalConf;
        private Timer _SearchTimer;
        private List<Item> _AllItems;
        private IEnumerable<IGrouping<int, Item>> _CurrentFilteredItems;
        private string _SearchFilter;
        private Item _SelectedItem;
        private bool _IsFiltered = false;
        private bool _IsLoading = false;

        public event RequestWindowCloseHandler RequestWindowClose;
        public event RequestViewOpeningHandler RequestViewOpening;

        public bool IsLoading
        {
            get
            { 
                return _IsLoading; 
            }
            set
            {
                _IsLoading = value;
                RaisePropertyChanged();
            }
        }

        public bool IsFiltered
        {
            get
            {
                return _IsFiltered;
            }
            set
            {
                _IsFiltered = value;
                RaisePropertyChanged();
            }
        }

        public Item SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                _SelectedItem = value;
                RaisePropertyChanged();
            }
        }

        public ICommand CmdUpdateResearchTimer
        {
            get
            {
                return _CmdUpdateResearchTimer;
            }
            set
            {
                _CmdUpdateResearchTimer = value;
                RaisePropertyChanged();
            }
        }

        public ICommand CmdAcceptSelection
        {
            get
            {
                return _CmdAcceptSelection;
            }
            set
            {
                _CmdAcceptSelection = value;
                RaisePropertyChanged();
            }
        }

        public ICommand CmdCancelSelection
        {
            get
            {
                return _CmdCancelSelection;
            }
            set
            {
                _CmdCancelSelection = value;
                RaisePropertyChanged();
            }
        }

        public ICommand CmdLoadInitialData
        {
            get
            {
                return _CmdLoadInitialData;
            }
            set
            {
                _CmdLoadInitialData = value;
                RaisePropertyChanged();
            }
        }

        public string SearchFilter
        {
            get
            {
                return _SearchFilter;
            }
            set
            {
                _SearchFilter = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<IGrouping<int, Item>> CurrentFilteredItems
        {
            get
            {
                return _CurrentFilteredItems;
            }

            set
            {
                _CurrentFilteredItems = value;
                RaisePropertyChanged();
           }
        }

        public IViewFactory ViewFactory { get; set; }

        public GetItemViewModel(IGlobalConfigurations globalConf)
        {
            _GlobalConf = globalConf;
            CmdUpdateResearchTimer = new RelayCommand(() => UpdateSearchTimer(), () => true);
            CmdAcceptSelection = new RelayCommand(() => AcceptSelection(), () => SelectedItem != null);
            CmdCancelSelection = new RelayCommand(() => CancelSelection(), () => true);

           
            SearchFilter = "";

            _SearchTimer = new Timer(250)
            {
                AutoReset = false,
                Enabled = false
            };
            _SearchTimer.Elapsed += SearchTimer_Elapsed;
            _AllItems = new List<Item>();
            ExecuteSearch();
        }

        private void UpdateSearchTimer()
        {
            if (_SearchTimer.Enabled)
            {
                _SearchTimer.Enabled = false;
                _SearchTimer.Enabled = true;
            }
            else
            {
                _SearchTimer.Enabled = true;
            }
        }

        private void ExecuteSearch()
        {
            SelectedItem = null;
            if (_SearchFilter.Length == 0)
            {
                CurrentFilteredItems = from i in _AllItems
                                       group i by i.category into g
                                       select g;
                IsFiltered = false;
            }
            else
            {
                CurrentFilteredItems = from i in _AllItems
                                       where i.name.ToLower().Contains(_SearchFilter.ToLower()) || i.description.ToLower().Contains(_SearchFilter.ToLower())
                                       group i by i.category into g
                                       select g;
                IsFiltered = true;
            }
        }

        private void SearchTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ExecuteSearch();
            _SearchTimer.Enabled = false;
        }

        private void AcceptSelection()
        {
            RequestWindowClose?.Invoke();
        }

        private void CancelSelection()
        {
            SelectedItem = null;
            RequestWindowClose?.Invoke();
        }

        public async Task InitAsync()
        {
            IsLoading = true;
            if (_AllItems.Count == 0)
            {
                _AllItems = await Task.Run(() =>
                {
                    using (var context = new MapleMarketEntities(_GlobalConf.ConnectionString))
                    {
                        var itemQuery = from i in context.Item.AsNoTracking()
                                        select i;

                        return itemQuery.ToList();
                    }
                });
            }
            ExecuteSearch();
            IsLoading = false;
        }
    }
}
