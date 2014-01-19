using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Interface.Enterprise;
using Business.Service.Enterprise;
using Presentation;
using Presentation.Criteria.Enterprise;
using Presentation.Enum;
using Presentation.UIView;
using Presentation.UIView.Enterprise;
using Presentation.UIView.Enterprise.View;
using Telerik.Web.UI;

namespace XmutLuckV1.Manage.Student
{
    public partial class EnterpriseJobList : BaseStudentListPage<EnterpriseJobForStudentPresentation, EnterpriseJobCriteria>
    {
        private IEnterpriseJobService Service
        {
            get
            {
                return new EnterpriseJobService();
            }

        }

        protected override Panel PnlConditionControl
        {
            get { return pnlCondition; }
        }

        protected override RadGrid RadGridControl
        {
            get { return grdEnterpriseJob; }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            RadGridControl.CurrentPageIndex = 0;
            RadGridControl.Rebind();
        }

        protected override EntityCollection<EnterpriseJobForStudentPresentation> GetSearchResultList(EnterpriseJobCriteria criteria)
        {
            return Service.GetAllForStudents(criteria, StudentNum);
        }
    }
}