using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTradeRaptor
{
    internal class SalesCalc
    {
        public static string Symbol { get; set; }
        public static decimal SharesSold { get; set; }
        public static double SalePrice { get; set; }

        public static void AddSalesAtBidAskPrice()
        {
            while (MainWindow.IsRunning)
            {
                if (Symbol != null && SharesSold != 0 && SalePrice != 0 && MainWindow.WatchListDictionary.Values.ToList().Count > 0)
                {
                    foreach (Stock s in MainWindow.WatchListDictionary.Values.ToList())
                    {
                        if (s.AskPrice != s.LastAskPrice)
                        {
                            s.PreviousAskPrice = s.LastAskPrice;
                            s.LastAskPrice = s.AskPrice;
                            s.TotalSharesSoldAtCurrentAskPrice = 0;
                            s.NumberOfSalesAtCurrentAskPrice = 0;
                        }

                        if (s.Symbol == Symbol && s.AskPrice == SalePrice && s.BelongsInTradeList)
                        {
                            s.TotalSharesSoldAtCurrentAskPrice = s.TotalSharesSoldAtCurrentAskPrice + SharesSold;
                            s.NumberOfSalesAtCurrentAskPrice++;
                        }

                        if (s.BidPrice != s.LastBidPrice)
                        {
                            s.LastBidPrice = s.BidPrice;
                            s.TotalSharesSoldAtCurrentBidPrice = 0;
                            s.NumberOfSalesAtCurrentBidPrice = 0;
                        }

                        if (s.Symbol == Symbol && s.BidPrice == SalePrice && s.BelongsInTradeList)
                        {
                            s.TotalSharesSoldAtCurrentBidPrice = s.TotalSharesSoldAtCurrentBidPrice + SharesSold;
                            s.NumberOfSalesAtCurrentBidPrice++;
                        }
                    }

                    Symbol = null;
                    SharesSold = 0;
                    SalePrice = 0;
                }
            }
        }
    }
}
