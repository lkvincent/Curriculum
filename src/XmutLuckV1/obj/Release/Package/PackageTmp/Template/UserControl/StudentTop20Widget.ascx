<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentTop20Widget.ascx.cs" Inherits="XmutLuckV1.Template.UserControl.StudentTop20Widget" %>
<div class="top-student show-widget widget">
    <div class="bar">
        <div class="caption">
            <%=Caption%>
        </div>
    </div>
    <div class="container">
        <marquee direction="up" scrollamount="5" onmouseover="this.stop()" onmouseout="this.start()">
            <asp:Repeater ID="rptStudent" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <div class="widget-item">
                            <div class="image">
                                <a href='<%#Eval("Url") %>' title='<%#Eval("Title") %>'>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Photo") %>' /></a>
                            </div>
                            <div class="detail">
                                <div class="row name">
                                    <a href='<%#Eval("Url") %>' title='<%#Eval("Title") %>'>
                                        <%#Eval("NameZh")%>
                                    </a>
                                </div>
                                <div class="row">
                                    <%#Eval("MarjorName")%>
                                </div>
                            </div>
                            <br class="clear" />
                        </div>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </marquee>
    </div>
</div>
