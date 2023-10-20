using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTradeRaptor
{
    public class Position
    {
        public string Symbol { get; set; }
        public int Shares { get; set; }
        public double AvgPrice { get; set; }
        public double Realized { get; set; }
        public string PositionType { get; set; }
        public string Key { get; set; }
    }
}
