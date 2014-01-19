using System;
using Business.Interface.Enterprise;
using Business.Service.Enterprise;
using Presentation.Cache;
using Presentation.UIView.Enterprise;
using WebLibrary.Helper;

namespace XmutLuckV1.Manage.Enterprise.UserControl
{
    public partial class UserInfo : BaseUserControl
    {
        private IEnterpriseService Service
        {
            get
            {
                return new EnterpriseService();
            }
        }

        private string EnterpriseCode
        {
            get
            {
                return CurrentUser.Identity;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        protected override void BindData()
        {
            drp_CdIndustryCode_.BindSource(BindingSourceType.IndustryCodeInfo, false);
            drp_CdRegionCode_.BindSource(BindingSourceType.RegionCodeInfo, false);
            drp_EnterpriseTypeCode_.BindSource(BindingSourceType.EnterpriseTypeCodeInfo, false);
            drp_ScopeCode_.BindSource(BindingSourceType.EnterpriseScopeCodeInfo, false);
        }

        protected override void InitData()
        {
            var presentation = Service.Get(EnterpriseCode);

            txt_Code_.Text = presentation.Code;
            txt_Address_.Text = presentation.Address;
            txt_ContactName_.Text = presentation.ContactName;
            txt_ContactPhone_.Text = presentation.ContactPhone;
            txt_Corporation_.Text = presentation.Corporation;
            txt_Email_.Text = presentation.Email;
            txt_LicenseCode_.Text = presentation.LicenseNo;
            txt_Name_.Text = presentation.Name;
            txt_UserName_.Text = presentation.UserName;
            txt_WebSite_.Text = presentation.WebSite;

            drp_CdIndustryCode_.SelectedValue = presentation.IndustryCode;
            drp_CdRegionCode_.SelectedValue = presentation.RegionCode;
            drp_EnterpriseTypeCode_.SelectedValue = presentation.EnterpriseTypeCode;
            drp_ScopeCode_.SelectedValue = presentation.ScopeCode;
            lbl_VerifyStatus_.Text = GlobalBaseDataCache.GetVerifityStatusLabel(presentation.VerifyStatus);
            chk_IsOnline_.Checked = presentation.IsOnline;

            editDescription.LoadData(presentation.Description);
        }

        private void SaveData()
        {
            var presentation = new EnterprisePresentation()
            {
                Code = EnterpriseCode,
                Address = txt_Address_.Text,
                ContactName = txt_ContactName_.Text,
                ContactPhone = txt_ContactPhone_.Text,
                Corporation = txt_Corporation_.Text,
                Email = txt_Email_.Text,
                LicenseNo = txt_LicenseCode_.Text,
                Name = txt_Name_.Text,
                WebSite = txt_WebSite_.Text,
                IndustryCode = drp_CdIndustryCode_.SelectedValue,
                RegionCode = drp_CdRegionCode_.SelectedValue,
                EnterpriseTypeCode = drp_EnterpriseTypeCode_.SelectedValue,
                ScopeCode = drp_ScopeCode_.SelectedValue,
                IsOnline = chk_IsOnline_.Checked,
                Description = editDescription.SaveData()
            };
            if (presentation.VerifyStatus != Presentation.Enum.VerifyStatus.Passed)
            {
                presentation.VerifyStatus = Presentation.Enum.VerifyStatus.WaitAudited;
            }

            var result = Service.Save(presentation);

            ShowMsg(result.IsSucess, result.Message);

        }
    }
}