using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace TwoMinutesStarter.Actions
{
    /// <summary>
    /// タスクトレイを操作するアクション
    /// </summary>
    public class TaskTrayAction : TriggerAction<Window>
    {
        private NotifyIcon notifyIcon;

        public TaskTrayAction()
        {
            notifyIcon = new NotifyIcon
            {
                Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location)
            };

            System.Windows.Application.Current.Exit += (_, __) => notifyIcon.Dispose();
        }

        protected override void Invoke(object parameter)
        {
            var window = AssociatedObject;

            switch (window.WindowState)
            {
                case WindowState.Minimized:
                    // タスクトレイに表示
                    window.ShowInTaskbar = false;
                    notifyIcon.Visible = true;
                    break;

                case WindowState.Maximized:
                case WindowState.Normal:
                    // タスクトレイがあれば非表示にする
                    notifyIcon.Visible = false;
                    break;
            }
        }
    }
}
