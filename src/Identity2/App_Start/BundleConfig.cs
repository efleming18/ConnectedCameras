﻿using System.Web;
using System.Web.Optimization;

namespace ConnectedCamerasWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/bootstrap.js",
                       "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/LiveFeed/js").Include(
                       "~/Scripts/LiveFeed.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap.css",
                       "~/Content/PageFormatting.css",
                       "~/Content/Grid.css",
                       "~/Content/Backgrounds.css",
                       "~/Content/Panels.css"));

            bundles.Add(new StyleBundle("~/LiveFeed/css").Include(
                       "~/Content/CameraFeeds.css",
                       "~/Content/CameraInput.css"));

            bundles.Add(new StyleBundle("~/Picker/css").Include("~/Content/PickerStyle.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
