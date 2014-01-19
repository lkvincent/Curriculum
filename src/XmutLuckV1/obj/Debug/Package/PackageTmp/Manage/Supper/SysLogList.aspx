﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterList.master" AutoEventWireup="true" CodeBehind="SysLogList.aspx.cs"
    Inherits="XmutLuckV1.Manage.Supper.SysLogList" Theme="DepartAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceCondition" runat="server">
    <asp:Panel ID="pnlCondition" runat="server">
        <table>
            <tr>
                <th>日志类型:
                </th>
                <td>
                    <asp:DropDownList runat="server" ID="prm_LogType_" Width="120px"></asp:DropDownList>
                </td>
                <th>日志名称:
                </th>
                <td>
                    <asp:TextBox ID="prm_Name_" runat="server" Width="180px" CssClass="edit-text"></asp:TextBox>
                </td>
                <th>日志名称描述:</th>
                <td>
                    <asp:TextBox ID="prm_Message_" runat="server" Width="180px" CssClass="edit-text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>开始时间从:
                </th>
                <td>
                    <telerik:RadDatePicker ID="prm_DateFrom_" runat="server">
                        <DateInput ID="DateInput2" DateFormat="yyyy-MM-dd" runat="server">
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
    <telerik:RadGrid ID="grdSystemLog" runat="server" AutoGenerateColumns="false" OnNeedDataSource="radGrid_NeedDataSource">
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn DataField="Index" HeaderText="编号">
                    <HeaderStyle HorizontalAlign="Left" Width="40px" />
                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LogType" HeaderText="日志类型">
                    <HeaderStyle HorizontalAlign="Left" Width="100" />
                    <ItemStyle HorizontalAlign="Left" Width="100" />
                </telerik:GridBoundColumn>
                <telerik:GridDateTimeColumn DataField="Name" HeaderText="日志名称">
                    <HeaderStyle HorizontalAlign="Left" Width="200" />
                    <ItemStyle HorizontalAlign="Left" Width="200" />
                </telerik:GridDateTimeColumn>
                <telerik:GridDateTimeColumn DataField="Message" HeaderText="日志名称">
                    <HeaderStyle HorizontalAlign="Left" Width="400" />
                    <ItemStyle HorizontalAlign="Left" Width="400" />
                </telerik:GridDateTimeColumn>
                <telerik:GridDateTimeColumn DataField="LogTime" HeaderText="时间" DataFormatString="{0:yyyy-MM-dd hh:mm:ss}">
                    <HeaderStyle HorizontalAlign="Left" Width="100" />
                    <ItemStyle HorizontalAlign="Left" Width="100" />
                </telerik:GridDateTimeColumn>
            </Columns>
            <NoRecordsTemplate>
                <div class="empty">
                    没有记录
                </div>
            </NoRecordsTemplate>
        </MasterTableView>
        <ClientSettings>
            <Selecting AllowRowSelect="true" />
        </ClientSettings>
    </telerik:RadGrid>
</asp:Content>

