using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace XmutLuckV1.Manage.DepartAdmin
{
    public partial class Default : BaseDepartAdminDetailPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            (this.Master as Master).DefaultPage = "EnterpriseManage.aspx";

            if (CurrentUser != null)
            {
                ltlUserName.Text = CurrentUser.Name;
            }
            ltlWelCome.Text = string.Format(Resources.XmcaResource.WelcomeBackendLabel, Resources.XmcaResource.Organization);

            XmutLuckV1.Manage.Master master = this.Master as XmutLuckV1.Manage.Master;
            master.DefaultPage = "EnterpriseManage.aspx";
        }
    }
}