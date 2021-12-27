using AccountingTestWPF.Models;
using Prism.Mvvm;
using Prism.Regions;

namespace AccountingTestWPF.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware
    {
        private User _authUser;

        public User AuthUser
        {
            get => _authUser;
            set => SetProperty(ref _authUser, value);
        }

        public BaseViewModel()
        {

        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}
