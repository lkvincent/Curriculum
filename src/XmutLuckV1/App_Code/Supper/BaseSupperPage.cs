using System;
using Business.Interface.DepartAdmin;
using Business.Service.DepartAdmin;
using Presentation.Enum;

public class BaseSupperPage : BasePage
{
    public override UserType InitUserType()
    {
        return UserType.Supper;
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

    protected override void OnPreInit(EventArgs e)
    {
        this.Theme = "DepartAdmin";
        base.OnPreInit(e);
    }
}