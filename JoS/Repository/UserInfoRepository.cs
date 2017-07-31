using JoS.Models;
using JoS.Models.EmailModels;
using JoS.ViewModel;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace JoS.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        private readonly ApplicationDbContext _ctx;

        private const string ADMIN_ROLE = "Admin";

        public UserInfoRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<AdminUsersInfoViewModel> GetAllUsersInfo(AdminGridQueryModel query)
        {
            var role = _ctx.Roles.FirstOrDefault(w => w.Name.Contains(ADMIN_ROLE));

            var viewModel = _ctx.Users
                .Include(ui => ui.UserInfo)
                .Where(w => !w.Roles.Select(y => y.RoleId).Contains(role.Id))
                .Select(s =>
                    new AdminUsersInfoViewModel
                    {
                        Id = s.UserInfo.Id,
                        Name = s.UserInfo.Name,
                        LastName = s.UserInfo.LastName,
                        Email = s.Email,
                        Age = (DbFunctions.DiffDays(s.UserInfo.DateOfBirthday, DateTime.Now) / 365),
                        RegisteredDate = s.UserInfo.RegisteredDate,
                        StartStudy = s.UserInfo.StartStudy
                    });

            viewModel = SearchAdminQuery(query, viewModel);
            viewModel = SortingAdminQuery(query, viewModel);

            return viewModel;
        }

        public List<AdminUsersInfoViewModel> GetAllUsersInfoPagination(AdminGridQueryModel query, int pageIndex, int pageSize)
        {
            return GetAllUsersInfo(query).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public int GetAllUsersInfoCount(AdminGridQueryModel query)
        {
            return GetAllUsersInfo(query).Count();
        }

        public ApplicationUser GetUserById(string userId)
        {
            Logger.Info("DB GetUserById(" + userId + ")");
            return _ctx.Users.Include(i => i.UserInfo)
                             .FirstOrDefault(u => u.Id == userId);
        }

        public ApplicationUser GetUserByEmail(string mail)
        {
            Logger.Info("DB GetUserByEmail(" + mail + ")");
            return _ctx.Users.Include(i => i.UserInfo)
                             .FirstOrDefault(u => u.Email == mail);
        }

        public List<UserEmail> GetDataFromUsersByConcreteDay(int countDays)
        {
            return _ctx.Users
                       .Include(ui => ui.UserInfo)
                       .Where(u => DbFunctions.DiffDays(DateTime.UtcNow, u.UserInfo.StartStudy.StudyDate) == countDays)
                       .Select(u => new UserEmail { Name = u.UserInfo.Name + " " + u.UserInfo.LastName, To = u.Email })
                       .ToList();
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }

        private static IQueryable<AdminUsersInfoViewModel> SearchAdminQuery(AdminGridQueryModel query, IQueryable<AdminUsersInfoViewModel> viewModel)
        {
            if (query.Id.HasValue
                || !string.IsNullOrEmpty(query.Name)
                || !string.IsNullOrEmpty(query.LastName)
                || !string.IsNullOrEmpty(query.Email)
                || query.Age.HasValue
                || query.RegisteredDateFrom.HasValue && query.RegisteredDateTo.HasValue
                || query.StudyDateFrom.HasValue && query.StudyDateTo.HasValue)
            {
                viewModel = viewModel.Where(w => (!query.Id.HasValue || w.Id == query.Id)
                                                 && w.Name.Contains(query.Name)
                                                 && w.LastName.Contains(query.LastName)
                                                 && w.Email.Contains(query.Email)
                                                 && (!query.Age.HasValue || w.Age == query.Age)
                                                 && (!query.RegisteredDateFrom.HasValue || query.RegisteredDateFrom <= w.RegisteredDate)
                                                 && (!query.RegisteredDateTo.HasValue || query.RegisteredDateTo >= w.RegisteredDate)
                                                 && (!query.StudyDateFrom.HasValue || query.StudyDateFrom <= w.StartStudy.StudyDate)
                                                 && (!query.StudyDateTo.HasValue || query.StudyDateTo >= w.StartStudy.StudyDate)
                );
            }

            return viewModel;
        }

        private static IQueryable<AdminUsersInfoViewModel> SortingAdminQuery(AdminGridQueryModel query, IQueryable<AdminUsersInfoViewModel> viewModel)
        {
            var sortOrder = $"{query.SortField}_{query.SortOrder}".ToLower();
            switch (sortOrder)
            {
                case "id_desc":
                    viewModel = viewModel.OrderByDescending(o => o.Id);
                    break;
                case "name_asc":
                    viewModel = viewModel.OrderBy(o => o.Name);
                    break;
                case "name_desc":
                    viewModel = viewModel.OrderByDescending(o => o.Name);
                    break;
                case "lastname_asc":
                    viewModel = viewModel.OrderBy(o => o.LastName);
                    break;
                case "lastname_desc":
                    viewModel = viewModel.OrderByDescending(o => o.LastName);
                    break;
                case "email_asc":
                    viewModel = viewModel.OrderBy(o => o.Email);
                    break;
                case "email_desc":
                    viewModel = viewModel.OrderByDescending(o => o.Email);
                    break;
                case "age_asc":
                    viewModel = viewModel.OrderBy(o => o.Age);
                    break;
                case "age_desc":
                    viewModel = viewModel.OrderByDescending(o => o.Age);
                    break;
                case "registereddate_asc":
                    viewModel = viewModel.OrderBy(o => o.RegisteredDate);
                    break;
                case "registereddate_desc":
                    viewModel = viewModel.OrderByDescending(o => o.RegisteredDate);
                    break;
                case "startstudy.studydate_asc":
                    viewModel = viewModel.OrderBy(o => o.StartStudy.StudyDate);
                    break;
                case "startstudy.studydate_desc":
                    viewModel = viewModel.OrderByDescending(o => o.StartStudy.StudyDate);
                    break;
                default:
                    viewModel = viewModel.OrderBy(o => o.Id);
                    break;
            }
            return viewModel;
        }
    }
}