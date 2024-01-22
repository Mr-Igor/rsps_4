using lab1_E.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_E.ViewModel
{
    class OrderVerietyViewModel
    {
        public ObservableCollection<OrderVeriety> ListOrderVeriety { get; set; } = new ObservableCollection<OrderVeriety>();

        public OrderVerietyViewModel()
        {
            this.ListOrderVeriety.Add(new OrderVeriety(1, "Покупка"));
            this.ListOrderVeriety.Add(new OrderVeriety(2, "Продажа"));
        }
    }
}
