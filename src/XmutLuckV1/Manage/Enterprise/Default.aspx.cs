﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentation;

namespace XmutLuckV1.Manage.Enterprise
{
    public partial class Default : BaseEnterpriseDetailPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (CurrentUser != null)
            {
                ltlUserName.Text = CurrentUser.Name;

                ltlWelCome.Text = string.Format(Resources.XmcaResource.WelcomeBackendLabel, Resources.XmcaResource.Organization);

                XmutLuckV1.Manage.Master master = this.Master as XmutLuckV1.Manage.Master;
                if (IsPermission)
                {
                    master.DefaultPage = "JobRequesterList.aspx";
                }
                else
                {
                    master.DefaultPage = NavigateMenuItem.NotPermissionPage;
                }
            }
        }
    }
}