using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_E.Model
{
    class Currency
    {
        public int Id { get; set; }
        public string CurrencyFull { get; set; }
        public string CurrencyShort { get; set; }


        public Currency() { }

        public Currency(int Id, string CurrencyFull, string CurrencyShort)
        {
            this.Id = Id;
            this.CurrencyFull = CurrencyFull;
            this.CurrencyShort = CurrencyShort;
        }

        public Currency ShallowCopy()
        {
            return (Currency)this.MemberwiseClone();
        }
    }
}
