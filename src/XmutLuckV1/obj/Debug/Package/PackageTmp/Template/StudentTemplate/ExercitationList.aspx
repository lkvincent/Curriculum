<%@ Page Title="" Language="C#" MasterPageFile="~/Template/StudentTemplate/NMaster.master" AutoEventWireup="true" CodeBehind="ExercitationList.aspx.cs"
    Inherits="XmutLuckV1.Template.StudentTemplate.ExercitationList" Theme="FrontStudent" %>

<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopProjectWidget.ascx" TagName="NewestTopProjectWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopActivityWidget.ascx" TagName="NewestTopActivityWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopDailyEssayWidget.ascx" TagName="NewestTopDailyEssayWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopProfessionalWidget.ascx" TagName="NewestTopProfessionalWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopExercitationWidget.ascx" TagName="NewestTopExercitationWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/ExercitationList.ascx" TagName="ExercitationList" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentLeftContainer" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentCenter" runat="server">
    <uc:ExercitationList ID="exercitationList" runat="server"></uc:ExercitationList>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentRight" runat="server">
    <uc:NewestTopProjectWidget ID="pjList" runat="server"></uc:NewestTopProjectWidget>
    <uc:NewestTopActivityWidget ID="acvList" runat="server"></uc:NewestTopActivityWidget>
    <uc:NewestTopProfessionalWidget ID="professList" runat="server"></uc:NewestTopProfessionalWidget>
    <uc:NewestTopDailyEssayWidget ID="dailyList" runat="server"></uc:NewestTopDailyEssayWidget>
</asp:Content>
