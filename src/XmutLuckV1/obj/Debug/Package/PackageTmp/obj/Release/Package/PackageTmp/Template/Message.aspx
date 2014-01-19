<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Master.Master" AutoEventWireup="true"
    CodeBehind="Message.aspx.cs" Inherits="XmutLuckV1.Template.Message" Theme="BaseFront" %>

<%@ Register Src="~/Template/UserControl/UserNavigateControl.ascx" TagName="UserNavigateControl" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMain" runat="server">
    <div class="article widget">
        <div class="bar">
            <div class="caption">
                <uc:UserNavigateControl ID="ucNaviageControl" runat="server"></uc:UserNavigateControl>
            </div>
        </div>
        <div class="container">
            <div class="title">
                <h1>
                    <asp:Literal ID="ltlTitle" runat="server"></asp:Literal>
                </h1>
                <div class="content-time">
                    <span>
                        <asp:Literal ID="ltlTime" runat="server"></asp:Literal></span>
                </div>
            </div>
            <div class="content">
                <asp:Literal ID="ltlContent" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</asp:Content>

