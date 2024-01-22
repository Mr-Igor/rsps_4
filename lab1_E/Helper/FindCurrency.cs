using lab1_E.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_E.Helper
{
    class FindCurrency
    {
        int id;
        public FindCurrency(int id)
        {
            this.id = id;
        }
        public bool CurrencyPredicate (Currency cur)
        {
            return cur.Id == id;
        }
    }
}
