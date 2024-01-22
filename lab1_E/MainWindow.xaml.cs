using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using lab1_E.View;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab1_E
{
    public partial class MainWindow : Window
    {
        public static int IdCurrency { get; set; }
        public static int IdOrder { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Order_OnClick(object sender, RoutedEventArgs e)
        {
            WindowOrder or = new WindowOrder();
            or.Show();
        }
        private void OrderType_OnClick(object sender, RoutedEventArgs e)
        {
            WindowOrderType ort = new WindowOrderType();
            ort.Show();
        }
        private void OrderVeriety_OnClick(object sender, RoutedEventArgs e)
        {
            WindowOrderVeriety orv = new WindowOrderVeriety();
            orv.Show();
        }
        private void Currency_OnClick(object sender, RoutedEventArgs e)
        {
            WindowCurrency cu = new WindowCurrency();
            cu.Show();
        }
    }
}
