using AccountingTestWPF.Models;
using Prism.Events;

namespace AccountingTestWPF.Internal
{
    internal class UserAuthEvent : PubSubEvent<User>
    {
    }
}
