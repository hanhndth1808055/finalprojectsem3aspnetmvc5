using System.Web;
using System.Web.Optimization;

namespace OfficialFinalProjectSem3
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
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // Admin template js, css
            //bundles.Add(new StyleBundle("~/AdminTemplate/css").Include(
            //          "https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons",
            //          "https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css",
            //          "~/Acsset/css/material-dashboard.css?v=2.1.2"
            //          ));

            //bundles.Add(new ScriptBundle("~/AdminTemplate/js").Include(
            //          "~/Scripts/bootstrap.js"));

        }
    }
}
