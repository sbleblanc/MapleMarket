﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MapleMarket;
using System.Timers;
using MapleMarket.Windows;

namespace MapleMarket.Windows.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : BaseWindow
    {
        public IViewModel ViewModel { get; set; }

        public MainWindow(IViewModel vm) : base(vm)
        {
            InitializeComponent();
        }

        public override bool? ShowView(Window owner)
        {
            Show();
            return true;
        }
    }
}
