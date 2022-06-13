using System.Web;
using System.Web.Optimization;

namespace Card.Validation.Web.App
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region JS

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Bootstrap/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/Bootstrap/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/Modernizr/modernizr").Include(
                        "~/Scripts/Modernizr/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/Bootstrap/bootstrap").Include(
                      "~/Scripts/Bootstrap/bootstrap.js"));

            #endregion

            #region Custom JS

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                        "~/Scripts/Home/home.js"));

            bundles.Add(new ScriptBundle("~/bundles/card").Include(
                       "~/Scripts/Validation/card.js"));

            #endregion

            #region CSS

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Styles/Bootstrap/bootstrap.css",
                      "~/Content/Styles/site.css"));

            #endregion
        }
    }
}
