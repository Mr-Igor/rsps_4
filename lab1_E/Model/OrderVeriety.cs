using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_E.Model
{
    class OrderVeriety
    {
        public int Id { get; set; }
        public string Veriety { get; set; }


        public OrderVeriety() { }

        public OrderVeriety(int Id, string Veriety)
        {
            this.Id = Id;
            this.Veriety = Veriety;
        }
    }
}
