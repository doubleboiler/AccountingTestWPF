using AccountingTestWPF.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace AccountingTestWPF.Internal
{
    internal class MenuModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginView>();
            containerRegistry.RegisterForNavigation<UsersView>();
            containerRegistry.RegisterForNavigation<OperationsView>();
            containerRegistry.RegisterForNavigation<DictionaryView>();
        }
    }
}
