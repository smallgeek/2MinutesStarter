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
    /// <summary>
    /// 開始画面の ViewModel
    /// </summary>
    public class StartViewModel : BindableBase, INavigationAware, IDisposable
    {
        /// <summary>
        /// 作業名
        /// </summary>
        public BindableReactiveProperty<string> WorkName { get; }

        /// <summary>
        /// 開始ボタンのコマンド
        /// </summary>
        public ReactiveCommand StartCommand { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public StartViewModel()
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

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void Dispose()
        {
            Disposable.Dispose(WorkName, StartCommand);
        }
    }
}
