using System;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Wingale.Widget
{
    using Application = System.Windows.Forms.Application;

    /// <summary>
    /// 
    /// </summary>
    public class Tray : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler Closed;

        private NotifyIcon notifyIcon;
        private MenuItem visibilityItem;
        private Visibility visibility;

        public bool Able { get; private set; }
        public Visibility Visibility
        {
            get { return visibility; }
            set
            {
                visibilityItem.Text = Visibility.ToString();
                visibility = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Visibility"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Tray()
        {
            ContextMenu contextMenu = new ContextMenu();
            visibilityItem = new MenuItem("Hidden");
            visibilityItem.Click += (o, e) =>
            {
                if (Visibility.Visible == Visibility)
                {
                    Visibility = Visibility.Hidden;
                }
                else
                {
                    Visibility = Visibility.Visible;
                }
            };
            MenuItem closeItem = new MenuItem("Close");
            closeItem.Click += (o, e) =>
            {
                Able = false;
                Closed(o, e);
            };
            contextMenu.MenuItems.Add(visibilityItem);
            contextMenu.MenuItems.Add(closeItem);

            Able = true;
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            notifyIcon.Visible = true;
            notifyIcon.ContextMenu = contextMenu;
        }
    }
}
