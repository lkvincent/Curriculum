﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterList.master" AutoEventWireup="true" CodeBehind="TeacherReferralsList.aspx.cs" Inherits="XmutLuckV1.Manage.Student.TeacherReferralsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHead" runat="server">
    <script type="text/javascript">
        function ViewDetail(jobCode) {
            window.parent.ShowIframeForm("查看岗位明细要求", "ViewJobDetail.aspx?JobCode=" + jobCode, "910px", "500px");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceCondition" runat="server">
    <asp:Panel ID="pnlCondition" runat="server">
        <table>
            <tr>
                <th>公司名称:
                </th>
                <td>
                    <asp:TextBox ID="prm_EnterpriseName_" runat="server" CssClass="edit-text"></asp:TextBox>
                </td>
                <th>职位名称:
                </th>
                <td>
                    <asp:TextBox ID="prm_JobName_" runat="server" CssClass="edit-text"></asp:TextBox>
                </td>
                <th>工作地点:
                </th>
                <td>
                    <asp:TextBox ID="prm_WorkPlace_" runat="server" CssClass="edit-text">
                    </asp:TextBox>
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
    <telerik:RadGrid ID="grdEnterpriseJob" runat="server" OnNeedDataSource="radGrid_NeedDataSource"
        AutoGenerateColumns="false" PageSize="30" AllowCustomPaging="true" AllowPaging="true">
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn DataField="Index" HeaderText="序号">
                    <HeaderStyle HorizontalAlign="Left" Width="40px" />
                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn>
                    <HeaderStyle HorizontalAlign="Left" Width="90px" />
                    <ItemStyle HorizontalAlign="Left" Width="90px" />
                    <ItemTemplate>
                        <a href='#' title="查看岗位明细" onclick="ViewDetail('<%#Eval("Code") %>')" class="grid-edit">
                            <span>查看岗位要求</span>
                        </a>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="Referralers" HeaderText="邀请推荐人">
                    <HeaderStyle Width="180px" HorizontalAlign="Left" />
                    <ItemStyle Width="180px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ActualReferralers" HeaderText="实际推荐人">
                    <HeaderStyle Width="180px" HorizontalAlign="Left" />
                    <ItemStyle Width="180px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="RecruitTypeStatus" HeaderText="推荐状态">
                    <HeaderStyle Width="80px" HorizontalAlign="Left" />
                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="邀请时间" DataField="ReferralTime" DataFormatString="{0:yyyy-MM-dd hh:mm}">
                    <ItemStyle Width="120px" HorizontalAlign="Left" />
                    <HeaderStyle Width="120px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="EnterpriseName" HeaderText="公司名称">
                    <HeaderStyle Width="200px" HorizontalAlign="Left" />
                    <ItemStyle Width="200px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Name" HeaderText="职位名称">
                    <HeaderStyle Width="150px" HorizontalAlign="Left" />
                    <ItemStyle Width="150px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Num" HeaderText="数量">
                    <HeaderStyle Width="60px" HorizontalAlign="Left" />
                    <ItemStyle Width="60px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="SexRequired" HeaderText="性别要求">
                    <HeaderStyle Width="70px" HorizontalAlign="Left" />
                    <ItemStyle Width="70px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Education" HeaderText="学历要求">
                    <HeaderStyle Width="80px" HorizontalAlign="Left" />
                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="WorkPlace" HeaderText="工作地点">
                    <HeaderStyle Width="200px" HorizontalAlign="Left" />
                    <ItemStyle Width="200px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="SalaryScope" HeaderText="薪资范围">
                    <HeaderStyle Width="80px" HorizontalAlign="Left" />
                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="开始时间" DataField="StartTime" DataFormatString="{0:yyyy-MM-dd}">
                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                    <HeaderStyle Width="80px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="结束时间" DataField="EndTime" DataFormatString="{0:yyyy-MM-dd}">
                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                    <HeaderStyle Width="80px" HorizontalAlign="Left" />
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
