<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/SubMaster.Master" AutoEventWireup="true"
    CodeBehind="UserInfo.aspx.cs" Inherits="XmutLuckV1.Manage.Student.UserInfo"  Theme="StudentManage"%>

<%@ Register Src="~/Manage/Student/UserControl/UserInfo.ascx" TagName="UserInfo"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
  html body .RadInput .riTextBox, html body .RadInputMgr
  {
      border-style:none !important;
      background:none !important;
  }
  label
  {
      line-height:25px;
  }
  .body-content .main .wrap-right .file-Upload input[type="file"]
  {
     width:40px !important;
     right:65px !important;
     height:33px;
     cursor:pointer;
  }
  .file-Upload input[type="text"]
  {
      margin-right:4px;
  }
    .body-content .main .wrap-container .wrap-right .user-info .action {
        padding-right: 15px !important;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:UserInfo ID="UserInfo1" runat="server">
    </uc:UserInfo>
</asp:Content>
