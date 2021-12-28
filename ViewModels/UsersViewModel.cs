using AccountingTestWPF.Data;
using AccountingTestWPF.Models;
using AccountingTestWPF.Mvvm;
using Prism.Events;
using Prism.Regions;
using System;
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

        public UsersViewModel()
        {
            AddUserCommand = new RelayCommand(OnAddUser, OnCanAddUser);
        }

        private bool OnCanAddUser()
        {
            return Name != null;
        }

        private void OnAddUser()
        {
            DataAccess.AddUser(Name, IsAdmin, Balance);
            LoadData();
        }

        private void LoadData()
        {
            Users = new ObservableCollection<User>(DataAccess.GetAllUsers());
            Name = null;
            IsAdmin = false;
            Balance = 0;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            LoadData();
            AuthUser = (User)navigationContext.Parameters["User"];
            IsAuthAdmin = AuthUser.IsAdmin;
            base.OnNavigatedTo(navigationContext);
        }
    }
}
