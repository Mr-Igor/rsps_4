using lab1_E.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_E.Model
{
    class OrderDPO
    {
        public int Id { get; set; }
        public string OrderVerietyID { get; set; }
        public string OrderTypeID { get; set; }
        public string CurrencyID { get; set; }
        public string Tiker { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public DateTime Data { get; set; }
        public DateTime Duration { get; set; }

        public OrderDPO() { }

        public OrderDPO(int Id, string OrderVerietyID, string OrderTypeID, string CurrencyID, string Tiker, int Count, string Type, int Number, DateTime Data, DateTime Duration)
        {
            this.Id = Id;
            this.OrderVerietyID = OrderVerietyID;
            this.OrderTypeID = OrderTypeID;
            this.CurrencyID = CurrencyID;
            this.Tiker = Tiker;
            this.Count = Count;
            this.Type = Type;
            this.Number = Number;
            this.Data = Data;
            this.Duration = Duration;
        }

        public OrderDPO CopyFromOrder(Order order)
        {
            OrderDPO orderDPO = new OrderDPO();

            OrderTypeViewModel vmType = new OrderTypeViewModel();
            OrderVerietyViewModel vmVeriety = new OrderVerietyViewModel();
            CurrencyViewModel vmCurrency = new CurrencyViewModel();

            string type = string.Empty;
            foreach (var t in vmType.ListOrderType)
            {
                if (t.Id == order.OrderTypeID)
                {
                    type = t.Type.ToString();
                    break;
                }
            }

            string veriety = string.Empty;
            foreach (var v in vmVeriety.ListOrderVeriety)
            {
                if (v.Id == order.OrderVerietyID)
                {
                    veriety = v.Veriety.ToString();
                    break;
                }
            }

            string currency = string.Empty;
            foreach (var c in vmCurrency.ListCurrency)
            {
                if (c.Id == order.CurrencyID)
                {
                    currency = c.CurrencyShort.ToString();
                    break;
                }
            }

            if (type != string.Empty)
            {
                orderDPO.Id = order.Id;
                orderDPO.OrderVerietyID = type;
                orderDPO.OrderTypeID = veriety;
                orderDPO.CurrencyID = currency;
                orderDPO.Tiker = order.Tiker;
                orderDPO.Count = order.Count;
                orderDPO.Type = order.Type;
                orderDPO.Number = order.Number;
                orderDPO.Data = order.Data;
                orderDPO.Duration = order.Duration;
            }
            return orderDPO;
        }
    }
}
