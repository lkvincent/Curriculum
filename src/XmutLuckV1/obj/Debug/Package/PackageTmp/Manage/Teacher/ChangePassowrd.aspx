﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterDetail.master" AutoEventWireup="true"
    CodeBehind="ChangePassowrd.aspx.cs" Inherits="XmutLuckV1.Manage.Teacher.ChangePassowrd" %>
<%@ Register Src="~/Manage/UserControl/ChangePassword.ascx" TagName="ChangePassword" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceDetail" runat="server">
  <uc:ChangePassword ID="changePwd" runat="server"></uc:ChangePassword>
</asp:Content>
