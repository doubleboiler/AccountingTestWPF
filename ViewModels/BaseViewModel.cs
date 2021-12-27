using AccountingTestWPF.Internal;
using AccountingTestWPF.Models;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingTestWPF.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        private IEventAggregator _ea;
        private User _authUser;

        public User AuthUser
        {
            get => _authUser;
            set => SetProperty(ref _authUser, value);
        }

        public BaseViewModel(IEventAggregator ea)
        {
            _ea = ea;
            _ea.GetEvent<UserAuthEvent>().Subscribe(OnAuthUser);
        }

        private void OnAuthUser(User user)
        {
            AuthUser = user;
        }
    }
}
