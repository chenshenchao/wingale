using System;
using System.Windows;
using System.Windows.Controls;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Wingale.Utils;

namespace Wingale.Views.Pages
{
    public class PingInfo
    {
        public IPAddress IP { get; set; }
        public IPAddress ReplyIP { get; set; }
        public IPStatus Status { get; set; }
        public long Time { get; set; }
    }
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
            address.Text = next.ToString();
            Task task = new Task(() => {
                Ping ping = new Ping();
                PingReply reply = ping.Send(ip);
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    replyList.Items.Add(new PingInfo {
                        IP = ip,
                        Status = reply.Status,
                        ReplyIP = reply.Address,
                        Time = reply.RoundtripTime
                    });
                }));
            });
            task.Start();
        }
    }
}