﻿using System;
using System.Collections.Generic;
using System.Linq;
using Business.Interface.Student;
using Business.Service.Student;
using Presentation.Criteria.Student;
using Presentation.Enum;
using Presentation.UIView;
using Presentation.UIView.Student;
using WebLibrary;
using WebLibrary.Helper;

namespace XmutLuckV1.Manage.Student
{
    public partial class StudentProfessionalDetail : BaseStudentDetailPage
    {
        #region property
        public override AttachmentType InitAttachmentType()
        {
            return AttachmentType.Professional;
        }

        private List<int> DeletedAttachmentIDList
        {
            get
            {
                var deletedAttachmentIDList = this.ViewState["DeletedAttachmentIDList"] as List<int>;
                if (deletedAttachmentIDList == null)
                {
                    deletedAttachmentIDList = new List<int>();
                    this.ViewState["DeletedAttachmentIDList"] = deletedAttachmentIDList;
                }
                return deletedAttachmentIDList;
            }
        }

        private StudentProfessionalPresentation CurrentProfessional
        {
            get
            {
                var _CurrentProfessional = this.ViewState["CurrentProfessional"] as StudentProfessionalPresentation;
                if (_CurrentProfessional == null)
                {
                    _CurrentProfessional = Service.Get(new StudentProfessionalCriteria()
                    {
                        Id = CurrentID,
                        StudentNum = StudentNum,
                        IncludeRelativeData = true
                    });
                    if (_CurrentProfessional == null)
                    {
                        _CurrentProfessional = new StudentProfessionalPresentation()
                        {
                            StudentNum = StudentNum
                        };
                    }
                    this.ViewState["CurrentProfessional"] = _CurrentProfessional;
                }
                return _CurrentProfessional;
            }
        }
        #endregion

        private IStudentProfessionalService Service
        {
            get { return new StudentProfessionalService(); }
        }

        protected override void InitData()
        {
            txt_Description_.Text = (CurrentProfessional.Description);
            txt_Name_.Text = CurrentProfessional.Name;
            if (CurrentProfessional.ObtainTime != DateTime.MinValue)
            {
                dtp_ObtainTime_.SelectedDate = CurrentProfessional.ObtainTime;
            }
            chk_IsOnline_.Checked = CurrentProfessional.IsOnline;

            BindAttachmentList();
        }

        private void BindAttachmentList()
        {
            this.grdAttList.LoadData(
                CurrentProfessional.AttachmentPresentations.Where(it => !DeletedAttachmentIDList.Contains(it.ID))
                    .ToList());
        }

        protected void grdAttList_AttachmentDeleteCommmandEventHandler(int attachID)
        {
            DeletedAttachmentIDList.Add(attachID);
            BindAttachmentList();
        }

        protected void grdAttList_AttachmentInsertCommmandEventHandler(AttachmentPresentation viewItem)
        {
            var currentAttachmentID = 0;
            if (CurrentProfessional.AttachmentPresentations.Any())
            {
                currentAttachmentID = CurrentProfessional.AttachmentPresentations.Max(it => it.ID);
            }
            var attachmentItem = new AttachmentPresentation
            {
                IsMain = viewItem.IsMain,
                FileLabel = viewItem.FileLabel,
                DisplayOrder = viewItem.DisplayOrder,
                DocumentType = viewItem.DocumentType,
                Path = viewItem.Path,
                Index = viewItem.Index,
                ID = currentAttachmentID + 1,
                IsNew = true
            };
            string thumbPath = viewItem.Path;
            if (viewItem.DocumentType == DocumentType.Image)
            {
                thumbPath = FileHelper.GenerateRelativeThumbFilePath(MemberID.ToString(), UserType, AttachmentType, viewItem.FileName);
                FileHelper.DrawingUploadFile(viewItem.FileContent, FileHelper.GeneratePhysicalPath(thumbPath), MaxThumbSize.Width, MaxThumbSize.Height);
            }
            attachmentItem.ThumbPath = thumbPath;
            CurrentProfessional.AttachmentPresentations.Add(attachmentItem);

            BindAttachmentList();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            List<AttachmentPresentation> deleteAttachmentList = new List<AttachmentPresentation>();
            DeletedAttachmentIDList.ForEach(it =>
            {
                var attachment = CurrentProfessional.AttachmentPresentations.FirstOrDefault(ic => ic.ID == it);
                if (attachment != null)
                {
                    CurrentProfessional.AttachmentPresentations.Remove(attachment);
                    deleteAttachmentList.Add(attachment);
                }
            });
            GetProfessionalData();
            var result = Service.Save(CurrentProfessional);
            this.CurrentID = CurrentProfessional.Id;
            deleteAttachmentList.ForEach(it =>
            {
                FileHelper.DeleteAttachmentFile(it);
            });

            if (result.IsSucess)
            {
                Response.Redirect("StudentProfessionalList.aspx");
                return;
            }
            ShowMsg(result.IsSucess, result.Message);
            InitData();
        }

        private StudentProfessionalPresentation GetProfessionalData()
        {
            CurrentProfessional.Name = txt_Name_.Text;
            CurrentProfessional.Description = txt_Description_.Text;
            CurrentProfessional.IsOnline = chk_IsOnline_.Checked;
            CurrentProfessional.ObtainTime = dtp_ObtainTime_.SelectedDate.Value;
            return CurrentProfessional;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            (this.Page.Master as MasterDetail).EnableAJAX = false;
        }
    }
}