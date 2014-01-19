using System;
using Business.Interface.Student;
using Business.Service.Student;
using Presentation;
using Presentation.Cache;
using Presentation.Enum;
using Presentation.UIView;
using Presentation.UIView.Student;
using WebLibrary.Helper;

namespace XmutLuckV1.Manage.Student.UserControl
{
    public partial class UserInfo : BaseUserControl
    {
        private IStudentService Service
        {
            get
            {
                return new StudentService();
            }
        }

        protected UploadFileItemPresentation Filedata
        {
            get { return this.ViewState["Filedata"] as UploadFileItemPresentation; }
            set { this.ViewState["Filedata"] = value; }
        }

        protected override void BindData()
        {
            drp_DepartCode_.BindSource(BindingSourceType.DepartInfo, false);
            drp_MarjorCode_.BindSource(BindingSourceType.MarjorInfo, false);
            drp_Period_.BindSource(BindingSourceType.PeriodInfo, false);
            rdo_Sex_.BindSource(BindingSourceType.SexInfo, false);
            rdo_Married_.BindSource(BindingSourceType.MarriedInfo, false);
            drp_Politics_.BindSource(BindingSourceType.PoliticsInfo, false);
            drp_JobSalary_.BindSource(BindingSourceType.SalaryInfo, false);
            chk_OpenType_.BindSource(BindingSourceType.StudentOpenTypeInfo, false);
        }

        protected override void InitData()
        {
            var current = Service.Get(CurrentUser.UserName);
            txt_Address_.Text = current.Address;
            rad_Birthday_.SelectedDate = current.Birthday;
            txt_Class_.Text = current.Class;
            drp_DepartCode_.SelectedValue = current.DepartCode;
            txt_Description_.Text = current.Description;
            txt_Email_.Text = current.Email;
            txt_IDentityNum_.Text = current.IDentityNum;
            chkIsOnline.Checked = current.IsMarried;
            chkIsOnline.Checked = current.IsOnline;
            drp_MarjorCode_.SelectedValue = current.MarjorCode;
            txt_NameEn_.Text = current.NameEn;
            txt_NameZh_.Text = current.NameZh;
            txt_NativePlace_.Text = current.NativePlace;
            drp_Period_.SelectedValue = current.Period;
            imgSource.ImageUrl = FileHelper.GetPersonAbsoluatePath((SexType)current.Sex, current.Photo, false);
            drp_Politics_.SelectedValue = ((int) current.Politics).ToString();
            rdo_Sex_.SelectedValue = ((int) current.Sex).ToString();
            txt_StudentNum_.Text = current.StudentNum;
            txt_Tall_.Text = current.Tall;
            txt_Telephone_.Text = current.Telephone;
            txt_WebSite_.Text = current.WebSite;
            rdo_Married_.SelectedValue = GlobalBaseDataCache.GetMarriedValue(current.IsMarried);


            if (current.JobExpect != null)
            {
                for (var index = 0; index < this.chk_OpenType_.Items.Count; index++)
                {
                    int value = 0;
                    if (int.TryParse(chk_OpenType_.Items[index].Value, out value))
                    {
                        if (((int)current.JobExpect.OpenType).Contain(value))
                        {
                            chk_OpenType_.Items[index].Selected = true;
                        }
                    }
                }

                txt_JobAddress_.Text = current.JobExpect.JobAddress;
                txt_JobContent_.Text = current.JobExpect.JobContent;
                txt_JobRequired_.Text = current.JobExpect.JobRequired;
                drp_JobSalary_.SelectedValue = current.JobExpect.JobSalary;
            }

            Filedata = new UploadFileItemPresentation()
                {
                    Path = current.Photo,
                    ThumbPath = current.ThumbPath
                };
        }

        protected void upLoadControl_FinishUploadingImageEventHandler(BaseUploadControl.UploadFileDataItem fileItem)
        {
            this.imgSource.ImageUrl = fileItem.FilePath;
            var thumbPath = FileHelper.GenerateRelativeThumbFilePath(MemberID.ToString(), UserType.Student,
                                                                     AttachmentType.BaseInfo, fileItem.FileName);
            FileHelper.DrawingUploadFile(fileItem.FileContent, FileHelper.GeneratePhysicalPath(thumbPath), 60, 50);
            Filedata = new UploadFileItemPresentation
                {
                    Path = fileItem.FilePath,
                    ThumbPath = thumbPath
                };
        }

        protected override void OnInit(EventArgs e)
        {
            upLoadControl.FinishUploadingImageEventHandler +=
                new BaseUploadControl.FinishUploadingImageEvent(upLoadControl_FinishUploadingImageEventHandler);
            base.OnInit(e);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var studentPresentation = new StudentPresentation()
            {
                StudentNum = txt_StudentNum_.Text,
                NameEn = txt_NameEn_.Text,
                NameZh = txt_NameZh_.Text,
                Address = txt_Address_.Text,
                Birthday = rad_Birthday_.SelectedDate,
                Class = txt_Class_.Text,
                DepartCode = drp_DepartCode_.SelectedValue,
                Description = txt_Description_.Text,
                Email = txt_Email_.Text,
                IDentityNum = txt_IDentityNum_.Text,
                IsMarried = (rdo_Married_.SelectedValue == "1" ? true : false),
                IsOnline = chkIsOnline.Checked,
                MarjorCode=drp_MarjorCode_.SelectedValue,
                NativePlace = txt_NativePlace_.Text,
                Period = drp_Period_.SelectedValue,
                Sex = (SexType)int.Parse(rdo_Sex_.SelectedValue),
                Tall=txt_Tall_.Text,
                Telephone=txt_Telephone_.Text,
                WebSite=txt_WebSite_.Text,
                JobExpect = new StudentJobExpectPresentation()
                {
                    OpenType = (int)GetStudentOpenType(),
                    JobAddress = txt_JobAddress_.Text,
                    JobSalary = drp_JobSalary_.Text,
                    JobContent = txt_JobContent_.Text,
                    JobRequired = txt_JobRequired_.Text
                }
            };
            if (Filedata != null)
            {
                studentPresentation.Photo = Filedata.Path;
                studentPresentation.ThumbPath = Filedata.ThumbPath;
            }
            if (!string.IsNullOrEmpty(drp_Politics_.SelectedValue))
            {
                studentPresentation.Politics = (PoliticsType)int.Parse(drp_Politics_.SelectedValue);
            }
            var result = Service.Save(studentPresentation);

            ShowMsg(result.IsSucess, result.Message);
        }

        private StudentOpenType GetStudentOpenType()
        {
            var openType = StudentOpenType.None;
            for (var index = 0; index < this.chk_OpenType_.Items.Count; index++)
            {
                if (this.chk_OpenType_.Items[index].Selected)
                {
                    int value = 0;
                    if (int.TryParse(chk_OpenType_.Items[index].Value, out value))
                    {
                        openType = openType | (StudentOpenType) value;
                    }
                }
            }
            return openType;
        }
    }

}
