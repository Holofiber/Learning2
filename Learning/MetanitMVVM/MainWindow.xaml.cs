using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MetanitMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<TradeOrder> Trades { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Trades = new ObservableCollection<TradeOrder>
            {
                new TradeOrder{Price = 123, Amount = 0.98f, Time = DateTime.Now},
                new TradeOrder{Price = 123, Amount = 0.98f, Time = DateTime.Now},
                new TradeOrder{Price = 123, Amount = 0.98f, Time = DateTime.Now},
                new TradeOrder{Price = 123, Amount = 0.98f, Time = DateTime.Now},
                new TradeOrder{Price = 123, Amount = 0.98f, Time = DateTime.Now},
            };

        }







    }


}
