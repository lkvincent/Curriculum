<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Master.Master" AutoEventWireup="true" CodeBehind="EnterpriseList.aspx.cs" Inherits="XmutLuckV1.Template.EnterpriseList" %>

<%@ Register Src="~/Template/UserControl/EnterpriseListWidget.ascx" TagName="EnterpriseListWidget" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMain" runat="server">
  <uc:EnterpriseListWidget ID="entPriseList" runat="server"></uc:EnterpriseListWidget>
</asp:Content>
