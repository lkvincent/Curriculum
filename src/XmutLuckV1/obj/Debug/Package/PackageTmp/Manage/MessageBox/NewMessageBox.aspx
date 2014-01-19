﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/SubMaster.Master" AutoEventWireup="true" CodeBehind="NewMessageBox.aspx.cs"
    Inherits="XmutLuckV1.Manage.MessageBox.NewMessageBox" Theme="BaseManage" %>

<%@ Register Src="~/Manage/UserControl/EditorControl.ascx" TagName="EditorControl" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
          .msg-container {
            padding: 10px 20px 20px 20px;
        }
    </style>

    <script type="text/javascript">
        function goBack() {
            window.location.href = "../MessageBox/MessageBoxList.aspx";
        }
        $(function () {
            $("input.edit-text").jqxInput({ height: 20 });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:radajaxpanel id="ajaxPanel" runat="server" loadingpanelid="ajaxLoadingPanel" clientevents-onresponseend="ResponseEnd">
        <div class="msg-container">
            <div class="action-bar">
                <asp:Button runat="server" ID="btnSend" Text="发送" OnClick="btnSend_Click" />
                <input type="button" id="btnBack" value="返回" onclick="goBack()" style="height: 25px;" />
            </div>
            <div class="msg-header">
                <table width="100%">
                   <tr>
                     <th><input type="button" value="收信人" onclick="" disabled="disabled" /></th>  
                     <td>
                      <div class="content">
                        <telerik:RadComboBox runat="server" ID="txtReceiver" AllowCustomText="True" AppendDataBoundItems="True" ShowMoreResultsBox="False"
                            ShowToggleImage="False" EnableLoadOnDemand="True" Width="760px" OnItemsRequested="txtReceiver_ItemsRequested">
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
                     </td>
                   </tr>
                    <tr>
                        <th>主题:</th>
                        <td>
                                             <div class="content">
                        <asp:TextBox runat="server" ID="txtSubject" Width="760px" CssClass="edit-text"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtSubject" Display="Dynamic"
                            ErrorMessage="<br/><span class='error'><i class='msg-ico'></i><label>主题不能为空!</label></span>"></asp:RequiredFieldValidator>
                    </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="msg-body">
                <uc:EditorControl ID="editMsgBody" runat="server" EditorWidth="820" EditorHeight="400"></uc:EditorControl>
            </div>
        </div>
    </telerik:radajaxpanel>
</asp:Content>
