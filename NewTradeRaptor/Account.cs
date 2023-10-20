using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTradeRaptor
{
    public class Account
    {
        public string AccountNum { get; set; }
        public string AccountType { get; set; }
        public double Equity { get; set; }
        public double PL { get; set; }
        public double BP { get; set; }
        public double Commissions { get; set; }
        public double ECN { get; set; }
    }
}
