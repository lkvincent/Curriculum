<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SlidePlusPage.aspx.cs"
    Inherits="XmutLuckV1.Test.SlidePlusPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../Scripts/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/Slides/slides.jquery.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="slider">
        <div class="slider-container">
            <div class="slider-item">
                <img src="../Upload/Student/6/BaseInfo/Desert.jpg" />
            </div>
            <div class="slider-item">
                <img src="../Upload/Student/6/BaseInfo/Jellyfish.jpg" />
            </div>
            <div class="slider-item">
                <img src="../Upload/Student/6/BaseInfo/Penguins.jpg_2.jpg" />
            </div>
            <div class="slider-item">
                <img src="../Upload/Student/6/BaseInfo/Desert.jpg_2.jpg" />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $.fn.SliderEx = function (option) {
            option = $.extend({}, $.fn.SliderEx.Option, option);
            return this.each(function () {
                var elem = $(this);
                var space = 24;
                var slider = elem.css("overflow", "hidden").css("width", option.width);
                $(".slider-container", slider).children().css("position", "absolute").wrapAll("<div class='slides_control'/>");
                var sliderContainer = $(".slides_control", elem).css("width", "9999999px").css("height", "200px").css("position", "relative");
                var prev = 0, next = 1, current = 0, total = 0;
                var groupCount = 2;
                total = $(".slider-item", sliderContainer).children().size() / groupCount;
                prev = total - 1;
                //                var width = sliderContainer.children().outerWidth();
                var width = 200,
				height = 200;
                var animate = function (direction, effect) {
                    if (direction == sliderDirection.Next) {
                        prev = current;
                        current = next;
                        next = next + 1;
                        if (next >= total) {
                            next = 0;
                        }
                    } else {
                        next = current;
                        current = prev;
                        prev = prev - 1;
                        if (prev < 0) {
                            prev = total - 1;
                        }
                    }
                    var leftIndex = 0;
                    for (var index = prev * groupCount; index < (prev + 1) * groupCount; index++) {
                        sliderContainer.children(":eq(" + index + ")").data("index", index).animate({ left: width * (leftIndex - groupCount) }, 1000, function () {
                            var currentIndex = $(this).data("index");
                            var left = width * (groupCount + (currentIndex - prev * groupCount)) +
                                       (currentIndex - prev * groupCount + 1 + groupCount) * space;
                            sliderContainer.children(":eq(" + currentIndex + ")").css("left", left);
                        });
                        leftIndex = leftIndex + 1;
                    }

                    leftIndex = 0;
                    for (var index = current * groupCount; index < (current + 1) * groupCount; index++) {
                        sliderContainer.children(":eq(" + index + ")").data("index", index).animate({
                            left: (leftIndex * width + (space * (leftIndex + 1)))
                        }, 1000);
                        leftIndex = leftIndex + 1;
                    }
                }
                for (var index = 0; index < total * groupCount; index++) {
                    sliderContainer.children(":eq(" + index + ")").css("left", (index * width + space * (index + 1)));
                }
                var nextStep = function () {
                    animate(sliderDirection.Next, sliderEffect.slider);
                }
                var prevStep = function () {
                    animate(sliderDirection.Prev, sliderEffect.slider);
                }

                if (option.play) {
                    var intervalID = setInterval(function () {
                        animate(sliderDirection.Next, sliderEffect.slider);
                    }, option.play);
                    elem.data("Interval", intervalID);
                }
            });
        }
        $.fn.SliderEx.Option = {
            width: "472px",
            play: 6000
        };
        var sliderDirection = {
            Next: 0,
            Prev: 1,
            Move: 2
        };
        var sliderEffect = {
            slider: "slider"
        }
        $(function () {
            $("#slider").SliderEx({});
        })
    </script>
    </form>
</body>
</html>
