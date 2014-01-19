<%@ Page Title="" Language="C#" MasterPageFile="~/Template/StudentTemplate/NMaster.master" AutoEventWireup="true" CodeBehind="ProfessionalList.aspx.cs" Inherits="XmutLuckV1.Template.StudentTemplate.ProfessionalList" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopProjectWidget.ascx" TagName="NewestTopProjectWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopActivityWidget.ascx" TagName="NewestTopActivityWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopDailyEssayWidget.ascx" TagName="NewestTopDailyEssayWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/ProfessionalList.ascx" TagName="ProfessionalList" TagPrefix="uc" %>
<%@Register src="~/Template/StudentTemplate/UserControl/NewestTopExercitationWidget.ascx" 
    tagName="NewestTopExercitationWidget" tagPrefix="uc" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentLeftContainer" runat="server">
  <uc:NewestTopProjectWidget ID="projectWidget" runat="server"></uc:NewestTopProjectWidget>
  <uc:NewestTopActivityWidget ID="actiList" runat="server"></uc:NewestTopActivityWidget>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentRight" runat="server">
 <uc:NewestTopDailyEssayWidget ID="dailyEssayList" runat="server"></uc:NewestTopDailyEssayWidget>
        <uc:NewestTopExercitationWidget ID="exercitationList" runat="server"></uc:NewestTopExercitationWidget>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="contentCenter" runat="server">
  <uc:ProfessionalList ID="professList" runat="server"></uc:ProfessionalList>
</asp:Content>
