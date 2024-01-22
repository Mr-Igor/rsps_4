using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1_E.Model;

namespace lab1_E.ViewModel
{
    class OrderViewModel
    {
        public ObservableCollection<Order> ListOrder { get; set; } = new ObservableCollection<Order>();

        public OrderViewModel()
        {
            this.ListOrder.Add(new Order(1, 1, 1, 1, "OneTicker", 1, "Покупка", 1, new DateTime(2023, 02, 05), new DateTime(2023, 12, 05)));
            this.ListOrder.Add(new Order(2, 2, 2, 1, "TwoTicker", 2, "Продажа", 2, new DateTime(2023, 05, 05), new DateTime(2023, 12, 15)));
            this.ListOrder.Add(new Order(3, 1, 2, 2, "ThreTicker", 3, "Покупка", 3, new DateTime(2023, 07, 05), new DateTime(2023, 12, 17)));
        }

        public int MaxId()
        {
            int max = 0;
            foreach (var order in this.ListOrder)
            {
                if (max < order.Id) max = order.Id;
            }
            return max;
        }
    }
}
