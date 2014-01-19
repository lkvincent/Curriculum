<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageBox.ascx.cs" Inherits="XmutLuckV1.Manage.UserControl.MessageBox" %>

<div class="messagebox-list">
    <%--<div class="messagebox-Item">
        <div class="messagebox-vistor">
            <div class="vistor-photo">
                <img src="../../Upload/Student/6/BaseInfo/Koala.jpg" />
            </div>
            <div class="vistor-detail">
                <div class="vistor-item">
                    <span>200500213</span>
                </div>
                <div class="vistor-item">
                    <span>身份:</span>家长
                </div>
            </div>
        </div>
        <div class="messagebox-block">
            <div class="messagebox-caption">
                <span class="messagebox-title"></span>
                <span class="messagebox-time">发表于: 2013-02-16 22:29:31</span>
            </div>
            <div class="messagebox-content">
                xssdasdsadsad
            </div>
            <div class="messagebox-action">
                <a href="#"><span>回复</span></a>
            </div>
        </div>
        <div class="clear"></div>
    </div>--%>
</div>
<div class="loading-container">
    <div class="loading-image">
        <img src="../../Image/loadingAnimation.gif" />
    </div>
</div>
<script type="text/javascript">
    var maxMessageId = 0;
    var maxReplyMsgID = 0;
    
    $(document).ready(function () {
        function ExecuteInterval() {
            var islocked = false;
            var isLocked2 = false;
            var interValValue = setInterval(function () {
                clearInterval(interValValue);
                if (!islocked) {
                    islocked = true;
                    if (!isLocked2) {
                        AjaxRequestMessage();
                        isLocked2 = false;
                    }

                    islocked = false;

                    if (!islocked && !isLocked2) {
                        ExecuteInterval();
                    }
                }
            }, 2000);
            return interValValue;
        }
        ExecuteInterval();
    });


    function AjaxRequestMessage() {
        XmutLuckV1.Ajax.AjaxService.GetMessageBoxInfo(<%=MsgID%>, "<%=CurrentAccount.UserName%>", "<%=CurrentAccount.UserType%>", function(result) {
            if (maxReplyMsgID < result.MaxReplyMessageBoxID || maxMessageId < result.MaxMessageBoxItemID) {
                maxMessageId = result.MaxMessageBoxItemID;
                maxReplyMsgID = result.MaxReplyMessageBoxID;

                BeginLoadingMessage();
                var isReflash = GenerateMessageBox(result.MessageBoxItemInfoList, ".messagebox-list");
                if (isReflash) {
                    $(".messagebox-list").scrollTop(0);
                }
            }
            EndLoadingMessage();
        }, function(result) {
            // alert("error");
        });
    }

    function GenerateMessageBox(messageList, containerSelector) {
        var messageBoxContainer = $(containerSelector);
        messageBoxContainer.children().remove();
        for (var index = 0; index < messageList.length; index++) {
            var messageBoxItem = messageList[index];
            var messgaeBoxItemDom = GenerateMessageBoxItemDom(messageBoxItem);
            messageBoxContainer.append(messgaeBoxItemDom);

            $("#" + messageBoxItem.ID + "> .messagebox-vistor").css("height", $("#" + messageBoxItem.ID).height());
            //var newestDom = messageBoxContainer.children().first();
            //if (newestDom.length == 0) {
            //    messageBoxContainer.append(messgaeBoxItemDom);
            //} else {
            //    messgaeBoxItemDom.insertBefore(newestDom);
            //}
        }

        return messageList.length > 0;
    }

    function GenerateMessageBoxItemDom(messageBoxItem) {
        var divMessageItem = $("<div class='messagebox-Item' ID='" + messageBoxItem.ID + "'>" +
            "<div class='messagebox-vistor'>" +
            "<div class='vistor-photo'>" +
            "<img src='../../Upload/Student/6/BaseInfo/Koala.jpg' />" +
            "</div>" +
            "<div class='vistor-detail'>" +
            "<div class='vistor-item'>" +
            //"<span>" + messageBoxItem.SenderName + "</span>" +
            "</div>" +
            "<div class='vistor-item'>" +
            //"<span>身份:</span>" + messageBoxItem.UserTypeLabel +
            //"<br/><span>编号:" + messageBoxItem.ID + "</span>" +
            "</div>" +
            "</div>" +
            "</div>" +
            "<div class='messagebox-block'>" +
            "<div class='messagebox-caption'>" +
            "<span class='messagebox-title'>" + messageBoxItem.ID + ") " + "<span>&lt;" + messageBoxItem.SenderName + "&gt;</span>" + //messageBoxItem.Subject +
            "</span>" +
            "<span class='messagebox-time'>" + messageBoxItem.CreateTime + "</span>" +
            "</div>" +
            "<div class='messagebox-content'>" +
            messageBoxItem.Content +
            "</div>" +
            "<div class='message-expColContainer' id='message-expColContainer"+messageBoxItem.ID+"'><a href='#' onclick='expColAction(\"#message-replyList"+messageBoxItem.ID+"\",\"#message-expColContainer"+messageBoxItem.ID+"\")'><span class='text'>展开</span></a></div>"+
            "<div class='message-replyList collapse' id='message-replyList"+messageBoxItem.ID+"'>" +
            GenerateReplyContentList(messageBoxItem) +
            "</div>" +
            "<div class='messagebox-action'>" +
            "<a href='#' class='reply' onclick='reply(" + messageBoxItem.ID + ",\"" + messageBoxItem.Subject + "\",\"" + messageBoxItem.SenderName + "\",\"" + messageBoxItem.UserType + "\");'><span>回复</span></a>" +
            //"<span class='messagebox-time'>发表于: " + messageBoxItem.CreateTime + "</span>" +
            "</div>" +
            "<div class='messagebox-itemList'>" +
            "</div>" +
            "<div class='clear'/>" +
            "</div>" +
            "<div class='clear'/>" +
            "</div>"
        );
        var msgBoxItemContainer = $(".messagebox-itemList", divMessageItem);
        for (var i = 0; i < messageBoxItem.MessageBoxItemInfoList.length; i++) {
            var childMsgBoxItem = messageBoxItem.MessageBoxItemInfoList[i];
            msgBoxItemContainer.append(GenerateMessageBoxItemDom(childMsgBoxItem));
        }

        return divMessageItem;
    }

    function GenerateReplyContentList(messageBoxItem) {
        var replyContentHTML = "";
        if (messageBoxItem && messageBoxItem.ReplyContentList) {
            for (var i = 0; i < messageBoxItem.ReplyContentList.length; i++) {
                var replyItem = messageBoxItem.ReplyContentList[i];
                replyContentHTML += "<div class='messagebox-replyItem'>" +
                    "<div class='messagebox-vistor'>" +
                    "<div class='vistor-photo'>" +
                    "<img src='../../Upload/Student/6/BaseInfo/Koala.jpg' />" +
                    "</div>" +
                    "</div>" +
                    "<div class='messagebox-block'>" +
                    "<div class='messagebox-title'><span>" + replyItem.ID + ") 回复:</span>" + "<span class='messagebox-time'>" + replyItem.ReplyTime + "</span>" + "</div>" +
                    "<div class='messagebox-replycontent'>" +
                    replyItem.Content +
                    "</div>" +
                    "</div>" +
                    "<div class='clear'/>" +
                    "</div>";
            }
        }
        return replyContentHTML;
    }

    function BeginLoadingMessage() {
        $(".loading-container").show();
    }

    function EndLoadingMessage() {
        $(".loading-container").hide();

        var messageBoxItemWidth = $(".messagebox-list .messagebox-Item").width();
        var messageBoxVisitorWidth = $(".messagebox-list .messagebox-Item .messagebox-vistor").width();
        $(".messagebox-list .messagebox-Item .messagebox-block").css("width", messageBoxItemWidth - messageBoxVisitorWidth - 30);
    }

    function expColAction(selector,excolSelector) {
        if ($(selector).hasClass("collapse")) {
            BeginLoadingMessage();
            $(selector).removeClass("collapse").addClass("expand", 1000);
            $(".text", excolSelector).html("收起");
            EndLoadingMessage();
        } else {
            BeginLoadingMessage();
            $(selector).removeClass("expand").addClass("collapse", 1000);
            $(".text", excolSelector).html("展开");
            EndLoadingMessage();
        }
    }
    
    function reply(id, subject, senderName, senderType) {
        parent.tb_showIFrame("回复 (编号:" + id + ") " + subject, "../../MessageBoxItem.aspx?RefMsgID=" + id + "&ReceiverName=" + senderName + "&ReceiverType=" + senderType + "&width=600&height=280&TB_iframe=true");
    }
</script>
