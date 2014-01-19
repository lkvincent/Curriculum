﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/SubMaster.Master" AutoEventWireup="true" CodeBehind="JobActionTip.aspx.cs"
    Inherits="XmutLuckV1.Manage.Enterprise.JobActionTip" Theme="EnterpriseManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .body-content .main {
            width: 600px !important;
            border: 1px solid #ddd;
            border-right-width: 0px;
        }
        .body-content .main table.wrap-container {
            height: 200px !important;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtDescription.ClientID%>").jqTransInputText();
            $("#btnSubmit,#btnClose").jqTransInputButton();

            $("#btnSubmit > span").click(function() {
                var desc = $("#<%=txtDescription.ClientID%>").val();
                XmutLuckV1.Ajax.AjaxService.ChangeRequestJobStage(<%=JobRequestId%>, <%=JobRequestStageId%>, desc, function (result) {
                    if (!result.IsSucess) {
                        to_show(result.IsSucess, result.Message);
                    } else {
                        alert("保存成功!");
                    }
                }, function (error) {
                    alert(error);
                });
            });

            $("#btnClose > span").click(function() {
                parent.tb_remove();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="detail">
        <div class="container">
            <table>
                <tr>
                    <th valign="top">描述:</th>
                    <td>
                        <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Width="500px" Height="100px" MaxLength="2000"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th></th>
                    <td>
                        <input type="button" id="btnSubmit" value="提交" />
                        <input type="button" id="btnClose" value="关闭"  />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
