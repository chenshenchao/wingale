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
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace Wingale.Views
{
    /// <summary>
    /// TaskView.xaml 的交互逻辑
    /// </summary>
    public partial class TaskView : UserControl
    {
        public TaskView()
        {
            InitializeComponent();
            table.ItemsSource = new ObservableCollection<Process>( Process.GetProcesses());
        }

        private void OnSearch(object sender, RoutedEventArgs e)
        {
            List<Process> result = new List<Process>();
            Regex pattern = new Regex(keyword.Text);
            foreach (Process process in Process.GetProcesses())
            {
                Match match = pattern.Match(process.ProcessName);
                if (match.Success) result.Add(process);
            }
            table.ItemsSource = new ObservableCollection<Process>(result);
        }

        private void OnUpdate(object sender, RoutedEventArgs e)
        {
            table.ItemsSource = new ObservableCollection<Process>(Process.GetProcesses());
        }

        private void OnSort(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Process> processes = table.ItemsSource as ObservableCollection<Process>;
            GridViewColumnHeader header = e.OriginalSource as GridViewColumnHeader;
            switch (header.Content) {
                case "PID":
                    table.ItemsSource = new ObservableCollection<Process>(processes.OrderBy(i => i.Id));
                    break;
                case "Name":
                    table.ItemsSource = new ObservableCollection<Process>(processes.OrderBy(i => i.ProcessName));
                    break;
            }
        }

        private void OnSelect(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
