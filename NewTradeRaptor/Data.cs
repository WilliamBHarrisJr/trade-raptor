using NewTradeRaptor.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NewTradeRaptor
{
    public class Data 
    {
        static TcpClient client;
        static NetworkStream stream;
        static StreamReader reader;
        static StreamWriter writer;
        public static bool clientConnected = false;
        public static bool keepTryingToConnect;
        public static bool keepRunning;
        
        public static void ConnectToServer()
        {
            client = new TcpClient();
            keepTryingToConnect = true;
            keepRunning = true;

            while (keepTryingToConnect)
            {
                try
                {
                    client.Connect(IPAddress.Loopback, Settings.Default.PortNumber);
                    keepTryingToConnect = false;
                    clientConnected = true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }

            if (keepRunning)
            {
                try
                {
                    stream = client.GetStream();
                    reader = new StreamReader(stream);
                    writer = new StreamWriter(stream);
                    writer.AutoFlush = true;

                    ReadFromStream();

                    SendMessage(String.Format("LOGIN {0} {1} {2}", Settings.Default.DasUsername, Settings.Default.DasPassword, MainWindow.account.AccountNum));
                    SendMessage("GET BP");
                }
                catch(Exception ex)
                {
                    
                }
            }
        }

        public static async Task ReadFromStream()
        {
            while (clientConnected)
            {
                string message = await reader.ReadLineAsync();
                
                Debug.WriteLine(message);
                
                if(message == null)
                {
                    DisconnectFromServer();
                    
                    RaptorEvents.TriggerStartDataThread();
                    break;
                }
                
                else if(message != null)
                {
                    MessageProcess.ProcessMessage(message);
                }
            }
        }

        public static void SendMessage(string message)
        {
            writer.WriteLine(message);
            Debug.WriteLine(message);
        }

        public static void DisconnectFromServer()
        {
            keepTryingToConnect = false;
            keepRunning = false;
            clientConnected = false;
            RaptorEvents.TriggerStopRunning();
            MainWindow.IsRunning = false;
            
            NullifyAccount();
            
            RaptorEvents.TriggerNullifyWatchlist();
            
            RaptorEvents.TriggerNullifyClock();

            RaptorEvents.TriggerDataGridRefresh();

            RaptorEvents.TriggerClearTradeLog();

            RaptorEvents.TriggerEnableMenuSettings();

            try
            {
                client.Close();
                
            }
            catch(Exception ex)
            {
                
            }
            
        }

        public static void NullifyAccount()
        {
            MainWindow.account.AccountType = null;
            MainWindow.account.Equity = 0;
            MainWindow.account.BP = 0;
            MainWindow.account.Commissions = 0;
            MainWindow.account.ECN = 0;
            MainWindow.account.PL = 0;
        }
    }
}
