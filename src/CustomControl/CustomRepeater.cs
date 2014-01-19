using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;

namespace CustomControl
{
    [ToolboxData("<{0}:CustomRepeater runat=server PersistentDataSource=true></{0}:CustomRepeater>")]
    public class CustomRepeater : Repeater,IPageableItemContainer
    {
        public int MaximumRows
        {
            get
            {
                return this.ViewState["MaximumRows"] != null ? (int)ViewState["MaximumRows"] : -1;
            }
        }

        public int StartRowIndex
        {
            get
            {
                return ViewState["StartRowIndex"] != null ? (int)ViewState["StartRowIndex"] : -1;
            }
        }

        public int TotalRows
        {
            get
            {
                return ViewState["TotalRows"] != null ? (int)ViewState["TotalRows"] : -1;
            }
            set
            {
                ViewState["TotalRows"] = value;
            }
        }

        public bool PersistentDataSource
        {
            get
            {
                return ViewState["PersistentDataSource"] != null ? (bool)ViewState["PersistentDataSource"] : true;
            }
            set
            {
                ViewState["PersistentDataSource"] = value;
            }
        }

        public bool PagingInDataSource
        {
            get
            {
                return ViewState["PagingInDataSource"] != null ? (bool)ViewState["PagingInDataSource"] : false;
            }
            set
            {
                ViewState["PagingInDataSource"] = value;
            }
        }

        public bool NeedsDataSource
        {
            get
            {
                if (PagingInDataSource) return true;
                if (IsBoundUsingDataSourceID == false && !Page.IsPostBack) return true;
                if (IsBoundUsingDataSourceID == false && PersistentDataSource == false && Page.IsPostBack)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public event EventHandler<PageEventArgs> FetchingData;
        public event System.EventHandler<PageEventArgs> TotalRowCountAvailable;

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (NeedsDataSource && FetchingData != null)
                {
                    if (PagingInDataSource)
                    {
                       
                    }
                }
            }
            base.OnLoad(e);
        }

        public void SetPageProperties(int startRowIndex, int maximumRows, bool databind)
        {
            ViewState["StartRowIndex"] = startRowIndex;
            ViewState["MaximumRows"] = maximumRows;

            if (TotalRows > -1)
            {
                if (TotalRowCountAvailable != null)
                {
                    TotalRowCountAvailable(this, new PageEventArgs((int)ViewState["StartRowIndex"], (int)ViewState["MaximumRows"], TotalRows));
                }
            }
        }

        protected override void OnDataPropertyChanged()
        {
            if (MaximumRows != -1 || IsBoundUsingDataSourceID)
            {
                this.RequiresDataBinding = true;
            }
            base.OnDataPropertyChanged();
        }

        protected override void RenderChildren(HtmlTextWriter writer)
        {
            if (!PagingInDataSource && MaximumRows != -1)
            {
                foreach (RepeaterItem item in this.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        item.Visible = false;
                        if (item.ItemIndex >= (int)ViewState["StateRowIndex"] && item.ItemIndex < (int)ViewState["StartRowIndex"] + (int)ViewState["MaxmumRows"])
                        {
                            item.Visible = true;
                        }
                    }
                    else
                    {
                        item.Visible = true;
                    }
                }
            }
            base.RenderChildren(writer);
        }

        protected override System.Collections.IEnumerable GetData()
        {
            IEnumerable dataObjects = base.GetData();
            if (dataObjects == null && this.DataSource != null)
            {
                if (this.DataSource is IEnumerable)
                {
                    dataObjects = (IEnumerable)this.DataSource;
                }
                else
                {
                    dataObjects = ((System.ComponentModel.IListSource)this.DataSource).GetList();
                }
            }
            if (!PagingInDataSource && MaximumRows != -1 && dataObjects != null)
            {
                int i = -1;

                i = 0;
                foreach (object o in dataObjects)
                {
                    i++;
                }
                ViewState["TotalRows"] = i;

                if (!IsBoundUsingDataSourceID && PersistentDataSource)
                {
                    ViewState["DataSource"] = this.DataSource;
                }
                SetPageProperties(StartRowIndex, MaximumRows, true);
            }
           if(PagingInDataSource && !Page.IsPostBack)
           {
               SetPageProperties(StartRowIndex,MaximumRows,true);
           }
            return dataObjects;
        }
    }
}
