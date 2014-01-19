<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewestTopProjectWidget.ascx.cs" Inherits="XmutLuckV1.Template.StudentTemplate.UserControl.NewestTopProjectWidget" %>
<div class="widget widget-list project-list top-widget">
    <div class="bar">
        <div class="caption">
            最新项目列表
        </div>
        <div class="more">
            <asp:HyperLink ID="linkmore" runat="server" Text="更多"></asp:HyperLink>
        </div>
        <br class="clear" />
    </div>
    <div class="container">
        <asp:Repeater ID="rptProject" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <div class="list-item">
                        <a href='<%#Eval("Url") %>'><%#Eval("Name")%></a>
                    </div>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                <br class="clear" />
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</div>
