using AccountingTestWPF.Data;
using AccountingTestWPF.Internal;
using AccountingTestWPF.Models;
using AccountingTestWPF.Mvvm;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace AccountingTestWPF.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private User _selectedUser;
        private IEventAggregator _ea;

        public List<User> UserList { get; set; }
        public ICommand LoginCommand { get; private set; }

        public User SelectedUser
        {
            get => _selectedUser;
            set => SetProperty(ref _selectedUser, value);
        }

        public LoginViewModel(IEventAggregator ea)
        {
            DataAccess.LoadDefaultData();

            _ea = ea;

            UserList = DataAccess.GetAllUsers();
            SelectedUser = UserList.FirstOrDefault();
            LoginCommand = new RelayCommand(OnLogIn);
        }

        private void OnLogIn()
        {
            _ea.GetEvent<UserAuthEvent>().Publish(SelectedUser);
        }
    }
}
