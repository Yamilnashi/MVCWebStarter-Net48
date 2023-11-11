using System.Web;
using System.Web.Optimization;
using WebMvc.Data;

namespace WebMvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new Bundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.js"));

            bundles.Add(new Bundle("~/bundles/statecorejs").Include(
                "~/Scripts/state/cagov.core.min.js"));

            bundles.Add(new Bundle("~/bundles/googlefont", "https://fonts.googleapis.com/css2?family=Roboto&display=swap").Include(
                "~/Content/fonts/google/css2.css"));

            bundles.Add(new Bundle("~/bundles/bootstrapicons", "https://cdn.jsdelivr.net/npm/bootstrap-icons@1.8.1/font/bootstrap-icons.css").Include(
                "~/Content/icons/bootstrap/bootstrap-icons.css"));

            bundles.Add(new Bundle("~/bundles/statecore", "https://california.azureedge.net/cdt/statetemplate/5.5.24/css/cagov.core.css").Include(
                "~/Content/statestyles/core/cagov.core.css"));

            bundles.Add(new Bundle("~/bundles/css").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new Bundle("~/bundles/site").Include(
                "~/Content/site.css"));

            bundles.Add(new Bundle("~/bundles/datatablescss").Include(
                "~/Content/DataTables/css/dataTables.bootstrap5.min.css"));

            bundles.Add(new Bundle("~/bundles/datatablesjs").Include(
                "~/Scripts/DataTables/jquery.dataTables.min.js",
                "~/Scripts/DataTables/dataTables.bootstrap5.min.js"));

            bundles.Add(new Bundle("~/bundles/moment").Include(
                "~/Scripts/moment.js"));


            if (Utils.GetAppSetting(EAppSettings.ENVIRONMENT) != "Development")
            {
                BundleTable.EnableOptimizations = true; // only minify styles and scripts outside of dev
            }
        }
    }
}
