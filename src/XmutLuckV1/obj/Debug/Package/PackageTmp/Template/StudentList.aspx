<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Master.Master" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="XmutLuckV1.Template.StudentList" %>

<%@ Register Src="~/Template/UserControl/StudentList.ascx" TagName="StudentList" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    <script type="text/javascript" src="~/Scripts/Prompt.js"></script>--%>
    <style type="text/css">
        .dialog-container {
            overflow: hidden !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMain" runat="server">
    <uc:StudentList ID="stuList" runat="server"></uc:StudentList>
</asp:Content>
