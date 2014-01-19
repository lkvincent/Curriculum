﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Interface.Student;
using Business.Service.Student;
using LkHelper;
using Presentation.Criteria.Student;
using Presentation.Enum;
using Presentation.UIView.Student;
using WebLibrary.Helper;

namespace XmutLuckV1.Manage.Teacher
{
    public partial class StudentExercitationVerifyDetail : BaseTeacherDetailPage
    {
        private IStudentExercitationService Service
        {
            get
            {
                return new StudentExercitationService();
            }
        }

        protected StudentExercitationPresentation CurrentActivity
        {
            get
            {
                var activity = this.ViewState["CurrentActivity"] as StudentExercitationPresentation;
                if (activity == null)
                {
                    activity = Service.Get(new StudentExercitationCriteria()
                    {
                        Id = CurrentID,
                        TeacherNum = TeacherNum,
                        IncludeRelativeData = true
                    });
                    this.ViewState["CurrentActivity"] = activity;
                }
                return activity;
            }
        }

        protected override void InitData()
        {
            base.InitData();

            if (CurrentActivity == null)
            {
                Response.Redirect("StudentProjectVerifyList.aspx"); return;
            }
            txt_Title_.Text = CurrentActivity.Title;
            txt_EvaluateFromTeacher_.Text = CurrentActivity.EvaluateFromTeacher;
            txt_VerifyStatusReason_.Text = CurrentActivity.VerifyStatusReason;
            ltl_Content_.Text = CurrentActivity.Content;
            txt_Address_.Text = CurrentActivity.Address;
            txt_BeginTime_.Text = CurrentActivity.BeginTime.ToCustomerShortDateString();
            txt_EndTime_.Text = CurrentActivity.EndTime.ToCustomerShortDateString();

            //rdoVerify.SelectedValue = (CurrentActivity.VerfyStatus == VerifyStatus.Passed ? "2" : "3");
            rdoVerify.SelectedValue = ((int)CurrentActivity.VerfyStatus).ToString();
            attachmentList.LoadData(CurrentActivity.AttachmentPresentations);
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var result = Service.ChangeVerifyStatus(CurrentID, (VerifyStatus) (int.Parse(rdoVerify.SelectedValue)),
                txt_VerifyStatusReason_.Text, txt_EvaluateFromTeacher_.Text, CurrentUser.UserName);
            if (result.IsSucess)
            {
                Response.Redirect("StudentExercitationVerifyList.aspx");
            }
            else
            {
                ShowMsg(result.IsSucess, result.Message);
            }
        }

        protected override void InitBindData()
        {
            rdoVerify.BindSource(BindingSourceType.VerifyStatusInfo, false);
        }
    }
}