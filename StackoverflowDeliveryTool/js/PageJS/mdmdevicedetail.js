$(document).ready(function () {
    $("#adeviceID").html("Device - " + GetParam());
    $("#tddeviceID").html(GetParam());
});

function GetParam() {
    var url = document.location.href;
    var name = ""
    if (url.indexOf("=") > 0) {
        name = url.substring(url.indexOf("=") + 1, url.length)
    }
    return name;
}