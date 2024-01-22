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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using lab1_E.Helper;
using lab1_E.Model;
using lab1_E.ViewModel;

namespace lab1_E.View
{
    /// <summary>
    /// Логика взаимодействия для WindowOrder.xaml
    /// </summary>
    public partial class WindowOrder : Window
    {
        private OrderViewModel vmOrder = new OrderViewModel();
        private ObservableCollection<OrderDPO> ordersDPO;

        private OrderTypeViewModel vmOrT;
        private ObservableCollection<OrderType> OrTs;

        private OrderVerietyViewModel vmOrV;
        private ObservableCollection<OrderVeriety> Orvs;

        private CurrencyViewModel vmCurrency;
        private ObservableCollection<Currency> curs;

        public WindowOrder()
        {
            InitializeComponent();
            ordersDPO = new ObservableCollection<OrderDPO>();

            vmOrT = new OrderTypeViewModel();
            OrTs = vmOrT.ListOrderType;

            vmOrV = new OrderVerietyViewModel();
            Orvs = vmOrV.ListOrderVeriety;

            vmCurrency = new CurrencyViewModel();
            curs = vmCurrency.ListCurrency;


            foreach (Order p in vmOrder.ListOrder)
            {
                OrderDPO oDPO = new OrderDPO();
                oDPO = oDPO.CopyFromOrder(p);
                ordersDPO.Add(oDPO);
            }
            ListOrder.ItemsSource = ordersDPO;

            /*OrderViewModel ordervm = new OrderViewModel();
            ListOrder.ItemsSource = ordervm.ListOrder;

            OrderTypeViewModel OrderTypevm = new OrderTypeViewModel();
            List<OrderType> orderTypes = new List<OrderType>();

            foreach (OrderType olf in OrderTypevm.ListOrderType)
            {
                orderTypes.Add(olf);
            }

            OrderVerietyViewModel OrderVerietyvm = new OrderVerietyViewModel();
            List<OrderVeriety> orderVerietys = new List<OrderVeriety>();

            foreach (OrderVeriety olf in OrderVerietyvm.ListOrderVeriety)
            {
                orderVerietys.Add(olf);
            }

            CurrencyViewModel Currencyvm = new CurrencyViewModel();
            List<Currency> Currencys = new List<Currency>();

            foreach (Currency olf in Currencyvm.ListCurrency)
            {
                Currencys.Add(olf);
            }

            ObservableCollection<OrderDPO> orders = new ObservableCollection<OrderDPO>();

            FindOrderType finderOrderType;
            FindOrderVeriety finderOrderVeriety;
            FindCurrency finderCurrency;

            foreach (var or in ordervm.ListOrder)
            {
                finderOrderType = new FindOrderType(or.OrderTypeID);
                OrderType orderType = orderTypes.Find(new Predicate<OrderType>(finderOrderType.OrderTypePredicate));

                finderOrderVeriety = new FindOrderVeriety(or.OrderVerietyID);
                OrderVeriety orderVeriety = orderVerietys.Find(new Predicate<OrderVeriety>(finderOrderVeriety.OrderVerietyPredicate));

                finderCurrency = new FindCurrency(or.CurrencyID);
                Currency currency = Currencys.Find(new Predicate<Currency>(finderCurrency.CurrencyPredicate));

                orders.Add(new OrderDPO 
                {
                    Id = or.Id,
                    OrderVerietyID = orderVeriety.Veriety,
                    OrderTypeID = orderType.Type,
                    CurrencyID = currency.CurrencyFull,
                    Tiker = or.Tiker,
                    Count = or.Count,
                    Type = or.Type,
                    Number = or.Number,
                    Data = or.Data,
                    Duration = or.Duration
                });
                ListOrder.ItemsSource = orders;
            }*/
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewOrder windowNewOrder = new WindowNewOrder
            {
                Title = "Новое поручение",
                Owner = this
            };

            int maxIdOrder = vmOrder.MaxId() + 1;
            OrderDPO orderDPO = new OrderDPO
            {
                Id = maxIdOrder,
                Data = DateTime.Now,
                Duration = DateTime.Now

            };

            windowNewOrder.DataContext = orderDPO;
            windowNewOrder.cb_orderType.ItemsSource = OrTs;
            windowNewOrder.cb_orderVeriety.ItemsSource = Orvs;
            windowNewOrder.cb_Currency.ItemsSource = curs;

            if (windowNewOrder.ShowDialog() == true)
            {
                OrderType orderType = (OrderType)windowNewOrder.cb_orderType.SelectedValue;
                OrderVeriety orderVeriety = (OrderVeriety)windowNewOrder.cb_orderVeriety.SelectedValue;
                Currency currency = (Currency)windowNewOrder.cb_Currency.SelectedValue;

                orderDPO.OrderTypeID = orderType.Type.ToString();
                orderDPO.OrderVerietyID = orderVeriety.Veriety.ToString();
                orderDPO.CurrencyID = currency.CurrencyShort.ToString();

                ordersDPO.Add(orderDPO);

                Order order = new Order();
                order = order.CopyFromOrderDPO(orderDPO);
                vmOrder.ListOrder.Add(order);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewOrder windowNewOrder = new WindowNewOrder
            {
                Title = "Редактирование поручения",
                Owner = this
            };

            OrderDPO orderDPO = (OrderDPO)ListOrder.SelectedValue;
            OrderDPO tempOrderDPO;

            if (orderDPO != null)
            {
                tempOrderDPO = new OrderDPO
                {
                    Id = orderDPO.Id,
                    OrderVerietyID = orderDPO.OrderVerietyID,
                    OrderTypeID = orderDPO.OrderTypeID,
                    CurrencyID = orderDPO.CurrencyID,
                    Tiker = orderDPO.Tiker,
                    Count = orderDPO.Count,
                    Type = orderDPO.Type,
                    Number = orderDPO.Number,
                    Data = orderDPO.Data,
                    Duration = orderDPO.Duration
                };
                windowNewOrder.DataContext = tempOrderDPO;

                windowNewOrder.cb_orderType.ItemsSource = OrTs;
                windowNewOrder.cb_orderType.Text = tempOrderDPO.OrderTypeID;

                windowNewOrder.cb_orderVeriety.ItemsSource = Orvs;
                windowNewOrder.cb_orderVeriety.Text = tempOrderDPO.OrderVerietyID;

                windowNewOrder.cb_Currency.ItemsSource = curs;
                windowNewOrder.cb_Currency.Text = tempOrderDPO.CurrencyID;

                if (windowNewOrder.ShowDialog() == true)
                {
                    OrderType orderType = (OrderType)windowNewOrder.cb_orderType.SelectedValue;
                    OrderVeriety orderVeriety = (OrderVeriety)windowNewOrder.cb_orderVeriety.SelectedValue;
                    Currency currency = (Currency)windowNewOrder.cb_Currency.SelectedValue;

                    orderDPO.OrderVerietyID = orderVeriety.Veriety.ToString();
                    orderDPO.OrderTypeID = orderType.Type;
                    orderDPO.CurrencyID = currency.CurrencyShort;
                    orderDPO.Tiker = tempOrderDPO.Tiker;
                    orderDPO.Count = tempOrderDPO.Count;
                    orderDPO.Type = tempOrderDPO.Type;
                    orderDPO.Number = tempOrderDPO.Number;
                    orderDPO.Data = tempOrderDPO.Data;
                    orderDPO.Duration = tempOrderDPO.Duration;

                    FindOrder finder = new FindOrder(orderDPO.Id);
                    List<Order> listOrder = vmOrder.ListOrder.ToList();
                    Order order = listOrder.Find(new Predicate<Order>(finder.OrderPredicate));
                    order = order.CopyFromOrderDPO(orderDPO);

                    ListOrder.ItemsSource = null;
                    ListOrder.ItemsSource = ordersDPO;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать поручение для редактирования",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            OrderDPO order = (OrderDPO)ListOrder.SelectedItem;

            if (order != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по поручению: \n"
                    + order.Tiker, "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK)
                {
                    ordersDPO.Remove(order);
                    Order orderTemp = new Order();
                    orderTemp = orderTemp.CopyFromOrderDPO(order);
                    vmOrder.ListOrder.Remove(orderTemp);
                }
                else MessageBox.Show("Необходимо выбрать поручение для удаления", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
    }
}
