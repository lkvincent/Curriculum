using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebLibrary;


namespace XmutLuckV1
{
    public partial class GeneratePassword : System.Web.UI.Page
    {
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            txtOutput.Text = AccountSecurityManage.MD5Password(txtPassword.Text);
        }
    }
}