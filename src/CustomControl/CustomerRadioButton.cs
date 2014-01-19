using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomControl
{
    public class CustomerRadioButton:CompositeControl,IPostBackDataHandler
    {
        #region GroupName
        /// <summary>
        /// GroupName
        /// </summary>
        public string GroupName
        {
            get
            {
                if (this.ViewState["GroupName"] == null) return this.UniqueID;
                return this.ViewState["GroupName"].ToString();
            }
            set
            {
                this.ViewState["GroupName"] = value;
            }
        }
        #endregion

        #region Checked
        /// <summary>
        /// Checked
        /// </summary>
        public bool Checked
        {
            get
            {
                if (this.ViewState["Checked"] == null) return false;
                return (bool)this.ViewState["Checked"];
            }
            set
            {
                this.ViewState["Checked"] = value;
            }
        }
        #endregion

        public string ValueAttribute
        {
            get
            {
                if (this.Attributes["value"] == null) return UniqueID;
                return this.Attributes["value"];
            }
        }

        public virtual bool AutoPostBack
        {
            get
            {
                if (this.ViewState["AutoPostBack"] == null) return false;
                return (bool)this.ViewState["AutoPostBack"];
            }
            set
            {
                this.ViewState["AutoPostBack"] = value;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Id, this.UniqueID);
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "radio");
            writer.AddAttribute(HtmlTextWriterAttribute.Name, GroupName);
            writer.AddAttribute(HtmlTextWriterAttribute.Value, ValueAttribute);
            if (AutoPostBack)
            {
                PostBackOptions option = new PostBackOptions(this, string.Empty);
                if (this.Page.Form != null)
                {
                    option.AutoPostBack = true;
                }
                writer.AddAttribute(HtmlTextWriterAttribute.Onclick, this.Page.ClientScript.GetPostBackEventReference(option));
            }

            if (this.Checked)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Checked, "true");
            }
            if (this.Page != null)
            {
                this.Page.VerifyRenderingInServerForm(this);
            }
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag();
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (this.Page != null)
            {
                this.Page.RegisterRequiresPostBack(this);
            }
        }

        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            var eventArgument = postCollection[GroupName];
            if (!string.IsNullOrEmpty(eventArgument) && eventArgument.Equals(this.ValueAttribute))
            {
                this.Checked = !this.Checked;
                return true;
            }
            return false;
        }

        public void RaisePostDataChangedEvent()
        {
            RaiseBubbleEvent(this, new EventArgs());            
        }
    }
}
