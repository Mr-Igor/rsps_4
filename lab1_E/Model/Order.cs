using lab1_E.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_E.Model
{
    class Order
    {
        public int Id { get; set; }
        public int OrderVerietyID { get; set; }
        public int OrderTypeID { get; set; }
        public int CurrencyID { get; set; }
        public string Tiker { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public DateTime Data { get; set; }
        public DateTime Duration { get; set; }

        public Order() { }

        public Order(int Id, int OrderVerietyID, int OrderTypeID, int CurrencyID, string Tiker, int Count, string Type, int Number, DateTime Data, DateTime Duration)
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

        public Order CopyFromOrderDPO(OrderDPO orderDPO)
        {
            OrderTypeViewModel vmType = new OrderTypeViewModel();
            int typeId = 0;

            OrderVerietyViewModel vmVeriety = new OrderVerietyViewModel();
            int verietyId = 0;

            CurrencyViewModel vmCurrency = new CurrencyViewModel();
            int currencyId = 0;

            foreach (var type in vmType.ListOrderType)
            {
                if (type.Type.ToString() == orderDPO.OrderTypeID)
                {
                    typeId = type.Id;
                    break;
                }
            }

            foreach (var veriety in vmVeriety.ListOrderVeriety)
            {
                if (veriety.Veriety == orderDPO.OrderVerietyID)
                {
                    verietyId = veriety.Id;
                    break;
                }
            }

            foreach (var currency in vmCurrency.ListCurrency)
            {
                if (currency.CurrencyShort == orderDPO.CurrencyID)
                {
                    currencyId = currency.Id;
                    break;
                }
            }

            if (typeId != 0)
            {
                this.Id = orderDPO.Id;
                this.OrderVerietyID = verietyId;
                this.OrderTypeID = typeId;
                this.CurrencyID = currencyId;
                this.Tiker = orderDPO.Tiker;
                this.Count = orderDPO.Count;
                this.Type = orderDPO.Type;
                this.Number = orderDPO.Number;
                this.Data = orderDPO.Data;
                this.Duration = orderDPO.Duration;
            }
            return this;
        }
    }
}
