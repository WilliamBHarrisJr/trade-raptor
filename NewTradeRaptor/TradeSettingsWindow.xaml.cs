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
    /// Interaction logic for TradeSettingsWindow.xaml
    /// </summary>
    public partial class TradeSettingsWindow : Window
    {
        public TradeSettingsWindow()
        {
            InitializeComponent();
            
            tbProfitTargetA.Text = Settings.Default.ProfitTargetA.ToString();
            tbProfitTargetB.Text = Settings.Default.ProfitTargetB.ToString();
            tbMaxShareSize.Text = Settings.Default.MaxShareSize.ToString();
            tbMinShareSize.Text = Settings.Default.MinShareSize.ToString();
            tbMaxLoss.Text = Settings.Default.MaxLoss.ToString();
            
            tbBuyTrigger.Text = Settings.Default.BuyTrigger.ToString();
            tbStopTime.Text = Settings.Default.StopTime.ToString();
            tbStartTime.Text = Settings.Default.StartTime.ToString();
            tbBailTrigger.Text = Settings.Default.BailTrigger.ToString();
            tbBreakEvenTime.Text = Settings.Default.BreakEvenTime.ToString();
            tbBailTime.Text = Settings.Default.BailTime.ToString();
            tbLowTrigger.Text = Settings.Default.LowTrigger.ToString();

            
            if (Settings.Default.IsSellHalf)
            {
                cbAllOrHalf.SelectedIndex = 1;
            }
            else if (!Settings.Default.IsSellHalf)
            {
                cbAllOrHalf.SelectedIndex = 0;
                tbProfitTargetB.IsEnabled = false;
            }

            if (Settings.Default.IsSellAtProfitTarget)
            {
                cbSellAt.SelectedIndex = 0;
            }
            else if (!Settings.Default.IsSellAtProfitTarget)
            {
                cbSellAt.SelectedIndex = 1;
            }

            if (Settings.Default.IsSellRestAtProfitTarget)
            {
                cbSellRestAt.SelectedIndex = 0;
            }
            else if (!Settings.Default.IsSellRestAtProfitTarget)
            {
                cbSellRestAt.SelectedIndex = 1;
                tbProfitTargetB.IsEnabled=false;
            }

            if (Settings.Default.IsBailChecked)
            {
                cbBail.IsChecked = true;
            }
            else if (!Settings.Default.IsBailChecked)
            {
                cbBail.IsChecked= false;
            }


            all = "All";
            half = "Half";
            profitTarget = "Profit Target";
            reversal = "Reversal";
            
            SellAllOrHalf = new string[] {all, half};

            PTReversal = new string[] {profitTarget, reversal};


            DataContext = this;
        }
        static string all;
        string half;
        string profitTarget;
        string reversal;
        
        public string[] SellAllOrHalf { get; set; } 
        public string[] PTReversal { get; set; }
        public List <string> accountNums { get; set; }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.ProfitTargetA = double.Parse(tbProfitTargetA.Text);
            Settings.Default.ProfitTargetB = double.Parse(tbProfitTargetB.Text);
            Settings.Default.MaxShareSize = int.Parse(tbMaxShareSize.Text);
            Settings.Default.MinShareSize = int.Parse(tbMinShareSize.Text);
            Settings.Default.MaxLoss = double.Parse(tbMaxLoss.Text);
            Settings.Default.BuyTrigger = double.Parse(tbBuyTrigger.Text);
            Settings.Default.StopTime = tbStopTime.Text;
            Settings.Default.StartTime = tbStartTime.Text;
            Settings.Default.BailTrigger = double.Parse(tbBailTrigger.Text);
            Settings.Default.LowTrigger = double.Parse(tbLowTrigger.Text);
            Settings.Default.BreakEvenTime = tbBreakEvenTime.Text;
            Settings.Default.BailTime = tbBailTime.Text;

            if (cbBail.IsChecked == true)
            {
                Settings.Default.IsBailChecked = true;
            }
            else if (cbBail.IsChecked == false)
            {
                Settings.Default.IsBailChecked = false;
            }
            
            Settings.Default.Save();

            Close();
        }


        private void cbAllOrHalf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbAllOrHalf.SelectedItem.Equals(all))
            {
                Settings.Default.IsSellHalf = false;
                cbSellRestAt.IsEnabled = false;
                cbSellRestAt.Foreground = Brushes.Gray;
                tbProfitTargetB.IsEnabled = false;
                lblSellRestAt.Foreground = Brushes.Gray;
                cbSellAt.IsEnabled = true;
            }

            if(cbAllOrHalf.SelectedItem.Equals(half))
            {
                Settings.Default.IsSellHalf = true;
                cbSellRestAt.IsEnabled = true;
                lblSellRestAt.Foreground = Brushes.Black;
                cbSellRestAt.Foreground = Brushes.Black;
                cbSellAt.SelectedIndex = 0;
                cbSellAt.IsEnabled = false;

                if (cbSellRestAt.SelectedIndex.Equals(0))
                {
                    tbProfitTargetB.IsEnabled = true;
                }
            }
        }

        private void cbSellRestAt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbSellRestAt.SelectedItem.Equals(profitTarget))
            {
                Settings.Default.IsSellRestAtProfitTarget = true;

                if (cbAllOrHalf.SelectedItem.Equals(half))
                {
                    tbProfitTargetB.IsEnabled = true;
                }
            }

            if (cbSellRestAt.SelectedItem.Equals(reversal))
            {
                Settings.Default.IsSellRestAtProfitTarget = false;
                
                if (cbAllOrHalf.SelectedItem.Equals(all))
                {
                    tbProfitTargetB.IsEnabled = false;
                }
            }
        }

        private void cbSellAt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbSellAt.SelectedItem.Equals(profitTarget))
            {
                Settings.Default.IsSellAtProfitTarget = true;
                tbProfitTargetA.IsEnabled = true;
            }

            if (cbSellAt.SelectedItem.Equals(reversal))
            {
                Settings.Default.IsSellAtProfitTarget = false;
                tbProfitTargetA.IsEnabled = false;
            }
        }
    }
}
