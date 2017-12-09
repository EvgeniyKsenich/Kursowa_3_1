using System.Web;
using System.Web.Optimization;

namespace KR.Web_
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/Customer").Include(
                      "~/Scripts/Custom/Customer.js"));

            bundles.Add(new ScriptBundle("~/bundles/Designer").Include(
                     "~/Scripts/Custom/Designer.js"));

            bundles.Add(new ScriptBundle("~/bundles/Land").Include(
                     "~/Scripts/Custom/Land.js"));

            bundles.Add(new ScriptBundle("~/bundles/Zakaz").Include(
                     "~/Scripts/Custom/Zakaz.js"));

            bundles.Add(new ScriptBundle("~/bundles/OrderInfo").Include(
                     "~/Scripts/Custom/Order.js"));
        }
    }
}
