using System.Web;
using System.Web.Optimization;

namespace Pitch
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/scripts/angular.min.js",
                      "~/scripts/angular-route.min.js",
                      "~/scripts/angular-resource.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jQuery").Include(
                      "~/scripts/bootstrap.min.js",
                      "~/scripts/jquery-1.9.1.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/pitchApp")
                      .Include("~/scripts/main.js",
                      "~/scripts/main.config.js")
                      .IncludeDirectory("~/scripts/Controllers", "*.js")
                      .IncludeDirectory("~/scripts/Factories", "*.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
