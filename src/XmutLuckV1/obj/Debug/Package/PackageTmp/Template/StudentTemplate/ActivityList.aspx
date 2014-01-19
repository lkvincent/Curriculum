<%@ Page Title="" Language="C#" MasterPageFile="~/Template/StudentTemplate/NMaster.master" AutoEventWireup="true" CodeBehind="ActivityList.aspx.cs"
    Inherits="XmutLuckV1.Template.StudentTemplate.ActivityList" Theme="FrontStudent" %>

<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopProjectWidget.ascx" TagName="NewestTopProjectWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/ActivityList.ascx" TagName="ActivityList" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopDailyEssayWidget.ascx" TagName="NewestTopDailyEssayWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopProfessionalWidget.ascx" TagName="NewestTopProfessionalWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopExercitationWidget.ascx"
    TagName="NewestTopExercitationWidget" TagPrefix="uc" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentLeftContainer" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentRight" runat="server">
    <uc:NewestTopProjectWidget ID="projectWidget" runat="server"></uc:NewestTopProjectWidget>
    <uc:NewestTopExercitationWidget ID="exercitationList" runat="server"></uc:NewestTopExercitationWidget>
    <uc:NewestTopProfessionalWidget ID="professionList" runat="server"></uc:NewestTopProfessionalWidget>
    <uc:NewestTopDailyEssayWidget ID="dailyEssayList" runat="server"></uc:NewestTopDailyEssayWidget>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentCenter" runat="server">
    <uc:ActivityList ID="actiList" runat="server"></uc:ActivityList>
</asp:Content>
