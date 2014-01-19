<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterList.master" AutoEventWireup="true"
    CodeBehind="JobRequesterList.aspx.cs" Inherits="XmutLuckV1.Manage.Enterprise.JobRequesterList" Theme="EnterpriseManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHead" runat="server">
    <script type="text/javascript">
        function ViewResume(studentNum, jobRequestID) {
            window.parent.tb_showIFrame("求职者简历", "ViewRequesterResume.aspx?StudentNum=" + studentNum + "&JobRequestID=" + jobRequestID + "&width=980&height=580&TB_iframe=true");
        }

        window.parent.IframeRemovedFunc = function () {
            __doPostBack('ctl00$ctl00$ContentPlaceHolder1$contentPlaceAction$btnSearch', '');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceCondition" runat="server">
    <asp:Panel ID="pnlCondition" runat="server">
        <table>
            <tr>
                <th>职位:
                </th>
                <td>
                    <asp:TextBox ID="prm_JobTitle_" runat="server" Width="200px" CssClass="edit-text"></asp:TextBox>
                </td>
                <th>申请人:
                </th>
                <td>
                    <asp:TextBox ID="prm_StudentName_" runat="server" Width="200px" CssClass="edit-text"></asp:TextBox>
                </td>
                <th>状态:
                </th>
                <td>
                    <asp:DropDownList ID="prm_RecruitFlowID_" runat="server"></asp:DropDownList>
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
    <div class="clear">
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentPlaceList" runat="server">
    <div class="list-container">
        <telerik:RadGrid ID="grdEnterpriseJob" runat="server" AutoGenerateColumns="false"
            OnNeedDataSource="radGrid_NeedDataSource" OnItemDataBound="grdEnterpriseJob_ItemDataBound">
            <MasterTableView DataKeyNames="StudentNum,JobCode,ID">
                <Columns>
                    <telerik:GridBoundColumn DataField="Index" HeaderText="编号">
                        <HeaderStyle HorizontalAlign="Left" Width="40px" />
                        <ItemStyle HorizontalAlign="Left" Width="40px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JobTitle" HeaderText="职位名称">
                        <HeaderStyle HorizontalAlign="Left" Width="200px" />
                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JobNum" HeaderText="招聘人数">
                        <HeaderStyle HorizontalAlign="Left" Width="70px" />
                        <ItemStyle HorizontalAlign="Left" Width="70px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="StudentName" HeaderText="申请人">
                        <HeaderStyle HorizontalAlign="Left" Width="60px" />
                        <ItemStyle HorizontalAlign="Left" Width="60px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Sex" HeaderText="性别">
                        <HeaderStyle HorizontalAlign="Left" Width="40px" />
                        <ItemStyle HorizontalAlign="Left" Width="40px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Telephone" HeaderText="联系方式">
                        <HeaderStyle HorizontalAlign="Left" Width="70px" />
                        <ItemStyle HorizontalAlign="Left" Width="70px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RequestTime" HeaderText="申请时间" DataFormatString="{0:yyyy-MM-dd hh:mm:ss}">
                        <HeaderStyle HorizontalAlign="Left" Width="120px" />
                        <ItemStyle HorizontalAlign="Left" Width="120px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RequestStatus" HeaderText="状态">
                        <HeaderStyle HorizontalAlign="Left" Width="60px" />
                        <ItemStyle HorizontalAlign="Left" Width="60px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <a href="#">
                                <span onclick='ViewResume("<%#Eval("StudentNum") %>",<%#Eval("ID") %>)'>查看简历</span>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <NoRecordsTemplate>
                    没有记录.
                </NoRecordsTemplate>
            </MasterTableView>
            <ClientSettings>
                <Selecting AllowRowSelect="true" />
            </ClientSettings>
        </telerik:RadGrid>
    </div>
</asp:Content>
