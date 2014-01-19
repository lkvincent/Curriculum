<%@ Page Title="" Language="C#" MasterPageFile="~/Template/StudentTemplate/NMaster.master" AutoEventWireup="true" CodeBehind="DailyEssayList.aspx.cs" 
    Inherits="XmutLuckV1.Template.StudentTemplate.DailyEssayList" Theme="FrontStudent" %>

<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopActivityWidget.ascx" TagName="NewestTopActivityWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopProfessionalWidget.ascx" TagName="NewestTopProfessionalWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopProjectWidget.ascx" TagName="NewestTopProjectWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/DailyEssayList.ascx" TagName="DailyEssayList" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopExercitationWidget.ascx" TagName="NewestTopExercitationWidget" TagPrefix="uc" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentLeftContainer" runat="server">
    <uc:NewestTopProfessionalWidget ID="prefessList" runat="server"></uc:NewestTopProfessionalWidget>
    <uc:NewestTopActivityWidget ID="actiList" runat="server"></uc:NewestTopActivityWidget>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentRight" runat="server">
    <uc:NewestTopProjectWidget ID="projectList" runat="server"></uc:NewestTopProjectWidget>
    <uc:NewestTopExercitationWidget ID="exercitationList" runat="server"></uc:NewestTopExercitationWidget>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="contentCenter" runat="server">
    <uc:DailyEssayList ID="dailyList" runat="server"></uc:DailyEssayList>
</asp:Content>
