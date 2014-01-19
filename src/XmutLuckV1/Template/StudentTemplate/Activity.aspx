<%@ Page Title="" Language="C#" MasterPageFile="~/Template/StudentTemplate/NMaster.master"
    AutoEventWireup="true" CodeBehind="Activity.aspx.cs" Inherits="XmutLuckV1.Template.StudentTemplate.Activity" Theme="FrontStudent" %>

<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopProjectWidget.ascx"
    TagName="NewestTopProjectWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopActivityWidget.ascx"
    TagName="NewestTopActivityWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopDailyEssayWidget.ascx"
    TagName="NewestTopDailyEssayWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/ActivityDetailControl.ascx"
    TagName="ActivityDetailControl" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopProfessionalWidget.ascx"
    TagName="NewestTopProfessionalWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopExercitationWidget.ascx"
    TagName="NewestTopExercitationWidget" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentLeftContainer" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentCenter" runat="server">
    <uc:ActivityDetailControl ID="actControl" runat="server">
    </uc:ActivityDetailControl>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentRight" runat="server">
    <uc:NewestTopActivityWidget ID="acvList" runat="server">
    </uc:NewestTopActivityWidget>
    <uc:NewestTopProjectWidget ID="pjList" runat="server">
    </uc:NewestTopProjectWidget>
    <uc:NewestTopExercitationWidget ID="exercitationList" runat="server"></uc:NewestTopExercitationWidget>
    <uc:NewestTopProfessionalWidget ID="professList" runat="server">
    </uc:NewestTopProfessionalWidget>
    <uc:NewestTopDailyEssayWidget ID="dailyList" runat="server">
    </uc:NewestTopDailyEssayWidget>
</asp:Content>
