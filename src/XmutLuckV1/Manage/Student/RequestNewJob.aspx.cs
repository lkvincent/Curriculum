using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Interface.Enterprise;
using Business.Service.Enterprise;
using Presentation.Cache;
using WebLibrary.Helper;

namespace XmutLuckV1.Manage.Student
{
    public partial class RequestNewJob : BaseStudentPage
    {
        private IEnterpriseJobService Service
        {
            get { return new EnterpriseJobService(); }
        }

        private string JobCode
        {
            get { return Request.QueryString["JobCode"]; }
        }

        protected override void InitData()
        {
            base.InitData();

            var job = Service.Get(JobCode, true);
            if (job == null)
            {
                Response.Write("职位不存在!");
                Response.End();
                return;
            }

            ltlEnterpriseName.Text = job.Enterprise.Name;
            ltlJobName.Text = job.Name;
            ltlNum.Text = job.Num.ToString();
            ltlSalaryScope.Text = job.SalaryScope;
            ltlWorkPlace.Text = job.WorkPlace;

            foreach (var teacher in GlobalBaseDataCache.TeacherList)
            {
                lstTeacher.Items.Add(new ListItem(teacher.Text, teacher.Value));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var serviceJobRequester = new EnterpriseJobRequestService();
            int[] selectedIndexs = lstTeacher.GetSelectedIndices();
            List<string> teacherNums = new List<string>();
            foreach (var index in selectedIndexs)
            {
                teacherNums.Add(lstTeacher.Items[index].Value);
            }

            var result = serviceJobRequester.AddRequestJob(CurrentUser.UserName, JobCode, teacherNums, txtNote.Text);
            if (result.IsSucess)
            {
                this.ReflashFrame();
            }
            ShowMsg(result.IsSucess, result.Message);
        }
    }
}