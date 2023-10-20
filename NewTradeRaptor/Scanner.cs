using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NewTradeRaptor.Properties;
using System.Threading;

namespace NewTradeRaptor
{
    internal class Scanner
    {
        private static IWebDriver driver;
        public static IDictionary<string, ScannerSymbol> ScannerDictionary = new Dictionary<string, ScannerSymbol>();

        public static void Scan()
        {
            try
            {

                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("--window-position=-32000,-32000");

                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;

                driver = new ChromeDriver(service);
                driver.Navigate().GoToUrl(Settings.Default.TILoginURL);

                //Thread.Sleep(2000);

                var username = driver.FindElement(By.Id("x-auto-6-input"));
                var password = driver.FindElement(By.Id("x-auto-7-input"));

                username.SendKeys(Settings.Default.TIUsername);
                password.SendKeys(Settings.Default.TiPassword);

                while (MainWindow.programIsAlive)
                {
                    if (MainWindow.IsRunning)
                    {
                        Search();
                    }
                }

                driver.Quit();
            }
            catch(Exception ex)
            {

            }
        }

        public static void CloseChrome()
        {
            driver.Quit();
        }

        public static void Search()
        {
            try
            {
                //string className = "K15MBM-W-d.K15MBM-X-b.rowdatacellInner";

                var elements = driver.FindElements(By.XPath("//div[contains(@class,'K15MBM-W-d K15MBM-X-b rowdatacellInner')]"));

                IDictionary<string, ScannerSymbol> TempScannerDictionary = new Dictionary<string, ScannerSymbol>();

                foreach (var element in elements)
                {
                    if (element.Text.All(Char.IsUpper) && !element.Text.Any(Char.IsWhiteSpace))
                    {
                        if (!TempScannerDictionary.ContainsKey(element.Text))
                        {
                            TempScannerDictionary[element.Text] = new ScannerSymbol { Symbol = element.Text, Count = 1 };
                        }

                        else if (TempScannerDictionary.ContainsKey(element.Text))
                        {
                            ScannerSymbol ssTemp = TempScannerDictionary[element.Text];
                            ssTemp.Count++;
                            TempScannerDictionary[element.Text] = ssTemp;
                        }
                    }
                }

                foreach (ScannerSymbol ssTemp in TempScannerDictionary.Values.ToList())
                {
                    if (ScannerDictionary.ContainsKey(ssTemp.Symbol))
                    {
                        ScannerSymbol ss = ScannerDictionary[ssTemp.Symbol];
                        
                        if (ssTemp.Count > ss.Count)
                        {
                            if (!MainWindow.WatchListDictionary.ContainsKey(ssTemp.Symbol))
                            {
                                string longPositionKey = string.Format("{0}2", ssTemp.Symbol);
                                string shortPositionKey = string.Format("{0}3", ssTemp.Symbol);
                                MainWindow.WatchListDictionary[ssTemp.Symbol] = new Stock { Symbol = ssTemp.Symbol, TimeAddedToWatchlist = DateTime.Now, LongPositionKey = longPositionKey, ShortPositionKey = shortPositionKey };
                                MainWindow.RequestMarketData(ssTemp.Symbol);
                                RaptorEvents.TriggerUpdateWatchListDG();
                            }
                        }
                    }
                    else if (!ScannerDictionary.ContainsKey(ssTemp.Symbol))
                    {
                        if (!MainWindow.WatchListDictionary.ContainsKey(ssTemp.Symbol))
                        {
                            string longPositionKey = string.Format("{0}2", ssTemp.Symbol);
                            string shortPositionKey = string.Format("{0}3", ssTemp.Symbol);
                            MainWindow.WatchListDictionary[ssTemp.Symbol] = new Stock { Symbol = ssTemp.Symbol, TimeAddedToWatchlist = DateTime.Now, LongPositionKey = longPositionKey, ShortPositionKey = shortPositionKey };
                            MainWindow.RequestMarketData(ssTemp.Symbol);
                            RaptorEvents.TriggerUpdateWatchListDG();
                        }
                        
                    }
                }

                
                ScannerDictionary = TempScannerDictionary;

            }
            catch (Exception ex)
            {

            }
        }

        

    }
}
