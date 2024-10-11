using R3;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TwoMinutesStarter.Models;

namespace TwoMinutesStarter.ViewModels
{
    public class MainWindowViewModel : BindableBase, IDisposable
    {
        public BindableReactiveProperty<string> WorkName { get; }
        public ReactiveCommand StartCommand { get; }

        public MainWindowViewModel()
        {
            WorkName = new BindableReactiveProperty<string>("");

            StartCommand = WorkName
                .Select(name => !string.IsNullOrWhiteSpace(name))
                .ToReactiveCommand(_ =>
                {
                    // 画面遷移
                    Debug.WriteLine("xxx");
                }, initialCanExecute: false);
        }

        public void Dispose()
        {
            Disposable.Dispose(WorkName, StartCommand);
        }
    }
}
