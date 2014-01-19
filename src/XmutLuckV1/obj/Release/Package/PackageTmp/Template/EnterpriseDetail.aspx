<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Master.Master" AutoEventWireup="true" CodeBehind="EnterpriseDetail.aspx.cs" Inherits="XmutLuckV1.Template.EnterpriseDetail" %>
<%@ Register Src="~/Template/UserControl/EnterpriseDetailWidget.ascx" TagName="EnterpriseDetailWidget" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <style type="text/css">
    .job-request
    {
       width:120px;
       margin-left:auto;
       margin-right:auto;
    }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMain" runat="server">
  <uc:EnterpriseDetailWidget ID="enterWidget" runat="server"></uc:EnterpriseDetailWidget>
</asp:Content>
