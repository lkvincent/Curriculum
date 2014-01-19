<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/SubMaster.Master" AutoEventWireup="true" CodeBehind="MessageBoxList.aspx.cs" 
    Inherits="XmutLuckV1.Manage.Teacher.MessageBoxList" Theme="TeacherManage" %>

<%@ Register Src="~/Manage/UserControl/MessageBoxList.ascx" TagName="MessageBoxList" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../../Css/MessageBoxStyleSheet.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:MessageBoxList ID="msgBoxList" runat="server"></uc:MessageBoxList>
</asp:Content>