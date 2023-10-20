using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewTradeRaptor
{
    internal class MessageProcess : MainWindow
    {
        public static void ProcessMessage(string message)
        {
            try
            {

                if (message.Substring(0,2) == "Redacted due to NDA")
                {
                    List<string> messageList = message.Split(' ').ToList();

                    MainWindow.account.BP = double.Parse(messageList[1]);
                    MainWindow.account.Equity = Math.Round((MainWindow.account.BP / 6), 2);

                    RaptorEvents.TriggerDataGridRefresh();
                    //Debug.WriteLine(message);
                }


                else if (message.Contains("Redacted due to NDA"))
                {
                    string symbol = "";

                    List<string> messageList = message.Split(' ').ToList();

                    symbol = messageList[1];

                    Stock stock = WatchListDictionary[symbol];

                    foreach (string s in messageList)
                    {
                        if (s.Contains("A:"))
                        {
                            stock.AskPrice = double.Parse(s.Remove(0,2));
                        }

                        else if (s.Contains("B:"))
                        {
                            stock.BidPrice = double.Parse(s.Remove(0,2));
                        }

                        else if (s.Contains("Asz:"))
                        {
                            stock.AskSize = int.Parse(s.Remove(0,4));
                        }

                        else if (s.Contains("VWAP:"))
                        {
                            stock.VWAP = double.Parse(s.Remove(0,5));
                        }
                    }

                    //Debug.WriteLine("DATA Recieved:{0} {1} {2} {3}", symbol, askPrice, askSize, bidPrice);
                    MainWindow.FindInWatchList(symbol, stock.AskPrice, stock.AskSize, stock.BidPrice, stock.VWAP);
                    //RaptorEvents.TriggerDataGridRefresh();
                    
                }

               
                else if (message.Contains("Redacted due to NDA"))
                {
                    string symbol = "@#";
                    decimal sharesSold = 0;
                    double salePrice = 0;
                    
                    List<string> messageList = message.Split(' ').ToList();

                    symbol = messageList[1];
                    salePrice = double.Parse(messageList[2]);
                    sharesSold = decimal.Parse(messageList[3]) / 100;

                    if (symbol != "@#")
                    {
                        SendDataToSalesCalc(symbol, sharesSold, salePrice);
                    }
                }

               
                else if (message.Contains("Redacted due to NDA"))
                {
                    string symbol = "@#";
                    int shares = 0;
                    double price = 0;
                    string side = "";
                    string id = "";
                    string status = "";

                    List<string> messageList = message.Split(' ').ToList();

                    id = messageList[1];
                    symbol = messageList[3];
                    side = messageList[4];
                    shares = int.Parse(messageList[7]);
                    price = double.Parse(messageList[9]);
                    status = messageList[11];

                    if (symbol != "@#")
                    {
                        MainWindow.ProcessOrder(symbol, shares, price, side, id, status);
                    }
                    //Debug.WriteLine(message);
                }

                
                else if (message.Contains("Redacted due to NDA"))
                {
                    string symbol = "@#";
                    int shares = 0;
                    double avgPrice = 0;
                    double realized = 0;
                    string type = "";

                    List<string> messageList = message.Split(' ').ToList();

                    symbol = messageList[1];
                    type = messageList[2];
                    shares = int.Parse(messageList[3]);
                    avgPrice = double.Parse(messageList[4]);
                    realized = double.Parse(messageList[7]);

                    if (symbol != "@#")
                    {
                        MainWindow.CreatePosition(symbol, shares, avgPrice, realized, type);
                    }
                    //Debug.WriteLine(message);
                }


                else if (message.Contains("Redacted due to NDA"))
                {
                    List<string> messageList = message.Split(' ').ToList();
                    
                    string symbol = "";
                    string side = "";
                    string time = "";
                    double price = 0;
                    int shares = 0;
                    string id = "";

                    id = messageList[1];
                    symbol = messageList[2];
                    side = messageList[3];
                    shares = int.Parse(messageList[4]);
                    price = double.Parse(messageList[5]);
                    time = messageList[7];

                    MainWindow.CreateTradeLog(symbol, side, time, shares, price, id);
                    //Debug.WriteLine(message);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        
        public static void SendDataToSalesCalc(string symbol, decimal sharesSold, double salePrice)
        {
            SalesCalc.Symbol = symbol;
            SalesCalc.SalePrice = salePrice;
            SalesCalc.SharesSold = sharesSold;
        }
    }
}
