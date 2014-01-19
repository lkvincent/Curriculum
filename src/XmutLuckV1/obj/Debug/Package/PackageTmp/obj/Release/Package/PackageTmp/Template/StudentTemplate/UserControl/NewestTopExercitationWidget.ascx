<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewestTopExercitationWidget.ascx.cs" Inherits="XmutLuckV1.Template.StudentTemplate.UserControl.NewestTopExercitationWidget" %>
<div class="widget widget-list activity-list top-widget">
    <div class="bar">
        <div class="caption">
            实习列表</div>
        <div class="more">
            <asp:HyperLink ID="linkmore" runat="server" Text="更多"></asp:HyperLink>
        </div>
        <br class="clear"/>
    </div>
    <div class="container">
        <asp:Repeater ID="rptActivity" runat="server">
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
                <br class="clear" />
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</div>