﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Service.Student;

namespace XmutLuckV1.Template
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }

            Page.Header.DataBind();
        }

        protected void LoadData()
        {
            var service = new StudentService();
            this.StudentEvaluateTop20Widget.DataSource = service.GetFrontStudentList(Presentation.Enum.StudentSearchType.TopClick, 20, null);
            StudentEvaluateTop20Widget.DataBind();

            empStudentWidget.DataSource = service.GetTopEmployedStudentList(20);
            empStudentWidget.DataBind();
        }
    }
}