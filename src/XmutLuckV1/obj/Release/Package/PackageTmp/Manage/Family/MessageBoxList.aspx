<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/SubMaster.Master" AutoEventWireup="true" CodeBehind="MessageBoxList.aspx.cs"
    Inherits="XmutLuckV1.Manage.Family.MessageBoxList" Theme="FamilyManage" %>

<%@ Register Src="~/Manage/UserControl/MessageBoxList.ascx" TagName="MessageBoxList" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../../Css/MessageBoxStyleSheet.css" />

    <script type="text/javascript">
        $(document).ready(function () {
            $("input[type='button']").jqTransInputButton();
            $("#btnTeacher > span").click(function () {
                SendEmail("", "");
            });

            $("#btnAssistant > span").click(function () {
                SendEmail("", "");
            });

            function SendEmail(senderName, senderType) {
                parent.tb_showIFrame("新建信件", "../MessageBoxDialog.aspx?ReceiverName=" + senderName + "&ReceiverType=" + senderType + "&width=600&height=280&TB_iframe=true");
            }
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="msgbox-action">
        <div class="left">
            <input type="button" value="发生信件给子女班主任" id="btnTeacher" />
            <input type="button" value="发生信件给子女辅导员" id="btnAssistant" />
        </div>
        <div class="right">
            <asp:Button runat="server" ID="btnReflash" OnClick="btnReflash_Click" Text="刷新" />
        </div>
        <br class="clear" />
    </div>
    <uc:MessageBoxList ID="msgBoxList" runat="server"></uc:MessageBoxList>
</asp:Content>
