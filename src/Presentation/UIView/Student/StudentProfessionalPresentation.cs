using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.UIView.Student
{
    [Serializable]
    public class StudentProfessionalPresentation:BasePresentation
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public DateTime ObtainTime
        {
            get; set;
        }

        public DateTime CreateTime
        {
            get; set;
        }

        public string StudentNum
        {
            get; set;
        }

        public bool IsOnline
        {
            get; set;
        }

        private IList<AttachmentPresentation> _AttachmentPresentations;
        public IList<AttachmentPresentation> AttachmentPresentations
        {
            get
            {
                if (_AttachmentPresentations == null)
                {
                    _AttachmentPresentations=new List<AttachmentPresentation>();
                }
                return _AttachmentPresentations;
            }
            set
            {
                _AttachmentPresentations = value;
            }
        }
    }
}
