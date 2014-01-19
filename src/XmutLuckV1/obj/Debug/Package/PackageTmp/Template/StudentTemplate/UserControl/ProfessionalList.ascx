<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfessionalList.ascx.cs"
    Inherits="XmutLuckV1.Template.StudentTemplate.UserControl.ProfessionalList" %>
<%@ Register Src="~/Template/UserControl/CommonSearchWidget.ascx" TagName="CommonSearchWidget"
    TagPrefix="uc" %>
<div class="widget widget-list">
    <div class="bar">
        <div class="caption">
            掌握技能</div>
    </div>
    <div class="container">
        <uc:CommonSearchWidget ID="cmSearchWidget" runat="server" OnSearchClicked="CommonSearchWidget_SearchClicked">
        </uc:CommonSearchWidget>
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
