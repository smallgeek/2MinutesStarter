using System.Configuration;
using System.Data;
using System.Windows;
using TwoMinutesStarter.Models;
using TwoMinutesStarter.Views;

namespace TwoMinutesStarter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var window = Container.Resolve<MainWindow>();
            return window;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<StartView>();
            containerRegistry.RegisterForNavigation<TryingView>();
            containerRegistry.RegisterForNavigation<ContinueConfirmView>();
            containerRegistry.RegisterForNavigation<WorkingView>();

            WorkTimer timer = new WorkTimer();
            containerRegistry.RegisterInstance(timer);
        }
    }

}
