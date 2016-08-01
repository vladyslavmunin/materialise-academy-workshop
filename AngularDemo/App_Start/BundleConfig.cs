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
            bundles.Add(new ScriptBundle(Constants.AngularBundle)
                    .Include("~/Scripts/angular.min.js", 
                            "~/Scripts/angular-route.min.js")
                    );

            bundles.Add(new ScriptBundle(Constants.ApplicationBundle)
                .IncludeDirectory("~/Scripts/home", "*.js", true)
                );
        }
    }
}