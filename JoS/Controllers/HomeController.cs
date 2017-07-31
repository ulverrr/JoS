using JoS.Models;
using JoS.Repository;
using Microsoft.AspNet.Identity;
using NLog;
using System;
using System.Globalization;
using System.Net;
using System.Web.Mvc;

namespace JoS.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IStartStudyRepository _startStudyRepository;
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public HomeController(IUserInfoRepository userInfoRepository, IStartStudyRepository startStudyRepository)
        {
            _userInfoRepository = userInfoRepository;
            _startStudyRepository = startStudyRepository;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStartStudyDate(StartStudy startStudy)
        {
            if (startStudy == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userId = User.Identity.GetUserId();

            var user = _userInfoRepository.GetUserById(userId);
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "No user");
            }
            var infoUserid = user.UserInfo.Id;

            var model = _startStudyRepository.GetStudyDateByUserInfoId(infoUserid);
            if (model == null)
            {
                Logger.Info($"User: {user.Email} Add new sturt stady date: {startStudy.StudyDate}");
                model = new StartStudy { Id = infoUserid, StudyDate = startStudy.StudyDate };
                _startStudyRepository.Add(model);
            }
            else
            {
                Logger.Info($"User: {user.Email} Update sturt stady date to: {startStudy.StudyDate}");
                model.StudyDate = startStudy.StudyDate;
                _startStudyRepository.Update(model);
            }
            _startStudyRepository.Save();
            return new HttpStatusCodeResult(HttpStatusCode.OK, "Start study date added");
        }

        [HttpGet]
        public JsonResult GetCurrentDate()
        {
            var userId = User.Identity.GetUserId();
            var user = _userInfoRepository.GetUserById(userId);
            var infoUserid = user.UserInfo.Id;

            var model = _startStudyRepository.GetStudyDateByUserInfoId(infoUserid);
            if (model == null)
            {
                return Json(DateTime.Now.ToString(CultureInfo.CurrentCulture), JsonRequestBehavior.AllowGet);
            }

            return Json(model.StudyDate.ToString(CultureInfo.CurrentCulture), JsonRequestBehavior.AllowGet);
        }
    }
}