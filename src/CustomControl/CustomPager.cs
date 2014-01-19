using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomControl
{
    public class CustomPager : CompositeControl
    {
        private Repeater repeater;

        //public delegate void RepeaterDataItemEventHandler(RepeaterDataItem item);
        //public event RepeaterDataItemEventHandler RepeaterDataItemPropertying;

        //public delegate int StartPageIndexEventHandler(int lastPageIndex);
        //public event StartPageIndexEventHandler StartPageIndexItemBouding;

        private ITemplate _HeaderTemplate;
        [TemplateContainer(typeof(RepeaterItem))]
        public ITemplate HeaderTemplate
        {
            get
            {
                return _HeaderTemplate;
            }
            set
            {
                _HeaderTemplate = value;
            }
        }

        private ITemplate _ItemTemplate;
        [TemplateContainer(typeof(RepeaterItem))]
        public ITemplate ItemTemplate
        {
            get
            {
                return _ItemTemplate;
            }
            set
            {
                _ItemTemplate = value;
            }
        }

        private ITemplate _FooterTemplate;
        [TemplateContainer(typeof(RepeaterItem))]
        public ITemplate FooterTemplate
        {
            get
            {
                return _FooterTemplate;
            }
            set
            {
                _FooterTemplate = value;
            }
        }

        private StateBag _viewState;
        protected StateBag viewState
        {
            get
            {
                if (_viewState == null)
                {
                    _viewState = new StateBag();
                    if (IsTrackingViewState)
                    {
                        ((IStateManager)_viewState).TrackViewState();
                    }
                }
                return _viewState;
            }
        }

        protected override void LoadViewState(object savedState)
        {
            object[] view = savedState as object[];
            base.LoadViewState(view[1]);
            ((IStateManager)viewState).LoadViewState(view[0]);
        }

        protected override object SaveViewState()
        {
            object[] views = new object[2];
            views[1] = base.SaveViewState();
            views[0] = ((IStateManager)viewState).SaveViewState();
            return views;
        }

        public int PageSize
        {
            get
            {
                return viewState["PageSize"] == null ? 20 : (int)viewState["PageSize"];
            }
            set
            {
                this.viewState["PageSize"] = value;
            }
        }

        public int PageCountPerPage
        {
            get
            {
                return viewState["PageCountPerPage"] == null ? 14 : (int)viewState["PageCountPerPage"];
            }
            set
            {
                this.viewState["PageCountPerPage"] = value;
            }
        }

        public int PageIndex
        {
            get
            {
                return (viewState["PageIndex"] == null || viewState["PageIndex"].ToString() == "0")
                           ? 1
                           : (int) viewState["PageIndex"];
            }
            set { this.viewState["PageIndex"] = value; }
        }

        private int StartIndex
        {
            get
            {
                return viewState["StartIndex"] == null ? 1 : (int)viewState["StartIndex"];
            }
            set
            {
                this.viewState["StartIndex"] = value;
            }
        }

        private int EndIndex
        {
            get
            {
                return viewState["EndIndex"] == null ? 18 : (int)viewState["EndIndex"];
            }
            set
            {
                this.viewState["EndIndex"] = value;
            }
        }

        public int TotalReords
        {
            get
            {
                return viewState["TotalReords"] == null ? 20 : (int)viewState["TotalReords"];
            }
            set
            {
                this.EnsureChildControls();
                if (HeaderTemplate != null)
                {
                    repeater.HeaderTemplate = HeaderTemplate;
                }
                if (ItemTemplate != null)
                {
                    repeater.ItemTemplate = ItemTemplate;
                }
                if (FooterTemplate != null)
                {
                    repeater.FooterTemplate = FooterTemplate;
                }
                int totalSize = (int)Math.Ceiling(value / (PageSize * 1.0));

                if (totalSize >= PageIndex)
                {
                    var array = GetPageDataSource(totalSize, PageIndex);
                    repeater.ItemCommand += new RepeaterCommandEventHandler(repeater_ItemCommand);
                    repeater.DataSource = array;
                    repeater.DataBind();
                    this.viewState["TotalReords"] = value;
                }
            }
        }

        public string PageItemTemplate
        {
            get;
            set;
        }

        private IList<RepeaterDataItem> GetPageDataSource(int totalSize, int pageIndex)
        {
            IList<RepeaterDataItem> list = new List<RepeaterDataItem>();
            if (totalSize == 0 || totalSize < pageIndex)
            {
                return list;
            }
            list.Add(new RepeaterDataItem
            {
                Index = 1,
                Text = (1).ToString(),
                Tooltip = (1).ToString(),
                Url = string.IsNullOrEmpty(PageItemTemplate) ? "" : string.Format(PageItemTemplate, 1)
            });
            var secondStartIndex = PageIndex - 5;
            if (secondStartIndex + PageCountPerPage > totalSize)
            {
                secondStartIndex = totalSize - PageCountPerPage + 1;
            }
            if (secondStartIndex > PageCountPerPage / 2)
            {
                list.Add(new RepeaterDataItem
                {
                    Index = secondStartIndex - 2,
                    Text = "...",
                    Tooltip = "...",
                    Url = string.IsNullOrEmpty(PageItemTemplate) ? "" : string.Format(PageItemTemplate, secondStartIndex - 2),
                    CssClass = "more-start"
                });
            }
            else
            {
                secondStartIndex = 2;
            }
            var lastPage = PageCountPerPage + secondStartIndex - 2;
            if (lastPage > totalSize)
            {
                lastPage = totalSize;
            }

            for (var index = secondStartIndex; index <= lastPage; index++)
            {
                list.Add(new RepeaterDataItem
                {
                    Index = index,
                    Text = (index).ToString(),
                    Tooltip = (index + 1).ToString(),
                    Url = string.IsNullOrEmpty(PageItemTemplate) ? "" : string.Format(PageItemTemplate, index)
                });
            }
            if (lastPage < totalSize - 1)
            {
                list.Add(new RepeaterDataItem
                {
                    Index = PageCountPerPage + secondStartIndex,
                    Text = "...",
                    Tooltip = "...",
                    Url = string.IsNullOrEmpty(PageItemTemplate) ? "" : string.Format(PageItemTemplate, PageCountPerPage + secondStartIndex),
                    CssClass = "more-end"
                });
            }
            if (lastPage < totalSize)
            {
                list.Add(new RepeaterDataItem
                {
                    Index = totalSize,
                    Text = (totalSize).ToString(),
                    Tooltip = (totalSize).ToString(),
                    Url = string.IsNullOrEmpty(PageItemTemplate) ? "" : string.Format(PageItemTemplate, totalSize)
                });
            }
            var currentItem = list.FirstOrDefault(it => it.Index == PageIndex);
            if (currentItem != null)
            {
                currentItem.CssClass = currentItem.CssClass + " current";
            }
            return list;
        }

        void repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "")
            {

            }
        }

        protected override void CreateChildControls()
        {
            repeater = new Repeater();

            base.CreateChildControls();
        }

        protected override void RenderChildren(HtmlTextWriter writer)
        {
            this.EnsureChildControls();
            repeater.RenderControl(writer);
            base.RenderChildren(writer);
        }
    }

    public class RepeaterDataItem
    {
        public string Text
        {
            get;
            set;
        }

        public string Tooltip
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }

        public int Index
        {
            get;
            set;
        }

        public string Keyword
        {
            get;
            set;
        }

        public string CssClass
        {
            get;
            set;
        }
    }
}
