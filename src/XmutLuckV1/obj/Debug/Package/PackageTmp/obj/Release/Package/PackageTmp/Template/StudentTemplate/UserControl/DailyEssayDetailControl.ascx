<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DailyEssayDetailControl.ascx.cs"
    Inherits="XmutLuckV1.Template.StudentTemplate.UserControl.DailyEssayDetailControl" %>
<%@ Register Src="~/Template/StudentTemplate/UserControl/CommentWidget.ascx" TagName="CommentWidget" TagPrefix="uc" %>

<div class="detail-widget">
    <div class="container">
        <div class="caption">
            <h1>
                <asp:Literal ID="ltlTitle" runat="server"></asp:Literal></h1>
            <div class="content-time">
                <div class="left">
                    <asp:Literal ID="ltlTime" runat="server"></asp:Literal>
                </div>
                <br class="clear" />
            </div>
        </div>
        <div class="row-content">
            <asp:Literal ID="ltlContent" runat="server"></asp:Literal>
        </div>
        <div>
            <uc:CommentWidget ID="cmtWidget" runat="server" commenttype="DailyEssay"></uc:CommentWidget>
        </div>
    </div>
</div>
