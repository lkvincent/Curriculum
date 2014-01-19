﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Service;
using Presentation;
using Presentation.Enum;
using WebLibrary;
using WebLibrary.Helper;

namespace XmutLuckV1.Manage.UserControl
{
    public partial class MenuNaviageControl : BaseUserControl
    {
        protected override void InitData()
        {
            IList<NavigateMenuItem> list = null;
            if (UserType == UserType.Enterprise)
            {
                var isPermission = (this.Page as BaseEnterprisePage).IsPermission;
                list = NavigateMenuItem.LoadNavigateMenuItemList(this.UserType, isPermission);
            }
            else
            {
                list = NavigateMenuItem.LoadNavigateMenuItemList(this.UserType, true);
            }
            if (this.UserType == UserType.Student || this.UserType == UserType.Family)
            {
                foreach (var item in list)
                {
                    if (item != null && item.NavigateType == NavigateItemType.Front)
                    {
                        if (this.UserType == UserType.Student)
                        {
                            item.LinkUrl = UrlRuleHelper.GenerateUrl(CurrentUser.UserName, "",
                                                                     RulePathType.StudentInfo);
                        }
                        else
                        {
                            if (CurrentUser.AddtionalUser.ContainsKey("StudentNum"))
                            {
                                var studentNum = CurrentUser.AddtionalUser["StudentNum"];
                                item.LinkUrl = UrlRuleHelper.GenerateUrl(studentNum, "",
                                                                         RulePathType.StudentInfo);
                            }
                        }
                    }
                    else
                    {
                        if (this.UserType == UserType.Student)
                        {
                            item.LinkUrl = item.LinkUrl.Replace(NavigateMenuItem.CurrentUserName,
                                                                CurrentUser.UserName);
                        }
                        else
                        {
                            if (CurrentUser.AddtionalUser.ContainsKey("StudentNum"))
                            {
                                var studentNum = CurrentUser.AddtionalUser["StudentNum"];
                                item.LinkUrl = item.LinkUrl.Replace(NavigateMenuItem.CurrentUserName,
                                                                    studentNum);
                            }
                        }
                    }


                }
            }
            var msgBoxItem = list.FirstOrDefault(it => it.NavigateType == NavigateItemType.MessageBox);
            if (msgBoxItem != null && msgBoxItem.NavigateType == NavigateItemType.MessageBox)
            {
                var msgCount = (new MessageBoxService()).GetNewestMessageBoxCount(CurrentUser.UserName,
                                                                         CurrentUser.UserType);
                msgBoxItem.Text = String.Format(msgBoxItem.Text, msgCount);
            }

            rptNavigate.DataSource = list.OrderBy(it => it.DisplayOrder).ToList();
            rptNavigate.DataBind();
        }

        protected void rptNavigate_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var rptNavigateItems = e.Item.FindControl("rptNavigateItems") as Repeater;
                var dataItem = (e.Item.DataItem as NavigateMenuItem);
                rptNavigateItems.DataSource = dataItem.NavigateMenuItemList;
                rptNavigateItems.DataBind();
            }
        }
    }
}