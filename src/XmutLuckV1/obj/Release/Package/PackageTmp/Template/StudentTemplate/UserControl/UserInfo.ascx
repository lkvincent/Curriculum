<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.ascx.cs" Inherits="XmutLuckV1.Template.StudentTemplate.UserControl.UserInfo" %>
<div class="user-info widget">
    <div class="bar">
        <div class="caption">
            <a href="<%=URL %>">基本资料</a></div>
    </div>
    <div class="container">
        <table>
            <tr>
                <td colspan="2">
                    <div class="image">
                        <asp:Image ID="imgPhoto" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <th>
                    中文名:
                </th>
                <td>
                    <asp:Literal ID="ltlNameZh" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <th>
                    英文名:
                </th>
                <td>
                    <asp:Literal ID="ltlNameEn" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
        <asp:PlaceHolder ID="phPublish" runat="server">
            <div class="personal-info">
                <table>
                  <tr>
                    <th>系别<asp:Literal ID="ltlPeriod" runat="server"></asp:Literal></th>
                  </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="ltlDepartName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                      <th>专业与班级</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="ltlMarjorClass" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            籍贯
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="ltlNativePlace" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            政治面貌
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="ltlPolitics" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            身高
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="ltlTall" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            生日
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="ltlBirthday" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            个人主页
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="linkWebSite" runat="server" Target="_blank"></asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:PlaceHolder>
    </div>
</div>
