﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Interface.Student;
using Business.Service.Student;
using LkHelper;
using WebLibrary;
using WebLibrary.Helper;
using XmutLuckV1.Front;

namespace XmutLuckV1.Template.StudentTemplate.UserControl
{
    public partial class NewestTopDailyEssayWidget : BaseFrontStudentUserControl, IShortWidget
    {
        private IStudentDailyEssayService Service
        {
            get
            {
                return new StudentDailyEssayService();
            }
        }

        protected override void InitData()
        {
            int totalCount;
            var list = Service.GetNewestFrontDailyEssayList(StudentInfo.StudentNum, out totalCount);
            if (!list.Any())
            {
                ltlEmptyMessage.Text = HtmlContentHelper.GetEmptyContent();
                linkmore.Visible = false;
            }
            else
            {
                rptDailyEssay.DataSource = list.Select(it => new
                    {
                        Title = it.Name.Cut(EnableShortContent, MaxContentLength).HtmlEncode(),
                        Url =
                                                                 UrlRuleHelper.GenerateUrl(StudentInfo.StudentNum,
                                                                                           it.Identity,
                                                                                           it.Name.Cut(200, ""),
                                                                                           StudentRulePathType
                                                                                               .DailyEssay)
                    }).ToList();
                rptDailyEssay.DataBind();
            }
            linkmore.NavigateUrl = UrlRuleHelper.GenerateStudentMoreUrl(StudentInfo.StudentNum, StudentRulePathType.DailyEssay);
        }

        public int MaxContentLength
        {
            get
            {
                if (this.ViewState["MaxContentLength"] == null)
                {
                    return 15;
                }
                return (int)this.ViewState["MaxContentLength"];
            }
            set { this.ViewState["MaxContentLength"] = value; }
        }

        public bool EnableShortContent
        {
            get
            {
                if (this.ViewState["EnableShortContent"] == null)
                {
                    return true;
                }
                return (bool)this.ViewState["EnableShortContent"];
            }
            set { this.ViewState["EnableShortContent"] = value; }
        }
    }
}