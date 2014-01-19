using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interface.Enterprise;
using LkDataContext;
using Presentation.Criteria.Enterprise;
using Presentation.Enum;
using Presentation.UIView;
using Presentation.UIView.Enterprise;
using Presentation.UIView.Enterprise.View;

namespace Business.Service.Enterprise
{
    public class EnterpriseRecruitBatchService:BaseService,IEnterpriseRecruitBatchService
    {
        private IEnterpriseJobRequestService jobRequestService;

        public EnterpriseRecruitBatchService()
        {
            jobRequestService = new EnterpriseJobRequestService();
        }

        public EnterpriseRecruitBatchPresentation Get(int id)
        {
            var recruitBatch = dataContext.EnterpriseRecruitBatches.FirstOrDefault(it => it.ID == id);
            if (recruitBatch == null) return null;

            return new EnterpriseRecruitBatchPresentation()
            {
                Id = recruitBatch.ID,
                Title = recruitBatch.Title,
                Description = recruitBatch.Description,
                EnterpriseCode = recruitBatch.EnterpriseCode,
                JobRequestPresentations =
                    jobRequestService.GetAllByBatchId(recruitBatch.ID, recruitBatch.EnterpriseCode)
            };
        }

        public ActionResult Save(EnterpriseRecruitBatchPresentation presentation)
        {
            var recruitBatch = dataContext.EnterpriseRecruitBatches.FirstOrDefault(it => it.ID == presentation.Id &&
                                                                                         it.EnterpriseCode ==
                                                                                         presentation.EnterpriseCode);
            if (recruitBatch == null)
            {
                recruitBatch = new EnterpriseRecruitBatch()
                {
                    EnterpriseCode = presentation.EnterpriseCode
                };
                dataContext.EnterpriseRecruitBatches.InsertOnSubmit(recruitBatch);
            }
            recruitBatch.Title = presentation.Title;
            recruitBatch.Description = presentation.Description;

            foreach (var batchRelative in recruitBatch.EnterpriseBatchRelatives)
            {
                if (!presentation.JobRequestPresentations.Any(ic=>ic.Id==batchRelative.JobRequestID))
                {
                    dataContext.EnterpriseBatchRelatives.DeleteOnSubmit(batchRelative);
                }
            }

            foreach (var batchRelative in presentation.JobRequestPresentations)
            {
                if (!recruitBatch.EnterpriseBatchRelatives.Any(ic => ic.JobRequestID == batchRelative.Id))
                {
                    recruitBatch.EnterpriseBatchRelatives.Add(new EnterpriseBatchRelative()
                    {
                        CreateTime = DateTime.Now,
                        JobRequestID = batchRelative.Id
                    });
                }
            }

            dataContext.SubmitChanges();

            return ActionResult.DefaultResult;
        }

        public ActionResult Delete(int id)
        {
            var recruitBatch = dataContext.EnterpriseRecruitBatches.FirstOrDefault(it => it.ID == id);
            if (recruitBatch == null)
            {
                return ActionResult.NotFoundResult;
            }
            dataContext.EnterpriseRecruitBatches.DeleteOnSubmit(recruitBatch);
            dataContext.SubmitChanges();

            return ActionResult.DefaultResult;
        }

        public EntityCollection<EnterpriseRecruitBatchStatisticsPresentation> GetAllStatistics(
            EnterpriseRecruitBatchCriteria criteria)
        {
            var query = from it in dataContext.EnterpriseRecruitBatches
                where it.EnterpriseCode == criteria.EnterpriseCode
                select it;
            if (!String.IsNullOrEmpty(criteria.Title))
            {
                query = query.Where(it => it.Title.Contains(criteria.Title.Trim())).Select(it => it);
            }

            if (!String.IsNullOrEmpty(criteria.Description))
            {
                query = query.Where(it => it.Description.Contains(criteria.Description.Trim())).Select(it => it);
            }

            int totalCount = 0;
            query = PageingQueryable(query.OrderByDescending(it => it.ID), criteria, out totalCount);

            var list = query.Select(ix => new
            {
                ix.ID,
                ix.Title,
                ix.EnterpriseBatchRelatives,
            }).ToList().Select(it => new EnterpriseRecruitBatchStatisticsPresentation()
            {
                Id = it.ID,
                Title = it.Title,
                DenyNum =
                    it.EnterpriseBatchRelatives.Count(ix => StatisticsWhereFunc(ix, RecruitType.NoPassed)),
                InterviewNum =
                    it.EnterpriseBatchRelatives.Count(ix => StatisticsWhereFunc(ix, RecruitType.Interviewing)),
                PassedNum = it.EnterpriseBatchRelatives.Count(ix => StatisticsWhereFunc(ix, RecruitType.Passed)),
                ProcessLessNum = it.EnterpriseBatchRelatives.Count(ix => StatisticsWhereFunc(ix, RecruitType.Request)),
                RequestNum = it.EnterpriseBatchRelatives.Count()
            }).ToList();

            EntityCollection<EnterpriseRecruitBatchStatisticsPresentation> entityCollection =
                Translate2Presentations(list);
            entityCollection.TotalCount = totalCount;

            return entityCollection;
        }

        private bool StatisticsWhereFunc(EnterpriseBatchRelative relative, RecruitType recruitType)
        {
            //return relative.EnterpriseJobRequester.JobRequestRecruitStages.Any() &&
            //       relative.EnterpriseJobRequester.JobRequestRecruitStages.Any(
            //           ix => ix.RecruitFlowSetted.RecruitType == (int) recruitType);
            if (relative.EnterpriseJobRequester.JobRequestRecruitStages.Any())
            {
                var stage =
                    relative.EnterpriseJobRequester.JobRequestRecruitStages.OrderByDescending(it => it.ID)
                        .FirstOrDefault();
                if (recruitType == RecruitType.Interviewing)
                {
                    return (stage.RecruitFlowSetted.RecruitType == (int) RecruitType.Interviewing ||
                            stage.RecruitFlowSetted.RecruitType == (int) RecruitType.Invited ||
                            stage.RecruitFlowSetted.RecruitType == (int) RecruitType.View);
                }
                else
                {
                    return stage.RecruitFlowSetted.RecruitType == (int) recruitType;
                }
            }
            if (recruitType == RecruitType.Request)
            {
                return true;
            }
            return false;
        }
    }
}
