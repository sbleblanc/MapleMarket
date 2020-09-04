using AsyncAwaitBestPractices.MVVM;
using GalaSoft.MvvmLight;
using MapleMarket.Windows;
using MapleMarket.Windows.GetItem;
using MapleMarket.Windows.InsertPrice;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MapleMarket.ViewModels
{
    class InsertPriceViewModel : ViewModelBase, IInsertPrice
    {
        // Commands
        private ICommand _CmdGetMapleItem;

        private IGlobalConfigurations _GlobalConfig;
        private Regex _PriceRgx;
        private Item _SelectedMapleItem = null;
        private long _Price;
        private bool _Sold;
        private string _Source;
        private ObservableCollection<string> _SourceChoices;
        private ObservableCollection<Event> _SelectedEvents;
        private ObservableCollection<Event> _EventChoices;

        public IViewFactory ViewFactory { get; set; }
        public event RequestWindowCloseHandler RequestWindowClose;
        public event RequestViewOpeningHandler RequestViewOpening;

        public ObservableCollection<Event> SelectedEvents
        {
            get
            {
                return _SelectedEvents;
            }
            set
            {
                _SelectedEvents = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Event> EventChoices
        {
            get
            {
                return _EventChoices;
            }
            set
            {
                _EventChoices = value;
                RaisePropertyChanged();
            }
        }

        public bool Sold
        {
            get
            {
                return _Sold;
            }
            set
            {
                _Sold = value;
                RaisePropertyChanged();
            }
        }

        public string Source
        {
            get
            {
                return _Source;
            }
            set
            {
                _Source = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<string> SourceChoices
        {
            get
            {
                return _SourceChoices;
            }
            set
            {
                _SourceChoices = value;
                RaisePropertyChanged();
            }
        }

        public ICommand CmdGetMapleItem
        {
            get
            {
                return _CmdGetMapleItem;
            }
            set
            {
                _CmdGetMapleItem = value;
                RaisePropertyChanged();
            }
        }

        public Item SelectedMapleItem
        {
            get
            {
                return _SelectedMapleItem;
            }
            set
            {
                _SelectedMapleItem = value;
                RaisePropertyChanged();
            }
        }

        public string PriceStr
        {
            get
            {
                if (_Price / 1000000000.0 >= 1)
                {
                    return String.Format("{0} {1}", _Price / 1000000000.0, 'B');
                }
                else if (_Price / 1000000.0 >= 1)
                {
                    return String.Format("{0} {1}", _Price / 1000000.0, 'M');
                }
                else
                {
                    return String.Format("{0} {1}", _Price / 1000.0, 'K');
                }
            }
            set
            {
                var m = _PriceRgx.Match(value);
                if (m.Success)
                {
                    double amount = double.Parse(m.Groups[1].Value.Replace(',', '.'));
                    string unit = m.Groups[m.Groups.Count - 1].Value.ToLower();
                    switch (unit)
                    {
                        case "k":
                            _Price = (long)(amount * 1000);
                            break;
                        case "m":
                            _Price = (long)(amount * 1000000);
                            break;
                        case "b":
                            _Price = (long)(amount * 1000000000);
                            break;
                    }
                }
                else
                {
                    throw new ArgumentException("The price is not in a valid format.");
                }
                RaisePropertyChanged();
            }
        }

        

        public InsertPriceViewModel(IGlobalConfigurations globalConf)
        {
            _GlobalConfig = globalConf;
            _PriceRgx = new Regex(@"^(\d+([\.\,]\d+)?)\s*([kmb])$", RegexOptions.IgnoreCase);
            CmdGetMapleItem = new AsyncCommand(() => GetMapleItem(), (o) => true);
            _Sold = false;
            _Source = "SHOP";
            SourceChoices = new ObservableCollection<string>()
            {
                "OWL",
                "SHOP",
                "SOLD"
            };
            _SelectedEvents = new ObservableCollection<Event>();
            _EventChoices = new ObservableCollection<Event>()
            {
                new Event(){name = "Anniversary"},
                new Event(){name = "Haloween"},
                new Event(){name = "Christmas"}
            };
        }

        public Task InitAsync()
        {
            return Task.CompletedTask;
        }

        private async Task GetMapleItem()
        {
            var selectMIView = ViewFactory.CreateView<IGetItem>();
            await selectMIView.Item2.InitAsync();
            RequestViewOpening?.Invoke(selectMIView.Item1);
            SelectedMapleItem = selectMIView.Item2.SelectedItem;
        }
    }
}
