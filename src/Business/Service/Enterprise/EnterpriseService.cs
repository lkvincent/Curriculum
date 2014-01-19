using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Business.Interface;
using Business.Interface.Enterprise;
using LkDataContext;
using Presentation.Cache;
using Presentation.Criteria.Enterprise;
using Presentation.Enum;
using Presentation.UIView;
using Presentation.UIView.Enterprise;
using WebLibrary;
using WebLibrary.Helper;

namespace Business.Service.Enterprise
{
    public partial class EnterpriseService : BaseService, IAuthenticateService, IEnterpriseService
    {
        #region IAuthenticateService
        public LoginUserPresentation Login(string userName, string password)
        {
            var enterprise = dataContext.Enterprises.FirstOrDefault(
                it =>
                    !it.IsDeleted && it.UserName == userName &&
                    it.Password == AccountSecurityManage.MD5Password(password));
            if (enterprise!=null)
            {
                return new LoginUserPresentation()
                {
                    Id = enterprise.ID,
                    Identity = enterprise.Code,
                    LogTime = DateTime.Now,
                    UserName = enterprise.UserName,
                    UserType = UserType.Enterprise,
                    UserLabel = enterprise.Name,
                    AddtionalUser = new Dictionary<string, string>()
                    {
                        {"isPermission", ((VerifyStatus)enterprise.VerifyStatus==VerifyStatus.Passed).ToString()}
                    }
                };
            }
            return null;
        }

        public ActionResult ChangePassword(string userName, string oldPassword, string newPassword)
        {
            try
            {
                var enterprise =
                    dataContext.Enterprises.FirstOrDefault(
                        it =>
                            !it.IsDeleted && it.UserName == userName &&
                            it.Password == AccountSecurityManage.MD5Password(oldPassword));
                if (enterprise == null)
                {
                    return ActionResult.CreateErrorActionResult("原密码错误!");
                }
                enterprise.Password = AccountSecurityManage.MD5Password(newPassword);

                dataContext.SubmitChanges();

                return new ActionResult
                {
                    IsSucess = true,
                    Message = "密码修改成功!"
                };
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

        public ActionResult ResetPassword(string userName, UserType userType, string checkCode)
        {
            if (CheckCodeHelper.ValidateCheckCode(userType.ToString(), checkCode))
            {
                var result = ActionResult.DefaultResult;
                var enterprise = dataContext.Enterprises.FirstOrDefault(it => it.UserName == userName);
                if (enterprise != null)
                {
                    if (!String.IsNullOrEmpty(enterprise.Email))
                    {
                        var newPassword = AccountSecurityManage.GenerateRadomPassword();
                        enterprise.Password = AccountSecurityManage.MD5Password(newPassword);
                        dataContext.MailQueues.InsertOnSubmit(new MailQueue()
                        {
                            CreateTime = DateTime.Now,
                            Cc = null,
                            IsSended = false,
                            Name =
                                EmailTemplateHelper.FormatterResetPasswordContent(enterprise.Name, userName, newPassword,
                                    EmailTemplateHelper.GetEmailTemplateSubject(SystemEmailType.ResetPassword)),
                            Sender = EmailTemplateHelper.MailSender,
                            Receiver = enterprise.Email,
                            ReceiverName = enterprise.Email,
                            Message =
                                EmailTemplateHelper.FormatterResetPasswordContent(enterprise.Name, userName, newPassword,
                                    EmailTemplateHelper.GetEmailTemplateBody(SystemEmailType.ResetPassword))
                        });
                        dataContext.SubmitChanges();

                        return new ActionResult()
                        {
                            Message = string.Format("密码重置成功! 已经发送至您的邮箱:{0}", enterprise.Email)
                        };
                    }
                    return new ActionResult()
                    {
                        IsSucess = false,
                        Message = "用户Email信息为空,无法进行密码重置, 请联系管理员!"
                    };
                }
                return new ActionResult
                {
                    IsSucess = false,
                    Message = "用户名无效!"
                };
            }
            return ActionResult.CreateErrorActionResult("验证码错误!");
        }
        #endregion

        public ActionResult SetVerifyStatus(int Id, VerifyStatus status)
        {
            var enterprise = dataContext.Enterprises.FirstOrDefault(it => it.ID == Id);
            if (enterprise == null)
            {
                return new ActionResult()
                {
                    IsSucess = false,
                    Message = String.Format("该企业已经不存在(Id={0})", Id)
                };
            }
            enterprise.VerifyStatus = (int) status;
            dataContext.SubmitChanges();

            return ActionResult.DefaultResult;
        }

        public EntityCollection<EnterpriseTopPresentation> GetFrontHotEnterpriseList(HotEnterpriseType type, int pageIndex,
                                                                             int pageSize)
        {
            List<EnterpriseTopPresentation> list = new List<EnterpriseTopPresentation>();
            switch (type)
            {
                case HotEnterpriseType.TopHotJob:
                    list = GetTopHotJobEnterprise(pageSize);
                    break;
                case HotEnterpriseType.TopNewest:
                    list = GetTopNewestEnterprise(pageSize);
                    break;
                case HotEnterpriseType.TopNotified:
                    list = GetTopNotifiedEnterprise(pageSize);
                    break;
                case HotEnterpriseType.TopSalary:
                    list = GetTopSalaryEnterprise(pageSize);
                    break;
            }
            EntityCollection<EnterpriseTopPresentation> entityCollection = Translate2Presentations(list);
            entityCollection.TotalCount = entityCollection.Count;

            return entityCollection;
        }

        public EntityCollection<EnterprisePresentation> GetFrontEnterpriseList(string keyword, int pageIndex, int pageSize)
        {
            var query = from it in GetBaseFrontQuery() select it;

            if (!String.IsNullOrEmpty(keyword))
            {
                query = from it in query
                    where it.Name.Contains(keyword.Trim()) || it.Description.Contains(keyword.Trim())
                    select it;
            }

            var list =
                query.Skip((pageIndex - 1)*pageSize)
                    .Take(pageSize)
                    .Select(it => Translate2Presentation(it, false))
                    .ToList();

            EntityCollection<EnterprisePresentation> entityCollection = Translate2Presentations(list);
            entityCollection.TotalCount = entityCollection.Count;

            return entityCollection;
        }

        public EnterprisePresentation GetFrontEnterpriseByCode(string enterpriseCode)
        {
            var enterprise =
                dataContext.Enterprises.FirstOrDefault(it => !it.IsDeleted && it.IsOnline && it.Code == enterpriseCode);
            if (enterprise == null)
            {
                return null;
            }
            return Translate2Presentation(enterprise, true);
        }

        public ActionResult Register(EnterprisePresentation presentation, out int enterpriseId)
        {
            enterpriseId = 0;
            if (String.IsNullOrEmpty(presentation.Email))
            {
                return ActionResult.CreateErrorActionResult("Email不能为空!");
            }

            if (String.IsNullOrEmpty(presentation.UserName))
            {
                return ActionResult.CreateErrorActionResult("用户名不能为空!");
            }

            if (String.IsNullOrEmpty(presentation.Name))
            {
                return ActionResult.CreateErrorActionResult("企业名称不能为空!");
            }

            if (String.IsNullOrEmpty(presentation.LicenseNo))
            {
                return ActionResult.CreateErrorActionResult("营业执照号码不能为空!");
            }

            if (dataContext.Enterprises.Any(ic => ic.Email == presentation.Email))
            {
                return new ActionResult
                {
                    IsSucess = false,
                    Message = "该邮件已经注册过."
                };
            }

            if (dataContext.Enterprises.Any(ic => ic.UserName == presentation.UserName))
            {
                return new ActionResult
                {
                    IsSucess = false,
                    Message = "该用户名已经注册过了."
                };
            }

            if (dataContext.Enterprises.Any(ic => ic.Name == presentation.Name.Trim()))
            {
                return new ActionResult
                {
                    IsSucess = false,
                    Message = "该企业名称已经注册过了."
                };
            }

            if (dataContext.Enterprises.Any(ic => ic.LicenseNo == presentation.LicenseNo.Trim()))
            {
                return new ActionResult
                {
                    IsSucess = false,
                    Message = "该营业执照号码已经注册过了."
                };
            }

            var enterprise = new LkDataContext.Enterprise()
            {
                Code = GenerateCodeHelper.GenerateCode(GenerateCodeHelper.GenerateCodeType.Enterprise, null),
                CreateTime = DateTime.Now,
                Email = presentation.Email,
                Address = presentation.Address,
                ContactName = presentation.ContactName,
                ContactPhone = presentation.ContactPhone,
                Corporation = presentation.Corporation,
                Description =
                    String.IsNullOrEmpty(presentation.Description) ? presentation.Name : presentation.Description,
                EnterpriseTypeCode = presentation.EnterpriseTypeCode,
                IndustryCode = presentation.IndustryCode,
                IsOnline = presentation.IsOnline,
                LicenseNo = presentation.LicenseNo,
                RegionCode = presentation.RegionCode,
                ScopeCode = presentation.ScopeCode,
                UserName = presentation.UserName,
                VerifyStatus = (int) presentation.VerifyStatus,
                WebSite = presentation.WebSite,
                UpdateTime = DateTime.Now,
                Name = presentation.Name,
                Password = AccountSecurityManage.MD5Password(presentation.Password)
            };
            try
            {
                dataContext.Enterprises.InsertOnSubmit(enterprise);
                EmailTemplateHelper.InitialEnterpriseEmailTemplate(enterprise);
                dataContext.SubmitChanges();

                enterpriseId = enterprise.ID;
                presentation.Id = enterpriseId;
                presentation.Code = enterprise.Code;
                return new ActionResult
                {
                    IsSucess = true,
                    Message = "注册成功!"
                };
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
            return new ActionResult
            {
                IsSucess = false,
                Message = "注册失败"
            };
        }

        public static void AddVisitedRecord(string enterpriseCode, string IPAddress, string userName, UserType userType)
        {
            using (CVAcademicianDataContext dataContext = new CVAcademicianDataContext())
            {
                if (
                    dataContext.EnterpriseVisiteds.Any(
                        it =>
                            it.VisitTime > DateTime.Now.AddHours(-1) && it.EnterpriseCode == enterpriseCode &&
                            it.IPAddress == IPAddress))
                {
                    dataContext.EnterpriseVisiteds.InsertOnSubmit(new EnterpriseVisited()
                    {
                        EnterpriseCode = enterpriseCode,
                        IPAddress = IPAddress,
                        VisitTime = DateTime.Now,
                        UserType = (int) userType,
                        UserName = userName
                    });

                    dataContext.SubmitChanges();
                }
            }
        }

        public ActionResult Delete(int id)
        {
            var enterprise = dataContext.Enterprises.FirstOrDefault(it => it.ID == id);
            if (enterprise != null)
            {
                enterprise.IsDeleted = true;

                dataContext.SubmitChanges();
            }
            return ActionResult.DefaultResult;
        }

        public EnterprisePresentation Get(string code)
        {
            var enterprise = dataContext.Enterprises.FirstOrDefault(it => it.Code == code);
            if (enterprise == null)
            {
                return null;
            }
            return Translate2Presentation(enterprise, false);
        }

        public ActionResult Save(EnterprisePresentation presentation)
        {
            var enterprise = dataContext.Enterprises.FirstOrDefault(it => it.Code == presentation.Code);
            if (enterprise == null)
            {
                return ActionResult.CreateErrorActionResult("找不到数据!");
            }

            enterprise.Address = presentation.Address;
            enterprise.ContactName = presentation.ContactName;
            enterprise.ContactPhone = presentation.ContactPhone;
            enterprise.Corporation = presentation.Corporation;
            enterprise.Description = presentation.Description;
            enterprise.Email = presentation.Email;
            enterprise.EnterpriseTypeCode = presentation.EnterpriseTypeCode;
            enterprise.IndustryCode = presentation.IndustryCode;
            enterprise.IsOnline = presentation.IsOnline;
            enterprise.LicenseNo = presentation.LicenseNo;
            enterprise.RegionCode = presentation.RegionCode;
            enterprise.ScopeCode = presentation.ScopeCode;
            enterprise.WebSite = presentation.WebSite;
            enterprise.Name = presentation.Name;

            dataContext.SubmitChanges();

            return ActionResult.DefaultResult;
        }

        public EntityCollection<EnterprisePresentation> GetAll(EnterpriseCriteria criteria)
        {
            var query = from it in dataContext.Enterprises where !it.IsDeleted select it;
            if (!String.IsNullOrEmpty(criteria.Name))
            {
                query = from it in query where it.Name.Contains(criteria.Name.Trim()) select it;
            }

            int totalCount = 0;
            query = PageingQueryable(query.OrderByDescending(it => it.CreateTime), criteria, out totalCount);

            var list = query.Select(enterprise => Translate2Presentation(enterprise, false)).ToList();

            EntityCollection<EnterprisePresentation> entityCollection = Translate2Presentations(list);
            entityCollection.TotalCount = totalCount;

            return entityCollection;
        }

        public static void ReflashEnterpriseTemplate()
        {
            using (CVAcademicianDataContext dataContext = new CVAcademicianDataContext())
            {
                foreach (var enterprise in dataContext.Enterprises)
                {
                    EmailTemplateHelper.InitialEnterpriseEmailTemplate(enterprise);   
                }

                dataContext.SubmitChanges();
            }
        }
    }

    partial class EnterpriseService
    {
        #region GetTopNotifiedEnterprise
        private List<EnterpriseTopPresentation> GetTopNotifiedEnterprise(int pageSize)
        {
            var query = from it in GetBaseFrontQuery()
                        select new
                        {
                            it.Code,
                            it.Name,
                            it.WebSite,
                            VisitCount = (it.EnterpriseVisiteds.Count())
                        };

            query = from it in query orderby it.VisitCount descending select it;

            var list = query.Take(pageSize).Select(enterprise => new EnterpriseTopPresentation()
            {
                Code = enterprise.Code,
                Name = enterprise.Name,
                WebSite = enterprise.WebSite,
            }).ToList();


            EntityCollection<EnterpriseTopPresentation> entityCollection = Translate2Presentations(list);

            return entityCollection;
        }
        #endregion

        #region GetTopSalaryEnterprise
        private List<EnterpriseTopPresentation> GetTopSalaryEnterprise(int pageSize)
        {
            var query = from it in GetBaseFrontQuery()
                        select new
                        {
                            it.Code,
                            it.Name,
                            it.WebSite,
                            HightestSalary = (it.EnterpriseJobs.Where(ic => ic.IsOnline).Max(ic => ic.SalaryScope))
                        };

            query = from it in query orderby it.HightestSalary descending select it;

            var list = query.Take(pageSize).Select(enterprise => new EnterpriseTopPresentation()
            {
                Code = enterprise.Code,
                Name = enterprise.Name,
                WebSite = enterprise.WebSite,
            }).ToList();


            EntityCollection<EnterpriseTopPresentation> entityCollection = Translate2Presentations(list);

            return entityCollection;
        }
        #endregion

        #region GetTopHotJobEnterprise
        private List<EnterpriseTopPresentation> GetTopHotJobEnterprise(int pageSize)
        {
            var query = from it in GetBaseFrontQuery()
                        select new
                        {
                            it.Code,
                            it.Name,
                            RequestCount =
                                (dataContext.EnterpriseJobRequesters.Where(
                                    ic => it.EnterpriseJobs.Any(ix => ix.Name.Trim() == ic.EnterpriseJob.Name.Trim().ToLower()))
                                    .Count())
                        };

            query = from it in query orderby it.RequestCount descending select it;

            var list = query.Take(pageSize).Select(enterprise => new EnterpriseTopPresentation()
            {
                Code = enterprise.Code,
                Name = enterprise.Name,
            }).ToList();


            EntityCollection<EnterpriseTopPresentation> entityCollection = Translate2Presentations(list);

            return entityCollection;
        }
        #endregion

        #region GetTopNewestEnterprise
        private List<EnterpriseTopPresentation> GetTopNewestEnterprise(int pageSize)
        {
            var query = from it in GetBaseFrontQuery() orderby it.CreateTime descending select it;

            var list = query.Take(pageSize).Select(enterprise => new EnterpriseTopPresentation()
            {
                Code = enterprise.Code,
                Name = enterprise.Name,
            }).ToList();

            EntityCollection<EnterpriseTopPresentation> entityCollection = Translate2Presentations(list);

            return entityCollection;
        }
        #endregion

        private EnterprisePresentation Translate2Presentation(LkDataContext.Enterprise enterprise, bool includeRelativeData)
        {
            var presentation = new EnterprisePresentation()
            {
                Address = enterprise.Address,
                Code = enterprise.Code,
                ContactName = enterprise.ContactName,
                ContactPhone = enterprise.ContactPhone,
                Corporation = enterprise.Corporation,
                CreateTime = enterprise.CreateTime,
                Description = enterprise.Description,
                Email = enterprise.Email,
                EnterpriseTypeCode = enterprise.EnterpriseTypeCode,
                Id = enterprise.ID,
                IndustryCode = enterprise.IndustryCode,
                LicenseNo = enterprise.LicenseNo,
                Name = enterprise.Name,
                RegionCode = enterprise.RegionCode,
                ScopeCode = enterprise.ScopeCode,
                UserName = enterprise.UserName,
                VerifyStatus = (VerifyStatus)enterprise.VerifyStatus,
                WebSite = enterprise.WebSite,
                IsOnline = enterprise.IsOnline
            };
            if (includeRelativeData)
            {
                presentation.JobPresentations = enterprise.EnterpriseJobs.Select(it => new EnterpriseJobPresentation()
                {
                    Code = it.Code,
                    Name = it.Name,
                    Num = it.Num,
                    Education = it.Education,
                    EndTime = it.EndTime,
                    StartTime = it.StartTime,
                    WorkPlace = it.WorkPlace,
                    SalaryScope = it.SalaryScope,
                    Address = it.Address,
                    AgeScope = it.AgeScope,
                    ContactName = it.ContactName,
                    Description = it.Description,
                    IsOnline = it.IsOnline,
                    Telephone = it.Telephone,
                    CreateTime = it.CreateTime,
                    DepartName = it.DepartName,
                    Tax = it.Tax,
                    Nature = it.Nature,
                    Professional = it.Professional,
                    RecruitmentTargets = it.RecruitmentTargets,
                    Sex = it.Sex
                }).ToList();
            }

            return presentation;
        }

        private IQueryable<LkDataContext.Enterprise> GetBaseFrontQuery()
        {
            return
                dataContext.Enterprises.Where(
                    it => !it.IsDeleted && it.IsOnline && it.VerifyStatus == (int)VerifyStatus.Passed);
        }
    }
}
