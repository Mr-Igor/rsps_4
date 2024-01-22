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

namespace lab1_E.View
{
    /// <summary>
    /// Логика взаимодействия для WindowNewOrder.xaml
    /// </summary>
    public partial class WindowNewOrder : Window
    {
        public WindowNewOrder()
        {
            InitializeComponent();
        }
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
