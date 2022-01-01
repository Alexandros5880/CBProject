using System.Web.Optimization;

namespace CBProject
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js"
                      ));


            bundles.Add(new StyleBundle("~/Content/css")
                .Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Login.css",
                      "~/Content/About.css",
                      "~/Content/Details.css",
                      "~/Content/Lessons.css",
                      "~/Content/Subscribe.css",
                      "~/Content/Datatables/css/dataTables.bootstrap.css"
                      ));




            bundles.Add(new StyleBundle("~/Scripts/DataTables").Include(
                "~/Scripts/DataTables*",
                "~/Scripts/Datatables/jquery.dataTables.js",
                "~/Scripts/Datatables/dataTables.bootstrap.js"
                ));

            bundles.Add(new Bundle("~/Scripts/DataTables_Videos.js").Include(
                      "~/Scripts/DataTables_Videos.js"
                      ));



            // Admin Dashboard
            bundles.Add(new Bundle("~/assets/libs/jquery/jquery.min.js").Include(
                      "~/assets/libs/jquery/jquery.min.js"
                      ));
            bundles.Add(new Bundle("~/assets/libs/bootstrap/js/bootstrap.bundle.min.js").Include(
                      "~/assets/libs/bootstrap/js/bootstrap.bundle.min.js"
                      ));
            bundles.Add(new Bundle("~/assets/libs/metismenu/metisMenu.min.js").Include(
                      "~/assets/libs/metismenu/metisMenu.min.js"
                      ));
            bundles.Add(new Bundle("~/assets/libs/simplebar/simplebar.min.js").Include(
                      "~/assets/libs/simplebar/simplebar.min.js"
                      ));
            bundles.Add(new Bundle("~/assets/libs/node-waves/waves.min.js").Include(
                      "~/assets/libs/node-waves/waves.min.js"
                      ));
            bundles.Add(new Bundle("~/assets/js/app.js").Include(
                      "~/assets/js/app.js"
                      ));

            bundles.Add(new StyleBundle("~/assets/css/bootstrap.min.css").Include(
                "~/assets/css/bootstrap.min.css"
                ));
            bundles.Add(new StyleBundle("~/assets/css/icons.min.css").Include(
                "~/assets/css/icons.min.css"
                ));
            bundles.Add(new StyleBundle("~/assets/css/app.min.css").Include(
                "~/assets/css/app.min.css"
                ));

            bundles.Add(new StyleBundle("~/assets/images/flags/spain.jpg").Include(
                "~/assets/images/flags/spain.jpg"
                ));


            BundleTable.EnableOptimizations = true;
        }
    }
}
