<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DailyEssayList.ascx.cs"
    Inherits="XmutLuckV1.Template.StudentTemplate.UserControl.DailyEssayList" %>
<%@ Register Src="~/Template/UserControl/CommonSearchWidget.ascx" TagName="CommonSearchWidget"
    TagPrefix="uc" %>
<div class="widget widget-list daily-list">
    <div class="bar">
        <div class="caption">
            博文列表</div>
    </div>
    <div class="container">
        <uc:CommonSearchWidget ID="cmSearchWidget" runat="server" OnSearchClicked="CommonSearchWidget_SearchClicked">
        </uc:CommonSearchWidget>
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
