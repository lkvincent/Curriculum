using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XmutLuckV1.Manage.UserControl
{
    public partial class EditorControl : BaseUserControl
    {
        protected override void InitData()
        {
            string path = string.Format("~/Upload/{0}/{1}/DocImage/", UserType.ToString(), MemberID);
            var dictionary = new System.IO.DirectoryInfo(Server.MapPath(path));
            if (!dictionary.Exists)
            {
                dictionary.Create();
            }
            this.radEditor1.ImageManager.ViewPaths =
                this.radEditor1.ImageManager.DeletePaths =
                this.radEditor1.ImageManager.UploadPaths = new string[] { path };

            base.InitData();
        }

        public int EditorWidth
        {
            get
            {
                return (int)this.radEditor1.Width.Value;
            }
            set
            {
                this.radEditor1.Width = value;
            }
        }

        public int EditorHeight
        {
            get
            {
                return (int)this.radEditor1.Height.Value;
            }
            set
            {
                this.radEditor1.Height = value;
            }
        }

        public bool EditorEnabled
        {
            set
            {
                this.radEditor1.Enabled = value;
            }
        }

        public void LoadData(string content)
        {
            this.radEditor1.Content = content;
        }

        public string SaveData()
        {
            return this.radEditor1.Content;
        }
    }
}