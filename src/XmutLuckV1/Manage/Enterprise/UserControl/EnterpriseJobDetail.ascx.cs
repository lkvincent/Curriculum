using System;
using Business.Interface.Enterprise;
using Business.Service.Enterprise;
using Presentation.Enum;
using Presentation.UIView.Enterprise;
using WebLibrary.Helper;

namespace XmutLuckV1.Manage.Enterprise.UserControl
{
    public partial class EnterpriseJobDetail : BaseUserControl
    {
        public void LoadData(EnterpriseJobPresentation job)
        {
            drpSex.BindSource(BindingSourceType.SexInfo, false);
            drpNature.BindSource(BindingSourceType.PositionNatureInfo, false);
            drpRecruitmentTarget.BindSource(BindingSourceType.RequiredTargeterInfo, false);
            drpEducation.BindSource(BindingSourceType.EducationCodeInfo, false);

            if (job != null)
            {
                txtAgeScope.Text = job.AgeScope;
                txtAddress.Text = job.Address;
                txtContactName.Text = job.ContactName;
                radEditor.LoadData(job.Description);
                drpEducation.Text = job.Education;
                radStartTime.SelectedDate = job.StartTime;
                radEndTime.SelectedDate = job.EndTime;

                txtName.Text = job.Name;

                txtSalaryScope.Text = job.SalaryScope;
                txtTelephone.Text = job.Telephone;
                txtWorkPlace.Text = job.WorkPlace;
                radNum.Value = job.Num;
                chkIsOnline.Checked = job.IsOnline;

                drpRecruitmentTarget.SelectedValue = job.RecruitmentTargets;
                drpNature.SelectedValue = job.Nature;

                drpSex.SelectedValue = ((int) job.Sex).ToString();

            }
        }

        public EnterpriseJobPresentation SaveData(string code)
        {
            return new EnterpriseJobPresentation()
            {
                Code = code,
                AgeScope = txtAgeScope.Text,
                Address = txtAddress.Text,
                ContactName = txtContactName.Text,
                Description = radEditor.SaveData(),
                EndTime = radEndTime.SelectedDate ?? DateTime.Now,
                StartTime = radStartTime.SelectedDate ?? DateTime.Now,
                Name = txtName.Text,
                Nature = drpNature.SelectedItem.Text,
                Num = (int) (radNum.Value ?? 0),
                SalaryScope = txtSalaryScope.Text,
                RecruitmentTargets = drpRecruitmentTarget.SelectedValue,
                Education = drpEducation.SelectedValue,
                Sex = int.Parse(drpSex.SelectedValue),
                Telephone = txtTelephone.Text,
                WorkPlace = txtWorkPlace.Text,
                IsOnline = chkIsOnline.Checked
            };
        }
    }
}