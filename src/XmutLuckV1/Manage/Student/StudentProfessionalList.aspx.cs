using System;
using System.Web.UI.WebControls;
using Business.Interface.Student;
using Business.Service.Student;
using Presentation.Criteria.Student;
using Presentation.UIView;
using Presentation.UIView.Student;
using Telerik.Web.UI;

namespace XmutLuckV1.Manage.Student
{
    public partial class StudentProfessionalList : BaseStudentListPage<StudentProfessionalPresentation,StudentProfessionalCriteria >
    {
        private IStudentProfessionalService Service
        {
            get
            {
                return new StudentProfessionalService();
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentProfessionalDetail.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            RadGridControl.CurrentPageIndex = 0;
            RadGridControl.Rebind();
        }

        protected override Panel PnlConditionControl
        {
            get { return pnlCondition; }
        }

        protected void radGrid_DeleteCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                var id = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"];
                var result = Service.Delete(CurrentUser.UserName, id);
                ShowMsg(result.IsSucess, result.Message);
            }
        }

        protected virtual void chkIsOnline_CheckedChanged(object sender, EventArgs e)
        {
            var chkIsOnline = sender as CheckBox;
            var dataItem = chkIsOnline.NamingContainer as GridItem;
            var id = (int)dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["ID"];
            Service.SetStatus(StudentNum, id, chkIsOnline.Checked);
            RadGridControl.Rebind();
        }

        protected override RadGrid RadGridControl
        {
            get { return grdProfessional; }
        }

        protected override EntityCollection<StudentProfessionalPresentation> GetSearchResultList(StudentProfessionalCriteria criteria)
        {
            return Service.GetAll(criteria);
        }
    }
}