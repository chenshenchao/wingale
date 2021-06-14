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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Timers;
using System.ComponentModel;

namespace Wingale.Views.Pages
{
    public class ProcessPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Process[] processes;

        public Process[] Processes
        {
            get { return processes; }
            set
            {
                processes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Processes"));
            }
        }
    }

    /// <summary>
    /// ProcessPage.xaml 的交互逻辑
    /// </summary>
    public partial class ProcessPage : Page
    {
        private Timer timer;
        public ProcessPageModel Model { get; private set; }
        public ProcessPage()
        {
            Model = new ProcessPageModel
            {
                Processes = Process.GetProcesses(),
            };
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += (o, e) =>
            {
                lock (Model)
                {
                    Model.Processes = Process.GetProcesses();
                }
            };
            InitializeComponent();
            DataContext = this;
        }

        private void onVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }
    }
}
