using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Security;
using System.Web.SessionState;
using Business.Service;
using LkHelper;
using Presentation.Enum;

namespace XmutLuckV1
{
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        private void Application_Error(object sender, EventArgs e)
        {
            string subject = HttpContext.Current.Request.Url.ToString().Cut(270, "...");
            //SystemLogService.AddSystemLog(subject, Server.GetLastError().ToString(),
            //                                      LogType.Error,
            //                                      HttpContext.Current.Request.UserHostAddress);

            LogService.Log(Server.GetLastError(), HttpContext.Current.Request.UserHostAddress, subject);

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
