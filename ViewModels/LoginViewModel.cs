using AccountingTestWPF.Data;
using AccountingTestWPF.Internal;
using AccountingTestWPF.Models;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;

namespace AccountingTestWPF.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private User _selectedUser;
        private IEventAggregator _ea;

        public List<User> UserList { get; set; }

        public User SelectedUser
        {
            get => _selectedUser;
            set => SetProperty(ref _selectedUser, value);
        }

        public LoginViewModel(IEventAggregator ea)
        {
            DataAccess.LoadDefaultData();

            _ea = ea;
            _ea.GetEvent<UserAuthEvent>().Publish(SelectedUser);

            UserList = DataAccess.GetAllUsers();
            SelectedUser = UserList.FirstOrDefault();
        }
    }
}
