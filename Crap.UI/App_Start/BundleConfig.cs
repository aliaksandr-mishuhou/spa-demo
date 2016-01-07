using System.Web.Optimization;

namespace Crap.UI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/libs/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                "~/Scripts/libs/jquery.js",
                "~/Scripts/libs/bootstrap.js",
                "~/Scripts/libs/angular.js",
                "~/Scripts/libs/angular-route.js",
                "~/Scripts/libs/angular-validator.js",
                "~/Scripts/libs/angular-validator-rules.js",
                "~/Scripts/libs/toastr.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/app/common").Include(
                "~/Scripts/app/modules/common.core.js",
                "~/Scripts/app/modules/common.ui.js",
                "~/Scripts/app/services/api.js",
                "~/Scripts/app/services/notification.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/app/admin").Include(
                "~/Scripts/app/admin-app.js",
                "~/Scripts/app/admin/rootCtrl.js",
                "~/Scripts/app/admin/indexCtrl.js",
                "~/Scripts/app/admin/topBar.directive.js"
                ));

            bundles.Add(new StyleBundle("~/content/css").Include(
                "~/Content/css/site.css",
                "~/content/css/bootstrap.css",
                "~/content/css/bootstrap-theme.css"
                ));

            BundleTable.EnableOptimizations = false;
        }
    }
}