using System;
using System.Windows;
using System.Windows.Controls;
using System.Net;
using Wingale.Utils;

namespace Wingale.Views.Pages
{
    public partial class PingPage : Page
    {
        public PingPage()
        {
            InitializeComponent();
        }

        private void OnClickScan(object sender, RoutedEventArgs e)
        {
            IPAddress ip = IPAddress.Parse(address.Text);
            IPAddress mask = IPAddress.Parse(netmask.Text);
            IPAddress next = ip.Next();
            long count = mask.Count();
            IPAddress net = ip.GetNet(mask);
            info.Text = string.Format("net:{0} count: {1}",net, count);
            address.Text = next.ToString();
        }
    }
}