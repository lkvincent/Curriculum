<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/SubMaster.Master" AutoEventWireup="true" CodeBehind="SyMsgDetail.aspx.cs" Inherits="XmutLuckV1.Manage.MsgBox.SyMsgDetail" %>

<%@ Register Src="~/Manage/UserControl/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../../Css/MessageBoxStyleSheet.css" />
    <style type="text/css">
        .msg-container {
            padding: 10px 20px 20px 20px;
        }

            .msg-container .row {
                margin: 10px auto;
            }

                .msg-container .row.msg-to, .msg-container .row.msg-receiver {
                    border-bottom: 1px solid rgb(249, 243, 243);
                    padding-bottom: 5px;
                }

                .msg-container .row .label {
                    display: inline-block;
                    width: 60px;
                    text-align: right;
                    padding-right: 5px;
                }

                .msg-container .row .content {
                    display: inline-block;
                }

            .msg-container .msg-action {
                margin-top: 10px;
            }

        .auto-list li {
            display: inline;
        }

        .auto-list {
            list-style: none;
        }

            .auto-list span {
                display: inline-block;
            }

            .auto-list .index > span {
                width: 40px;
            }

            .auto-list .code > span {
                width: 120px;
            }

            .auto-list .userType > span {
                width: 80px;
            }

            .auto-list .name > span {
                width: 150px;
            }

        .rcbList > li .index span {
            padding-left: 8px;
        }

        .rcbList > li {
            border-bottom: 1px solid #ddd;
        }

            .rcbList > li :hover {
                background-color: rgb(226, 241, 207);
            }

        .msg-body {
            padding: 10px;
            background-color: rgb(249, 243, 243);
            border: 1px solid #ddd;
        }

            .msg-body .label {
                padding-top: 5px;
                padding-bottom: 5px;
            }

            .msg-body .content {
                margin-top: 5px;
                border: 2px solid #ddd;
                min-height: 400px;
                background-color: #fff;
                padding: 2px;
            }
    </style>
    <script type="text/javascript">
        function goBack() {
            window.location.href = "../MsgBox/SyMsgBoxList.aspx";
        }

        function reply() {
            window.location.href = "../MsgBox/SyMsgBoxNew.aspx?RefId=<%=MsgID %>";
        }
    </script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxPanel ID="ajaxPanel" runat="server" LoadingPanelID="ajaxLoadingPanel" ClientEvents-OnResponseEnd="ResponseEnd">
        <div class="msg-container">
            <div class="action-bar">
                <asp:Button runat="server" ID="btnReply" OnClientClick="reply();return;" Text="回复"/>
                <input type="button" id="btnBack" value="返回" onclick="goBack()" />
            </div>
            <div class="msg-header">
                <div class="row msg-to">
                    <div class="label">
                        发件人:
                    </div>
                    <div class="content">
                        <asp:Literal runat="server" ID="ltlSender"></asp:Literal>
                    </div>
                </div>
                <div class="row msg-receiver">
                    <div class="label">
                        收件人:
                    </div>
                    <div class="content">
                        <asp:Literal runat="server" ID="ltlReceiver"></asp:Literal>
                    </div>
                </div>
                <div class="row msg-title">
                    <div class="label">
                        主题:
                    </div>
                    <div class="content">
                        <asp:Literal runat="server" ID="ltlSubject"></asp:Literal>
                    </div>
                </div>
            </div>
            <div class="msg-body">
                <div class="label">
                    内容:
                </div>
                <div class="content">
                    <asp:Literal runat="server" ID="ltlContent"></asp:Literal>
                </div>
            </div>
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>

