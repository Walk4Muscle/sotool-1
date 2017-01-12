$(document).ready(function () {
    $(".bar").css("width", "0%");
    $("#servicelogtbody").empty();
    GetServiceLog("read");
    //setTimeout("StartProcess1();", 300);
});

function _getservicelog(logType) {
    return function () {
        GetServiceLog(logType);
    }
}

function GetServiceLog(logType)
{
    GetServiceFunctions("GET", "PortalService.svc/GetServiceLog?logType=" + logType, "application/xml").then(function (args) { GenerateLogList(args) }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });
}

function GenerateLogList(args)
{
    var widthValue = 100 / $(args).find("ServiceLog").length;
    if ($(args).find("ServiceLog").length != 0) {
        $(args).find("ServiceLog").each(function (i, item) {
            widthValue = (i + 1) * widthValue;
            if (widthValue > 100) {
                widthValue = 100;
            }
            $(".bar").animate({ width: widthValue + "%" }, function () {
                $("#servicelogtbody").prepend("<tr><td><span class=\"label label-warning\">" + $(item).children("ActionDate").text() + "</span></td><td><code>" + $(item).children("LogDetail").text() + "</code></td></tr>");
            });
        });
    }
    setTimeout(_getservicelog("unread"), 300);
    
}



function StartProcess1()
{
    $(".bar").animate({ width: '15%' }, "slow", function () {
        $("#servicelogtbody").prepend("<tr><td><span class=\"label\">2014/7/16 11:31AM</span></td><td><code>New Device Enrolled...</code></td></tr>");
        setTimeout("StartProcess2();", 600);
    });
}

function StartProcess2() {
    $(".bar").animate({ width: '30%' }, "slow", function () {
        $("#servicelogtbody").prepend("<tr><td><span class=\"label label-success\">2014/7/16 11:31AM</span></td><td><code>Enroll completed, start device management...</code></td></tr>");
        setTimeout("StartProcess3();", 600);
    });
}
function StartProcess3() {
    $(".bar").animate({ width: '45%' }, "slow", function () {
        $("#servicelogtbody").prepend("<tr><td><span class=\"label label-warning\">2014/7/16 11:31AM</span></td><td><code>Set client id [fdsa1-werfd-03ref-a132f] for new device...</code></td></tr>");
        setTimeout("StartProcess4();", 600);
    });
}
function StartProcess4() {
    $(".bar").animate({ width: '65%' }, "slow", function () {
        $("#servicelogtbody").prepend("<tr><td><span class=\"label label-important\">2014/7/16 11:31AM</span></td><td><code>[fdsa1-werfd-03ref-a132f] installing app [speech]...</code></td></tr>");
        setTimeout("StartProcess5();", 600);
    });
}
function StartProcess5() {
    $(".bar").animate({ width: '85%' }, "slow", function () {
        $("#servicelogtbody").prepend("<tr><td><span class=\"label label-info\">2014/7/16 11:31AM</span></td><td><code>[fdsa1-werfd-03ref-a132f] installing certificate [cer 1]</code></td></tr>");
        setTimeout("StartProcess6();", 600);
    });
}
function StartProcess6() {
    $(".bar").animate({ width: '100%' }, "slow", function () {
        $("#servicelogtbody").prepend("<tr><td><span class=\"label label-inverse\">2014/7/16 11:31AM</span></td><td><code>Session cycle done</code></td></tr>");
        $(".progress-success").removeClass("active").removeClass("progress-striped");
        setTimeout("StartProcess7();", 6000);
    });
}
function StartProcess7() {
    $(".progress-success").addClass("progress-striped").addClass("active");
    setTimeout("StartProcess8();", 6000);
}
function StartProcess8() {
    $(".progress-success").removeClass("progress-striped").removeClass("active");
    setTimeout("StartProcess7();", 5000);
}