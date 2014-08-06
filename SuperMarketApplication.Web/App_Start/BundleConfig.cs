using System.Web;
using System.Web.Optimization;

namespace SuperMarketApplication.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js")
                .Include("~/Content/js/vendor/jquery.js")
                .Include("~/Content/js/vendor/bootstrap.min.js")
                .Include("~/Content/js/vendor/underscore.js")
                .Include("~/Content/js/vendor/backbone.js")
                .Include("~/Content/js/build/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/css/main.css"));
        }
    }
}