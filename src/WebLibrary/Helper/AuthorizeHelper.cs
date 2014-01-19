using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using Presentation.UIView;
using Presentation.UIView.Student;

namespace WebLibrary.Helper
{
    public static class AuthorizeHelper
    {
        public static void SetCurrentUser(LoginUserPresentation user, bool customerRedirect = false)
        {
            user.LogTime = DateTime.Now;
            var accountInfoJson = AccountSecurityManage.SerializeAccountInfo(user);

            if (HttpContext.Current.Request.Url.LocalPath.ToLower().Contains("login"))
            {
                FormsAuthentication.RedirectFromLoginPage(accountInfoJson, false);
            }
            else
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, accountInfoJson, DateTime.Now,
                                                                                 DateTime.Now.AddMinutes(30),
                                                                                 false, String.Empty,
                                                                                 FormsAuthentication.FormsCookiePath);
                string encryptedCookie = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedCookie);
                cookie.Expires = DateTime.Now.AddMinutes(30);
                HttpContext.Current.Response.Cookies.Add(cookie);

                if (!customerRedirect)
                {
                    HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.ToString());
                }
            }
        }

        internal static LoginUserPresentation GetCurrentUser(string accountInfoJson)
        {
            return AccountSecurityManage.DeserializeAccountInfo(accountInfoJson);
        }

        public static void LogOut()
        {
            FormsAuthentication.SignOut();
        }

        public static string AuthorizateStudentInfo(StudentPresentation student, CultureInfo culture)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return student.NameZh;
            }
            if (string.IsNullOrEmpty(student.NameZh))
            {
                return "";
            }
            StringBuilder name = new StringBuilder();
            for (var index = 0; index < student.NameZh.Length; index++)
            {
                if (index == 0)
                {
                    name.Append(student.NameZh[index].ToString());
                }
                else
                {
                    name.Append("*");
                }
            }
            return name.ToString();
        }
    }
}
