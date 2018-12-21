using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace Wingale.Views.Pages
{
    public partial class TaskPage : Page
    {
        public TaskPage()
        {
            InitializeComponent();
            table.ItemsSource = new ObservableCollection<Process>(Process.GetProcesses());
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
            switch (header.Content)
            {
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