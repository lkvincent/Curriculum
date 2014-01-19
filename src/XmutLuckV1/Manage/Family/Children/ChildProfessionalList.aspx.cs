using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Interface.Student;
using Business.Service.Student;
using Presentation.Criteria.Student;
using Presentation.UIView;
using Presentation.UIView.Student;
using Telerik.Web.UI;

namespace XmutLuckV1.Manage.Family.Children
{
    public partial class ChildProfessionalList : BaseFamilyListPage<StudentProfessionalPresentation, StudentProfessionalCriteria>
    {
        private IStudentProfessionalService Service
        {
            get
            {
                return new StudentProfessionalService();
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

        protected override RadGrid RadGridControl
        {
            get { return grdProfessional; }
        }

        protected override EntityCollection<StudentProfessionalPresentation> GetSearchResultList(StudentProfessionalCriteria criteria)
        {
            criteria.StudentNum = StudentNum;
            return Service.GetAll(criteria);
        }
    }
}