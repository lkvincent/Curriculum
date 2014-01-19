using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebLibrary
{
    public static class WebUiConfig
    {
        public static string ErrorEmail = System.Configuration.ConfigurationManager.AppSettings["ErrorEmail"];
    }
}
