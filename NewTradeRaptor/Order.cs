using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTradeRaptor
{
    public class Order
    {
        public string Side { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
        public int Shares { get; set; }
        public string Id { get; set; }  
    }
}
