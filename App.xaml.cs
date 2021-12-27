using System.Windows;
using AccountingTestWPF.Internal;
using AccountingTestWPF.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace AccountingTestWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MenuModule>();
        }

        protected override void OnInitialized()
        {
            var login = Container.Resolve<LoginView>();
            var result = login.ShowDialog();

            if (result.Value)
            {
                base.OnInitialized();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}
