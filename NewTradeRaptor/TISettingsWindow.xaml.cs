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
    /// Interaction logic for TISettingsWindow.xaml
    /// </summary>
    public partial class TISettingsWindow : Window
    {
        public TISettingsWindow()
        {
            InitializeComponent();
            tbURL.Text = Settings.Default.TILoginURL.ToString();
            tbUsername.Text = Settings.Default.TIUsername.ToString();
            pbTIPassword.Password = Settings.Default.TiPassword.ToString();
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.TILoginURL = tbURL.Text;
            Settings.Default.TIUsername = tbUsername.Text;
            Settings.Default.TiPassword = pbTIPassword.Password.ToString();
            
            Settings.Default.Save();
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
