using System.Configuration;
using System.Data;
using System.Windows;
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
        }
    }

}
