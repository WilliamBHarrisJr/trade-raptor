using NewTradeRaptor.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace NewTradeRaptor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Thread.CurrentThread.Name = "Main Thread";

            RaptorEvents.OnUpdateConnectionStatusLabel += UpdateConnectionStatusLabel;
            RaptorEvents.OnUpdateTRStatusLabel += UpdateTRStatusLabel;
            RaptorEvents.OnDataGridRefresh += RefreshAccount;
            RaptorEvents.OnDataGridRefresh += UpdateProfitLabel;
            RaptorEvents.OnDataGridRefresh += RefreshWatchList;
            RaptorEvents.OnStartDataThread += StartDataThread;
            RaptorEvents.OnStartWatcherThread += StartWatcherThread;
            RaptorEvents.OnClockUpdate += UpdateClockLabel;
            RaptorEvents.OnNullifyClockLabel += NullifyClockLabel;
            RaptorEvents.OnNullifyWatchlist += NullifyWatchlist;
            RaptorEvents.OnEnableStartButton += EnableStartButton;
            RaptorEvents.OnDisableStartButton += DisableStartButton;
            RaptorEvents.OnDisableStopButton += DisableStopButton;
            
            
            RaptorEvents.OnUpdateDgOrders += UpdateDgOrders;
            RaptorEvents.OnUpdateDgPositions += UpdateDgPositions;
            
            RaptorEvents.OnAddToTradeLog += AddToDgTradeLog;
            RaptorEvents.OnClearTradeLog += ClearTradeLog;
            RaptorEvents.OnShowMaxLossLabel += ShowMaxLossLabel;
            RaptorEvents.OnHideMaxLossLabel += HideMaxLossLabel;
            RaptorEvents.OnDisableSettingsMenu += DisableSettingsMenu;
            RaptorEvents.OnEnableSettingsMenu += EnableSettingsMenu;
            RaptorEvents.OnStopRunning += StopRunning;
            RaptorEvents.OnPowerStatusLabelUpdate += UpdatePowerStatusLabel;
            RaptorEvents.OnShowTradingDayEndedLabel += ShowTradingDayEndedLabel;
            RaptorEvents.OnHideTradingDayEndedLabel += HideTradingDayEndedLabel;
            RaptorEvents.OnShowPowerFailureLabel += ShowPowerFailureLabel;
            RaptorEvents.OnHidePowerFailureLabel += HidePowerFailureLabel;
            RaptorEvents.OnClearDataGrids += ClearDataGrids;
            RaptorEvents.OnUpdateWatchListDG += UpdateWatchListDG;
            RaptorEvents.OnStartRunning += StartRunning;
            RaptorEvents.OnShowWaitingLabel += ShowWaitingLabel;
            RaptorEvents.OnHideWaitingLabel += HideWaitingLabel;

            
            RaptorEvents.TriggerUpdateTRStatusLabel();

            account = new Account();
            account.AccountNum = Settings.Default.AccountNum;
            dgAccount.Items.Add(account);
            programIsAlive = true;
            StartClock();

            RaptorEvents.TriggerStartDataThread();

            StartStatusCheckerThread();
            //StartScannerThread();
            
        }

        //******************************************
        //declare variables and dictionaries
        //*********************************************

        public static bool IsRunning;

        public static bool IsWaiting;

        public static bool programIsAlive;

        public static Account account;

        public static IDictionary<string, Stock> WatchListDictionary = new Dictionary<string, Stock>();

        public static IDictionary<string, Order> OrderDictionary = new Dictionary<string, Order>();

        public static IDictionary<string, Position> PositionDictionary = new Dictionary<string, Position>();

        public static IDictionary<string, TradeLog> TradeLogDictionary = new Dictionary<string, TradeLog>();

        public static List<Stock> WatchList = new List<Stock>();

        public static string clockTime;


        //********************************************
        //On Program Close Event
        //********************************************

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            programIsAlive = false;
            
            if (IsRunning)
            {
                CancelOrdersAndClearOrderDictionary();
                ClearPositionDictionary();
                DisableStopButton();
                Thread.Sleep(100);
                StopAllMarketData();
                NullifyWatchlist();
                RefreshWatchList();
                MessageBox.Show("Trade Raptor was stopped");
            }
            Data.DisconnectFromServer();
        }


        //***********************************
        //*Thread Start Methods*
        //************************************

        public void StartDataThread()
        {
            Thread dataThread = new Thread(Data.ConnectToServer);
            dataThread.Name = "dataThread";

            if (!dataThread.IsAlive)
            {
                dataThread.Start();
            }
        }


        public void StartWatcherThread()
        {
            Thread watcherThread = new Thread(Watcher.Watch);
            watcherThread.Name = "watcherThread";

            if (!watcherThread.IsAlive)
            {
                watcherThread.Start();
            }
        }


        public void StartTradeLogicThread()
        {
            Thread tradeLogicThread = new Thread(TradeLogic.RunTradeLogic);
            tradeLogicThread.Name = "tradeLogicThread";

            if (!tradeLogicThread.IsAlive)
            {
                tradeLogicThread.Start();
            }
        }


        public void StartSalesCalcThread()
        {
            Thread salesCalcThread = new Thread(SalesCalc.AddSalesAtBidAskPrice);
            salesCalcThread.Name = "tradeLogicThread";

            if (!salesCalcThread.IsAlive)
            {
                salesCalcThread.Start();
            }
        }


        public void StartStatusCheckerThread()
        {
            Thread statusCheckerThread = new Thread(StatusChecker.RunStatusChecker);
            statusCheckerThread.Name = "statusCheckerThread";

            if (!statusCheckerThread.IsAlive)
            {
                statusCheckerThread.Start();
            }
        }


        public void StartScannerThread()
        {
            Thread scannerThread = new Thread(Scanner.Scan);
            scannerThread.Name = "scannerThread";

            if (!scannerThread.IsAlive)
            {
                scannerThread.Start();
            }
        }





        //********************************************
        //*Methods for updating UI Labels*
        //**********************************************

        void UpdateConnectionStatusLabel()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                if (Data.clientConnected)
                {
                    tbConnectionStatus.Text = "Connected";
                    tbConnectionStatus.FontWeight = FontWeights.Bold;
                    tbConnectionStatus.Foreground = Brushes.ForestGreen;
                }

                if (!Data.clientConnected)
                {
                    tbConnectionStatus.Text = "Not Connected";
                    tbConnectionStatus.Foreground = Brushes.Red;
                    tbConnectionStatus.FontWeight = FontWeights.DemiBold;
                }
            }, null);
        }


        void UpdateTRStatusLabel()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                if (IsRunning)
                {
                    tbTRStatus.Text = "Running...";
                    tbTRStatus.FontWeight = FontWeights.Bold;
                    tbTRStatus.Foreground = Brushes.Blue;
                }

                else if (IsWaiting)
                {
                    tbTRStatus.Text = "Waiting";
                    tbTRStatus.FontWeight = FontWeights.Bold;
                    tbTRStatus.Foreground = Brushes.Blue;
                }

                else if (!IsRunning && StatusChecker.IsRunningOnMain && Data.clientConnected)
                {
                    tbTRStatus.Text = "Ready";
                    tbTRStatus.FontWeight = FontWeights.Bold;
                    tbTRStatus.Foreground = Brushes.ForestGreen;
                }

                else if (!IsRunning && (!Data.clientConnected || StatusChecker.IsRunningOnBattery))
                {
                    tbTRStatus.Text = "Not Ready";
                    tbTRStatus.FontWeight = FontWeights.DemiBold;
                    tbTRStatus.Foreground = Brushes.Red;
                }
            }, null);
        }


        public void ShowMaxLossLabel()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                lblMaxLoss.Opacity = 100;
            }, null);
        }


        public void HideMaxLossLabel()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                lblMaxLoss.Opacity = 0;
            }, null);
        }

        public static void UpdateMaxLossLabel()
        {
            if (StatusChecker.IsMaxLossReached())
            {
                RaptorEvents.TriggerShowMaxLossLabel();
            }

            else if (!StatusChecker.IsMaxLossReached())
            {
                RaptorEvents.TriggerHideMaxLossLabel();
            }
        }


        public void ShowTradingDayEndedLabel()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                lblTradingDayEnded.Content = string.Format("Trading Ended At {0}", Settings.Default.StopTime);
                lblTradingDayEnded.Opacity = 100;
                lblTradingDayEnded.Foreground = Brushes.SlateGray;
            }, null);
        }


        public void HideTradingDayEndedLabel()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                lblTradingDayEnded.Opacity = 0;
            }, null);
        }

        public void ShowWaitingLabel()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                lblTradingDayEnded.Content = string.Format("   Waiting Until {0}", Settings.Default.StartTime);
                lblTradingDayEnded.Opacity = 100;
                lblTradingDayEnded.Foreground = Brushes.Blue;
            }, null);
        }


        public void HideWaitingLabel()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                lblTradingDayEnded.Opacity = 0;
            }, null);
        }

        public static void UpdateTradingDayEndedLabel()
        {
            if (StatusChecker.IsTooLate())
            {
                RaptorEvents.TriggerShowTradingDayEndedLabel();
            }

            else if (StatusChecker.IsTooEarly() && IsWaiting)
            {
                RaptorEvents.TriggerShowWaitingLabel();
            }

            else if (!StatusChecker.IsTooLate() && !IsWaiting)
            {
                RaptorEvents.TriggerHideTradingDayEndedLabel();
            }
        }


        void UpdateProfitLabel()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                tbProfit.Text = string.Format("${0}", Math.Round(account.PL, 2));

                if (account.PL < 0)
                {
                    tbProfit.Foreground = Brushes.Red;
                }
                else
                {
                    tbProfit.Foreground = Brushes.ForestGreen;
                }
            }, null);
        }


        void UpdateClockLabel()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                tbClock.Text = clockTime;
            }, null);
        }


        void UpdatePowerStatusLabel()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                if (StatusChecker.IsRunningOnMain)
                {
                    tbPowerStatus.Text = StatusChecker.CheckPower();
                    tbPowerStatus.Foreground = Brushes.ForestGreen;
                    tbPowerStatus.FontWeight = FontWeights.Bold;
                }
                else if (StatusChecker.IsRunningOnBattery)
                {
                    tbPowerStatus.Text = StatusChecker.CheckPower();
                    tbPowerStatus.Foreground = Brushes.Red;
                    tbPowerStatus.FontWeight = FontWeights.DemiBold;
                }
            }, null);
        }


        void NullifyClockLabel()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                tbClock.Text = "";
            }, null);
        }


        public void ShowPowerFailureLabel()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                lblPowerFailed.Opacity = 100;
            }, null);
        }


        public void HidePowerFailureLabel()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                lblPowerFailed.Opacity = 0;
            }, null);
        }


        public static void UpdatePowerFailedLabel()
        {
            if (StatusChecker.IsRunningOnMain)
            {
                RaptorEvents.TriggerHidePowerFailureLabel();
            }

            else if (!StatusChecker.IsRunningOnBattery)
            {
                RaptorEvents.TriggerShowPowerFailureLabel();
            }
        }


        //***************************************************************
        //*Methods for updating UI DataGrids*
        //***************************************************************

        void RefreshAccount()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                dgAccount.Items.Refresh();
            }, null);
        }



        void UpdateWatchListDG()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                dgWatchList.Items.Clear();

                foreach (Stock stock in WatchListDictionary.Values.ToList())
                {
                    dgWatchList.Items.Add(stock);
                }

                int itemCount = WatchListDictionary.Values.ToList().Count;
                lblWatchListCount.Content = itemCount.ToString() + " Items";
            }, null);
        }


        void RefreshWatchList()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                dgWatchList.Items.Refresh();
                
            }, null);
        }


        public void AddToDgTradeLog(TradeLog tradelog)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                dgTradeLog.Items.Add(tradelog);
            }, null);
        }


        public void UpdateDgOrders()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                dgOrders.Items.Clear();

                foreach (Order o in OrderDictionary.Values.ToList())
                {
                    dgOrders.Items.Add(o);
                }

            }, null);
        }


        public void UpdateDgPositions()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                dgPositions.Items.Clear();

                foreach (Position p in PositionDictionary.Values.ToList())
                {
                    dgPositions.Items.Add(p);
                }

                dgPositions.Items.Refresh();

            }, null);
        }


        public void ClearDataGrids()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                dgPositions.Items.Clear();
                dgOrders.Items.Clear();
                dgTradeLog.Items.Clear();
            }, null);
        }


        

        //**************************************
        //*Enable and Disable Buttons*
        //***************************************

        void EnableStartButton()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                btnStart.IsEnabled = true;
                btnStart.FontWeight = FontWeights.Bold;
                menuBtnStart.IsEnabled = true;

            }, null);
        }


        void DisableStartButton()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                btnStart.IsEnabled = false;
                btnStart.FontWeight = FontWeights.Regular;
                menuBtnStart.IsEnabled = false;

            }, null);
        }


        void EnableStopButton()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                btnStop.IsEnabled = true;
                btnStop.FontWeight = FontWeights.Bold;
                menuBtnStop.IsEnabled = true;
                tbAddSymbol.Focus();
            }, null);
        }


        void DisableStopButton()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                btnStop.IsEnabled = false;
                btnStop.FontWeight = FontWeights.Regular;
                menuBtnStop.IsEnabled = false;
            }, null);
        }


        void EnableSettingsMenu()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                menuBtnSettings.IsEnabled = true;
            }, null);
        }

        void DisableSettingsMenu()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                menuBtnSettings.IsEnabled = false;
            }, null);
        }



        //***************************************************************
        //*Button click events*
        //***************************************************************

        private void menuBtnStart_Click(object sender, RoutedEventArgs e)
        {
            StartRunning();
        }

        private void menuBtnStop_Click(object sender, RoutedEventArgs e)
        {
            StopRunning();
            EnableSettingsMenu();
        }


        private void menuBtnClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }


        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            StartRunning();
        }


        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            StopRunning();
            EnableSettingsMenu();
        }


        private void TRSettings_Click(object sender, RoutedEventArgs e)
        {
            TradeSettingsWindow tradeSettingsWindow = new TradeSettingsWindow();
            tradeSettingsWindow.Topmost = true;
            tradeSettingsWindow.ShowDialog();
        }


        private void DasSettings_Click(object sender, RoutedEventArgs e)
        {
            DasSettingsWindow dasSettingsWindow = new DasSettingsWindow();
            dasSettingsWindow.Topmost = true;
            dasSettingsWindow.ShowDialog();
        }


        private void TISessings_Click(object sender, RoutedEventArgs e)
        {
            TISettingsWindow tiSettingsWindow = new TISettingsWindow();
            tiSettingsWindow.Topmost = true;
            tiSettingsWindow.ShowDialog();
        }


        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Topmost = true;
            aboutWindow.ShowDialog();
        }


        //Determinse whether symbol entered in the TextBox should be added or removed

        private void tbAddSymbol_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                AddToWatchlist();
            }
            else if (e.Key == System.Windows.Input.Key.Delete)
            {
                RemoveFromWatchList();
            }
        }




        //**************************************************
        //Market Data Methods
        //************************************************
        

        //Request market data for each symbol in watchlist dictionary

        public static void RequestAllMarketData()
        {
            if (Data.clientConnected && IsRunning)
            {
                foreach (Stock s in WatchListDictionary.Values.ToList())
                {
                    if (!s.IsStreaming)
                    {
                        Data.SendMessage(string.Format("SB {0} Lv1", s.Symbol));
                        
                        s.IsStreaming = true;
                    }
                }
            }
        }

        
        //Request market data for individual symbol

        public static void RequestMarketData(string s)
        {
            if (Data.clientConnected && IsRunning && WatchListDictionary.ContainsKey(s))
            {
                Stock stock = WatchListDictionary[s];

                if (!stock.IsStreaming)
                {
                    Data.SendMessage(string.Format("SB {0} Lv1", s));
                    
                    stock.IsStreaming = true;
                }
            }
        }


        //Stops market data for each symbol in watchlist dictionary

        public static void StopAllMarketData()
        {
            if (Data.clientConnected)
            {
                foreach (Stock s in WatchListDictionary.Values.ToList())
                {
                    if (s.IsStreaming)
                    {
                        Data.SendMessage(string.Format("UNSB {0} Lv1", s.Symbol));
                        
                        s.IsStreaming = false;
                    }
                }
            }
        }


        //Stops market data for individual symbol

        public static void StopMarketData(Stock s)
        {
            if (Data.clientConnected && s.IsStreaming)
            {
                Data.SendMessage(string.Format("UNSB {0} Lv1", s.Symbol));
                
                s.IsStreaming = false;
            }
        }


        //**************************************************
        //Start Stop Methods
        //**************************************************


        //Starts running the program

        public void StartRunning()
        {
            if (StatusChecker.IsRunningOnMain && !StatusChecker.IsTooLate() && account.PL > Settings.Default.MaxLoss)
            {
                if (!StatusChecker.IsTooEarly())
                {
                    IsRunning = true;
                    RequestAllMarketData();
                    StartWatcherThread();
                    StartTradeLogicThread();
                    //StartSalesCalcThread();
                    RequestAllMarketData();
                    //StartScannerThread();
                }

                else if (StatusChecker.IsTooEarly())
                {
                    IsWaiting = true;
                    RaptorEvents.TriggerShowWaitingLabel();
                    
                }
                
                DisableStartButton();
                EnableStopButton();
                UpdateTRStatusLabel();
                DisableSettingsMenu();
            }

            UpdateMaxLossLabel();
            UpdateTradingDayEndedLabel();
            UpdatePowerFailedLabel();
        }


        //Stops running the program

        public void StopRunning()
        {
            IsRunning = false;

            IsWaiting = false;

            CancelOrdersAndClearOrderDictionary();
            ClearPositionDictionary();
            DisableStopButton();
            Thread.Sleep(100);
            StopAllMarketData();
            
            UpdateTRStatusLabel();
            EnableSettingsMenu();
            NullifyWatchlist();
            TradeLogic.NullifyTriggers();
            RefreshWatchList();
            UpdateTradingDayEndedLabel();

            if (StatusChecker.isReady)
            {
                EnableStartButton();
            }
        }


        

        //*************************************************
        //*Watchlist Dictionary Methods*
        //****************************************************

        //Adds symbols to the WathList Dictionary and adds it to DGWatchList

        void AddToWatchlist()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                bool isAllChar = tbAddSymbol.Text.All(Char.IsLetter);
                bool whiteSpace = string.IsNullOrWhiteSpace(tbAddSymbol.Text);
                string input = tbAddSymbol.Text;
                bool clearAllInput = input.Equals("clear all");

                if (isAllChar == true && whiteSpace == false && clearAllInput == false && WatchListDictionary.Count < Settings.Default.MaxSymbols)
                {
                    string name = tbAddSymbol.Text.ToString().ToUpper();
                    
                    if (!WatchListDictionary.ContainsKey(name))
                    {
                        string longPositionKey = string.Format("{0}2", name);
                        string shortPositionKey = string.Format("{0}3", name);

                        WatchListDictionary[name] = new Stock { Symbol = name, LongPositionKey = longPositionKey, ShortPositionKey = shortPositionKey, TimeAddedToWatchlist = DateTime.Now };

                        RequestMarketData(name);

                        dgWatchList.Items.Clear();

                        foreach (Stock stock in WatchListDictionary.Values.ToList())
                        {
                            dgWatchList.Items.Add(stock);
                        }
                    }

                    if (WatchListDictionary.ContainsKey(name))
                    {
                        Stock s = WatchListDictionary[name];
                        s.TargetAskPrice = 0;
                        s.TimeAddedToWatchlist = DateTime.Now;
                        WatchListDictionary[name] = s;
                    }
                }

                else if (clearAllInput == true)
                {
                    StopAllMarketData();
                    NullifyWatchlist();

                    WatchListDictionary.Clear();

                    dgWatchList.Items.Clear();

                    foreach (Stock stock in WatchListDictionary.Values.ToList())
                    {
                        dgWatchList.Items.Add(stock);
                    }
                }

                tbAddSymbol.Clear();
                int itemCount = WatchListDictionary.Values.ToList().Count;
                lblWatchListCount.Content = itemCount.ToString() + " Items";

            }, null);
        }




        //Removes Symbol from watchlist dictionary and removes it from dgWatchlist

        void RemoveFromWatchList()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                bool isAllChar = tbAddSymbol.Text.All(Char.IsLetter);
                bool whiteSpace = string.IsNullOrWhiteSpace(tbAddSymbol.Text);

                if (isAllChar == true && whiteSpace == false)
                {
                    string name = tbAddSymbol.Text.ToString().ToUpper();

                    if (WatchListDictionary.ContainsKey(name))
                    {
                        Stock s = WatchListDictionary[name];
                        StopMarketData(s);
                        WatchListDictionary.Remove(name);
                    }


                    dgWatchList.Items.Clear();
                    

                    foreach (Stock stock in WatchListDictionary.Values.ToList())
                    {
                        dgWatchList.Items.Add(stock);
                    }

                }

                tbAddSymbol.Clear();
                int itemCount = WatchListDictionary.ToList().Count;
                lblWatchListCount.Content = itemCount.ToString() + " Items";

            }, null);
        }


        //Finds symbol in watchlist dictionary and updates it with the provided information

        public static void FindInWatchList(string symbol, double AskPrice, int AskSize, double BidPrice, double VWAP)
        {
            if (WatchListDictionary.ContainsKey(symbol))
            {
                Stock s = WatchListDictionary[symbol];
                s.AskPrice = AskPrice;
                s.AskSize = AskSize;
                s.BidPrice = BidPrice;
                s.VWAP = VWAP;
                
                if(s.High == 0)
                {
                    s.High = AskPrice;
                }

                WatchListDictionary[symbol] = s;
            }
        }


        //Sets data values to 0 for each symbol in watchlist dictionary

        public static void NullifyWatchlist()
        {
            foreach (Stock s in WatchListDictionary.Values.ToList())
            {
                s.IsStreaming = false;
                s.AskPrice = 0;
                s.AskSize = 0;
                s.SalePrice = 0;
                s.TotalSharesSoldAtCurrentAskPrice = 0;
                s.TargetAskPrice = 0;
                s.TargetAskSize = 0;
                s.BelongsInTradeList = false;
                s.BidPrice = 0;
                s.LastAskPrice = 0;
                s.LastBidPrice = 0;
                s.TotalSharesSoldAtCurrentBidPrice = 0;
                s.PreviousAskPrice = 0;
            }
        }



        


        //************************************************
        //Position Dictionary Methods
        //************************************************

        //Creates position in position dictionary

        public static void CreatePosition(string symbol, int shares, double avgPrice, double realized, string type)
        {
            string key = string.Format("{0}{1}", symbol, type);

            if (!PositionDictionary.ContainsKey(key))
            {
                PositionDictionary[key] = new Position { Symbol = symbol, Shares = shares, AvgPrice = avgPrice, Realized = realized, PositionType = type };
            }

            if (PositionDictionary.ContainsKey(key))
            {
                UpdatePosition(symbol, shares, avgPrice, realized, type);
            }

            account.PL = 0;
            foreach(Position p in PositionDictionary.Values.ToList())
            {
                account.PL = account.PL + p.Realized;
            }

            RaptorEvents.TriggerUpdateDgPositions();
            RaptorEvents.TriggerDataGridRefresh();
        }


        //Bails out of any active positions and clears position dictionary

        public static void ClearPositionDictionary()
        {
            if (PositionDictionary.Values.ToList().Count > 0)
            {
                foreach (Position p in PositionDictionary.Values.ToList())
                {
                    if (p.Shares > 0 && WatchListDictionary.ContainsKey(p.Symbol) && p.PositionType == "2")
                    {
                        Stock s = WatchListDictionary[p.Symbol];
                        TradeLogic.SellAllOnBid( p, s);
                    }
                }
                PositionDictionary.Clear();
                Data.SendMessage("POSREFRESH");
                RaptorEvents.TriggerUpdateDgPositions();
            }
        }


        //Updates position in position dictionary

        public static void UpdatePosition(string symbol, int shares, double avgPrice, double realized, string type)
        {
            string key = string.Format("{0}{1}", symbol, type);

            if (PositionDictionary.ContainsKey(key))
            {
                Position p = PositionDictionary[key];
                p.Shares = shares;
                p.AvgPrice = avgPrice;
                p.Realized = realized;
                p.PositionType = type;
                PositionDictionary[key] = p;
            }

            RaptorEvents.TriggerUpdateDgPositions();
        }


        //Clears position dictionary

        public static void ClearPositions()
        {
            PositionDictionary.Clear();

            RaptorEvents.TriggerUpdateDgPositions();
        }


        //**********************************************
        //Order Dictionary Methods
        //**********************************************

        //Creates order in order dictionary

        public static void ProcessOrder(string symbol, int shares, double price, string side, string id, string status)
        {
            if(shares == 0 || status == "Closed" || status == "Canceled" || status == "Rejected" )
            {
                foreach(Order o in OrderDictionary.Values.ToList())
                {
                    if(o.Id == id)
                    {
                        OrderDictionary.Remove(symbol);
                    }
                }
            }

            else if((status == "Sending" && shares != 0) || (status == "Accepted" && shares != 0))
            {
                OrderDictionary[symbol] = new Order { Symbol = symbol, Shares = shares, Price = price, Side = side, Id = id };
            }

            else if(status == "Executed")
            {
                foreach(Order o in OrderDictionary.Values.ToList())
                {
                    if(o.Id == id)
                    {
                        o.Shares = shares;
                    }
                }
            }
            

            RaptorEvents.TriggerUpdateDgOrders();
        }


        //Removes order from order dictionary

        public static void RemoveOrder(string symbol)
        {
            if (OrderDictionary.ContainsKey(symbol))
            {
                OrderDictionary.Remove(symbol);
            }

            RaptorEvents.TriggerUpdateDgOrders();
        }


        //Cancels any active orders and Clears order dictionary

        public static void CancelOrdersAndClearOrderDictionary()
        {
            if (OrderDictionary.Values.ToList().Count > 0)
            {
                foreach (Order o in OrderDictionary.Values.ToList())
                {
                    if (WatchListDictionary.ContainsKey(o.Symbol))
                    {
                        Stock s = WatchListDictionary[o.Symbol];
                        TradeLogic.CancelOrder();
                    }
                }
                RaptorEvents.TriggerUpdateDgOrders();
            }
        }


        

        //*************************************************
        //Trade log Dictionary Methods
        //*************************************************


        //Creates entry in trade log

        public static void CreateTradeLog(string symbol, string side, string time, int shares, double price, string id)
        {
            if (!TradeLogDictionary.ContainsKey(id))
            {
                TradeLogDictionary[id] = new TradeLog { Symbol = symbol, Shares = shares, Price = price, Side = side, Time = time };
                TradeLog tradelog = TradeLogDictionary[id];
                RaptorEvents.TriggerAddToTradeLog(tradelog);
            }
        }


        //Clears trade log dictionary

        public void ClearTradeLog()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                TradeLogDictionary.Clear();
                dgTradeLog.Items.Clear();
            }, null);
        }

        private void StartClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += tickEvent;
            timer.Start();
        }


        private void tickEvent(object sender, EventArgs e)
        {
            clockTime = DateTime.Now.ToString("T");
            RaptorEvents.TriggerDataGridRefresh();
            RaptorEvents.TriggerClockUpdate();
            
        }

        private void tbAddSymbol_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartScannerThread();
            btnTI.IsEnabled = false;
        }
    }
}
