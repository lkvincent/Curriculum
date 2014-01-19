<%@ Page Title="" Language="C#" MasterPageFile="~/Template/StudentTemplate/Master.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="XmutLuckV1.Template.StudentTemplate.Default" Theme="FrontStudent" %>

<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopProfessionalWidget.ascx"
    TagName="NewestTopProfessionalWidget" TagPrefix="uc" %>

<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopExercitationWidget.ascx" TagName="NewestTopExercitationWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopActivityWidget.ascx" TagName="NewestTopActivityWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopDailyEssayWidget.ascx" TagName="NewestTopDailyEssayWidget" TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopProjectWidget.ascx" TagName="NewestTopProjectWidget" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" href="../../../../Scripts/Slides/slides.css" rel="Stylesheet" />
    <script type="text/javascript" src="../../../../Scripts/Slides/slides.jquery.js"></script>
    <style type="text/css" media="screen">
        .slides_container {
            width: 570px;
            height: 270px;
        }

            .slides_container div {
                width: 570px;
                height: 270px;
                display: block;
            }

        #slides .next, #slides .prev {
            position: absolute;
            top: 280px;
            width: 24px;
            height: 43px;
            display: block;
            z-index: 101;
        }

        #slides .next {
            right: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMain" runat="server">
    <uc:NewestTopProjectWidget ID="pjoList" runat="server" EnableShortContent="False"></uc:NewestTopProjectWidget>
    <uc:NewestTopExercitationWidget ID="etwList" runat="server" EnableShortContent="False"></uc:NewestTopExercitationWidget>
    <uc:NewestTopActivityWidget ID="atwList" runat="server" EnableShortContent="False"></uc:NewestTopActivityWidget>
    <uc:NewestTopProfessionalWidget ID="pflList" runat="server" EnableShortContent="False"></uc:NewestTopProfessionalWidget>
    <uc:NewestTopDailyEssayWidget ID="dewList" runat="server" EnableShortContent="False"></uc:NewestTopDailyEssayWidget>
</asp:Content>
<asp:Content ID="conentLeft" runat="server" ContentPlaceHolderID="contentLeftContainer">
</asp:Content>
