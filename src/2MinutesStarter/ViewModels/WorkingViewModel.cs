using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoMinutesStarter.Commands;

namespace TwoMinutesStarter.ViewModels
{
    /// <summary>
    /// 作業中画面の ViewModel
    /// </summary>
    /// <param name="windowCommands"></param>
    public class WorkingViewModel(WindowCommands windowCommands) : BindableBase, INavigationAware
    {
        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            windowCommands.Minimize.Execute(R3.Unit.Default);
        }
    }
}
