using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace Wingale.View
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Tray tray = FindResource("tray") as Tray;
            SetBinding(VisibilityProperty, new Binding()
            {
                Source = tray,
                Path = new PropertyPath("Visibility"),
                Mode = BindingMode.TwoWay
            });
            tray.Closed += (o, e) => Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Tray tray = FindResource("tray") as Tray;
            Visibility = Visibility.Hidden;
            e.Cancel = tray.Able;
        }
    }
}