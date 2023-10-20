using NewTradeRaptor.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace NewTradeRaptor
{
    internal class TradeLogic
    {

        public static void RunTradeLogic()
        {
            while (MainWindow.IsRunning)
            {
                try
                {
                    if(MainWindow.WatchListDictionary.Count > 0)
                    {

                        foreach (Stock s in MainWindow.WatchListDictionary.Values.ToList())
                        {
                            if (CheckShareSize(s) &&
                                !MainWindow.OrderDictionary.ContainsKey(s.Symbol) &&
                                !IsOpenLongPosition(s) && !s.IsBought &&
                                 s.AskPrice >= s.TargetAskPrice && s.TargetAskPrice != 0)
                            {
                                Buy(s);
                                Thread.Sleep(400);
                            }


                            while (s.IsBought)
                            {
                                CancelBuyOrderConditions(s);

                                if (!Settings.Default.IsSellHalf && s.IsBought)
                                {
                                    if (Settings.Default.IsSellAtProfitTarget)
                                    {
                                        if (IsOpenLongPosition(s) && s.IsBought)
                                        {
                                            Position p = MainWindow.PositionDictionary[s.LongPositionKey];

                                            if (p.Shares > 0 && s.AskPrice >= p.AvgPrice + Settings.Default.ProfitTargetA && !IsOpenOrder(s) && DateTime.Now < DateTime.Parse(Settings.Default.BreakEvenTime))
                                            {
                                                SellAllOnAsk(p, s);
                                                Thread.Sleep(800);
                                                NullifyTriggers();
                                                IsBoughtConditions(s);

                                                //CancelSellOrderAndBailConditions(s, p);
                                            }

                                            else if (p.Shares > 0 && s.AskPrice >= p.AvgPrice && !IsOpenOrder(s) && DateTime.Now >= DateTime.Parse(Settings.Default.BreakEvenTime))
                                            {
                                                SellAllOnAsk(p, s);
                                                Thread.Sleep(800);
                                                NullifyTriggers();
                                                IsBoughtConditions(s);
                                            }

                                            else if (p.Shares > 0 && !IsOpenOrder(s) && DateTime.Now >= DateTime.Parse(Settings.Default.BailTime))
                                            {
                                                SellAllOnBid(p, s);
                                                Thread.Sleep(800);
                                                NullifyTriggers();
                                                IsBoughtConditions(s);
                                            }

                                            else if (Settings.Default.IsBailChecked && p.Shares > 0 && s.AskPrice < p.AvgPrice - Settings.Default.BailTrigger)
                                            {
                                                if (IsOpenOrder(s))
                                                {
                                                    CancelOrder();
                                                }
                                                
                                                SellAllOnBid(p, s);
                                                Thread.Sleep(800);
                                                NullifyTriggers();
                                                IsBoughtConditions(s);
                                            }

                                            //BailConditions(s, p);
                                        }
                                    }

                                    else if (!Settings.Default.IsSellAtProfitTarget)
                                    {
                                        if (MainWindow.PositionDictionary.ContainsKey(s.LongPositionKey))
                                        {
                                            Position p = MainWindow.PositionDictionary[s.LongPositionKey];

                                            BailConditions(s, p);
                                        }
                                    }

                                    IsBoughtConditions(s);
                                }

                                else if (Settings.Default.IsSellHalf)
                                {
                                    if (IsOpenLongPosition(s) && s.IsBought)
                                    {
                                        Position p = MainWindow.PositionDictionary[s.LongPositionKey];

                                        if (p.Shares > 0 && s.AskPrice >= p.AvgPrice + Settings.Default.ProfitTargetA)
                                        {
                                            SellHalfOnAsk(p, s);
                                            Thread.Sleep(1000);

                                            while (s.IsBought)
                                            {
                                                //CancelSellOrderAndBailConditions(s, p);

                                                if (IsOpenLongPosition(s))
                                                {
                                                    p = MainWindow.PositionDictionary[s.LongPositionKey];

                                                    if (!Settings.Default.IsSellRestAtProfitTarget)
                                                    {
                                                        BailConditions(s, p);
                                                    }

                                                    else if (Settings.Default.IsSellRestAtProfitTarget)
                                                    {
                                                        if (s.IsBought && p.Shares > 0 && s.AskPrice >= p.AvgPrice + Settings.Default.ProfitTargetB)
                                                        {
                                                            SellAllOnAsk(p, s);
                                                            NullifyTriggers();
                                                            Thread.Sleep(800);
                                                            IsBoughtConditions(s);

                                                            //CancelSellOrderAndBailConditions(s, p);
                                                        }

                                                        BailConditions(s, p);
                                                    }
                                                }
                                                IsOpenShortPosition(s);
                                            }
                                        }

                                        //ReversalConditions(s, p);
                                    }

                                    IsBoughtConditions(s);
                                }

                            }

                            IsOpenShortPosition(s);
                            //RemoveFromWatchListConditions(s);
                        }
                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        static void BailConditions(Stock s, Position p)
        { 
            if (s.IsBought && Settings.Default.IsBailChecked && s.AskPrice < p.AvgPrice - Settings.Default.BailTrigger && !IsOpenOrder(s))
            {
                p = MainWindow.PositionDictionary[s.LongPositionKey];
                SellAllOnBid(p, s);
                Thread.Sleep(800);
                IsBoughtConditions(s);
            }
        }


        static void CancelBuyOrderConditions(Stock s)
        {
            while (MainWindow.OrderDictionary.ContainsKey(s.Symbol) && s.IsBought)
            {
                Order o = MainWindow.OrderDictionary[s.Symbol];

                if (o.Side == "B" && o.Price != s.AskPrice)
                {
                    CancelOrder();
                    Thread.Sleep(600);
                    IsBoughtConditions(s);
                }
            }
        }


        static void CancelSellOrderAndBailConditions(Stock s, Position p)
        {
            if (MainWindow.OrderDictionary.ContainsKey(s.Symbol) &&
                IsOpenLongPosition(s))
            {
                Order o = MainWindow.OrderDictionary[s.Symbol];
                p = MainWindow.PositionDictionary[s.LongPositionKey];

                if (o.Price > s.AskPrice && o.Side == "S")
                {
                    CancelOrder();
                    SellAllOnBid(p, s);
                    Thread.Sleep(400);
                    IsBoughtConditions(s);
                }
            }
        }


        static void RemoveFromWatchListConditions(Stock s)
        {
            if(!s.IsBought && s.AskPrice > s.TargetAskPrice + .03 &&
                !MainWindow.OrderDictionary.ContainsKey(s.Symbol) &&
                !IsOpenLongPosition(s) && s.TargetAskPrice != 0)
            {
                RemoveFromWatchList(s);
                RaptorEvents.TriggerUpdateWatchListDG();
            }
        }

        
        static void IsBoughtConditions(Stock s)
        {
            if (!MainWindow.OrderDictionary.ContainsKey(s.Symbol) &&
                !IsOpenLongPosition(s))
            {
                s.IsBought = false;
            }

            else if(MainWindow.OrderDictionary.ContainsKey(s.Symbol) &&
                IsOpenLongPosition(s))
            {
                s.IsBought = true;
            }
        }


        public static bool IsOpenLongPosition(Stock s)
        {
            bool result = false;

            if (MainWindow.PositionDictionary.ContainsKey(s.LongPositionKey))
            {
                Position p = MainWindow.PositionDictionary[s.LongPositionKey];
                
                if (p.Shares > 0 && p.PositionType != "3")
                {
                    result = true;
                }
            }

            return result;
        }


        static void IsOpenShortPosition(Stock s)
        {
            if (MainWindow.PositionDictionary.ContainsKey(s.ShortPositionKey))
            {
                Position p = MainWindow.PositionDictionary[s.ShortPositionKey];

                if (p.Shares > 0 && p.PositionType == "3")
                {
                    string message = string.Format("NEWORDER 1 B {0} SMAT {1} {2} TIF=DAY+", s.Symbol, p.Shares, s.AskPrice);
                    Data.SendMessage(message);
                    Thread.Sleep(800);
                }
            }
        }


        static bool IsOpenOrder(Stock s)
        {
            bool result = false;

            if (MainWindow.OrderDictionary.ContainsKey(s.Symbol))
            {
                result = true;
            }

            return result;
        }

        public static void NullifyTriggers()
        {
            foreach(Stock s in MainWindow.WatchListDictionary.Values.ToList())
            {
                s.High = 0;
                s.Low = 0;
                s.TargetAskPrice = 0;
            }
        }


        public static void RemoveFromWatchList(Stock s)
        {
            Data.SendMessage(string.Format("UNSB {0} Lv1", s.Symbol));
            MainWindow.WatchListDictionary.Remove(s.Symbol);
            RaptorEvents.TriggerUpdateWatchListDG();
            
        }


        static bool CheckShareSize(Stock s)
        {
            int shareSize = GetShareSize(s);

            bool result = false;

            if(shareSize >= Settings.Default.MinShareSize)
            {
                result = true;
            }

            return result;
        }


        static int GetShareSize(Stock s)
        {
            int shareSize = (int)Math.Floor(MainWindow.account.BP / s.AskPrice);

            if (s.AskPrice < 2)
            {
                shareSize = (int)Math.Floor(MainWindow.account.Equity / s.AskPrice);
            }

            else if(s.AskPrice >= 2 && s.AskPrice < 5)
            {
                shareSize = (int)Math.Floor((MainWindow.account.Equity * 2) / s.AskPrice);
            }

            if (shareSize > Settings.Default.MaxShareSize)
            {
                shareSize = Settings.Default.MaxShareSize;
            }

            return shareSize;
        }

        
        static void Buy(Stock s)
        {
            string message = string.Format("NEWORDER 1 B {0} SMAT {1} {2} TIF=DAY+", s.Symbol, GetShareSize(s), s.AskPrice);
            Data.SendMessage(message);
            s.IsBought = true;
        }


        static void SellHalfOnAsk(Position p, Stock s)
        {
            string message = string.Format("NEWORDER 1 S {0} SMAT {1} {2} TIF=DAY+", p.Symbol, (int)Math.Floor(p.Shares * .5), s.AskPrice);
            Data.SendMessage(message);
        }


        static void SellAllOnAsk(Position p, Stock s)
        {
            string message = string.Format("NEWORDER 1 S {0} SMAT {1} {2} TIF=DAY+", p.Symbol, p.Shares, p.AvgPrice + Settings.Default.ProfitTargetA);
            Data.SendMessage(message);
            s.Low = 0;
            s.High = 0;
            s.TargetAskPrice = 0;
        }


        public static void SellAllOnBid(Position p, Stock s)
        {
            string message = string.Format("NEWORDER 1 S {0} SMAT {1} {2} TIF=DAY+", p.Symbol, p.Shares, s.BidPrice);
            Data.SendMessage(message);
            s.Low = 0;
            s.TargetAskPrice = 0;
            s.High = 0;
        }


        public static void CancelOrder()
        {
            string message = string.Format("CANCEL ALL");
            Data.SendMessage(message);
        }
    }
}
