using lab1_E.Model;
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
    /// Логика взаимодействия для WindowCurrency.xaml
    /// </summary>
    public partial class WindowCurrency : Window
    {
        CurrencyViewModel vmViewModel = new CurrencyViewModel();
        public WindowCurrency()
        {
            InitializeComponent();
            CurrencyViewModel vmViewModel = new CurrencyViewModel();
            ListCurrency.ItemsSource = vmViewModel.ListCurrency;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewCurrency windowNewCurrency = new WindowNewCurrency
            {
                Title = "Новая валюта",
                Owner = this
            };

            int maxIdCurrency = vmViewModel.MaxId() + 1;
            Currency сurrency = new Currency
            {
                Id = maxIdCurrency,
            };

            windowNewCurrency.DataContext = сurrency;
            if (windowNewCurrency.ShowDialog() == true)
            {
                vmViewModel.ListCurrency.Add(сurrency);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewCurrency windowNewCurrency = new WindowNewCurrency
            {
                Title = "Редактирование валюты",
                Owner = this
            };

            Currency сurrency = ListCurrency.SelectedItem as Currency;

            if (сurrency != null)
            {
                Currency tempCurrency = new Currency
                {
                    Id = сurrency.Id,
                    CurrencyFull = сurrency.CurrencyFull,
                    CurrencyShort = сurrency.CurrencyShort,
                };

                windowNewCurrency.DataContext = tempCurrency;
                if (windowNewCurrency.ShowDialog() == true)
                {
                    сurrency.Id = tempCurrency.Id;
                    сurrency.CurrencyFull = tempCurrency.CurrencyFull;
                    сurrency.CurrencyShort = tempCurrency.CurrencyShort;

                    ListCurrency.ItemsSource = null;
                    ListCurrency.ItemsSource = vmViewModel.ListCurrency;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать валюту для редактирования",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Currency сurrency = (Currency)ListCurrency.SelectedItem;

            if (сurrency != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные валюте: [ "
                    + сurrency.Id + " ]", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK) vmViewModel.ListCurrency.Remove(сurrency);
                else MessageBox.Show("Необходимо выбрать валюту для удаления", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
    }
}
