using R3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoMinutesStarter.Models;

namespace TwoMinutesStarter.ViewModels
{
    /// <summary>
    /// 作業中画面の ViewModel
    /// </summary>
    public class WorkingViewModel : BindableBase, INavigationAware
    {
        private readonly WorkTimer timer;

        /// <summary>
        /// 作業名
        /// </summary>
        public ReactiveProperty<string> WorkName { get; }

        /// <summary>
        /// 経過時間
        /// </summary>
        public ReactiveProperty<TimeSpan> ElapsedTime { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="timer">作業タイマー</param>
        public WorkingViewModel(WorkTimer timer)
        {
            this.timer = timer;

            ElapsedTime = timer
                .ObservePropertyChanged(t => t.ElapsedTime)
                .ToBindableReactiveProperty();

            WorkName = new ReactiveProperty<string>();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;
        
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            timer.Stop();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 遷移元の作業名を設定
            var workName = (string?)navigationContext.Parameters[nameof(WorkName)];
            if (workName != null)
            {
                WorkName.Value = workName;
            }

            timer.Start();
        }
    }
}
