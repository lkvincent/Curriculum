using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.UI;
using Presentation.Enum;
using Presentation.UIView;

namespace WebLibrary
{
    public static class WebUiManage
    {
        public static void RedirectToLoginPage(this Page currentPage)
        {
            FormsAuthentication.SignOut();
            var loginUrl = FormsAuthentication.LoginUrl;
            var script = new StringBuilder();
            script.Append("(function(){");
            script.AppendLine();
            script.Append("try{");
            script.AppendLine();
            script.Append("var win = get_TopParent(window)");
            script.AppendLine();
            script.AppendFormat("win.location.href={0}", loginUrl);
            script.AppendLine();
            script.Append("}");
            script.AppendLine();
            script.Append("catch(e){ window.location.href=" + loginUrl + " }");
            script.AppendLine();
            script.Append("})();");
            currentPage.ClientScript.RegisterClientScriptBlock(currentPage.GetType(), "SignOut", script.ToString(), true);
        }

        public static void ShowMsg(this Page currentPage,bool isSucess,string msg)
        {
            if (String.IsNullOrEmpty(msg))
            {
                if (isSucess)
                {
                    msg = "操作成功!";
                }
                else
                {
                    msg = "操作失败!";
                }
            }
            var script = new StringBuilder();
            script.AppendFormat("parent.showAlterResultMsg({0},'{1}');", isSucess ? "true" : "false", msg);
            if (!ScriptManager.GetCurrent(currentPage).IsInAsyncPostBack)
            {
                currentPage.ClientScript.RegisterClientScriptBlock(currentPage.GetType(), "PopMsg", "$(function(){" + script.ToString() + "});", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(currentPage, currentPage.GetType(), "AsyncPopMsg", script.ToString(), true);
            }
        }

        public static void EnsureAuthorized(this Page currentPage,LoginUserPresentation currentUser,UserType expectedUserType)
        {
            if (currentUser == null || (currentUser.UserType != expectedUserType))
            {
                if (
                    !(currentUser != null &&
                      (currentUser.UserType == UserType.DepartAdmin && expectedUserType == UserType.Supper)))
                {
                    currentPage.RedirectToLoginPage();
                }
            }
        }
    }
}
