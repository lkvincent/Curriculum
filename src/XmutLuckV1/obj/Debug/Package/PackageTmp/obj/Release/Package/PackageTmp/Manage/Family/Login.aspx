<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" 
    Inherits="XmutLuckV1.Manage.Family.Login" Theme="Login" %>
<%@ Register src="~/Manage/UserControl/LoginControl.ascx" tagName="LoginControl" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <uc:LoginControl ID="LoginControl" runat="server" UserNameEmptyMessage="家长帐号" UserType="Family" OnGetExtandAccountInfoHandler="LoginControl_GetExtandAccountInfoHandler"></uc:LoginControl>
</asp:Content>
