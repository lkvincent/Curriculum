<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Master.Master" AutoEventWireup="true" CodeBehind="EnterpriseRegister.aspx.cs" 
    Inherits="XmutLuckV1.Template.EnterpriseRegister" %>

<%@ Register Src="~/Template/UserControl/EnterpriseRegister.ascx" TagName="EnterpriseRegister" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Scripts/jqwidgets/jqwidgets/styles/jqx.base.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../../../Scripts/jqwidgets/jqwidgets/jqxcore.js"></script>
    <script type="text/javascript" src="../../../Scripts/jqwidgets/jqwidgets/jqxdata.js"></script>
    <script type="text/javascript" src="../../../Scripts/jqwidgets/jqwidgets/jqxinput.js"></script>
    <script type="text/javascript" src="../../../Scripts/jqwidgets/jqwidgets/jqxbuttons.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMain" runat="server">
    <uc:EnterpriseRegister ID="entRegister" runat="server"></uc:EnterpriseRegister>
</asp:Content>
