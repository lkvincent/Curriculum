using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XmutLuckV1.Template.UserControl
{
    public partial class CommonSearchWidget : BaseFrontUserControl
    {
        public delegate void SearchDelegate(string keyword);
        public event SearchDelegate SearchClicked;

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchClicked(this.txtkeyword.Text);
        }
    }
}