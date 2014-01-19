<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" 
    Inherits="XmutLuckV1.Manage.Enterprise.Login" Theme="Login"%>
<%@ Register Src="~/Manage/UserControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <uc:LoginControl ID="LoginControl" runat="server" UserNameEmptyMessage="用户名" UserType="Enterprise"></uc:LoginControl>
</asp:Content>
