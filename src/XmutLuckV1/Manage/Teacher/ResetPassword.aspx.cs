using System;
using Presentation.Enum;

namespace XmutLuckV1.Manage.Teacher
{
    public partial class ResetPassword : BaseAccountPage
    {
        public override UserType UserType
        {
            get
            {
                return UserType.Teacher;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}