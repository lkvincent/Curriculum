﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XmutLuckV1.Manage.DepartAdmin
{
    public partial class ImportStudent : BaseDepartAdminDetailPage
    {
        protected override void InitLoadedData()
        {
            btnImport.TableName = "STUDENT";
            base.InitLoadedData();
        }
    }
}