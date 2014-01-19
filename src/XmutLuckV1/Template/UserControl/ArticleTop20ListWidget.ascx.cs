using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Interface.DepartAdmin;
using Business.Service.DepartAdmin;
using LkHelper;
using WebLibrary;
using WebLibrary.Helper;

namespace XmutLuckV1.Template.UserControl
{
    public partial class ArticleTop20ListWidget : BaseFrontUserControl
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
            rptMessage.DataSource = Service.GetTop20FrontMessageList().Select(it => new
            {
                Title = string.Format("<a href='{0}' title={1}>{2}</a>", UrlRuleHelper.GenerateUrl(it.Id.ToString(), it.Title.Cut(40, ""), RulePathType.DepartMessage), it.Title, it.Title.Cut(30, " ")),
                LastUpdateTime = it.LastUpdateTime.ToCustomerShortDateString()
            });
            rptMessage.DataBind();
            base.InitData();
        }
    }
}