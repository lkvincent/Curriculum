﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadLabelControl.ascx.cs"
    Inherits="XmutLuckV1.Manage.UserControl.UploadLabelControl" %>
<div class="fileLabel-Upload">
    <table>
        <tr>
            <th></th>
            <td>
                <div class="file-Upload ">
                    <asp:FileUpload ID="uploadFile" runat="server" onchange="fileChange()" Width="70px" />
                    <asp:TextBox ID="txtFile" runat="server" Width="152px" ReadOnly="true" CssClass="upload-edit-text"></asp:TextBox>
                    <%--                  <input type="button" value="添加文件"/>--%>
                    <asp:Button ID="btnSelect" runat="server" OnClientClick="return false;"
                        Text="添加文件" />
                </div>
            </td>
        </tr>
        <tr>
            <th>附件描述:
            </th>
            <td>
                <asp:TextBox ID="txtFileLabel" runat="server" Width="225px" Height="25px" CssClass="multi-edit-text"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnUpload" runat="server" Text="开始上传" OnClick="btnUpload_Click" OnClientClick="if(!UploadValidate())return false;"
                    ValidationGroup="file-upload" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rqvFileLabel" runat="server" Display="Dynamic" ErrorMessage="<span class='error'><i class='msg-ico'></i><label>附件描述不能为空!</label></span>"
                    ControlToValidate="txtFileLabel" ValidationGroup="file-upload"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</div>
<script type="text/javascript">
    function fileChange() {
        var upload = $("#<%=uploadFile.ClientID %>");
        var txt = upload.next();
        txt.val(upload.val());
    }
    $("#<%=txtFile.ClientID %>").val("");

    function UploadValidate() {
        if (typeof BeforeUploadValidate == "function") {
            return BeforeUploadValidate();
        }
        return true;
    }

    $(function () {
        $(".file-Upload input[type='submit']").jqxButton({ width: "60px", height: "26px" });
    });
</script>
