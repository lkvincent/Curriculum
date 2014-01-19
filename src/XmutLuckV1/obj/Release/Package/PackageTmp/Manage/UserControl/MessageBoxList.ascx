<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageBoxList.ascx.cs" Inherits="XmutLuckV1.Manage.UserControl.MessageBoxList" %>

<div class="action">
    <div class="left">
        <button type="button" id="btnNew" value="新建">新建</button>
    </div>
    <br class="clear" />
</div>
<div class="msgbox-list">
    <telerik:RadGrid ID="grdActivity" runat="server" AutoGenerateColumns="false" PageSize="30" AllowCustomPaging="true" AllowPaging="true">
        <MasterTableView DataKeyNames="ID">
            <Columns>
                <telerik:GridBoundColumn DataField="Index" HeaderText="序号">
                            <HeaderStyle HorizontalAlign="Left" Width="40px" />
                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Content" HeaderText="信件内容">
                    <HeaderStyle HorizontalAlign="Left" Width="400px" />
                    <ItemStyle HorizontalAlign="Left" Width="400px" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn>
                    <HeaderStyle Width="30px" HorizontalAlign="Left" />
                    <ItemStyle Width="30px" HorizontalAlign="Left" />
                    <ItemTemplate>
                        <a href='MessageBox.aspx?ID=<%#Eval("ID") %>'>查看</a>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn>
                    <HeaderStyle Width="80px" HorizontalAlign="Left" />
                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                    <ItemTemplate>
                        <a href='MessageBox.aspx?ID=<%#Eval("ID") %>'><b style="color: red;"><%#Eval("NewReplyCount") %></b> 条回复数未读</a>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="Time" HeaderText="发送时间">
                    <HeaderStyle Width="80px" HorizontalAlign="Left" />
                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                </telerik:GridBoundColumn>
            </Columns>
            <NoRecordsTemplate>
                <div>
                    没有记录!
                </div>
            </NoRecordsTemplate>
        </MasterTableView>
    </telerik:RadGrid>
</div>
<script type="text/javascript">
    function view(msgId) {
        parent.tb_showIFrame("查看信件明细", "../SyMsgBoxNew.aspx?ID=" + msgId + "&width=920&height=600&TB_iframe=true");
    }

    $(document).ready(function () {
        $("#btnNew").click(function() {
            var senderName = "";
            var senderType = "";
            window.location.href = "SyMsgBoxNew.aspx?ReceiverName=" + senderName + "&ReceiverType=" + senderType;
            //parent.tb_showIFrame("新建信件", "../MsgBox/SyMsgBoxNew.aspx?ReceiverName=" + senderName + "&ReceiverType=" + senderType + "&width=600&height=280&TB_iframe=true");
        });
    });
</script>
