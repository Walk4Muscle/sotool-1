$(document).ready(function () {
    $("#btnlogin").click(function () {
        var username = $("#username").val();
        var pwd = $("#password").val();
        if (username == "Daniel Xu" && pwd == "123456" || username == "Han Xia" && pwd == "Password01!") {
            $.cookie('current_user', username, { expires: 356 });
            window.location.href = "MDMMgr.aspx";
        }
        else {
            var options = $.parseJSON($(this).attr('data-noty-options'));
            noty(options);
        }
    });
});

function notification()
{
    var options = $.parseJSON($(this).attr('data-noty-options'));
    noty(options);
}
