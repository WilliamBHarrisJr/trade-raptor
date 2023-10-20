using NewTradeRaptor.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NewTradeRaptor
{
    /// <summary>
    /// Interaction logic for DasSettingsWindow.xaml
    /// </summary>
    public partial class DasSettingsWindow : Window
    {
        public DasSettingsWindow()
        {
            InitializeComponent();
            tbPort.Text = Settings.Default.PortNumber.ToString();
            tbUserName.Text = Settings.Default.DasUsername;
            tbMaxSymbols.Text = Settings.Default.MaxSymbols.ToString();
            tbAccount.Text = MainWindow.account.AccountNum.ToString();
            pbPassword.Password = Settings.Default.DasPassword;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.PortNumber = int.Parse(tbPort.Text);
            Settings.Default.DasUsername = tbUserName.Text;
            Settings.Default.MaxSymbols = int.Parse(tbMaxSymbols.Text);
            Settings.Default.AccountNum = tbAccount.Text;
            Settings.Default.DasPassword = pbPassword.Password;
            Settings.Default.Save();
            
            if (Data.clientConnected)
            {
                Data.DisconnectFromServer();
            }
            
            MainWindow.account.AccountNum = Settings.Default.AccountNum;
            RaptorEvents.TriggerStartDataThread();
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
