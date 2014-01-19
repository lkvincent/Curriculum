<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterList.master" AutoEventWireup="true"
    CodeBehind="EnterpriseJobList.aspx.cs" Inherits="XmutLuckV1.Manage.Enterprise.EnterpriseJobList" Theme="EnterpriseManage" %>

<%@ Register Src="~/Manage/Enterprise/UserControl/EnterpriseJobDetail.ascx" TagName="EnterpriseJobDetail"
    TagPrefix="uc" %>
<asp:Content ContentPlaceHolderID="contentHead" runat="server">
    <style type="text/css">
        .enterprise-job .head-bar {
            margin-bottom: 10px;
        }

        .enterprise-job table tr th {
            width: 100px;
        }

            .enterprise-job table tr th.to {
                width: 20px;
            }

        .enterprise-job table tr .time-scope > div {
            float: left;
        }

            .enterprise-job table tr .time-scope > div.label {
                margin: 5px;
            }

        .enterprise-job .conatiner {
            padding: 10px;
        }

            .enterprise-job .conatiner > div {
                margin-left: 10px;
            }

        .list-container .rgEditForm .action {
            margin-right: 63px;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceCondition" runat="server">
    <asp:Panel ID="pnlCondition" runat="server">
        <table>
            <tr>
                <th>职位:
                </th>
                <td>
                    <asp:TextBox ID="prm_Name_" runat="server" Width="260px" CssClass="edit-text"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceAction" runat="server">
    <div class="left">
        <asp:Button ID="btnNew" runat="server" OnClick="btnNew_Click" Text="新增"></asp:Button>
    </div>
    <div class="right">
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="搜索"></asp:Button>
        <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="重置"></asp:Button>
    </div>
    <div class="clear">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceList" runat="server">
    <div class="list-container">
        <telerik:RadGrid ID="grdEnterpriseJob" runat="server" AutoGenerateColumns="false" AllowCustomPaging="True" AllowPaging="True"
            OnItemDataBound="grdEnterpriseJob_ItemDataBound" OnItemCommand="grdEnterpriseJob_ItemCommand"
            OnNeedDataSource="radGrid_NeedDataSource">
            <MasterTableView AllowCustomPaging="True" AllowPaging="True">
                <Columns>
                    <telerik:GridBoundColumn DataField="Index" HeaderText="编号">
                               <HeaderStyle HorizontalAlign="Left" Width="40px" />
                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Name" HeaderText="职位">
                        <HeaderStyle HorizontalAlign="Left" Width="160" />
                        <ItemStyle HorizontalAlign="Left" Width="160" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Num" HeaderText="数量">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SalaryScope" HeaderText="薪资范围">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Nature" HeaderText="职位性质">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn HeaderText="性别要求">
                        <ItemTemplate>
                            <asp:Literal ID="ltlSex" runat="server"></asp:Literal>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="RecruitmentTargets" HeaderText="招聘对象">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridCheckBoxColumn DataField="IsOnline" HeaderText="发布">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridCheckBoxColumn>
                    <telerik:GridDateTimeColumn DataField="StartTime" HeaderText="开始日期" DataFormatString="{0:yyyy-MM-dd}">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridDateTimeColumn>
                    <telerik:GridDateTimeColumn DataField="EndTime" HeaderText="结束日期" DataFormatString="{0:yyyy-MM-dd}">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridDateTimeColumn>
                    <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkEdit" runat="server" CommandName="Edit" Text="编辑"></asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <asp:HiddenField ID="hdfID" runat="server" Value='<%#Eval("ID") %>' />
                            <asp:LinkButton ID="linkDelete" runat="server" CommandName="Delete" OnClientClick='<%# "if(!BeforeDeletd(\""+DataBinder.Eval(Container,"DataItem.Code")+"\",\""+DataBinder.Eval(Container,"DataItem.Name")+"\"))return false;"%>' Text="删除"></asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <EditFormSettings EditFormType="Template">
                    <FormTemplate>
                        <div class="data-detail">
                            <asp:HiddenField ID="hdfJobCode" runat="server" />
                            <uc:enterprisejobdetail id="enterpriseJobDetail" runat="server">
                            </uc:enterprisejobdetail>
                        </div>
                        <div class="action">
                            <asp:Button ID="btnUpdate" runat="server" CommandName='<%# (Container is GridEditFormInsertItem)?"PerformInsert":"Update" %>'
                                Text="保存" />
                            <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="取消" />
                        </div>
                    </FormTemplate>
                </EditFormSettings>
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
