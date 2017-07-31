using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using NLog;
using System.Web;
using System.Web.Mvc;

namespace JoS.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            var logger = LogManager.GetLogger(GetType().ToString());
            logger.Error(filterContext.Exception);
            base.OnException(filterContext);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        protected const string XsrfKey = "XsrfId";

        protected IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        protected void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        #endregion
    }
}