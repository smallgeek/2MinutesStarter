using R3;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoMinutesStarter.Models;
using TwoMinutesStarter.Views;

namespace TwoMinutesStarter.ViewModels
{
    /// <summary>
    /// 作業中画面の ViewModel
    /// </summary>
    public class WorkingViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;
        private readonly WorkTimer timer;

        /// <summary>
        /// 作業名
        /// </summary>
        public ReactiveProperty<string> WorkName { get; }

        /// <summary>
        /// 残り時間
        /// </summary>
        public ReactiveProperty<TimeSpan> TimeLeft { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="timer">作業タイマー</param>
        public WorkingViewModel(IRegionManager regionManager, WorkTimer timer)
        {
            this.regionManager = regionManager;
            this.timer = timer;

            TimeLeft = this.timer
                .ObservePropertyChanged(t => t.TimeLeft)
                .ToBindableReactiveProperty();

            // ステータスが継続確認になったときに遷移
            this.timer.ObservePropertyChanged(t => t.Status)
                .Where(s => s == TimerStatus.ContinueConfirm)
                .Subscribe(_ =>
                {
                    this.regionManager.RequestNavigate("ContentRegion", nameof(ContinueConfirmView));
                });

            WorkName = new ReactiveProperty<string>();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;
        
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
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
