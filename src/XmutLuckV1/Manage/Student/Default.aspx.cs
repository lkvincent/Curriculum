using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace XmutLuckV1.Manage.Student
{
    public partial class Default : BaseStudentPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            ltlUserName.Text = CurrentUser.Name;
            ltlWelCome.Text = string.Format(Resources.XmcaResource.WelcomeBackendLabel, Resources.XmcaResource.Organization);

            Master master = this.Master as Master;
            master.DefaultPage = "StudenyDailyEssayList.aspx";
        }
    }
}