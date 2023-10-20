using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTradeRaptor
{
    public class Stock
    {
        public string Symbol { get; set; }
        
        public double AskPrice { get; set; }
        public double BidPrice { get; set; }
        public int AskSize { get; set; }
        public double TargetAskPrice { get; set; }
        public int TargetAskSize { get; set; }
        public double VWAP { get; set; }

        public double High { get; set; }
        public double Low { get; set; }
        
        public decimal TotalSharesSoldAtCurrentAskPrice { get; set; }
        public decimal TotalSharesSoldAtCurrentBidPrice { get; set; }
        public int NumberOfSalesAtCurrentAskPrice { get; set; }
        public int NumberOfSalesAtCurrentBidPrice { get; set; }
        public double SalePrice { get; set; }
        public double LastAskPrice { get; set; }
        public double LastBidPrice { get; set; }
        public double PreviousAskPrice { get; set; }
        public DateTime TimeAddedToWatchlist { get; set; }
        
        public DateTime TimeBought { get; set; }
        public string LongPositionKey { get; set; }
        public string ShortPositionKey { get; set; }
        

        public bool IsStreaming  { get; set; }
        public bool BelongsInTradeList { get; set; }
        public bool IsBought { get; set; }

        public Stock()
        {
            IsStreaming = false;
            BelongsInTradeList = false;
            IsBought = false;

            AskPrice = 0;
            AskSize = 0;
            TargetAskPrice = 0;
            TargetAskSize = 0;
            TotalSharesSoldAtCurrentAskPrice = 0;
            TotalSharesSoldAtCurrentBidPrice = 0;
            NumberOfSalesAtCurrentAskPrice = 0;
            NumberOfSalesAtCurrentBidPrice = 0;
            SalePrice = 0;
        }
    }
}
