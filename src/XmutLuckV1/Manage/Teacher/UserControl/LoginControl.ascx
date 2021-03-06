﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs" Inherits="XmutLuckV1.Manage.Teacher.UserControl.LoginControl" %>
<div class="data-container">
    <div class="caption">
        <h3>
            教师登入</h3>
    </div>
    <div class="data-detail">
        <table>
            <tr>
                <th>
                    工号:
                </th>
                <td>
                    <asp:TextBox ID="txt_TeacherNum_" runat="server" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    密码:
                </th>
                <td>
                    <asp:TextBox ID="txt_Password_" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div class="action-container">
        <div class="action-right">
            <asp:HyperLink ID="linkResetPassword" runat="server" NavigateUrl="~/Manage/Teacher/ResetPassword.aspx"
                Text="忘记密码" Target="_self"></asp:HyperLink>
            <asp:Button ID="btn_Login_" runat="server" OnClick="btn_Login_Click" Text="登入" />
        </div>
        <div class="clear">
        </div>
    </div>
</div>
