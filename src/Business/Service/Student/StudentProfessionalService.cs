using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Business.Interface.Student;
using LkDataContext;
using Presentation.Criteria.Student;
using Presentation.Enum;
using Presentation.UIView;
using Presentation.UIView.Student;

namespace Business.Service.Student
{
    public class StudentProfessionalService : BaseService, IStudentProfessionalService
    {
        public StudentProfessionalPresentation Get(StudentProfessionalCriteria criteria)
        {
            var profession =
                dataContext.StudentProfessionals.FirstOrDefault(it => it.ID == criteria.Id);
            if (profession == null)
            {
                return null;
            }
            var presentation = Translate2Presentation(profession, criteria.IncludeRelativeData);

            return presentation;
        }

        public EntityCollection<StudentProfessionalPresentation> GetAll(StudentProfessionalCriteria criteria)
        {
            var query = from it in dataContext.StudentProfessionals where it.StudentNum == criteria.StudentNum select it;

            if (!String.IsNullOrEmpty(criteria.Name))
            {
                query = from it in query where it.Name.Contains(criteria.Name.Trim()) select it;
            }

            if (criteria.DateFrom.HasValue)
            {
                query = from it in query where it.ObtainTime.Date >= criteria.DateFrom select it;
            }

            if (criteria.DateTo.HasValue)
            {
                query = from it in query where it.ObtainTime.Date <= criteria.DateTo select it;
            }

            int totalCount = 0;
            query = PageingQueryable(query, criteria, out totalCount);

            var list = query.Select(profession => Translate2Presentation(profession, criteria.IncludeRelativeData)).ToList();

            EntityCollection<StudentProfessionalPresentation> entityCollection = Translate2Presentations(list);
            entityCollection.TotalCount = totalCount;

            return entityCollection;
        }

        public ActionResult Save(StudentProfessionalPresentation presentation)
        {
            var professional =
                dataContext.StudentProfessionals.FirstOrDefault(
                    it => it.ID == presentation.Id && it.StudentNum == presentation.StudentNum);
            if (professional == null)
            {
                professional = new StudentProfessional()
                {
                    StudentNum = presentation.StudentNum,
                    CreateTime = DateTime.Now
                };
                dataContext.StudentProfessionals.InsertOnSubmit(professional);
            }
            professional.Name = presentation.Name;
            professional.ObtainTime = presentation.ObtainTime;
            professional.Description = presentation.Description;
            professional.IsOnline = presentation.IsOnline;
            foreach (var attachment in professional.StudentProfessionalAttachments)
            {
                if (presentation.AttachmentPresentations.Any(ic => ic.ID == attachment.ID))
                {
                    dataContext.StudentProfessionalAttachments.DeleteOnSubmit(attachment);
                }
            }

            foreach (var attachment in  presentation.AttachmentPresentations.Where(it => it.IsNew))
            {
                professional.StudentProfessionalAttachments.Add(new StudentProfessionalAttachment()
                {
                    CreateTime = DateTime.Now,
                    Description = attachment.FileLabel,
                    DisplayOrder = attachment.DisplayOrder,
                    DocumentType = (int) attachment.DocumentType,
                    IsMain = attachment.IsMain,
                    Path = attachment.Path,
                    ThumbPath = attachment.ThumbPath
                });
            }

            dataContext.SubmitChanges();

            return ActionResult.DefaultResult;
        }

        public ActionResult Delete(string studentNum, int id)
        {
            var professional =
                dataContext.StudentProfessionals.FirstOrDefault(it => it.StudentNum == studentNum && it.ID == id);
            if (professional == null)
            {
                return ActionResult.CreateErrorActionResult("找不到数据!");
            }
            dataContext.StudentProfessionalAttachments.DeleteAllOnSubmit(professional.StudentProfessionalAttachments);
            dataContext.StudentProfessionals.DeleteOnSubmit(professional);
            dataContext.SubmitChanges();

            return ActionResult.DefaultResult;
        }

        public ActionResult SetStatus(string studentNum, int id, bool isOnline)
        {
            var professional =
                dataContext.StudentProfessionals.FirstOrDefault(ic => ic.StudentNum == studentNum && ic.ID == id);
            if (professional == null)
            {
                return ActionResult.NotFoundResult;
            }
            professional.IsOnline = isOnline;
            dataContext.SubmitChanges();

            return ActionResult.DefaultResult;
        }

        public IList<ContentPresentation> GetNewestFrontProfessionalList(string studentNum, out int totalCount)
        {
            var query = from it in GetBaseFrontQuery() where it.StudentNum == studentNum select it;
            totalCount = query.Count();
            return query.Take(10).Select(it => Translate2ContentPresentation(it)).ToList();
        }

        public StudentProfessionalPresentation GetFrontProfessionalById(int id, string studentNum)
        {
            var professional =
                GetBaseFrontQuery().Where(it => it.ID == id && it.StudentNum == studentNum).FirstOrDefault();
            if (professional == null)
            {
                return null;
            }
            return Translate2Presentation(professional, true);
        }

        public IList<ContentPresentation> GetFrontProfessionalList(string studentNum, string keyword)
        {
            var query = GetBaseFrontQuery().Where(it => it.StudentNum == studentNum);
            if (!String.IsNullOrEmpty(keyword))
            {
                query = query.Where(it => it.Name.Contains(keyword));
            }
            return query.Select(it => Translate2ContentPresentation(it)).ToList();
        }

        public IList<StudentProfessionalPresentation> GetFrontResumeProfessionalList(string studentNum, string keyword)
        {
            var query = GetBaseFrontQuery().Where(it => it.StudentNum == studentNum);
            if (!String.IsNullOrEmpty(keyword))
            {
                query = query.Where(it => it.Name.Contains(keyword));
            }
            return query.Select(it => Translate2Presentation(it, false)).ToList();
        }

        private IQueryable<StudentProfessional> GetBaseFrontQuery()
        {
            return dataContext.StudentProfessionals.Where(it => it.IsOnline);
        }

        private StudentProfessionalPresentation Translate2Presentation(StudentProfessional profession,bool includeRelativeData)
        {
            var presentation= new StudentProfessionalPresentation()
            {
                Id = profession.ID,
                Name = profession.Name,
                Description = profession.Description,
                CreateTime = profession.CreateTime,
                ObtainTime = profession.ObtainTime,
                IsOnline = profession.IsOnline,
                StudentNum = profession.StudentNum
            };
            if (includeRelativeData)
            {
                presentation.AttachmentPresentations =
                    profession.StudentProfessionalAttachments.Select(it => new AttachmentPresentation()
                    {
                        ID = it.ID,
                        DisplayOrder = it.DisplayOrder,
                        DocumentType = (DocumentType)it.DocumentType,
                        Path = it.Path,
                        ThumbPath = it.ThumbPath,
                        FileLabel = it.Description,
                        IsMain = it.IsMain
                    }).ToList();
            }

            return presentation;
        }

        private ContentPresentation Translate2ContentPresentation(StudentProfessional profession)
        {
            return new ContentPresentation()
            {
                Identity = profession.ID.ToString(),
                Name = profession.Name,
                ReferenceCode = profession.StudentNum,
                Time = profession.CreateTime
            };
        }
    }
}
