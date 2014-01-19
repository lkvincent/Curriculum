<%@ Page Title="" Language="C#" MasterPageFile="~/Template/StudentTemplate/NMaster.master"
    AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="XmutLuckV1.Template.StudentTemplate.Project" %>

<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopProjectWidget.ascx"
    TagName="NewestTopProjectWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopActivityWidget.ascx"
    TagName="NewestTopActivityWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopDailyEssayWidget.ascx"
    TagName="NewestTopDailyEssayWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/ProjectDetailControl.ascx"
    TagName="ProjectDetailControl" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopProfessionalWidget.ascx" TagName="NewestTopProfessionalWidget"
 TagPrefix="uc" %>

<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopExercitationWidget.ascx" TagName="NewestTopExercitationWidget"
 TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHead" runat="server">
    <link href="../../../../Scripts/Slides/slides.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript" src="../../../../Scripts/Slides/slides.jquery.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCenter" runat="server">
    <uc:ProjectDetailControl ID="projectjDetail" runat="server">
    </uc:ProjectDetailControl>
</asp:Content>
<asp:Content ID="ContentLeftContainer" runat="server" ContentPlaceHolderID="contentLeftContainer">
    <uc:NewestTopExercitationWidget ID="extList" runat="server"></uc:NewestTopExercitationWidget>
    <uc:NewestTopDailyEssayWidget ID="dailyList" runat="server">
    </uc:NewestTopDailyEssayWidget>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentRight" runat="server">
    <uc:NewestTopProjectWidget ID="pjList" runat="server">
    </uc:NewestTopProjectWidget>
    <uc:NewestTopActivityWidget ID="acvList" runat="server">
    </uc:NewestTopActivityWidget>
    <uc:NewestTopProfessionalWidget ID="professList" runat="server"></uc:NewestTopProfessionalWidget>
</asp:Content>
