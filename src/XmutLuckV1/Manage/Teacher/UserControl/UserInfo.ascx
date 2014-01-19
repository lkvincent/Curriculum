<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.ascx.cs" Inherits="XmutLuckV1.Manage.Teacher.UserControl.UserInfo" %>
<%@ Register Src="~/Manage/UserControl/UploadControl.ascx" TagName="UploadControl"
    TagPrefix="uc" %>
<div class="func-block user-detail">
    <div class="block user-info">
        <div class="caption">
            <h3>
                <%=GetLocalResourceObject("BaseUserInfo")%>
            </h3>
        </div>
        <div class="container">
            <div class="user-left">
                <table>
                    <tr>
                        <th>工号:
                        </th>
                        <td>
                            <asp:TextBox ID="txt_TeacherNum_" runat="server" Enabled="false" ReadOnly="True" CssClass="edit-text" MaxLength="30"></asp:TextBox>
                        </td>
                        <th>籍贯:
                        </th>
                        <td>
                            <asp:TextBox ID="txt_NativePlace_" runat="server" CssClass="edit-text" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>中文名:
                        </th>
                        <td>
                            <asp:TextBox ID="txt_NameZh_" runat="server" CssClass="edit-text" MaxLength="10"></asp:TextBox>
                        </td>
                        <th>性别:
                        </th>
                        <td>
                            <asp:RadioButtonList ID="rdo_Sex_" runat="server" RepeatDirection="Horizontal">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <th>英文名:
                        </th>
                        <td>
                            <asp:TextBox ID="txt_NameEn_" runat="server" CssClass="edit-text" MaxLength="30"></asp:TextBox>
                        </td>
                        <th>专业:
                        </th>
                        <td>
                            <asp:TextBox ID="txt_MarjorName_" runat="server" CssClass="edit-text" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>毕业学校:
                        </th>
                        <td colspan="3">
                            <asp:TextBox ID="txt_School_" runat="server" Width="478px" Height="25px" CssClass="multi-edit-text" MaxLength="40"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>常用电话:
                        </th>
                        <td>
                            <asp:TextBox ID="txt_ContactPhone_" runat="server" CssClass="edit-text" MaxLength="20"></asp:TextBox>
                        </td>
                        <th>Email:
                        </th>
                        <td>
                            <asp:TextBox ID="txt_Email_" runat="server" CssClass="edit-text" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="multiLine">描述:
                        </th>
                        <td colspan="3">
                            <asp:TextBox ID="txt_Description_" runat="server" Width="478px" TextMode="MultiLine" MaxLength="500"
                                Height="122px" CssClass="multi-edit-text"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="user-right upload-image">
                <div class="image-container">
                    <asp:Image ID="imgSource" runat="server" />
                </div>
                <div>
                    <uc:UploadControl ID="upLoadControl" runat="server" MaxWidth="210" MaxHeight="200">
                    </uc:UploadControl>
                </div>
            </div>
            <br class="clear" />
        </div>
    </div>
    <div class="block user-info persional">
        <div class="caption">
            <h3>
                <asp:CheckBox ID="chkIsOnline" runat="server" Text="公开个人信息" />
            </h3>
        </div>
        <div class="container">
            <table>
                <tr>
                    <th>学历:
                    </th>
                    <td>
                        <asp:DropDownList ID="drp_EducationCode_" runat="server" Width="150px" CssClass="edit-text">
                        </asp:DropDownList>
                    </td>
                    <th>婚姻状况:
                    </th>
                    <td>
                        <asp:RadioButtonList ID="rdo_Married_" runat="server" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <th>工龄:
                    </th>
                    <td>
                        <asp:TextBox runat="server" ID="txt_WorkingYear_" MaxLength="10"></asp:TextBox>
                    </td>
                    <th>手机:
                    </th>
                    <td>
                        <asp:TextBox ID="txt_Telephone_" runat="server" Width="175px" Height="25px" CssClass="multi-edit-text" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="block course-list">
        <div class="caption">
            <h3>
                <%=GetLocalResourceObject("BaseCourseInfo")%>
            </h3>
        </div>
        <div class="container">
            <div class="course-data">
                <table>
                    <tr>
                        <th>专业:
                        </th>
                        <td>
                            <asp:DropDownList ID="drp_MarjorID_" runat="server" Width="145px" AutoPostBack="true" OnSelectedIndexChanged="DrpCourse__SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rqvMarjorID" runat="server" Display="Dynamic" ControlToValidate="drp_MarjorID_" 
                                ErrorMessage="<img src='/Image/invalid.gif' title='专业不能为空!'/>" ValidationGroup="CourseGroup"></asp:RequiredFieldValidator>
                        </td>
                        <th>学期:
                        </th>
                        <td>
                            <asp:DropDownList ID="drp_CourseType_" runat="server" Width="145px" AutoPostBack="true"
                                OnSelectedIndexChanged="DrpCourse__SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rqvCourseType" runat="server" Display="Dynamic" ControlToValidate="drp_CourseType_"
                                ErrorMessage="<img src='/Image/invalid.gif' title='学期不能为空!'/>" ValidationGroup="CourseGroup"></asp:RequiredFieldValidator>
                        </td>
                        <th>课程名称:
                        </th>
                        <td>
                            <asp:DropDownList ID="drp_CourseID_" runat="server" Width="145px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rqvCourseID" runat="server" Display="Dynamic" ControlToValidate="drp_CourseID_"
                                ErrorMessage="<img src='/Image/invalid.gif' title='课程名称不能为空!'/>" ValidationGroup="CourseGroup"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th>开始时间:
                        </th>
                        <td>
                            <telerik:RadDatePicker ID="dtpBeginTime" runat="server" Width="170px">
                                <DateInput DateFormat="yyyy-MM-dd" runat="server">
                                </DateInput>
                            </telerik:RadDatePicker>
                        </td>
                        <th>结束时间:
                        </th>
                        <td>
                            <telerik:RadDatePicker ID="dtpEndTime" runat="server" Width="170px">
                                <DateInput DateFormat="yyyy-MM-dd" runat="server">
                                </DateInput>
                            </telerik:RadDatePicker>
                        </td>
                        <th></th>
                        <td>
                            <asp:CheckBox ID="chk_IsAdviserTeacher_" runat="server" Text="班主任" />
                        </td>
                    </tr>
                    <tr>
                        <th></th>
                        <td>
                            <asp:RequiredFieldValidator ID="rqvBeginTime" runat="server" Display="Dynamic" ControlToValidate="dtpBeginTime"
                                ErrorMessage="<span class='error'><i class='msg-ico'></i><label>开始时间不能为空!</label></span>"
                                ValidationGroup="CourseGroup"></asp:RequiredFieldValidator>
                        </td>
                        <th></th>
                        <td>
                            <asp:RequiredFieldValidator ID="rqvEndTime" runat="server" Display="Dynamic" ControlToValidate="dtpEndTime"
                                ErrorMessage="<span class='error'><i class='msg-ico'></i><label>结束时间不能为空!</label></span>"
                                ValidationGroup="CourseGroup"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="action">
                <div class="left">
                    <asp:Button ID="btnNew" runat="server" Text="新增" OnClick="btnNew_Click" ValidationGroup="CourseGroup"></asp:Button>
                </div>
                <br class="clear" />
            </div>
            <div class="item">
                <telerik:RadGrid ID="grdSource" runat="server" AutoGenerateColumns="false" OnItemCommand="grdSource_ItemCommand"
                    OnItemDataBound="grdSource_ItemDataBound" OnNeedDataSource="grdSource_NeedDataSource"
                    AllowCustomPaging="false" AllowPaging="false">
                    <MasterTableView DataKeyNames="ID" AllowCustomPaging="False" AllowPaging="False">
                        <Columns>
                            <telerik:GridBoundColumn DataField="Index" HeaderText="序号">
                                <HeaderStyle HorizontalAlign="Left" Width="40px" />
                                <ItemStyle HorizontalAlign="Left" Width="40px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="专业" DataField="MarjorName">
                                <HeaderStyle HorizontalAlign="Left" Width="160px" />
                                <ItemStyle HorizontalAlign="Left" Width="160px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="学期" DataField="CourseTypeName">
                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="课程名称" DataField="CourseName">
                                <HeaderStyle HorizontalAlign="Left" Width="160px" />
                                <ItemStyle HorizontalAlign="Left" Width="160px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="班主任">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk_IsAdviserTeacher_" runat="server" Checked='<%#Eval("IsAdviserTeacher") %>' AutoPostBack="False" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" Width="60px" />
                                <ItemStyle HorizontalAlign="Left" Width="60px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="BeginTimeLabel" HeaderText="开始时间">
                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EndTimeLabel" HeaderText="结束时间">
                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkEdit" runat="server" CommandName="edit" Text="编辑" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle Width="50px" />
                                <ItemStyle Width="50px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkDelete" runat="server" OnClientClick='<%# "if(!BeforeDeletd("+DataBinder.Eval(Container,"DataItem.ID")+",\""+DataBinder.Eval(Container,"DataItem.CourseName")+"\"))return false;"%>' CommandName="delete" Text="删除" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle Width="50px" />
                                <ItemStyle Width="50px" />
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <EditFormSettings EditFormType="Template">
                            <FormTemplate>
                                <div class="data-detail course-detail">
                                    <table>
                                        <tr>
                                            <th>专业:
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="drp_MarjorID_" runat="server" AutoPostBack="true" Width="145px"
                                                    OnSelectedIndexChanged="DropDownControl_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rqvMarjorID" runat="server" Display="Dynamic" ControlToValidate="drp_MarjorID_"
                                                    ErrorMessage="<img src='/Image/invalid.gif' title='专业不能为空!'/>" ValidationGroup="CourseItemGroup"></asp:RequiredFieldValidator>
                                            </td>
                                            <th>学期:
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="drp_CourseTypeID_" runat="server" AutoPostBack="true" Width="145px"
                                                    OnSelectedIndexChanged="DropDownControl_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                    ControlToValidate="drp_CourseTypeID_" ErrorMessage="<img src='/Image/invalid.gif' title='学期不能为空!'/>"
                                                    ValidationGroup="CourseItemGroup"></asp:RequiredFieldValidator>
                                            </td>
                                            <th>课程名称:
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="drp_CourseID_" runat="server" Width="145px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rqvCourseID" runat="server" Display="Dynamic" ControlToValidate="drp_CourseID_"
                                                    ErrorMessage="<img src='/Image/invalid.gif' title='课程名称不能为空!'/>" ValidationGroup="CourseItemGroup"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>开始时间:
                                            </th>
                                            <td>
                                                <telerik:RadDatePicker ID="dtpBeginTime" runat="server" Width="150px">
                                                    <DateInput DateFormat="yyyy-MM-dd" runat="server">
                                                    </DateInput>
                                                </telerik:RadDatePicker>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                    ControlToValidate="dtpBeginTime" ErrorMessage="<img src='/Image/invalid.gif' title='开始时间不能为空!'/>"
                                                    ValidationGroup="CourseItemGroup"></asp:RequiredFieldValidator>
                                            </td>
                                            <th>结束时间:
                                            </th>
                                            <td>
                                                <telerik:RadDatePicker ID="dtpEndTime" runat="server" Width="150px">
                                                    <DateInput DateFormat="yyyy-MM-dd" runat="server">
                                                    </DateInput>
                                                </telerik:RadDatePicker>
                                                <asp:RequiredFieldValidator ID="rqvEndTime" runat="server" Display="Dynamic" ControlToValidate="dtpEndTime"
                                                    ErrorMessage="<img src='/Image/invalid.gif' title='结束时间不能为空!'/>" ValidationGroup="CourseItemGroup"></asp:RequiredFieldValidator>
                                            </td>
                                            <th></th>
                                            <td>
                                                <asp:CheckBox ID="chk_IsAdviserTeacher_" runat="server" Text="班主任" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="action">
                                    <asp:Button ID="btnSave" runat="server" Text="保存" CommandName="Update" />
                                    <asp:Button ID="btnCancel" runat="server" Text="取消" CommandName="Cancel" CausesValidation="false" />
                                </div>
                            </FormTemplate>
                        </EditFormSettings>
                        <NoRecordsTemplate>
                            <div>
                                没有记录!
                            </div>
                        </NoRecordsTemplate>
                    </MasterTableView>
                    <ClientSettings EnableAlternatingItems="true" EnablePostBackOnRowClick="true">
                    </ClientSettings>
                </telerik:RadGrid>
            </div>
        </div>
    </div>
    <div class="block action">
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="保存"></asp:Button>
    </div>
</div>
<script type="text/javascript">
    //$(function () {
    //    $("input.edit-text").jqxInput({ height: 25, width: 182 });
    //    $(".multi-edit-text").jqxInput();
    //    $(".RadInput input.riTextBox").jqxInput();

    //    $(".upload-edit-text").jqxInput({ height: 25, width: 120 });
    //});
    //function RowClickEx(editPage, currentPK) {
    //    return true;
    //}

    setTimeout(function () {
        window.parent.ResetSize();
    }, 500);
</script>
