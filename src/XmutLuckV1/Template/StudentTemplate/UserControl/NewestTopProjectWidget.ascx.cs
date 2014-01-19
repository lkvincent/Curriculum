﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Interface.Student;
using Business.Service.Student;
using LkHelper;
using WebLibrary.Helper;
using XmutLuckV1.Front;


namespace XmutLuckV1.Template.StudentTemplate.UserControl
{
    public partial class NewestTopProjectWidget : BaseFrontStudentUserControl, IShortWidget
    {
        private IStudentProjectService Service
        {
            get
            {
                return new StudentProjectService();
            }
        }

        protected override void InitData()
        {
            int totalCount;
            var list = Service.GetNewestFrontProjectList(StudentInfo.StudentNum, out totalCount);
            if (!list.Any())
            {
                ltlEmptyMessage.Text = HtmlContentHelper.GetEmptyContent();
                linkmore.Visible = false;
            }
            else
            {
                rptProject.DataSource = list.Select(it => new
                    {
                        Name = it.Name.Cut(EnableShortContent, MaxContentLength).HtmlEncode(),
                        Url =
                                                              UrlRuleHelper.GenerateUrl(it.ReferenceCode,
                                                                                        it.Identity, it.Name,
                                                                                        StudentRulePathType.Project)
                    }).ToList();
                rptProject.DataBind();

                ltlRecordCount.Text = String.Format("({0})", totalCount);
            }
            linkmore.NavigateUrl = UrlRuleHelper.GenerateStudentMoreUrl(StudentInfo.StudentNum, StudentRulePathType.Project);
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