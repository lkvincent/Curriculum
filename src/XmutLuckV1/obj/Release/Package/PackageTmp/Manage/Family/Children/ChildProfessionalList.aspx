<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterList.master" AutoEventWireup="true" CodeBehind="ChildProfessionalList.aspx.cs" Inherits="XmutLuckV1.Manage.Family.Children.ChildProfessionalList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHead" runat="server">
    <script type="text/javascript">
        function ViewDetail(professionalId) {
            window.parent.tb_showIFrame("子女技能明细界面", "Children/ChildProfessionalDetail.aspx?ID=" + professionalId + "&width=800&height=600&TB_iframe=true");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceCondition" runat="server">
    <asp:Panel ID="pnlCondition" runat="server">
        <table>
            <tr>
                <th>证书名称:
                </th>
                <td>
                    <asp:TextBox ID="prm_Name_" runat="server" CssClass="edit-text"></asp:TextBox>
                </td>
                <th>获取时间从:
                </th>
                <td>
                    <telerik:RadDatePicker ID="prm_DateFrom_" runat="server">
                        <DateInput DateFormat="yyyy-MM-dd">
                        </DateInput>
                    </telerik:RadDatePicker>
                </td>
                <th>到
                </th>
                <td>
                    <telerik:RadDatePicker ID="prm_DateTo_" runat="server">
                        <DateInput ID="DateInput1" DateFormat="yyyy-MM-dd" runat="server">
                        </DateInput>
                    </telerik:RadDatePicker>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceAction" runat="server">
    <div class="right">
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="搜索"></asp:Button>
        <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="重置"></asp:Button>
    </div>
    <br class="clear" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentPlaceList" runat="server">
    <telerik:RadGrid ID="grdProfessional" runat="server" OnNeedDataSource="radGrid_NeedDataSource"
        OnPageIndexChanged="radGrid_PageIndexChanged" AutoGenerateColumns="false" PageSize="30" AllowCustomPaging="true" AllowPaging="true">
        <MasterTableView DataKeyNames="ID">
            <Columns>
                <telerik:GridBoundColumn DataField="Index" HeaderText="序号">
                           <HeaderStyle HorizontalAlign="Left" Width="40px" />
                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Name" HeaderText="证书名称">
                    <HeaderStyle Width="350px" HorizontalAlign="Left" />
                    <ItemStyle Width="350px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="获奖时间" DataField="ObtainTime">
                    <ItemStyle HorizontalAlign="Left" />
                    <HeaderStyle HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="公开">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkIsOnline" runat="server" Checked='<%#Eval("IsOnline") %>' Enabled="false" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn>
                    <ItemTemplate>
                        <a href="ChildProfessionalDetail.aspx?ID=<%#Eval("ID") %>"><span>查看</span></a>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" Width="35px" />
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                </telerik:GridTemplateColumn>
            </Columns>
            <NoRecordsTemplate>
                <div>
                    没有记录!
                </div>
            </NoRecordsTemplate>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>
