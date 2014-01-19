using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XmutLuckV1.Manage
{
    public partial class MasterDetail : System.Web.UI.MasterPage
    {
        public bool EnableAJAX
        {
            set
            {
                //this.ajaxPanel.EnableAJAX = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}