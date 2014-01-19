<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/Login.Master" AutoEventWireup="true" 
CodeBehind="Login.aspx.cs" Inherits="XmutLuckV1.Manage.Student.Login" Theme="Login" %>

<%@ Register Src="~/Manage/UserControl/LoginControl.ascx" TagPrefix="uc" TagName="LoginControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <uc:LoginControl ID="LoginControl" runat="server" UserNameEmptyMessage="学生学号" UserType="Student"></uc:LoginControl>
</asp:Content>
