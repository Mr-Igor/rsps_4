using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1_E.Model;

namespace lab1_E.Helper
{
    class FindOrder
    {
        int id;
        public FindOrder(int id)
        {
            this.id = id;
        }

        public bool OrderPredicate(Order order)
        {
            return order.Id == id;
        }
    }
}
