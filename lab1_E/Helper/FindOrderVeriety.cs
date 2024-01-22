using lab1_E.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_E.Helper
{
    class FindOrderVeriety
    {
        int id;
        public FindOrderVeriety(int id)
        {
            this.id = id;
        }
        public bool OrderVerietyPredicate(OrderVeriety orv)
        {
            return orv.Id == id;
        }
    }
}
