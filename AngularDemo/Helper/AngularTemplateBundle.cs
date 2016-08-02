using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AngularDemo.Helper
{
        public class AngularTemplateBundle : Bundle
    {
        public AngularTemplateBundle(string moduleName, string virtualPath)
            : base(virtualPath, new[] { new AngularTemplateTransform(moduleName) })
        {
        }
    }
}