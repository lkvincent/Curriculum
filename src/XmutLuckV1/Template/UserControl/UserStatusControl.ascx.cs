﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LkHelper;
using Presentation.Enum;
using WebLibrary.Helper;

namespace XmutLuckV1.Template.UserControl
{
    public partial class UserStatusControl : BaseFrontUserControl
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!HttpContext.Current.User.Identity.IsAuthenticated || CurrentUser.UserType == UserType.Guest)
            {
                phUserContainer.Visible = false;
                phRegisterContainer.Visible = true;
                link2Login.NavigateUrl = "~/Login.aspx?ReturnUrl="+HttpUtility.UrlEncode("/Template/Default.aspx");
            }
            else
            {
                ltlLoginTime.Text = CurrentUser.LogTime.ToCustomerShortDateString();
                ltlUserName.Text = CurrentUser.Name;
                switch (CurrentUser.UserType)
                {
                    case UserType.DepartAdmin:
                        ltlRoleName.Text = "系管理员";
                        link2Backend.NavigateUrl = "~/Manage/DepartAdmin/";
                        break;
                    case UserType.Enterprise:
                        ltlRoleName.Text = "企业用户";
                        link2Backend.NavigateUrl = "~/Manage/Enterprise/";
                        break;
                    case UserType.Student:
                        ltlRoleName.Text = "学生";
                        link2Backend.NavigateUrl = "~/Manage/Student/";
                        if (!(Page is BaseFrontStudentPage))
                        {
                            phHomePage.Visible = true;
                            link2Home.NavigateUrl = UrlRuleHelper.GenerateUrl(CurrentUser.UserName.ToString(), "",
                                                                              RulePathType.StudentInfo);
                        }
                        break;
                    case UserType.Teacher:
                        ltlRoleName.Text = "老师";
                        link2Backend.NavigateUrl = "~/Manage/Teacher/";
                        break;
                    case UserType.Family:
                        ltlRoleName.Text = "家长";
                        link2Backend.NavigateUrl = "~/Manage/Family/";
                        break;
                }
                phUserContainer.Visible = true;
                phRegisterContainer.Visible = false;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            AuthorizeHelper.LogOut();
            RedirectToDefaultPage();
        }
    }
}