using System.Web.Optimization;

namespace JoS
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                        "~/Scripts/angular/angular.min.js",
                        "~/Scripts/app/app.js",
                        "~/Scripts/app/Services/StartStudyService.js",
                        "~/Scripts/app/Controllers/StartStudyController.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundle/material").Include(
                        "~/Scripts/angular-animate/angular-animate.min.js",
                        "~/Scripts/angular-aria/angular-aria.min.js",
                        "~/Scripts/angular-messages/angular-messages.min.js",
                        "~/Scripts/angular-material/angular-material.min.js"));

            bundles.Add(new ScriptBundle("~/bundle/jquery-ui").Include(
                        "~/Scripts/jquery-ui-1.12.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr", "http://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js")
                        .Include("~/Scripts/toastr.js"));

            bundles.Add(new StyleBundle("~/bundles/metronic").Include(
                        "~/Metronic/global/scripts/app.min.js",
                        "~/Metronic/layouts/layout5/scripts/layout.min.js"));

            bundles.Add(new StyleBundle("~/bundles/metronic-auth").Include(
                        "~/Metronic/global/scripts/app.min.js",
                        "~/Metronic/pages/scripts/login.min.js"));

            bundles.Add(new StyleBundle("~/Content/jquery-ui").Include(
                        "~/Content/themes/smoothness/jquery.ui.all.css"));

            bundles.Add(new StyleBundle("~/Content/toastr", "http://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css")
                        .Include("~/Content/toastr.css"));

            bundles.Add(new StyleBundle("~/Content/angular-material").Include(
                        "~/Content/angular-material.min.css"));

            bundles.Add(new StyleBundle("~/Content/metronic-auth").Include(
                        "~/Metronic/global/css/components-md.min.css",
                        "~/Metronic/pages/css/login.min.css"));

            bundles.Add(new StyleBundle("~/Content/metronic").Include(
                        "~/Metronic/global/plugins/font-awesome/css/font-awesome.min.css",
                        "~/Metronic/global/plugins/simple-line-icons/simple-line-icons.min.css",
                        "~/Metronic/global/css/components-md.min.css",
                        "~/Metronic/layouts/layout5/css/layout.min.css",
                        "~/Metronic/layouts/layout5/css/custom.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                        "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/site.css"));
        }
    }
}