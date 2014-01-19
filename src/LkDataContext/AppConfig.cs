using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkDataContext
{
    public static class AppConfig
    {
        public static string ConnectString = ConfigurationManager.ConnectionStrings["CVAcademician"].ConnectionString;

        public static string MailSender = ConfigurationManager.AppSettings["MailSender"];
    }
}
