using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LkDataContext;
using Presentation.Criteria;
using Presentation.UIView;

namespace Business.Service
{
    public class BaseService
    {
        private CVAcademicianDataContext _dataContext;
        public CVAcademicianDataContext dataContext
        {
            get
            {
                if (_dataContext == null)
                {
                    _dataContext = new CVAcademicianDataContext();
                }
                return _dataContext;
            }
        }

        public void WriteLog(string message)
        {
            
        }

        public void WriteLog(Exception exception)
        {
            
        }

        protected IQueryable<T> PageingQueryable<T>(IQueryable<T> query, BaseCriteria criteria,out int totalCount)
        {
            totalCount = query.Count();

            if (criteria.NeedPaging)
            {
                query =
                    query.Take(criteria.PageSize)
                        .Skip(criteria.PageSize * criteria.PageIndex)
                        .Select(it => it);
            }

            return query;
        }

        protected EntityCollection<T> Translate2Presentations<T>(List<T> list) where T : BasePresentation, new()
        {
            int index = 0;
            EntityCollection<T> entityCollection =
                new EntityCollection<T>();
            list.ForEach(it =>
            {
                it.Index = ++index;
                entityCollection.Add(it);
            });

            return entityCollection;
        }
    }
}
