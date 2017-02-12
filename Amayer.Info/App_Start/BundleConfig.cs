using System.Web;
using System.Web.Optimization;

namespace Amayer.Info
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/bootstrap.css"));

            // Font Awesome icons
            bundles.Add(new StyleBundle("~/Content/fontAwesome").Include(
                      "~/Content/font-awesome.css"));





            //bundles.Add(new ScriptBundle("~/Assets/css/AppLikeOnePage").Include(
            //            "~/Assets/css/AppLikeOnePage/jq22-demo.css",
            //            "~/Assets/css/AppLikeOnePage/normalize/css"
            //    ));
            //bundles.Add(new StyleBundle("~/Assets/js/AppLikeOnePage").Include(
            //            "~/Assets/js/AppLikeOnePage/onepage.js"
            //    ));


            //bundles.Add(new ScriptBundle("~/Assets/css/IsometricGrids").Include(
            //            "~/Assets/css/IsometricGrids/component.css",
            //            "~/Assets/css/IsometricGrids/demo.css",
            //            "~/Assets/css/IsometricGrids/normalize.css"
            //    ));
            //bundles.Add(new StyleBundle("~/Assets/js/IsometricGrids").Include(
            //            "~/Assets/js/IsometricGrids/animOnScroll1.js",
            //            "~/Assets/js/IsometricGrids/classie.js",
            //            "~/Assets/js/IsometricGrids/dynamics.min.js",
            //            "~/Assets/js/IsometricGrids/imagesloaded.pkgd.min.js",
            //            "~/Assets/js/IsometricGrids/main.js",
            //            "~/Assets/js/IsometricGrids/masonry.pkgd.min.js",
            //            "~/Assets/js/IsometricGrids/modernizr.custom.js"
            //    ));
            bundles.Add(new StyleBundle("~/Assets/css/Material").Include(
                        
                        "~/Assets/css/Material/bootstrap-material-design.css",
                        "~/Assets/css/Material/ripples.css",
                        "~/Assets/css/Material/jquery.dropdown.css"
                ));
            bundles.Add(new ScriptBundle("~/Assets/js/Material").Include(
                        "~/Assets/js/Material/material.js",
                        "~/Assets/js/Material/ripples.js",
                        "~/Assets/js/Material/jquery.dropdown.js",
                        "~/Assets/js/Material/jquery.nouislider.min.js"
                ));
        }
    }
}
