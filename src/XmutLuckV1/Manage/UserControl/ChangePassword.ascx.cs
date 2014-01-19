using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Interface;
using Business.Service.DepartAdmin;
using Business.Service.Enterprise;
using Business.Service.Family;
using Business.Service.Student;
using Business.Service.Teacher;
using Presentation.Enum;

namespace XmutLuckV1.Manage.UserControl
{
    public partial class ChangePassword : BaseUserControl
    {
        protected void btnSave_Click(object sender, EventArgs e)
        {
           IAuthenticateService service = null;
            switch (UserType)
            {
                case UserType.Admin:
                    break;
                case UserType.DepartAdmin:
                    service = new DepartAdminService();
                    break;
                case UserType.Enterprise:
                    service = new EnterpriseService();
                    break;
                case UserType.Student:
                    service = new StudentService();
                    break;
                case UserType.Teacher:
                    service = new TeacherService();
                    break;
                case UserType.Family:
                    service = new FamilyService();
                    break;
            }
            var result = service.ChangePassword(CurrentUser.UserName, txtOrginalPassword.Text.Trim(), txtNewPassword.Text.Trim());
            ShowMsg(result.IsSucess, result.Message);
        }

        protected override void InitLoadedData()
        {
            btnSave.Style.Add("width", "80px");
            base.InitLoadedData();
        }
    }
}