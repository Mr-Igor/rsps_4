using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_E.Model
{
    class OrderType
    {
        public int Id { get; set; }
        public string Type { get; set; }


        public OrderType() { }

        public OrderType(int Id, string Type)
        {
            this.Id = Id;
            this.Type = Type;
        }
    }
}
