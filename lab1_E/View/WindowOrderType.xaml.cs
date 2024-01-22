using lab1_E.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab1_E.View
{
    /// <summary>
    /// Логика взаимодействия для WindowOrderType.xaml
    /// </summary>
    public partial class WindowOrderType : Window
    {
        public WindowOrderType()
        {
            InitializeComponent();

            OrderTypeViewModel vmViewModel = new OrderTypeViewModel();
            ListOrderType.ItemsSource = vmViewModel.ListOrderType;
        }
    }
}
