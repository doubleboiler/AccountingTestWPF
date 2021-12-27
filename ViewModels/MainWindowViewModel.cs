using AccountingTestWPF.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace AccountingTestWPF.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> NavigateCommand { get; set; }
        
        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator ea) : base(ea)
        {
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(OperationsView));
            NavigateCommand = new DelegateCommand<string>(OnNavigate);
        }

        private void OnNavigate(string path)
        {
            if (path != null)
                _regionManager.RequestNavigate("ContentRegion", path);
        }

    }
}
