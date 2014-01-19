using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Interface.Enterprise;
using Business.Service.Enterprise;
using Presentation.Cache;
using Presentation.Criteria.Enterprise;
using Presentation.UIView;
using Presentation.UIView.Enterprise;
using Presentation.UIView.Enterprise.View;
using Telerik.Web.UI;
using System.Text;
using WebLibrary.Helper;


namespace XmutLuckV1.Manage.Enterprise
{
    public partial class JobRequesterList : BaseEnterpriseListPage<EnterpriseJobRequestFromTeacherPresentation, EnterpriseJobRequestCriteria>
    {
        private IEnterpriseJobRequestService Service
        {
            get
            {
                return new EnterpriseJobRequestService();
            }
        }

        protected override Panel PnlConditionControl
        {
            get { return pnlCondition; }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            RadGridControl.CurrentPageIndex = 0;
            RadGridControl.Rebind();
        }

        protected void linkInvite_Click(object sender, EventArgs e)
        {
            var linkInvite = sender as LinkButton;
            var item = linkInvite.NamingContainer as GridItem;
            var jobRequestID = (int)item.OwnerTableView.DataKeyValues[item.ItemIndex]["ID"];
            var result = Service.InviteToAudition(jobRequestID);
            ShowMsg(result.IsSucess, result.Message);
        }

        protected override void InitData()
        {
            prm_RecruitFlowID_.BindSource(BindingSourceType.RecruitFlowSettedInfo, true);

            var recruitItem =
                GlobalBaseDataCache.RecruitFlowSettedList.FirstOrDefault(it => it.RecruitType == Presentation.Enum.RecruitType.Request);

            if (recruitItem != null)
            {
                prm_RecruitFlowID_.SelectedValue = prm_RecruitFlowID_.Items.FindByValue(recruitItem.Id.ToString()).Value;
            }
            base.InitData();
        }

        protected override RadGrid RadGridControl
        {
            get { return grdEnterpriseJob; }
        }

        protected override EntityCollection<EnterpriseJobRequestFromTeacherPresentation> GetSearchResultList(
            EnterpriseJobRequestCriteria criteria)
        {
            criteria.EnterpriseCode = EnterpriseCode;
            bool referralsQueueIdNotNull = false;
            bool.TryParse(Request.QueryString["IsReferralsQueueIDNotNull"], out referralsQueueIdNotNull);
            criteria.IsReferralsQueueIDNotNull = referralsQueueIdNotNull;
            return Service.GetJobRequestAll(criteria);
        }

        protected override void BindSearchResultList(RadGrid radGrid, IList<EnterpriseJobRequestFromTeacherPresentation> list)
        {
            radGrid.DataSource = list.Select(it => new
            {
                it.Index,
                it.JobName,
                it.JobNum,
                it.JobCode,
                it.StudentName,
                it.RequestTime,
                it.RequestStatus,
                it.StudentTelephone,
                Sex = GlobalBaseDataCache.GetSexLabel(it.StudentSex),
                it.StudentNum,
                it.Id,
                Referralers = String.Join(",", it.Referralers)
            });
        }
    }
}
