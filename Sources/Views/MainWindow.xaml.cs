using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using Wingale.Views.Widgets;

namespace Wingale.Views
{
    /// <summary>
    /// 主窗口。
    /// </summary>
    public partial class MainWindow : Window
    {
        private Tray tray;

        /// <summary>
        /// 构造子。
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
        /// 关闭事件回调。
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