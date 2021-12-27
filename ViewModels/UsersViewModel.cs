using AccountingTestWPF.Data;
using AccountingTestWPF.Models;
using AccountingTestWPF.Mvvm;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AccountingTestWPF.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        private ObservableCollection<User> _users;
        private decimal _balance;
        private bool _isAdmin;
        private string _name;
        private bool _isAuthAdmin;

        public ObservableCollection<User> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        public decimal Balance
        {
            get => _balance;
            set => SetProperty(ref _balance, value);
        }

        public bool IsAdmin
        {
            get => _isAdmin;
            set => SetProperty(ref _isAdmin, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public bool IsAuthAdmin
        {
            get => _isAuthAdmin;
            set => SetProperty(ref _isAuthAdmin, value);
        }

        public ICommand AddUserCommand { get; private set; }

        public UsersViewModel(IEventAggregator ea) : base(ea)
        {
            LoadData();
            IsAuthAdmin = AuthUser.IsAdmin;
            AddUserCommand = new RelayCommand(OnAddUser);
        }

        private void OnAddUser()
        {
            DataAccess.AddUser(Name, IsAdmin, Balance);
            LoadData();
        }

        private void LoadData()
        {
            Users = new ObservableCollection<User>(DataAccess.GetAllUsers());
        }
    }
}
