using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Criteria.Student
{
    public class BaseStudentCriteria:BaseCriteria
    {
        private string _StudentNum;
        public string StudentNum
        {
            get
            {
                if (String.IsNullOrEmpty(_StudentNum))
                {
                    return CurrentUser.UserName;
                }
                return _StudentNum;
            }
            set
            {
                _StudentNum = value;
            }
        }
    }
}
