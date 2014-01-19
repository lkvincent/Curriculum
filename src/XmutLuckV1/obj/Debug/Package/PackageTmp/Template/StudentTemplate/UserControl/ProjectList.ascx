<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectList.ascx.cs"
    Inherits="XmutLuckV1.Template.StudentTemplate.UserControl.ProjectList" %>
<%@ Register Src="~/Template/UserControl/CommonSearchWidget.ascx" TagName="CommonSearchWidget"
    TagPrefix="uc" %>
<div class="widget widget-list project-list">
    <div class="bar">
        <div class="caption">
            个人项目列表</div>
    </div>
    <div class="container">
        <uc:CommonSearchWidget ID="cmSearchWidget" runat="server" OnSearchClicked="CommonSearchWidget_SearchClicked">
        </uc:CommonSearchWidget>
        <asp:Repeater ID="rptProject" runat="server">
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
                <br class="clear" />
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</div>
