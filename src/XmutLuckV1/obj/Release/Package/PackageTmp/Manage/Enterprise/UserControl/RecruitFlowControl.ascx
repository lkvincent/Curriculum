<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecruitFlowControl.ascx.cs" Inherits="XmutLuckV1.Manage.Enterprise.UserControl.RecruitFlowControl" %>

<div class="condition">
    <div class="caption">
        <h4>搜索条件</h4>
    </div>
    <div class="container">
        <table>
            <tr>
                <th>时间从:</th>
                <td>
                    <telerik:RadDatePicker runat="server" ID="prm_DateFrom_"></telerik:RadDatePicker>
                </td>
                <th>到:</th>
                <td>
                    <telerik:RadDatePicker runat="server" ID="prm_DateTo_"></telerik:RadDatePicker>
                </td>
                <th>岗位:</th>
                <td>
                    <asp:TextBox runat="server" ID="prm_JobTitle_"></asp:TextBox>
                </td>
                <th>申请人:</th>
                <td>
                    <asp:TextBox runat="server" ID="prm_StudentName_"></asp:TextBox>
                </td>

            </tr>

        </table>
    </div>
</div>
<div class="action">
    <div class="left">
       <asp:Button runat="server" ID="btnSave" OnClientClick="if(!SaveConfirm())return;" Text="确认保存" OnClick="btnSave_Click"/> 
    </div>
    <div class="right">
        <asp:Button runat="server" ID="btnSearch" Text="搜索" OnClick="btnSearch_Click" />
        <asp:Button runat="server" ID="btnReset" Text="重置" OnClick="btnReset_Click" />
    </div>
    <br class="clear" />
</div>

<div class="flow-container">
    <telerik:RadDockLayout ID="RadDockLayout1" runat="server" EnableViewState="False">
    </telerik:RadDockLayout>
</div>
<script type="text/javascript">
    function DragEnd(event, arg) {
        //var targetDockZone = event.get_dockZone();
        //var dockZoneUniqueName = targetDockZone.get_uniqueName();

        //var dockZoneLength = dockZoneUniqueName.length;
        //var startIndex = dockZoneUniqueName.lastIndexOf("_") + 1;
        //var dockZoneStageId = dockZoneUniqueName.substr(startIndex, dockZoneLength - startIndex);

        //var dockId = event.get_uniqueName();

        //XmutLuckV1.Ajax.AjaxService.ChangeRequestJobStage(dockId, dockZoneStageId, "", function (result) {
        //    if (!result.IsSucess) {
        //        to_show(result.IsSucess, result.Message);
        //    }
        //}, function (error) {
        //    alert(error);
        //});
    }

    function menuItemEx(navigateType, url, containerSelector, iframeSelector) {
        var container = $(containerSelector, window.parent.document);
        var iframe = $(iframeSelector, window.parent.document);
        container.css("width", "100%");
        $(".body-content .main").css("width", "100%");
    }

    function AddNote(jobRequestID, jobRequestStageID) {
        tb_showIFrame("描述", "JobActionTip.aspx?JobRequestID=" + jobRequestID + "&JobRequestStageID=" + jobRequestStageID + "&width=600&height=200&TB_iframe=true");
    }

    function SaveConfirm() {
        if (confirm("确认进去保存?是:系统将发生站内消息给对应应聘者!)")) {
            return true;
        }
        return false;
    }
</script>
