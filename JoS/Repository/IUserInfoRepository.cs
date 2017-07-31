using JoS.Models;
using JoS.Models.EmailModels;
using JoS.ViewModel;
using System.Collections.Generic;

namespace JoS.Repository
{
    public interface IUserInfoRepository
    {
        IEnumerable<AdminUsersInfoViewModel> GetAllUsersInfo(AdminGridQueryModel model);
        List<AdminUsersInfoViewModel> GetAllUsersInfoPagination(AdminGridQueryModel model, int pageIndex, int pageSize);
        int GetAllUsersInfoCount(AdminGridQueryModel model);
        ApplicationUser GetUserById(string userId);
        ApplicationUser GetUserByEmail(string mail);
        List<UserEmail> GetDataFromUsersByConcreteDay(int countDays);

        void Save();
    }
}
