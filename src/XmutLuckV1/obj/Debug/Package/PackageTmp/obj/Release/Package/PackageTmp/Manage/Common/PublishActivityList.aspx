<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/ThickBox.Master" AutoEventWireup="true" Theme="ThickBox"
    CodeBehind="PublishActivityList.aspx.cs" Inherits="XmutLuckV1.Manage.Common.PublishActivityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceCondition" runat="server">
    <asp:Panel ID="pnlCondition" runat="server">
        <table>
            <tr>
                <th>标题:
                </th>
                <td>
                    <asp:TextBox ID="prm_Title_" runat="server" CssClass="edit-text" Width="200px"></asp:TextBox>
                </td>
                <th>活动时间从:
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
        <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" Text="搜索" Width="60px" />
        <asp:Button runat="server" ID="btnReset" OnClick="btnReset_Click" Text="重置" Width="60px" />
    </div>
    <div class="clear">
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentPlaceList" runat="server">
    <telerik:RadGrid ID="grdPublishActivity" runat="server" OnNeedDataSource="radGrid_NeedDataSource"
        OnPageIndexChanged="radGrid_PageIndexChanged" OnItemDataBound="grdPublishActivity_ItemDataBound"
        AutoGenerateColumns="false" PageSize="30" AllowCustomPaging="true" AllowPaging="true">
        <MasterTableView DataKeyNames="ID" AllowCustomPaging="True" AllowPaging="True">
            <Columns>
                <telerik:GridBoundColumn DataField="Index" HeaderText="序号">
                    <HeaderStyle HorizontalAlign="Left" Width="40px" />
                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Title" HeaderText="标题">
                    <HeaderStyle Width="400px" HorizontalAlign="Left" />
                    <ItemStyle Width="400px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ActivityTypeLabel" HeaderText="活动类型">
                    <HeaderStyle Width="100px" HorizontalAlign="Left" />
                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="活动状态">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkStatus" runat="server" OnClick="linkStatus_Click" Text="开始应用"></asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn HeaderText="开始时间" DataField="BeginTime" DataFormatString="{0:yyyy-MM-dd}">
                    <ItemStyle HorizontalAlign="Left" />
                    <HeaderStyle HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="结束时间" DataField="EndTime" DataFormatString="{0:yyyy-MM-dd}">
                    <ItemStyle HorizontalAlign="Left" />
                    <HeaderStyle HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
            </Columns>
            <NoRecordsTemplate>
                <div>
                    没有记录!
                </div>
            </NoRecordsTemplate>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>
