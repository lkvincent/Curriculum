<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/ThickBox.Master" AutoEventWireup="true" CodeBehind="RequestNewJob.aspx.cs" Inherits="XmutLuckV1.Manage.Student.RequestNewJob" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        table th {
            width: 80px;
        }

        table tr th:first-child {
            width: 110px;
            text-align: right;
            vertical-align: top;
        }

        table td.action {
            padding-right: 30px;
            padding-top: 6px;
        }
        .condition {
            display: none;
        }
    </style>
    <script type="text/javascript">
        function GetComponentSize(current, config) {
            return {
                Width: "60px"
            };
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceCondition" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceAction" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentPlaceList" runat="server">
    <table width="100%">
        <tr>
            <th>公司名称:</th>
            <td colspan="3">
                <asp:Literal runat="server" ID="ltlEnterpriseName"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th>职位名称:</th>
            <td colspan="3">
                <asp:Literal runat="server" ID="ltlJobName"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th>招聘人数:</th>
            <td>
                <asp:Literal runat="server" ID="ltlNum"></asp:Literal>
            </td>
            <th>薪资范围:</th>
            <td>
                <asp:Literal runat="server" ID="ltlSalaryScope"></asp:Literal></td>
        </tr>
        <tr>
            <th>工作地点:</th>
            <td colspan="3">
                <asp:Literal runat="server" ID="ltlWorkPlace"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th>备注:</th>
            <td colspan="3">
                <asp:TextBox runat="server" ID="txtNote" Width="323px" Height="60px" TextMode="MultiLine" CssClass="multi-edit-text" MaxLength="150"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>推荐人(老师):</th>
            <td colspan="3">
                <asp:ListBox runat="server" ID="lstTeacher" Height="120px" Width="325px" SelectionMode="Multiple" />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="right" class="action">
                <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Text="申请职位" />
            </td>
        </tr>
    </table>
</asp:Content>
