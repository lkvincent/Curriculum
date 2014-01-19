using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Interface.DepartAdmin;
using Business.Service.DepartAdmin;
using WebLibrary.Helper;
using XmutLuckV1.App_Code;

namespace XmutLuckV1.Template
{
    public partial class Message : BaseFrontPage
    {
        private IDepartMessageService Service
        {
            get
            {
                return new DepartMessageService();
            }
        }

        protected override void InitData()
        {
            var articleID = 0;
            int.TryParse(Request.QueryString["KeyCode"], out articleID);
            if (articleID == 0)
            {
                RedirectToDefaultPage();
                return;
            }
            var message = Service.Get(articleID);
            if (phContainer.PresentationEmptyCheck(message))
            {
                ltlTitle.Text = message.Title;
                ltlTime.Text = message.CreateTime.ToString("yyyy-MM-dd hh:mm:ss");
                ltlContent.Text = message.Content;
            }
            ucNaviageControl.LoadData(PageContentType.DepartMessage, Request.QueryString["KeyCode"]);

            base.InitData();
        }
    }
}