<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/SubMaster.Master" AutoEventWireup="true" CodeBehind="RecruitFlowDetailByBatch.aspx.cs"
    Inherits="XmutLuckV1.Manage.Enterprise.RecruitFlowDetailByBatch" Theme="EnterpriseManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .detail-moved-container > table {
            width: 100%;
            border-collapse: collapse;
            border-color: #ddd;
            background-color: #fff;
        }

            .detail-moved-container > table td.moved-cell {
                vertical-align: top;
                text-align: center;
                width: 50px;
            }

        .body-content .main .wrap-container .wrap-right .action {
            text-align: left !important;
            margin: auto !important;
            border: 1px solid #ddd;
            background-color: rgb(249, 243, 243);
            padding: 8px 10px !important;
            border-top-left-radius: 15px;
            border-top-right-radius: 15px;
        }

        .detail .container {
            border-bottom: 1px solid #ddd;
            margin-bottom: 10px;
            background-color: #fff;
        }

        .moved-action {
            padding-top: 40px;
        }

            .moved-action > div {
                width: 40px;
                margin: auto;
            }

            .moved-action input {
                margin-top: 10px;
            }

        .list-container {
            min-height: 200px;
        }

        .wrap {
            background-color: rgb(252, 231, 230);
        }

        .RadGrid.RadGrid_Default {
            border: 0px;
        }
    </style>
    <script type="text/javascript">
        function GoBack() {
            window.location.href = "RecruitFlowList.aspx";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="detail">
        <div class="action">
            <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="保存" />
            <input type="button" value="返回" id="btnGoBack" onclick="GoBack()" />
        </div>
        <div class="wrap">
            <div class="container">
                <span>备注:</span>
                <asp:TextBox runat="server" ID="txtNotes" CssClass="edit-text" Width="400px" MaxLength="2000"></asp:TextBox>
                <span>面试进度更改为:</span>
                <asp:DropDownList runat="server" ID="drp_RecruitFlow_" Width="160px" />
            </div>
            <div class="detail-moved-container">
                <table border="1">
                    <td class="moved-cell">
                        <div class="list-container">
                            <telerik:RadGrid ID="grdRecruitFlowDetail" runat="server"
                                AutoGenerateColumns="false" AllowCustomPaging="false" AllowPaging="false"
                                OnNeedDataSource="radGrid_NeedDataSource" Width="400px">
                                <MasterTableView AllowCustomPaging="false" AllowPaging="false" DataKeyNames="ID">
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="">
                                            <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                            <ItemStyle HorizontalAlign="Left" Width="20px" />
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chkOriginalSelected" />
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:CheckBox runat="server" ID="chkOriginalHeader" OnCheckedChanged="chkHeader_CheckedChanged" AutoPostBack="True" />
                                            </HeaderTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Index" HeaderText="编号">
                                            <HeaderStyle HorizontalAlign="Left" Width="30px" />
                                            <ItemStyle HorizontalAlign="Left" Width="30px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="姓名" DataField="StudentName">
                                            <HeaderStyle HorizontalAlign="Left" Width="60px" />
                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="性别" DataField="SexLabel">
                                            <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                            <ItemStyle HorizontalAlign="Left" Width="20px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="当前状态" DataField="RequestStatus">
                                            <HeaderStyle HorizontalAlign="Left" Width="60px" />
                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn HeaderText="查看简历">
                                            <HeaderStyle HorizontalAlign="Left" Width="60px" />
                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                            <ItemTemplate>
                                                <a href="../../Template/StudentTemplate/ViewStudentResume.aspx?StudentNum=<%#Eval("StudentNum") %>" target="_blank"></a>
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
                    </td>
                    <td class="moved-cell">
                        <div class="moved-action">
                            <div>
                                <asp:Button runat="server" ID="btnMoveRight" Text=">>" Width="40px" OnClick="btnMoveRight_Click" />
                            </div>
                            <div>
                                <asp:Button runat="server" ID="btnMoveLeft" Text="<<" Width="40px" OnClick="btnMoveLeft_Click" />
                            </div>
                        </div>
                    </td>
                    <td class="moved-cell">
                        <div class="list-container">
                            <telerik:RadGrid ID="grdTargetJobRequestStage" runat="server" AutoGenerateColumns="false" AllowCustomPaging="false" AllowPaging="false"
                                OnNeedDataSource="grdTargetJobRequestStage_NeedDataSource" Width="400px">
                                <MasterTableView AllowCustomPaging="false" AllowPaging="false" DataKeyNames="ID">
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="">
                                            <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                            <ItemStyle HorizontalAlign="Left" Width="20px" />
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chkTargetSelected" />
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:CheckBox runat="server" ID="chkTargetHeader" OnCheckedChanged="chkHeader_CheckedChanged" AutoPostBack="True" />
                                            </HeaderTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Index" HeaderText="编号">
                                            <HeaderStyle HorizontalAlign="Left" Width="30px" />
                                            <ItemStyle HorizontalAlign="Left" Width="30px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="姓名" DataField="StudentName">
                                            <HeaderStyle HorizontalAlign="Left" Width="60px" />
                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="性别" DataField="SexLabel">
                                            <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                            <ItemStyle HorizontalAlign="Left" Width="20px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="当前状态" DataField="RequestStatus">
                                            <HeaderStyle HorizontalAlign="Left" Width="60px" />
                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn HeaderText="查看简历">
                                            <HeaderStyle HorizontalAlign="Left" Width="60px" />
                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                            <ItemTemplate>
                                                <a href="../../Template/StudentTemplate/ViewStudentResume.aspx?StudentNum=<%#Eval("StudentNum") %>" target="_blank"></a>
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
                    </td>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
