<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterList.master" AutoEventWireup="true" CodeBehind="ChildCourseList.aspx.cs"
    Inherits="XmutLuckV1.Manage.Family.Children.ChildCourseList" Theme="FamilyManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHead" runat="server">
    <script type="text/javascript">
        function SendEmail(teahcerName, receiverNum) {
            parent.tb_showIFrame("发送给: " + teahcerName, "../../MessageBoxItem.aspx?ReceiverName=" + receiverNum + "&ReceiverType=Teacher&width=600&height=280&TB_iframe=true");
        }

        function ViewTeacher(teacherNum) {
            parent.tb_showIFrame("查看老师简介", "BaseTeacherInfo.aspx?ReceiverName=" + teacherNum + "&ReceiverType=Teacher&width=600&height=280&TB_iframe=true");
        }
        function ViewScore(courseCode) {
            parent.tb_showIFrame("查看课程成绩", "Children/ChildCourseScoreList.aspx?ReceiverName=" + courseCode + "&ReceiverType=Teacher&width=800&height=500&TB_iframe=true");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceCondition" runat="server">
    <asp:Panel ID="pnlCondition" runat="server">
        <table>
            <tr>
                <th>课程名称:</th>
                <td>
                    <asp:TextBox ID="prm_CourseName_" runat="server" CssClass="edit-text"></asp:TextBox>
                </td>
                <th>教师名称:</th>
                <td>
                    <asp:TextBox ID="prm_TeacherName_" runat="server" CssClass="edit-text"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceAction" runat="server">
    <div class="right">
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="搜索"></asp:Button>
        <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="重置"></asp:Button>
    </div>
    <div class="clear">
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentPlaceList" runat="server">
    <div class="list-container">
        <telerik:RadGrid ID="grdCourse" runat="server" AutoGenerateColumns="false" OnNeedDataSource="radGrid_NeedDataSource">
            <MasterTableView>
                <Columns>
                    <telerik:GridBoundColumn DataField="Index" HeaderText="编号">
                        <HeaderStyle HorizontalAlign="Left" Width="40" />
                        <ItemStyle HorizontalAlign="Left" Width="40" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CourseTypeName" HeaderText="学期">
                        <HeaderStyle HorizontalAlign="Left" Width="60" />
                        <ItemStyle HorizontalAlign="Left" Width="60" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CourseName" HeaderText="课程名称">
                        <HeaderStyle HorizontalAlign="Left" Width="300" />
                        <ItemStyle HorizontalAlign="Left" Width="300" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExamineTime" HeaderText="考试时间" DataFormatString="{0:yyyy-MM-dd hh:mm}">
                        <HeaderStyle HorizontalAlign="Left"  Width="80"/>
                        <ItemStyle HorizontalAlign="Left"  Width="80"/>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Score" HeaderText="成绩">
                        <HeaderStyle HorizontalAlign="Left"  Width="60"/>
                        <ItemStyle HorizontalAlign="Left"  Width="60"/>
                    </telerik:GridBoundColumn>

                </Columns>
                <NoRecordsTemplate>
                    没有记录.
                </NoRecordsTemplate>
            </MasterTableView>
            <ClientSettings>
                <Selecting AllowRowSelect="true" />
            </ClientSettings>
        </telerik:RadGrid>
    </div>
</asp:Content>
