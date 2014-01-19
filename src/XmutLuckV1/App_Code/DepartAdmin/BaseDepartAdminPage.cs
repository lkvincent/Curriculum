using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Interface.DepartAdmin;
using Business.Service.DepartAdmin;
using Presentation.Enum;
using WebLibrary;

public class BaseDepartAdminPage:BasePage
{
    public override UserType InitUserType()
    {
        return UserType.DepartAdmin;
    }

    public override AttachmentType InitAttachmentType()
    {
        return AttachmentType.BaseInfo;
    }

    private IDepartAdminService Service
    {
        get
        {
            return new DepartAdminService();
        }
    }

    protected string DepartCode
    {
        get
        {
            return HaddockContext.Current.CurrentUser.Identity;
        }
    }

    protected override void OnPreInit(EventArgs e)
    {
        this.Theme = "DepartAdmin";
        base.OnPreInit(e);
    }

    public int DepartAdminId
    {
        get
        {
            return CurrentUser.Id;
        }
    }
}