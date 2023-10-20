using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTradeRaptor
{
    public class TradeLog
    {
        public string Symbol { get; set; }
        public string Side { get; set; }
        public string Time { get; set; }
        public int Shares { get; set; }
        public double Price { get; set; }
    }
}
