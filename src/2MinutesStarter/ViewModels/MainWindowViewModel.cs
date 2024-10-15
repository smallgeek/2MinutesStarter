using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TwoMinutesStarter.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        
        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.regionManager.RegisterViewWithRegion("ContentRegion", typeof(Views.StartView));
        }
    }
}
