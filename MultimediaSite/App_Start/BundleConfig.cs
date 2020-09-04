using System.Web;
using System.Web.Optimization;

namespace AnimeSatellite
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/framework").Include(
                        "~/Scripts/lib/angularjs/angular.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs")
                        .Include("~/Scripts/app/app.js")
                        .IncludeDirectory(
                         "~/Scripts/app/Controllers/*",
                         "~/Scripts/app/Services/*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/lib/jquery/jquery-{version}.js",
                         "~/Scripts/lib/jquery/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/lib/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/library").Include(
                      "~/Scripts/lib/bootstrap.min.js",
                      "~/Scripts/lib/respond.js",
                      "~/Scripts/lib/jqBootstrapValidation.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/animestyle.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      //"~/Content/modern-business.css",
                      "~/Content/font-awesome.min.css"));
        }
    }
}
