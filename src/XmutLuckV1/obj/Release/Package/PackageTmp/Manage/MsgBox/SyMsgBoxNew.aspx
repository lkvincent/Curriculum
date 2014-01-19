<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/SubMaster.Master" AutoEventWireup="true" CodeBehind="SyMsgBoxNew.aspx.cs"
    Inherits="XmutLuckV1.Manage.MsgBox.SyMsgBoxNew" Theme="BaseManage" %>

<%@ Register Src="~/Manage/UserControl/EditorControl.ascx" TagName="EditorControl" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .msg-container {
            padding: 10px 20px 20px 20px;
        }

            .msg-container .row {
                margin: 10px auto;
            }

                .msg-container .row .label {
                    display: inline-block;
                    width: 60px;
                    text-align: right;
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

            .auto-list .image > div {
                max-height: 50px;
                max-width: 50px;
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
    </style>

    <script type="text/javascript">
        function goBack() {
            window.location.href = "../MsgBox/SyMsgBoxList.aspx";
        }
        $(function () {
            $("input.edit-text").jqxInput({ height: 20 });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxPanel ID="ajaxPanel" runat="server" LoadingPanelID="ajaxLoadingPanel" ClientEvents-OnResponseEnd="ResponseEnd">
        <div class="msg-container">
            <div class="action-bar">
                <asp:Button runat="server" ID="btnSend" Text="发送" OnClick="btnSend_Click" />
                <input type="button" id="btnBack" value="返回" onclick="goBack()" />
            </div>
            <div class="msg-header">
                <div class="row msg-to">
                    <div class="label">
                        <input type="button" value="收信人" onclick="" disabled="disabled" />
                    </div>
                    <div class="content">
                        <telerik:RadComboBox runat="server" ID="txtReceiver" AllowCustomText="True" AppendDataBoundItems="True" ShowMoreResultsBox="False"
                            ShowToggleImage="False" EnableLoadOnDemand="True" Width="752px" OnItemsRequested="txtReceiver_ItemsRequested">
                            <HeaderTemplate>
                                <ul class="auto-list">
                                    <li class="index"><span>序号</span></li>
                                    <li class="code"><span>编码</span></li>
                                    <li class="userType"><span>身份</span></li>
                                    <li class="name"><span>姓名</span></li>
                                    <li class="description"><span>描述</span></li>
                                </ul>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <ul class="auto-list">
                                    <li class="index"><span><%#Eval("Index") %></span></li>
                                    <li class="code"><span><%#Eval("Code") %></span></li>
                                    <li class="userType"><span><%#Eval("UserTypeLabel") %></span></li>
                                    <li class="name"><span><%#Eval("Name") %></span></li>
                                    <li class="description"><span><%#Eval("Description") %></span></li>
                                </ul>
                            </ItemTemplate>
                        </telerik:RadComboBox>
                    </div>
                    <asp:RequiredFieldValidator runat="server" ID="rqvReceiver" ControlToValidate="txtReceiver" Display="Dynamic"
                        ErrorMessage="<br/><span class='error'><i class='msg-ico'></i><label>收信人不能为空!</label></span>"></asp:RequiredFieldValidator>
                </div>
                <div class="row msg-title">
                    <div class="label">
                        主题:
                    </div>
                    <div class="content">
                        <asp:TextBox runat="server" ID="txtSubject" Width="750px" CssClass="edit-text"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtSubject" Display="Dynamic"
                            ErrorMessage="<br/><span class='error'><i class='msg-ico'></i><label>主题不能为空!</label></span>"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="msg-body">
                <uc:EditorControl ID="editMsgBody" runat="server" EditorWidth="820" EditorHeight="400"></uc:EditorControl>
            </div>
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>
