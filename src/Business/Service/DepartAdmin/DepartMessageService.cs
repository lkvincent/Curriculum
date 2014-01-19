using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Business.Interface.DepartAdmin;
using LkDataContext;
using Microsoft.SqlServer.Server;
using Presentation.Criteria.DepartAdmin;
using Presentation.UIView;
using Presentation.UIView.DepartAdmin;

namespace Business.Service.DepartAdmin
{
    public class DepartMessageService : BaseService, IDepartMessageService
    {
        public DepartMessagePresentation Get(int id)
        {
            var departMessage = dataContext.DepartMessages.FirstOrDefault(it => it.ID == id);
            if (departMessage == null)
            {
                return null;
            }

            return new DepartMessagePresentation()
            {
                Id = departMessage.ID,
                Title = departMessage.Title,
                Content = departMessage.Content,
                CreateTime = departMessage.CreateTime,
                DepartCode = departMessage.DepartCode,
                DepartAdminID = departMessage.DepartAdminID,
                IsOnline = departMessage.IsOnline,
                LastUpdateTime = departMessage.LastUpdateTime
            };
        }

        public ActionResult Save(DepartMessagePresentation presentation)
        {
            var departMessage = dataContext.DepartMessages.FirstOrDefault(it => it.ID == presentation.Id);
            if (departMessage == null)
            {
                departMessage = new DepartMessage()
                {
                    CreateTime = DateTime.Now,
                    DepartAdminID = presentation.DepartAdminID,
                    DepartCode = presentation.DepartCode
                };
                dataContext.DepartMessages.InsertOnSubmit(departMessage);
            }
            departMessage.Title = presentation.Title;
            departMessage.Content = presentation.Content;
            departMessage.IsOnline = presentation.IsOnline;
            departMessage.LastUpdateTime = DateTime.Now;

            dataContext.SubmitChanges();

            return ActionResult.DefaultResult;
        }

        public EntityCollection<DepartMessagePresentation> GetAll(DepartMessageCriteria criteria)
        {
            var query = from it in dataContext.DepartMessages select it;
            if (!String.IsNullOrEmpty(criteria.Title))
            {
                query = from it in query where it.Title.Contains(criteria.Title.Trim()) select it;
            }

            int totalCount = 0;
            query = PageingQueryable(query.OrderByDescending(it => it.CreateTime), criteria, out totalCount);

            var list = query.Select(departMessage => new DepartMessagePresentation()
            {
                Id = departMessage.ID,
                Title = departMessage.Title,
                Content = departMessage.Content,
                CreateTime = departMessage.CreateTime,
                DepartCode = departMessage.DepartCode,
                DepartAdminID = departMessage.DepartAdminID,
                IsOnline = departMessage.IsOnline,
                LastUpdateTime = departMessage.LastUpdateTime
            }).ToList();

            EntityCollection<DepartMessagePresentation> entityCollection = Translate2Presentations(list);
            entityCollection.TotalCount = totalCount;

            return entityCollection;
        }

        public ActionResult Delete(int id)
        {
            var departMessage = dataContext.DepartMessages.FirstOrDefault(it => it.ID == id);
            if (departMessage == null)
            {
                return ActionResult.NotFoundResult;
            }

            dataContext.DepartMessages.DeleteOnSubmit(departMessage);
            dataContext.SubmitChanges();

            return ActionResult.DefaultResult;
        }


        public EntityCollection<DepartMessagePresentation> GetTop20FrontMessageList()
        {
            var list = dataContext.GetTop20ArticleList().Select(it => new DepartMessagePresentation()
            {
                Id = it.ID,
                Title = it.Title,
                CreateTime = it.CreateTime,
                DepartAdminID = it.DepartAdminID,
                DepartCode = it.DepartCode,
                Content = it.Content,
                IsOnline = it.IsOnline,
                LastUpdateTime = it.LastUpdateTime
            }).ToList();

            var entityCollection = Translate2Presentations<DepartMessagePresentation>(list);
            return entityCollection;
        }


        public EntityCollection<MessageUiPresentation> GetFrontMessageList(int pageIndex, int pageSize)
        {
            var query = from it in dataContext.DepartMessages where it.IsOnline select it;
            int totalCount = 0;
            query = PageingQueryable(query.OrderByDescending(it => it.CreateTime), new DepartMessageCriteria()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                NeedPaging = true
            }, out totalCount);

            var list = query.Select(departMessage => new MessageUiPresentation()
            {
                Id = departMessage.ID,
                Title = departMessage.Title,
                LastUpdateTime = departMessage.LastUpdateTime
            }).ToList();

            EntityCollection<MessageUiPresentation> entityCollection = Translate2Presentations(list);
            entityCollection.TotalCount = totalCount;

            return entityCollection;
        }


        public ActionResult SetStatus(int departAdminId, int id, bool isOnline)
        {
            var departMessage = dataContext.DepartMessages.FirstOrDefault(ic => ic.DepartAdminID == departAdminId && ic.ID == id);
            if (departMessage == null) return ActionResult.NotFoundResult;
            departMessage.IsOnline = isOnline;
            dataContext.SubmitChanges();

            return ActionResult.DefaultResult;
        }
    }
}
