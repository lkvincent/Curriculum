using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentation.Enum;

namespace XmutLuckV1
{
    public partial class MessageBoxItem : BasePage
    {
        protected int RefMessageId
        {
            get
            {
                int refMsgId = 0;
                int.TryParse(Request.QueryString["RefMsgID"], out refMsgId);
                return refMsgId;
            }
        }

        protected string ReceiverName
        {
            get { return Request.QueryString["ReceiverName"]; }
        }

        protected string ReceiverType
        {
            get { return Request.QueryString["ReceiverType"]; }
        }

        public override UserType InitUserType()
        {
            return UserType.Guest;
        }

        public override AttachmentType InitAttachmentType()
        {
            throw new NotImplementedException(); 
        }
    }
}