using AngularDemo.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AngularDemo.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle(Constants.Bootstrap).
                Include("~/Content/bootstrap.min.css"));
            bundles.Add(new ScriptBundle(Constants.AngularBundle)
                    .Include("~/Scripts/angular.min.js",
                            "~/Scripts/angular-route.min.js",
                              "~/Scripts/jquery-{version}.js",
                            "~/Scripts/bootstrap.min.js" 
                          ));
            //  "~/Scripts/home/angularDemoApp.route.js"
            bundles.Add(new ScriptBundle(Constants.ApplicationBundle)
                .IncludeDirectory("~/Scripts/home", "*.js", true));

            //bundles.Add(new AngularTemplateBundle("angularDemoApp", Constants.AcademyTemplatesBundle)
            //               .IncludeDirectory("~/scripts/home/views", "*.html", true));

        }
    }
}