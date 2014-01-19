<%@ Page Title="" Language="C#" MasterPageFile="~/Template/StudentTemplate/NMaster.master"
    AutoEventWireup="true" CodeBehind="DailyEssay.aspx.cs" Inherits="XmutLuckV1.Template.StudentTemplate.DailyEssay" Theme="FrontStudent" %>

<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopProjectWidget.ascx"
    TagName="NewestTopProjectWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopActivityWidget.ascx"
    TagName="NewestTopActivityWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopDailyEssayWidget.ascx"
    TagName="NewestTopDailyEssayWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/DailyEssayDetailControl.ascx"
    TagName="DailyEssayDetailControl" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopProfessionalWidget.ascx"
    TagName="NewestTopProfessionalWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopExercitationWidget.ascx"
    TagName="NewestTopExercitationWidget" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentLeftContainer" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentCenter" runat="server">
    <uc:DailyEssayDetailControl ID="dailyDetail" runat="server">
    </uc:DailyEssayDetailControl>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentRight" runat="server">
    <uc:NewestTopDailyEssayWidget ID="dailyList" runat="server">
    </uc:NewestTopDailyEssayWidget>
    <uc:NewestTopProjectWidget ID="pjList" runat="server">
    </uc:NewestTopProjectWidget>
    <uc:NewestTopExercitationWidget ID="exercitationList" runat="server"></uc:NewestTopExercitationWidget>
    <uc:NewestTopActivityWidget ID="acvList" runat="server">
    </uc:NewestTopActivityWidget>
    <uc:NewestTopProfessionalWidget ID="professList" runat="server">
    </uc:NewestTopProfessionalWidget>

</asp:Content>
