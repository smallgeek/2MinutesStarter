using R3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoMinutesStarter.Models;
using TwoMinutesStarter.Views;

namespace TwoMinutesStarter.ViewModels
{
    /// <summary>
    /// 継続確認画面の ViewModel
    /// </summary>
    public class ContinueConfirmViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;
        private readonly WorkTimer timer;

        /// <summary>
        /// 継続するボタンのコマンド
        /// </summary>
        public ReactiveCommand YesCommand { get; }

        /// <summary>
        /// 継続しないボタンのコマンド
        /// </summary>
        public ReactiveCommand NoCommand { get; }

        public ContinueConfirmViewModel(IRegionManager regionManager, WorkTimer timer)
        {
            this.regionManager = regionManager;
            this.timer = timer;

            YesCommand = new ReactiveCommand(_ =>
            {
                this.regionManager.RequestNavigate("ContentRegion", nameof(WorkingView));
            });
                    
            NoCommand = new ReactiveCommand(_ =>
            {
                this.timer.Initialize();

                this.regionManager.RequestNavigate("ContentRegion", nameof(StartView));
            });
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
    }
}
