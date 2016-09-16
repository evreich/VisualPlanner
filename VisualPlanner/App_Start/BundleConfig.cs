using System.Web;
using System.Web.Optimization;

namespace VisualPlanner
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.maskedinput.js",
                        "~/Scripts/jquery.underscore.js"));
            bundles.Add(new ScriptBundle("~/bundles/salvattore").Include(
                        "~/Scripts/salvattore.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство сборки на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/Content/css").Include(
                      "~/Content/font-awesome.css",
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Scripts/Site.js"));
            bundles.Add(new StyleBundle("~/Content/sidebar").Include(
                      "~/Content/sidebar.css",
                      "~/Content/bootstrap-datetimepicker.css"));
            bundles.Add(new StyleBundle("~/Content/calendar").Include(
                      "~/Content/calendar.css"));
            bundles.Add(new StyleBundle("~/bundles/PagedList").Include(
                      "~/Content/PagedList.css"));   
            bundles.Add(new ScriptBundle("~/Script/calendar").Include(
                    "~/Scripts/underscore.js",
                    "~/Scripts/ru-RU.js",      
                    "~/Scripts/calendar.js"));
            bundles.Add(new ScriptBundle("~/Script/datetimepicker").Include(
                    "~/Scripts/moment.js",
                    "~/Scripts/moment-with-locales.js",
                    "~/Scripts/bootstrap-datetimepicker.js"));
        }
    }
}
