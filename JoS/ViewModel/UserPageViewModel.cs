using System.Collections.Generic;

namespace JoS.ViewModel
{
    public class UserPageViewModel
    {
        public int itemsCount { get; set; }
        public IEnumerable<AdminUsersInfoViewModel> data { get; set; }
    }
}