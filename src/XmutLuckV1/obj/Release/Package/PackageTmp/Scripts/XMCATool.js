(function ($) {
    $.fn.WrapText = function (param) {
        var config = {
            EmptyMessage: null
        };
        $.extend(config, param);
        $(this).each(function () {
            var elem = this;
            var emptyMessage = $(elem).attr("EmptyMessage");
            $(elem).parent().css("position", "relative")
            var label = $("<label style='position:absolute;left:6px;top:9px;color:#c1c1c1;cursor:text;display:none;' class='hintText'>" + emptyMessage + "</label>");
            $(elem).after(label);
            $(elem).focus(function () {
                label.hide();
            }).blur(function () {
                if (!$(this).val()) {
                    label.show();
                }
            })
            label.click(function () {
                label.prev().focus();
            })
            setTimeout(function () {
                var containerHeight = $(elem).parent().height();
                var labelHeight = label.height();
                var borderHeight = parseInt($(elem).css("border-top-width")) + parseInt($(elem).css("border-bottom-width"));
                label.css("top", (containerHeight - labelHeight - borderHeight) / 2 + 1);

                if ($(elem).val()) {
                    label.hide();
                } else {
                    label.show();
                }
            }, 800);
        })
    }
})(jQuery)
$(function () {
    $("input:text[EmptyMessage],input:password[EmptyMessage],textarea[EmptyMessage]").WrapText();
})