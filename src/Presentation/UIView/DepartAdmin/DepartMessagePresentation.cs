using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.UIView.DepartAdmin
{
    [Serializable]
    public class DepartMessagePresentation:BasePresentation
    {
        public int Id
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }

        public string Content
        {
            get; set;
        }

        public DateTime CreateTime
        {
            get; set;
        }

        public bool IsOnline
        {
            get; set;
        }

        public string DepartCode
        {
            get; set;
        }

        public int DepartAdminID
        {
            get; set;
        }

        public DateTime LastUpdateTime
        {
            get; set;
        }
    }

    public class MessageUiPresentation : BasePresentation
    {
        public int Id
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public DateTime LastUpdateTime
        {
            get;
            set;
        }
    }
}
