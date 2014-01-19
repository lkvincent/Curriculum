using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Presentation.UIView.Student;

namespace XmutLuckV1
{
    public static class SessionHelper
    {
        private const string RECOMMEND_SESSION_NAME = "RECOMMEND_SESSION_NAME";

        public static void AddRecommendStudentToSession(this HttpSessionState session,
                                                        List<StudentPresentation> studentPresentations)
        {
            var stuPresentationList = session[RECOMMEND_SESSION_NAME] as List<StudentPresentation>;
            if (stuPresentationList == null)
            {
                stuPresentationList = new List<StudentPresentation>();
            }
            studentPresentations.ForEach(it =>
                {
                    if (!stuPresentationList.Any(ic => ic.StudentNum == it.StudentNum))
                    {
                        stuPresentationList.Add(it);
                    }
                });

            session[RECOMMEND_SESSION_NAME] = stuPresentationList;
        }

        public static void UpdateRecommendStudentToSession(this HttpSessionState session,
                                                List<StudentPresentation> studentPresentations)
        {
            if (studentPresentations == null)
            {
                studentPresentations = new List<StudentPresentation>();
            }

            session[RECOMMEND_SESSION_NAME] = studentPresentations;
        }

        public static List<StudentPresentation> GetRecommendStudentFromSession(this HttpSessionState session)
        {
            var list = session[RECOMMEND_SESSION_NAME] as List<StudentPresentation>;
            if (list == null)
            {
                list = new List<StudentPresentation>();
            }
            return list;
        }

        public static void ClearRecommendCache(this HttpSessionState session)
        {
            session.Remove(RECOMMEND_SESSION_NAME);
        }
    }
}