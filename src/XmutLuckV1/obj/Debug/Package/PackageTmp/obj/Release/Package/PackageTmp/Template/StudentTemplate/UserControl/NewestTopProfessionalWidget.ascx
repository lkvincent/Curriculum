﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewestTopProfessionalWidget.ascx.cs"
    Inherits="XmutLuckV1.Template.StudentTemplate.UserControl.NewestTopProfessionalWidget" %>
<div class="widget widget-list top-widget">
    <div class="bar">
        <div class="caption">
            最新技能</div>
        <div class="more">
            <asp:HyperLink ID="linkmore" runat="server" Text="更多"></asp:HyperLink>
        </div>
        <br class="clear"/>
    </div>
    <div class="container">
        <asp:Repeater ID="rptProfessional" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <div class="list-item">
                        <a href='<%#Eval("Url") %>'>
                            <%#Eval("Name")%></a>
                    </div>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</div>
