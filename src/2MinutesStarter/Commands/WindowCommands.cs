using R3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TwoMinutesStarter.Commands
{
    /// <summary>
    /// 画面に対する処理を行うコマンド群
    /// </summary>
    public class WindowCommands
    {
        /// <summary>
        /// 最小化
        /// </summary>
        public ReactiveCommand Minimize { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public WindowCommands()
        {
            Minimize = new ReactiveCommand(static _ =>
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            });
        }
    }
}
