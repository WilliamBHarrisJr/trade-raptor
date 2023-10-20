using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTradeRaptor
{
    internal class RaptorEvents
    {
        public delegate void RaptorEvent();
        public delegate void TradeLogEvent(TradeLog tl);
        public delegate void CountEvent(int count);

        public static event RaptorEvent OnUpdateConnectionStatusLabel;
        public static event RaptorEvent OnUpdateTRStatusLabel;
        public static event RaptorEvent OnDataGridRefresh;
        public static event RaptorEvent OnStartDataThread;
        public static event RaptorEvent OnClockUpdate;
        public static event RaptorEvent OnNullifyClockLabel;
        public static event RaptorEvent OnNullifyWatchlist;
        public static event RaptorEvent OnEnableStartButton;
        public static event RaptorEvent OnDisableStartButton;
        public static event RaptorEvent OnDisableStopButton;
        public static event RaptorEvent OnStartWatcherThread;
        
        
        public static event RaptorEvent OnBuyLabel;
        public static event RaptorEvent OnUpdateDgOrders;
        public static event RaptorEvent OnUpdateDgPositions;
        
        public static event TradeLogEvent OnAddToTradeLog;
        public static event RaptorEvent OnClearTradeLog;
        public static event RaptorEvent OnShowMaxLossLabel;
        public static event RaptorEvent OnHideMaxLossLabel;
        public static event RaptorEvent OnEnableSettingsMenu;
        public static event RaptorEvent OnDisableSettingsMenu;
        public static event RaptorEvent OnStopRunning;
        public static event RaptorEvent OnPowerStatusLabelUpdate;
        public static event RaptorEvent OnShowTradingDayEndedLabel;
        public static event RaptorEvent OnHideTradingDayEndedLabel;
        public static event RaptorEvent OnShowPowerFailureLabel;
        public static event RaptorEvent OnHidePowerFailureLabel;
        public static event RaptorEvent OnClearDataGrids;
        public static event RaptorEvent OnUpdateWatchListDG;
        public static event RaptorEvent OnStartRunning;
        public static event RaptorEvent OnShowWaitingLabel;
        public static event RaptorEvent OnHideWaitingLabel;

        public static void TriggerDataGridRefresh()
        {
            OnDataGridRefresh();
        }

        public static void TriggerUpdateStatusConnectionLabel()
        {
            OnUpdateConnectionStatusLabel();
        }
        public static void TriggerUpdateTRStatusLabel()
        {
            OnUpdateTRStatusLabel();
        }

        public static void TriggerStartDataThread()
        {
            OnStartDataThread();
        }

        public static void TriggerStartWatcherThread()
        {
            OnStartWatcherThread();
        }

        public static void TriggerClockUpdate()
        {
            OnClockUpdate();
        }

        public static void TriggerNullifyClock()
        {
            OnNullifyClockLabel();
        }

        public static void TriggerNullifyWatchlist()
        {
            OnNullifyWatchlist();
        }

        public static void TriggerEnableStartButton()
        {
            OnEnableStartButton();
        }

        public static void TriggerDisableStartButton()
        {
            OnDisableStartButton();
        }

        public static void TriggerDisableStopButton()
        {
            OnDisableStopButton();
        }


        public static void TriggerBuyLabel()
        {
            OnBuyLabel();
        }

        public static void TriggerUpdateDgOrders()
        {
            OnUpdateDgOrders();
        }

        public static void TriggerUpdateDgPositions()
        {
            OnUpdateDgPositions();
        }


        public static void TriggerAddToTradeLog(TradeLog tl)
        {
            OnAddToTradeLog(tl);
        }

        public static void TriggerClearTradeLog()
        {
            OnClearTradeLog();
        }

        public static void TriggerShowMaxLossLabel()
        {
            OnShowMaxLossLabel();
        }

        public static void TriggerHideMaxLossLabel()
        {
            OnHideMaxLossLabel();
        }

        public static void TriggerDisableMenuSettings()
        {
            OnDisableSettingsMenu();
        }

        public static void TriggerEnableMenuSettings()
        {
            OnEnableSettingsMenu();
        }

        public static void TriggerStopRunning()
        {
            OnStopRunning();
        }

        public static void TriggerPowerStatusLabelUpdate()
        {
            OnPowerStatusLabelUpdate();
        }

        public static void TriggerShowTradingDayEndedLabel()
        {
            OnShowTradingDayEndedLabel();
        }

        public static void TriggerHideTradingDayEndedLabel()
        {
            OnHideTradingDayEndedLabel();
        }


        public static void TriggerShowPowerFailureLabel()
        {
            OnShowPowerFailureLabel();
        }


        public static void TriggerHidePowerFailureLabel()
        {
            OnHidePowerFailureLabel();
        }


        public static void TriggerClearDataGrids()
        {
            OnClearDataGrids();
        }

        public static void TriggerUpdateWatchListDG()
        {
            OnUpdateWatchListDG();
        }

        public static void TriggerStartRunning()
        {
            OnStartRunning();
        }

        public static void TriggerShowWaitingLabel()
        {
            OnShowWaitingLabel();
        }

        public static void TriggerHideWaitingLabel()
        {
            OnHideWaitingLabel();
        }
    }
}
