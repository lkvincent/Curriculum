using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace XmutLuckV1
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Manage/BaseJs").Include(
                "~/Scripts/jquery-1.9.1.js",
                "~/Scripts/validate/jquery.validate.js",
                "~/Scripts/validate/jquery.custom.validate.js",
                "~/Scripts/jqwidgets/jqwidgets/jqxcore.js",
                "~/Scripts/jqwidgets/jqwidgets/jqxdata.js",
                "~/Scripts/jqwidgets/jqwidgets/jqxinput.js",
                "~/Scripts/jqwidgets/jqwidgets/jqxcheckbox.js",
                "~/Scripts/jqwidgets/jqwidgets/jqxscrollbar.js",
                "~/Scripts/jqwidgets/jqwidgets/jqxlistbox.js",
                "~/Scripts/jqwidgets/jqwidgets/jqxdropdownlist.js",
                "~/Scripts/jqwidgets/jqwidgets/jqxcombobox.js",
                "~/Scripts/jqwidgets/jqwidgets/jqxbuttons.js",
                "~/Scripts/jqwidgets/jqwidgets/jqxpanel.js"));

            bundles.Add(new ScriptBundle("~/Manage/Js").Include(
               "~/Scripts/BaseCv.js",
               "~/Scripts/XMCATool.js",
               "~/Scripts/Prompt.js"));
        }
    }
}