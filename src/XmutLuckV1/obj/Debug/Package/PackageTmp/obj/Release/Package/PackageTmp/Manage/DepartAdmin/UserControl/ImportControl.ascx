<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImportControl.ascx.cs"
    Inherits="XmutLuckV1.Manage.DepartAdmin.UserControl.ImportControl" %>
<div class="file-Upload import-data">
    <asp:FileUpload ID="uploadFile" runat="server" onchange="fileChange()" />
    <asp:TextBox ID="txtFile" runat="server" ReadOnly="true" CssClass="edit-text"></asp:TextBox>
    <asp:Button ID="btnSelect" runat="server" OnClientClick="return false;" Text="添加文件" />
    <span>
        <asp:Button ID="btnUpload" runat="server" Text="开始导入" OnClick="btnUpload_Click" /></span>
    <br style="clear: both;" />
</div>
<script type="text/javascript">
    function fileChange() {
        var upload = $("#<%=uploadFile.ClientID %>");
        var txt = upload.next();
        txt.val(upload.val());
    }

    $(document).ready(function() {
        $("input.edit-text").jqxInput({ height: 25, width: 180 });
    });
</script>
