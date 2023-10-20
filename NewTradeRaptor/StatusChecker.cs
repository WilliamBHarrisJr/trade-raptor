using Microsoft.Win32;
using NewTradeRaptor.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace NewTradeRaptor
{
    internal class StatusChecker
    {
        public static void RunStatusChecker()
        {
            MainWindow.programIsAlive = true;
            bool isOnBatteryPower = IsRunningOnBattery;
            isReady = false;
            bool isConnected = false;
            RaptorEvents.TriggerPowerStatusLabelUpdate();
            

            while (MainWindow.programIsAlive)
            {
                if (IsRunningOnBattery && !isOnBatteryPower && !MainWindow.IsRunning)
                {
                    isOnBatteryPower = true;
                    RaptorEvents.TriggerPowerStatusLabelUpdate();
                }

                
                if(IsRunningOnMain && isOnBatteryPower)
                {
                    isOnBatteryPower = false;
                    RaptorEvents.TriggerPowerStatusLabelUpdate();
                }


                if(!isConnected && Data.clientConnected)
                {
                    isConnected = true;
                    RaptorEvents.TriggerUpdateStatusConnectionLabel();
                }


                if(isConnected && !Data.clientConnected)
                {
                    isConnected = false;
                    RaptorEvents.TriggerUpdateStatusConnectionLabel();
                }


                if(IsRunningOnMain && Data.clientConnected && !isReady)
                {
                    isReady = true;
                    RaptorEvents.TriggerUpdateTRStatusLabel();
                   
                    if (!MainWindow.IsRunning)
                    {
                        RaptorEvents.TriggerEnableStartButton();
                    }
                }


                if ((IsRunningOnBattery || !Data.clientConnected) && isReady)
                {
                    isReady = false;
                    RaptorEvents.TriggerUpdateTRStatusLabel();
                    RaptorEvents.TriggerDisableStartButton();
                }


                if (IsTooLate() && MainWindow.IsRunning)
                {
                    foreach(Stock s in MainWindow.WatchListDictionary.Values.ToList())
                    {
                        if (!TradeLogic.IsOpenLongPosition(s))
                        {
                            TradeLogic.RemoveFromWatchList(s);
                        }
                    }
                    if (!IsOpenPositions() && MainWindow.OrderDictionary.Count == 0)
                    {
                        RaptorEvents.TriggerShowTradingDayEndedLabel();
                        RaptorEvents.TriggerStopRunning();
                        Thread.Sleep(200);
                    };
                }

                
                if(IsMaxLossReached() && MainWindow.IsRunning)
                {
                    RaptorEvents.TriggerShowMaxLossLabel();
                    RaptorEvents.TriggerStopRunning();
                    Thread.Sleep(200);
                }


                if (IsRunningOnBattery && MainWindow.IsRunning)
                {
                    isOnBatteryPower = true;
                    RaptorEvents.TriggerPowerStatusLabelUpdate();

                    if (MainWindow.PositionDictionary.Count == 0 && MainWindow.OrderDictionary.Count == 0)
                    {
                        MainWindow.UpdatePowerFailedLabel();
                        RaptorEvents.TriggerStopRunning();
                        Thread.Sleep(200);
                    }
                }

                if (MainWindow.IsWaiting && !IsTooEarly())
                {
                    RaptorEvents.TriggerStartRunning();
                    MainWindow.IsWaiting = false;
                    MainWindow.UpdateTradingDayEndedLabel();
                }

                Thread.Sleep(100);
            }
        }
        public static bool isReady;
        
        public static string CheckPower()
        {
            string message = "Not available";

            if (IsRunningOnBattery)   
            {
                 message = "Battery";
            }

            if (IsRunningOnMain)
            {
                message = "Main";
            }

            return message;
        }

        
        public static Boolean IsRunningOnBattery
        {
            get
            {
                System.Windows.Forms.PowerLineStatus pls = System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus;

                return (pls == System.Windows.Forms.PowerLineStatus.Offline);
            }
        }

        
        public static Boolean IsRunningOnMain
        {
            get
            {
                System.Windows.Forms.PowerLineStatus pls = System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus;

                return (pls == System.Windows.Forms.PowerLineStatus.Online);
            }
        }

        
        public static float Capacity
        {
            get
            {
                float chargeStatus = System.Windows.Forms.SystemInformation.PowerStatus.BatteryLifePercent;

                return chargeStatus;
            }
        }


        public static bool IsTooEarly()
        {
            DateTime currentTime;
            DateTime startTime;
            
            DateTime.TryParse(MainWindow.clockTime, out currentTime);
            DateTime.TryParse(Settings.Default.StartTime, out startTime);

            return currentTime <= startTime;
        }

        public static bool IsTooLate()
        {
            DateTime currentTime;
            DateTime stopTime;

            DateTime.TryParse(MainWindow.clockTime, out currentTime);
            DateTime.TryParse(Settings.Default.StopTime, out stopTime);

            return currentTime >= stopTime;
        }

        public static bool IsMaxLossReached()
        {
            return MainWindow.account.PL <= Settings.Default.MaxLoss;
        }

        public static bool IsOpenPositions()
        {
            bool result = false;

            if (MainWindow.PositionDictionary.Count > 0)
            {
                foreach(Position p in MainWindow.PositionDictionary.Values.ToList())
                {
                    if (p.Shares > 0)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

    }
}
