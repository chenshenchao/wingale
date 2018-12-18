using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using Wingale.Views.Widgets;

namespace Wingale.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        private Tray tray;
        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            tray = new Tray();
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
            Visibility = Visibility.Hidden;
            e.Cancel = tray.Able;
        }
    }
}