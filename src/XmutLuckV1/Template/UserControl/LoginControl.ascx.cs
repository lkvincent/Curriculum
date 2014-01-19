using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Interface;
using Business.Service;
using Business.Service.DepartAdmin;
using Business.Service.Enterprise;
using Business.Service.Family;
using Business.Service.Student;
using Business.Service.Teacher;
using Presentation.Enum;
using Presentation.UIView;
using WebLibrary.Helper;

namespace XmutLuckV1.Template.UserControl
{
    public partial class LoginControl : System.Web.UI.UserControl
    {
        protected void btn_Login_Click(object sender, EventArgs e)
        {
            var userType = (UserType)int.Parse(this.rdoUserType.SelectedValue);
            IAuthenticateService instance = null;
            switch (userType)
            {
                case UserType.DepartAdmin:
                    instance = new DepartAdminService();
                    break;
                case UserType.Enterprise:
                    instance = new EnterpriseService();
                    break;
                case UserType.Teacher:
                    instance = new TeacherService();
                    break;
                case UserType.Family:
                    instance = new FamilyService();
                    break;
                default:
                    instance = new StudentService();
                    break;
            }
            var loginUser = instance.Login(txt_UserName_.Text, txt_Password_.Text);
            if (loginUser!=null)
            {
                AuthorizeHelper.SetCurrentUser(loginUser);
                var returnUrl = Request.QueryString["ReturnUrl"];
                if (string.IsNullOrEmpty(returnUrl))
                {
                    Response.Redirect("~/Template/Default.aspx");
                }
                else
                {
                    Response.Redirect(HttpUtility.UrlDecode(returnUrl));
                }
            }
            else
            {
                ShowMsg(false, "用户名/密码错误!");
            }
        }

        protected void btnLoginWithGuest_Click(object sender, EventArgs e)
        {
            var loginUser = ThirdUserService.LoginViaGuest();
            if (loginUser!=null)
            {
                var account = ThirdUserService.LoginViaGuest();
                AuthorizeHelper.SetCurrentUser(account);
                var returnUrl = Request.QueryString["ReturnUrl"];
                if (string.IsNullOrEmpty(returnUrl))
                {
                    Response.Redirect("~/Template/Default.aspx");
                }
                else
                {
                    Response.Redirect(HttpUtility.UrlDecode(returnUrl));
                }
            }
            else
            {
                ShowMsg(false, "系统发生异常!");
            }

        }

        private void ShowMsg(bool isSucess, string msg)
        {
            var script = new StringBuilder();
            script.AppendFormat("showAlterResultMsg({0},'{1}');", isSucess ? "true" : "false", msg);
            //var isAsyncPostBack = ScriptManager.GetCurrent(Page).IsInAsyncPostBack;
            if (!Page.IsAsync)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "PopMsg", "$(function(){" + script.ToString() + "});", true);
            }
            else
            {

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AsyncPopMsg", script.ToString(), true);
            }   
        }
    }
}