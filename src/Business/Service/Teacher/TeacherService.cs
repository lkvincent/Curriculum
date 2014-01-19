using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interface;
using Business.Interface.Teacher;
using LkDataContext;
using Presentation.Criteria.Teacher;
using Presentation.Enum;
using Presentation.UIView;
using Presentation.UIView.Base;
using Presentation.UIView.Teacher;
using WebLibrary;
using WebLibrary.Helper;

namespace Business.Service.Teacher
{
    public class TeacherService : BaseService, IAuthenticateService,ITeacherService
    {
        #region IAuthenticateService

        public LoginUserPresentation Login(string userName, string password)
        {
            var teacher = dataContext.Teachers.FirstOrDefault(it => !it.IsDelete && it.TeacherNum == userName &&
                                                                    it.Password ==
                                                                    AccountSecurityManage.MD5Password(password));
            if (teacher != null)
            {
                return new LoginUserPresentation()
                {
                    Id = teacher.ID,
                    Identity = teacher.TeacherNum,
                    UserType = UserType.Teacher,
                    UserLabel = teacher.NameZh,
                    UserName = teacher.TeacherNum,
                    LogTime = DateTime.Now
                };
            }
            return null;
        }

        public ActionResult ChangePassword(string userName, string oldPassword, string newPassword)
        {
            try
            {
                var teacher =
                    dataContext.Teachers.FirstOrDefault(
                        it => it.TeacherNum == userName && it.Password == AccountSecurityManage.MD5Password(oldPassword)
                              && !it.IsDelete);
                if (teacher == null)
                {
                    return ActionResult.NotFoundResult;
                }
                teacher.Password = AccountSecurityManage.MD5Password(newPassword);
                 SetAdminGroupAccount(teacher);
                dataContext.SubmitChanges();

                return ActionResult.DefaultResult;
            }
            catch (Exception ex)
            {
                WriteLog(ex);
                return new ActionResult
                {
                    IsSucess = false,
                    Message = "系统异常,请联系管理员!"
                };
            }
        }

        private ActionResult SetAdminGroupAccount(LkDataContext.Teacher teacher)
        {
            var departAdmin = dataContext.DepartAdmins.FirstOrDefault(it => it.UserName == teacher.TeacherNum);
            if (
                dataContext.TeacherRelativeGroups.Any(
                    ic => ic.TeacherGroup.TeacherGroupType == 2 && ic.TeacherNum == teacher.TeacherNum))
            {
                if (departAdmin == null)
                {
                    departAdmin = new LkDataContext.DepartAdmin()
                    {
                        DepartCode = teacher.DepartCode
                    };
                    dataContext.DepartAdmins.InsertOnSubmit(departAdmin);
                }
                departAdmin.UserName = teacher.TeacherNum;
                departAdmin.Password = teacher.Password;
                departAdmin.Email = teacher.Email;
                departAdmin.Telephone = teacher.Telephone;
                departAdmin.Description = teacher.Description;
            }
            else
            {
                if (departAdmin != null)
                {
                    dataContext.DepartAdmins.DeleteOnSubmit(departAdmin);
                }
            }
            dataContext.SubmitChanges();

            return ActionResult.DefaultResult;
        }

        public ActionResult ResetPassword(string userName, UserType userType, string checkCode)
        {
            if (CheckCodeHelper.ValidateCheckCode(userType.ToString(), checkCode))
            {
                var teacher = dataContext.Teachers.FirstOrDefault(it => it.TeacherNum == userName);
                if (teacher != null)
                {
                    if (!String.IsNullOrEmpty(teacher.Email))
                    {
                        var newPassword = AccountSecurityManage.GenerateRadomPassword();
                        teacher.Password = AccountSecurityManage.MD5Password(newPassword);
                        dataContext.MailQueues.InsertOnSubmit(new MailQueue()
                        {
                            CreateTime = DateTime.Now,
                            Cc = null,
                            IsSended = false,
                            Name = EmailTemplateHelper.FormatterResetPasswordContent(teacher.NameZh,userName,newPassword, EmailTemplateHelper.GetEmailTemplateSubject(SystemEmailType.ResetPassword)),
                            Sender = EmailTemplateHelper.MailSender,
                            Receiver = teacher.Email,
                            ReceiverName = teacher.Email,
                            Message =
                                 EmailTemplateHelper.FormatterResetPasswordContent(teacher.NameZh, userName, newPassword,EmailTemplateHelper.GetEmailTemplateBody(SystemEmailType.ResetPassword))
                        });
                        dataContext.SubmitChanges();
                        return new ActionResult()
                        {
                            IsSucess = true,
                            Message = string.Format("密码重置成功! 已经发送至您的邮箱:{0}", teacher.Email)
                        };
                    }
                    return new ActionResult()
                    {
                        IsSucess = false,
                        Message = "用户Email信息为空,无法进行密码重置, 请联系管理员!"
                    };
                }

                return ActionResult.NotFoundResult;
            }

            return ActionResult.CreateErrorActionResult("验证码错误!");
        }

        #endregion


        public TeacherPresentation Get(TeacherCriteria criteria)
        {
            var teacher = dataContext.Teachers.FirstOrDefault(it => it.TeacherNum == criteria.TeacherNum && !it.IsDelete);
            if (teacher == null)
            {
                return null;
            }
            return Translate2Presentation(teacher, criteria.IncludeCourse, criteria.IncludeGroup);
        }

        public EntityCollection<TeacherPresentation> GetAll(TeacherCriteria criteria)
        {
            var query = from it in dataContext.Teachers.Where(it => !it.IsDelete) select it;
            if (!String.IsNullOrEmpty(criteria.Name))
            {
                query = from it in query
                    where (it.NameZh.Contains(criteria.Name.Trim()) || it.NameEn.Contains(criteria.Name))
                    select it;
            }

            if (!String.IsNullOrEmpty(criteria.TeacherGroupCode))
            {
                query = from it in query where it.TeacherGroupCode == criteria.TeacherGroupCode select it;
            }

            int totalCount = 0;
            query = PageingQueryable(query.OrderByDescending(it => it.ID), criteria, out totalCount);

            var list = query.Select(it => Translate2Presentation(it, criteria.IncludeCourse, criteria.IncludeGroup)).ToList();

            EntityCollection<TeacherPresentation> entityCollection = Translate2Presentations(list);
            entityCollection.TotalCount = totalCount;

            return entityCollection;
        }

        public ActionResult Save(TeacherPresentation presentation, bool includeCourse, bool includeGroup)
        {
            var teacher =
                dataContext.Teachers.FirstOrDefault(it => !it.IsDelete && it.TeacherNum == presentation.TeacherNum);
            if (teacher == null)
            {
                teacher = new LkDataContext.Teacher()
                {
                    TeacherNum = presentation.TeacherNum,
                    IsOnline = true
                };
                dataContext.Teachers.InsertOnSubmit(teacher);
            }

            teacher.ContactPhone = presentation.ContactPhone;
            teacher.DepartCode = presentation.DepartCode;
            teacher.Description = presentation.Description;
            teacher.EducationCode = presentation.EducationCode;
            teacher.Email = presentation.Email;
            teacher.IsMarried = presentation.IsMarried;
            teacher.IsOnline = presentation.IsOnline;
            teacher.MarjorName = presentation.MarjorName;
            teacher.NameEn = presentation.NameEn;
            teacher.NameZh = presentation.NameZh;
            teacher.NativePlace = presentation.NativePlace;
            teacher.Photo = presentation.Photo;
            teacher.School = presentation.School;
            teacher.Sex = (int)presentation.Sex;
            teacher.Telephone = presentation.Telephone;
            teacher.ThumbPath = presentation.ThumbPath;
            teacher.WorkingYear = presentation.WorkingYear;

            if (includeCourse)
            {
                foreach (var course in teacher.TeacherRelativeCourses)
                {
                    if (!presentation.RelativeCourses.Any(ic => ic.Id == course.ID))
                    {
                        dataContext.TeacherRelativeCourses.DeleteOnSubmit(course);
                    }
                }

                foreach (var course in presentation.RelativeCourses)
                {
                    if (!teacher.TeacherRelativeCourses.Any(ic => ic.ID == course.Id))
                    {
                        teacher.TeacherRelativeCourses.Add(new TeacherRelativeCourse()
                        {
                            BeginTime = course.BeginTime,
                            EndTime = course.EndTime,
                            BrokenTime = course.BrokenTime,
                            CourseCode = course.CourseCode,
                            IsAdviserTeacher = course.IsAdviserTeacher,
                            IsBroken = course.IsBroken,
                            MarjorCode = course.MarjorCode
                        });
                    }
                }
            }
            if (includeGroup)
            {

                foreach (var group in teacher.TeacherRelativeGroups)
                {
                    if (!presentation.RelativeGroups.Any(ic => ic.Code == group.GroupCode))
                    {
                        dataContext.TeacherRelativeGroups.DeleteOnSubmit(group);
                    }
                }

                foreach (var group in presentation.RelativeGroups)
                {
                    if (!teacher.TeacherRelativeGroups.Any(ic => ic.GroupCode == group.Code))
                    {
                        teacher.TeacherRelativeGroups.Add(new TeacherRelativeGroup()
                        {
                            GroupCode = group.Code,
                            CreateTime = DateTime.Now,
                            
                        });
                    }
                }
            }
            dataContext.SubmitChanges();

            return ActionResult.DefaultResult;
        }

        private TeacherPresentation Translate2Presentation(LkDataContext.Teacher teacher,bool includeCourse,bool includeGroup=false)
        {
            var presentation = new TeacherPresentation()
            {
                ContactPhone = teacher.ContactPhone,
                DepartCode = teacher.DepartCode,
                Description = teacher.Description,
                EducationCode = teacher.EducationCode,
                Email = teacher.Email,
                IsMarried = teacher.IsMarried,
                IsOnline = teacher.IsOnline,
                MarjorName = teacher.MarjorName,
                NameEn = teacher.NameEn,
                NameZh = teacher.NameZh,
                NativePlace = teacher.NativePlace,
                Photo = teacher.Photo,
                School = teacher.School,
                Sex = (SexType) teacher.Sex,
                Telephone = teacher.Telephone,
                ThumbPath = teacher.ThumbPath,
                WorkingYear = teacher.WorkingYear,
                TeacherNum = teacher.TeacherNum,
                Id = teacher.ID
            };

            if (includeCourse)
            {
                var index = 1;
                presentation.RelativeCourses =
                    teacher.TeacherRelativeCourses.Select(ic => new TeacherRelativeCoursePresentation()
                    {
                        BeginTime = ic.BeginTime,
                        EndTime = ic.EndTime,
                        BrokenTime = ic.BrokenTime,
                        CourseCode = ic.CourseCode,
                        IsAdviserTeacher = ic.IsAdviserTeacher,
                        MarjorCode = ic.MarjorCode,
                        TeacherNum = ic.TeacherNum,
                        Id = ic.ID,
                        Index = index++
                    }).ToList();
            }
            if (includeGroup)
            {
                var index = 1;
                presentation.RelativeGroups =
                    teacher.TeacherRelativeGroups.Select(ic => new TeacherGroupPresentation()
                    {
                        Code = ic.TeacherGroup.Code,
                        Name = ic.TeacherGroup.Name,
                        Description = ic.TeacherGroup.Description,
                        LastUpdateTime = ic.TeacherGroup.LastUpdateTime,
                        TeacherGroupType = (TeacherGroupType) ic.TeacherGroup.TeacherGroupType,
                        Index = index++
                    }).ToList();
            }

            return presentation;
        }

        public ActionResult Delete(int id)
        {
            var teacher = dataContext.Teachers.FirstOrDefault(ic => ic.ID == id);
            if (teacher == null)
            {
                return ActionResult.NotFoundResult;
            }
            teacher.IsDelete = true;
            dataContext.SubmitChanges();

            return ActionResult.DefaultResult;
        }
    }
}
