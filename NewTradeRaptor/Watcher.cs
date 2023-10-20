using NewTradeRaptor.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewTradeRaptor
{
    internal class Watcher
    {
        public static void Watch()
        {
            while (MainWindow.IsRunning)
            {
                try
                {
                    foreach (Stock stock in MainWindow.WatchListDictionary.Values.ToList())
                    {
                         if(stock.AskPrice > stock.High)
                        {
                            stock.High = stock.AskPrice;
                        }

                         else if(stock.Low == 0 && stock.AskPrice <= stock.High - Settings.Default.LowTrigger)
                        {
                            stock.Low = stock.AskPrice;
                            stock.TargetAskPrice = stock.Low + Settings.Default.BuyTrigger;
                        }

                         else if(stock.AskPrice < stock.Low)
                        {
                            stock.Low = stock.AskPrice;
                            stock.TargetAskPrice = stock.Low + Settings.Default.BuyTrigger;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Debug.WriteLine(ex);
                }
            }
        }

    }
}
