<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterList.master" AutoEventWireup="true"
    CodeBehind="EnterpriseManage.aspx.cs" Inherits="XmutLuckV1.Manage.DepartAdmin.EnterpriseManage" Theme="DepartAdmin" %>

<asp:Content ContentPlaceHolderID="contentHead" ID="cntHead" runat="server">
    <style type="text/css">
        .body-content .main table.wrap-container .description {
            width: 560px !important;
            max-width: 560px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceCondition" runat="server">
    <asp:Panel ID="pnlCondition" runat="server">
        <table>
            <tr>
                <th>企业名称:
                </th>
                <td>
                    <asp:TextBox ID="prm_Name_" runat="server" Width="260px" CssClass="edit-text"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceAction" runat="server">
    <div class="right">
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="搜索"></asp:Button>
        <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="重置"></asp:Button>
    </div>
    <br class="clear"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceList" runat="server">
    <telerik:RadGrid ID="grdEnterprise" runat="server"
        AutoGenerateColumns="false" AllowCustomPaging="True" AllowPaging="True"
        OnPageIndexChanged="radGrid_PageIndexChanged"
        OnNeedDataSource="radGrid_NeedDataSource" OnDeleteCommand="radGrid_DeleteCommand"
        OnUpdateCommand="grdEnterprise_UpdateCommand" OnItemDataBound="grdEnterprise_ItemDataBound">
        <MasterTableView DataKeyNames="ID" AllowCustomPaging="True" AllowPaging="True">
            <Columns>
                <telerik:GridBoundColumn DataField="Index" HeaderText="编号">
                    <HeaderStyle HorizontalAlign="Left" Width="40px" />
                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Name" HeaderText="企业名称">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LicenseNo" HeaderText="营业执照号码">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Email" HeaderText="Email">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="审核状态">
                    <ItemTemplate>
                        <%#Eval("VerifyStatusName")%>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn>
                    <ItemTemplate>
                        <asp:LinkButton ID="linkEdit" runat="server" Text="编辑" CommandName="Edit"></asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn>
                    <ItemTemplate>
                        <asp:LinkButton ID="linkDelete" OnClientClick='<%# "if(!BeforeDeletd(\""+DataBinder.Eval(Container,"DataItem.Code")+"\",\""+DataBinder.Eval(Container,"DataItem.Name")+"\"))return false;"%>'  runat="server" Text="删除" CommandName="delete" ></asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            <NoRecordsTemplate>
                <div class="empty">
                    没有记录
                </div>
            </NoRecordsTemplate>
            <EditFormSettings EditFormType="Template">
                <FormTemplate>
                    <div class="data-detail">
                        <div class="caption">
                            <h3>企业明细</h3>
                        </div>
                        <div class="container">
                            <table>
                                <tr>
                                    <th>企业名称:
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" Enabled="false" Width="240px" CssClass="edit-text"></asp:TextBox>
                                        <asp:HiddenField ID="hdfID" runat="server" Value='<%#Eval("ID") %>' />
                                    </td>
                                    <th>营业执照号码:
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtLicenseNo" runat="server" Enabled="false" Width="240px" CssClass="edit-text"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>联系人姓名:
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtContactName" runat="server" Enabled="false" Width="240px" CssClass="edit-text"></asp:TextBox>
                                    </td>
                                    <th>联系电话号码:
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtContactPhone" runat="server" Enabled="false" Width="240px" CssClass="edit-text"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>用户名:
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtUserName" runat="server" Enabled="false" Width="240px" CssClass="edit-text"></asp:TextBox>
                                    </td>
                                    <th>电子邮件地址:
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" Enabled="false" Width="240px" CssClass="edit-text"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>描述:
                                    </th>
                                    <td colspan="3">
                                        <div class="description">
                                            <asp:Literal ID="ltlDescription" runat="server"></asp:Literal>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <th>审核状态:
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="cmbVerifyStatus" runat="server">
                                            <asp:ListItem Text="等待审核" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="审核通过" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="审核未通过" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th></th>
                                    <td style="text-align: right;">
                                        <asp:CheckBox ID="chkIsOnline" runat="server" Text=" 发布" Enabled="false" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="action">
                        <asp:Button ID="btnUpdate" runat="server" Text="保存" CommandName="Update" />
                        <asp:Button ID="btnCancel" Text="取消" runat="server" CausesValidation="False" CommandName="Cancel" />
                    </div>
                </FormTemplate>
            </EditFormSettings>
        </MasterTableView>
        <ClientSettings>
            <Selecting AllowRowSelect="true" />
        </ClientSettings>
    </telerik:RadGrid>
</asp:Content>
