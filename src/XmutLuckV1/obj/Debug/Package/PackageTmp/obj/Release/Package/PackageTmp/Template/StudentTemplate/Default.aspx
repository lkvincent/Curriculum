<%@ Page Title="" Language="C#" MasterPageFile="~/Template/StudentTemplate/Master.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="XmutLuckV1.Template.StudentTemplate.Default" Theme="FrontStudent" %>

<%@ Register Src="~/Template/StudentTemplate/UserControl/DailyEssayList.ascx" TagName="DailyEssayList"
    TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/ProjectList.ascx" TagName="ProjectList"
    TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/ActivityList.ascx" TagName="ActivityList"
    TagPrefix="uc" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopProfessionalWidget.ascx"
    TagName="NewestTopProfessionalWidget" TagPrefix="uc" %>

<%@ Register Src="~/Template/StudentTemplate/UserControl/NewestTopExercitationWidget.ascx" TagName="NewestTopExercitationWidget" TagPrefix="uc" %>

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
    <uc:ProjectList ID="projectList" runat="server">
    </uc:ProjectList>
    <uc:ActivityList ID="activityList" runat="server">
    </uc:ActivityList>
    <uc:DailyEssayList ID="dailyEssayList" runat="server">
    </uc:DailyEssayList>
</asp:Content>
<asp:Content ID="conentLeft" runat="server" ContentPlaceHolderID="contentLeftContainer">
    <uc:NewestTopProfessionalWidget ID="pflList" runat="server">
    </uc:NewestTopProfessionalWidget>
    <uc:NewestTopExercitationWidget ID="extList" runat="server">
    </uc:NewestTopExercitationWidget>
</asp:Content>
