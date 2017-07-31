using JoS.Models;
using JoS.Repository;
using JoS.ViewModel;
using System;
using System.Collections.Specialized;
using System.Web.Mvc;

namespace JoS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public AdminController(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllUsers(int pageIndex = 0, int pageSize = 0)
        {
            var query = ParseQuery(Request.QueryString);

            var users = _userInfoRepository.GetAllUsersInfoPagination(query, pageIndex, pageSize);
            var total = _userInfoRepository.GetAllUsersInfoCount(query);

            return Json(new UserPageViewModel
            {
                data = users,
                itemsCount = total
            }, JsonRequestBehavior.AllowGet);
        }

        #region Helper
        private AdminGridQueryModel ParseQuery(NameValueCollection query)
        {
            return new AdminGridQueryModel
            {
                Id = TryParseInt(query["Id"]),
                Name = query["Name"],
                LastName = query["LastName"],
                Age = TryParseInt(query["Age"]),
                Email = query["Email"],
                RegisteredDateFrom = TryParseDateTime(query["RegisteredDate[from]"]),
                RegisteredDateTo = TryParseDateTime(query["RegisteredDate[to]"]),
                StudyDateFrom = TryParseDateTime(query["StartStudy[StudyDate][from]"]),
                StudyDateTo = TryParseDateTime(query["StartStudy[StudyDate][to]"]),
                SortField = query["sortField"],
                SortOrder = query["sortOrder"]
            };
        }

        private DateTime? TryParseDateTime(string input)
        {
            return !DateTime.TryParse(input, out DateTime date)
                            ? new DateTime?()
                            : date;
        }

        private int? TryParseInt(string input)
        {
            return !int.TryParse(input, out int numb)
                       ? new int?()
                       : numb;
        }
        #endregion
    }
}