﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XmutLuckV1.UserControl
{
    public partial class GradeControl : System.Web.UI.UserControl
    {
        public bool Enabled
        {
            set
            {
                this.rcRadRate.Enabled = value;
            }
        }

        public string Caption
        {
            get
            {
                return this.ltlTitle.Text;
            }
            set
            {
                this.ltlTitle.Text = value;
            }
        }

        public double RadRate
        {
            get
            {
                return rcRadRate.Value;
            }
            set
            {
                rcRadRate.Value = value;
            }
        }

        public bool ShowTitle
        {
            set
            {
                placeTitle.Visible = value;
            }
        }
    }
}