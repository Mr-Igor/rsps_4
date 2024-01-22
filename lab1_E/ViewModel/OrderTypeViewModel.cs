using lab1_E.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_E.ViewModel
{
    class OrderTypeViewModel
    {
        public ObservableCollection<OrderType> ListOrderType { get; set; } = new ObservableCollection<OrderType>();

        public OrderTypeViewModel()
        {
            this.ListOrderType.Add(new OrderType(1, "Диллерская"));
            this.ListOrderType.Add(new OrderType(2, "Брокерская"));
        }
    }
}
