using lab1_E.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_E.Helper
{
    class FindOrderType
    {
        int id;
        public FindOrderType(int id)
        {
            this.id = id;
        }
        public bool OrderTypePredicate(OrderType ort)
        {
            return ort.Id == id;
        }
    }
}
