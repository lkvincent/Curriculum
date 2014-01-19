<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterList.master" AutoEventWireup="true" CodeBehind="SyMsgBoxList.aspx.cs"
    Inherits="XmutLuckV1.Manage.MsgBox.SyMsgBoxList" Theme="BaseManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceCondition" runat="server">
    <asp:Panel ID="pnlCondition" runat="server">
        <table>
            <tr>
                <th>标题:
                </th>
                <td>
                    <asp:TextBox ID="prm_Subject_" runat="server" CssClass="edit-text"></asp:TextBox>
                </td>
                <th>开始时间从:
                </th>
                <td>
                    <telerik:RadDatePicker ID="prm_DateFrom_" runat="server" Width="100px">
                        <DateInput DateFormat="yyyy-MM-dd">
                        </DateInput>
                    </telerik:RadDatePicker>
                </td>
                <th>到
                </th>
                <td>
                    <telerik:RadDatePicker ID="prm_DateTo_" runat="server" Width="100px">
                        <DateInput ID="DateInput1" DateFormat="yyyy-MM-dd" runat="server">
                        </DateInput>
                    </telerik:RadDatePicker>
                </td>
                <th>状态:</th>
                <td>
                    <asp:DropDownList runat="server" ID="prm_IsReaded_">
                    </asp:DropDownList>
                </td>
                <th>类型:</th>
                <td>
                    <asp:DropDownList runat="server" ID="prm_MsgType_">
                    </asp:DropDownList>
                </td>

            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceAction" runat="server">
    <div class="left">
        <input type="button" value="新建" onclick="CreateNewMsg();" />
    </div>
    <div class="right">
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="搜索"></asp:Button>
        <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="重置"></asp:Button>
    </div>
    <div class="clear">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceList" runat="server">
    <telerik:RadGrid ID="grdMsgBox" runat="server" OnNeedDataSource="radGrid_NeedDataSource"
        OnPageIndexChanged="radGrid_PageIndexChanged" AutoGenerateColumns="false" PageSize="30" AllowCustomPaging="true" AllowPaging="true">
        <MasterTableView DataKeyNames="ID">
            <Columns>
                <telerik:GridBoundColumn DataField="Index" HeaderText="序号">
                    <HeaderStyle HorizontalAlign="Left" Width="40px" />
                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="MsgType" HeaderText="类型">
                    <HeaderStyle HorizontalAlign="Left" Width="100px" />
                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ReadLabel" HeaderText="状态">
                    <HeaderStyle HorizontalAlign="Left" Width="40px" />
                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Subject" HeaderText="标题">
                    <HeaderStyle HorizontalAlign="Left" Width="350px" />
                    <ItemStyle HorizontalAlign="Left" Width="350px" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn>
                    <HeaderStyle Width="30px" HorizontalAlign="Left" />
                    <ItemStyle Width="30px" HorizontalAlign="Left" />
                    <ItemTemplate>
                        <a href='../MsgBox/SyMsgDetail.aspx?ID=<%#Eval("ID") %>'>查看</a>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <%--                <telerik:GridTemplateColumn>
                    <HeaderStyle Width="80px" HorizontalAlign="Left" />
                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                    <ItemTemplate>
                        <a href='../MsgBox/SyMsgDetail.aspx?ID=<%#Eval("ID") %>'><b style="color: red;"><%#Eval("NewReplyCount") %></b> 条回复数未读</a>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>--%>
                <telerik:GridBoundColumn DataField="Time" HeaderText="发送时间" DataFormatString="{0:yyyy-MM-dd hh:mm:ss}">
                    <HeaderStyle Width="120px" HorizontalAlign="Left" />
                    <ItemStyle Width="120px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
            </Columns>
            <NoRecordsTemplate>
                <div>
                    没有记录!
                </div>
            </NoRecordsTemplate>
        </MasterTableView>
    </telerik:RadGrid>
    <script type="text/javascript">
        function CreateNewMsg() {
            window.location.href = "../MsgBox/SyMsgBoxNew.aspx";
        }
    </script>
</asp:Content>
