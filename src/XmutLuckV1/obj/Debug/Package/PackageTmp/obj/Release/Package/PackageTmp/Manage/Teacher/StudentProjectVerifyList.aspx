<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterList.master" AutoEventWireup="true"
    CodeBehind="StudentProjectVerifyList.aspx.cs" Inherits="XmutLuckV1.Manage.Teacher.StudentProjectVerifyList" %>

<%@ Register Src="~/Manage/UserControl/GradeControl.ascx" TagName="GradeControl"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceCondition" runat="server">
    <asp:Panel ID="pnlCondition" runat="server">
        <table>
            <tr>
                <th>
                    项目名称:
                </th>
                <td>
                    <asp:TextBox ID="prm_Name_" runat="server"></asp:TextBox>
                </td>
                <th>
                    开始时间从:
                </th>
                <td>
                    <telerik:RadDatePicker ID="prm_DateFrom_" runat="server">
                        <DateInput DateFormat="yyyy-MM-dd" runat="server">
                        </DateInput>
                    </telerik:RadDatePicker>
                </td>
                <th>
                    到
                </th>
                <td>
                    <telerik:RadDatePicker ID="prm_DateTo_" runat="server">
                        <DateInput ID="DateInput1" DateFormat="yyyy-MM-dd" runat="server">
                        </DateInput>
                    </telerik:RadDatePicker>
                </td>
                <th>
                    审核状态:
                </th>
                <td>
                    <asp:DropDownList ID="prm_VerfyStatus_" runat="server" Width="110px">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceAction" runat="server">
    <div class="right">
       <asp:Button ID="btnSearch" runat="server"  OnClick="btnSearch_Click" Text="搜索"></asp:Button>
       <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="重置"></asp:Button>
    </div>
    <div class="clear">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceList" runat="server">
    <telerik:RadGrid ID="grdProject" runat="server" OnNeedDataSource="radGrid_NeedDataSource"
        OnPageIndexChanged="radGrid_PageIndexChanged" AutoGenerateColumns="false" PageSize="30"
        AllowCustomPaging="true" AllowPaging="true">
        <MasterTableView DataKeyNames="ID">
            <Columns>
                <telerik:GridBoundColumn DataField="Index" HeaderText="序号">
                                   <HeaderStyle HorizontalAlign="Left" Width="40px" />
                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="StudentName" HeaderText="学生姓名">
                    <HeaderStyle Width="70px" HorizontalAlign="Left" />
                    <ItemStyle Width="70px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Name" HeaderText="项目名称">
                    <HeaderStyle Width="250px" HorizontalAlign="Left" />
                    <ItemStyle Width="250px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Position" HeaderText="职责">
                    <HeaderStyle Width="120px" HorizontalAlign="Left" />
                    <ItemStyle Width="120px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="VerfyStatus" HeaderText="审核状态">
                    <HeaderStyle Width="70px" HorizontalAlign="Left" />
                    <ItemStyle Width="70px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="开始时间" DataField="BeginTime">
                    <ItemStyle HorizontalAlign="Left" />
                    <HeaderStyle HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="结束时间" DataField="EndTime">
                    <ItemStyle HorizontalAlign="Left" />
                    <HeaderStyle HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="通过">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkIsPassed" runat="server" OnCheckedChanged="chkIsPassed_CheckedChanged"
                            AutoPostBack="true" Checked='<%#Eval("IsPassed") %>' />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn>
                    <ItemTemplate>
                        <a href='StudentProjectVerifyDetail.aspx?ID=<%#Eval("ID") %>' title="编辑" class="grid-edit"><span>编辑</span>
                        </a>
                    </ItemTemplate>
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
