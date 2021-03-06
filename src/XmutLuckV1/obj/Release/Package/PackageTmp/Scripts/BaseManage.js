﻿function RowMouseOver(sender, eventsArgs) {
    var tr = eventsArgs._domEvent.target.parentNode;
    tr.style.backgroundColor = "#E2F1CF";
    tr.style.cursor = "pointer";
}

function RowMouseOut(sender, eventsArgs) {
    var tr = eventsArgs._domEvent.target.parentNode;
    tr.style.backgroundColor = "";
    tr.style.cursor = "default";
}
function RowClick(sender, eventArgs) {
    var currentRowID = eventArgs.get_id();
    var gridEdit = $("#" + currentRowID + " a.grid-edit");
    var editPage = gridEdit.attr("href");
    if (editPage) {
        document.location.href = editPage;
    }
}
function ResponseEnd(sender, args) {
    if (typeof ResponseEndEx == "function") {
        ResponseEndEx(sender, args);
    }
    ReflashPage();
}
function TabSelected(sender, args) {
    window.parent.ResetSize();
    if (typeof TabSelectedEx == "function") {
        TabSelectedEx(sender, args);
    }

}

function RowDeleting(sender, args) {
    var id = 0;
    var deleteAlertResourceMsg = "确定删除该记录(" + id + ")?";
    if (typeof getDeleteAlertResourceMsg == "function") {
        deleteAlertResourceMsg = getDeleteAlertResourceMsg(id);
    }
    if (confirm(deleteAlertResourceMsg)) {
        return true;
    }
    return false;
}

$(function() {
    ReflashPage();

    //$(".rgMasterTable a[href$='Delete']").each(function() {
    //    var current = $(this);
    //    var href = current.attr("href");
    //    if (href.indexOf("javascript:") > -1) {
    //        var func = href.replace("javascript:", "");
    //        var funcCode = "(function(){" +
    //            "if()"
    //            +"})();";
    //    }
    //});
});

function ReflashPage() {
    if (window.parent != null && typeof window.parent.ResetSize == "function") {
        window.parent.ResetSize();
    }

    var normalHeight = 25;
    if (typeof window.getInputBoxHeight == "function") {
        normalHeight = window.getInputBoxHeight();
    }

    $("input.edit-text").each(function () {
        var current = $(this);
        var value = current.attr("disabled");
        current.jqxInput({ height: normalHeight, disabled: value });
    });
    $(".multi-edit-text").each(function () {
        var current = $(this);
        var value = current.attr("disabled");
        current.jqxInput({ disabled: value });
    });

    $("input[type='submit'],input[type='button'],button").each(function () {
        var current = $(this);
        var value = current.attr("disabled");
        current.jqxButton({ disabled: value });
    });

    $(".upload-edit-text").jqxInput({ height: normalHeight, width: 120 });
}

function BeforeDeletd(id,name) {
    var deleteAlertResourceMsg = "确定删除该记录 " + name + "(" + id + ")?";
    if (typeof getDeleteAlertResourceMsg == "function") {
        deleteAlertResourceMsg = getDeleteAlertResourceMsg(id);
    }
    if (confirm(deleteAlertResourceMsg)) {
        return true;
    }
    return false;
}