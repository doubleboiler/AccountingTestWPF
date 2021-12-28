using AccountingTestWPF.Internal;
using AccountingTestWPF.Models;
using AccountingTestWPF.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace AccountingTestWPF.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IEventAggregator _ea;
        private readonly IRegionManager _regionManager;
        private string _authName;
        private bool _isAuthAdmin;

        public DelegateCommand<string> NavigateCommand { get; set; }

        public bool IsAuthAdmin
        {
            get => _isAuthAdmin;
            set => SetProperty(ref _isAuthAdmin, value);
        }

        public string AuthName
        {
            get => _authName;
            set => SetProperty(ref _authName, value);
        }

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator ea)
        {
            _ea = ea;
            _ea.GetEvent<UserAuthEvent>().Subscribe(OnAuthUser);
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(DictionaryView));

            NavigateCommand = new DelegateCommand<string>(OnRegionNavigate);
        }

        private void OnAuthUser(User user)
        {
            AuthUser = user;
            AuthName = user.FullName;
            IsAuthAdmin = user.IsAdmin;
        }

        private void OnRegionNavigate(string path)
        {
            NavigationParameters navParameters = new NavigationParameters();
            navParameters.Add("User", AuthUser);
            if (path != null)
                _regionManager.RequestNavigate("ContentRegion", path, navParameters);

        }

    }
}
