<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewestTopDailyEssayWidget.ascx.cs"
    Inherits="XmutLuckV1.Template.StudentTemplate.UserControl.NewestTopDailyEssayWidget" %>
<div class="widget widget-list daily-list">
    <div class="bar">
        <div class="caption">
            最新博文</div>
        <div class="more">
            <asp:HyperLink ID="linkmore" runat="server" Text="更多"></asp:HyperLink>
        </div>
        <br class="clear"/>
    </div>
    <div class="container">
        <asp:Repeater ID="rptDailyEssay" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <div class="list-item">
                        <a href='<%#Eval("Url") %>'>
                            <%#Eval("Title")%></a>
                    </div>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</div>
