<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/SubMaster.Master" AutoEventWireup="true" CodeBehind="MessageBox.aspx.cs" 
    Inherits="XmutLuckV1.Manage.Student.MessageBox" Theme="StudentManage" %>


<%@ Register Src="~/Manage/UserControl/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../../Css/MessageBoxStyleSheet.css" />
    <style type="text/css">
        .caption .item-right {
            float: right;
            margin-right: 30px;
            font-weight: bold;
            color: #000;
        }
        .caption h3 {
            float: left;
        }
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="func-block">
        <div class="block">
            <div class="caption">
                <h3>站内信件
                </h3>
                <span class="item-right"><a href="MessageBoxList.aspx">返回</a></span>
                <br class="clear"/>
            </div>
            <div class="container">
                <uc:MessageBox ID="msgBox" runat="server"></uc:MessageBox>
            </div>
        </div>
    </div>

</asp:Content>

