using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace XmutLuckV1.Manage.Family
{
    public partial class Default : BaseFamilyPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            ltlUserName.Text =  CurrentUser.Name;
            ltlWelCome.Text = string.Format(Resources.XmcaResource.WelcomeBackendLabel,
                                            Resources.XmcaResource.Organization);
        }
    }
}