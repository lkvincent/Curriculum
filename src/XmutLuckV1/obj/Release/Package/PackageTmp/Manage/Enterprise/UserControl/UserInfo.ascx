<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.ascx.cs" Inherits="XmutLuckV1.Manage.Enterprise.UserControl.UserInfo" %>
<%@ Register Src="~/Manage/UserControl/EditorControl.ascx" TagName="EditorControl"
    TagPrefix="uc" %>
<div class="func-block">
    <div class="block">
        <div class="caption">
            <h3>
                <%=GetLocalResourceObject("BaseUserInfo")%>
            </h3>
        </div>
        <div class="container">
            <div class="user-left">
                <table>
                    <tr>
                        <th>
                            编号:
                        </th>
                        <td>
                            <asp:TextBox ID="txt_Code_" runat="server" Enabled="false" CssClass="edit-text disabled"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            单位名称:
                        </th>
                        <td>
                            <asp:TextBox ID="txt_Name_" runat="server" Enabled="false" CssClass="edit-text"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            所属地区:
                        </th>
                        <td>
                            <asp:DropDownList ID="drp_CdRegionCode_" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            单位类型:
                        </th>
                        <td>
                            <asp:DropDownList ID="drp_EnterpriseTypeCode_" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            行业类别:
                        </th>
                        <td>
                            <asp:DropDownList ID="drp_CdIndustryCode_" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            单位规模:
                        </th>
                        <td>
                            <asp:DropDownList ID="drp_ScopeCode_" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            营业执照号码:
                        </th>
                        <td>
                            <asp:TextBox ID="txt_LicenseCode_" runat="server" Width="516px" Enabled="false" CssClass="edit-text"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            法人代表:
                        </th>
                        <td>
                            <asp:TextBox ID="txt_Corporation_" runat="server" Width="516px" CssClass="edit-text"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="user-right">
            </div>
        </div>
    </div>
    <div class="block">
        <div class="caption">
            <h3>
                <%=GetLocalResourceObject("BaseCompanyInfo")%>
            </h3>
        </div>
        <div class="container">
            <table>
                <tr class="">
                    <th>
                        用户名:
                    </th>
                    <td style="width: 160px;">
                        <asp:TextBox ID="txt_UserName_" runat="server" Enabled="false" CssClass="edit-text"></asp:TextBox>
                    </td>
                    <th>
                        Email:
                    </th>
                    <td class="email-block">
                        <asp:TextBox ID="txt_Email_" runat="server" Width="232px" CssClass="edit-text"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        联系人:
                    </th>
                    <td>
                        <asp:TextBox ID="txt_ContactName_" runat="server" CssClass="edit-text"></asp:TextBox>
                    </td>
                    <th>
                        联系电话:
                    </th>
                    <td class="tel-block">
                        <asp:TextBox ID="txt_ContactPhone_" runat="server" Width="232px" CssClass="edit-text"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        公司网站:
                    </th>
                    <td colspan="3">
                        <asp:TextBox ID="txt_WebSite_" runat="server" Width="516px" CssClass="edit-text"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        通讯地址:
                    </th>
                    <td colspan="3">
                        <asp:TextBox ID="txt_Address_" runat="server" Width="516px" CssClass="multi-edit-text"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        审核状态:
                    </th>
                    <td>
                        <asp:Label ID="lbl_VerifyStatus_" runat="server"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:CheckBox ID="chk_IsOnline_" runat="server" Text="公布企业信息" />
                    </td>
                </tr>
                <tr>
                    <th class="multiLine">
                        公司简介:
                    </th>
                    <td colspan="3">
                        <uc:EditorControl ID="editDescription" runat="server" EditorHeight="390" EditorWidth="700" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="block action">
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="保存" />
    </div>
</div>
<script type="text/javascript">
    $(function () {
        setTimeout(function () {
            window.parent.ResetSize();
        }, 1000);
    })
</script>

<script type="text/javascript">
    $(function () {
        $("input.edit-text").jqxInput({ height: 25, width: 298 });
        $(".multi-edit-text").jqxInput({ height: 25, width: 700 });

        $(".email-block input.edit-text,.tel-block input.edit-text").jqxInput({ height: 25, width: 275 });
        
        $(".upload-edit-text").jqxInput({ height: 25, width: 120 });

        $(".disabled").jqxInput({ disabled: true });
    })
</script>