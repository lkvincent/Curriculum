<%@ Page Title="" Language="C#" MasterPageFile="~/Template/StudentTemplate/NMaster.master" AutoEventWireup="true" CodeBehind="ProjectList.aspx.cs" Inherits="XmutLuckV1.Template.StudentTemplate.ProjectList" %>

<%@ Register Src="~/Template/StudentTemplate/UserControl/ProjectList.ascx" TagName="ProjectList" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopDailyEssayWidget.ascx" TagName="NewestTopDailyEssayWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopActivityWidget.ascx" TagName="NewestTopActivityWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopProfessionalWidget.ascx" TagName="NewestTopProfessionalWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopExercitationWidget.ascx" TagName="NewestTopExercitationWidget"
    TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentLeftContainer" runat="server">
    <uc:NewestTopProfessionalWidget ID="professList" runat="server"></uc:NewestTopProfessionalWidget>
    <uc:NewestTopActivityWidget ID="activityList" runat="server"></uc:NewestTopActivityWidget>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentRight" runat="server">
    <uc:NewestTopExercitationWidget ID="extList" runat="server"></uc:NewestTopExercitationWidget>
    <uc:NewestTopDailyEssayWidget ID="ndailyessay" runat="server"></uc:NewestTopDailyEssayWidget>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentCenter" runat="server">
    <uc:ProjectList ID="project" runat="server"></uc:ProjectList>
</asp:Content>
