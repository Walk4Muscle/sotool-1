$(document).ready(function () {
    SetEnrolledList();
});
function SetEnrolledList() {
    GetServiceFunctions("GET", "PortalService.svc/GetEnrolledDevicelist?listType=all", "application/xml").then(function (args) { GenerateLists(args) }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });
    GetServiceFunctions("GET", "PortalService.svc/GetEnrolledDevicelist?listType=today", "application/xml").then(function (args) { GenerateTodayLists(args) }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });
    GetServiceFunctions("GET", "PortalService.svc/GetEnrolledServiceCount", "application/xml").then(function (args) { GenerateCountlist(args) }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });
}
function GenerateLists(args) {

    $(args).find("Device").each(function (i, item) {
        if ($(item).children("OnlineStatus").text() == "Online") {
            $("#ulAllDevices").prepend("<li><a href=\"MDMEnrolledDeviceDetail.aspx?id=" + $(item).children("DeviceID").text() + "\"><img class=\"dashboard-avatar\" alt=\"" + $(item).children("DeviceID").text() + "\" src=\"img/white/flag.png\"></a><strong>Device <span class=\"hidden-phone\">ID</span>:</strong> <a href=\"MDMEnrolledDeviceDetail.aspx?id=" + $(item).children("DeviceID").text() + "\">" + $(item).children("DeviceID").text() + "</a><br><strong><span class=\"hidden-phone\">Enrolled Date:</span></strong>" + $(item).children("EnrolledDate").text() + "<br><strong>Status:</strong> <span class=\"label label-success\">" + $(item).children("OnlineStatus").text() + "</span></li>");
        }
        else {
            $("#ulAllDevices").prepend("<li><a href=\"MDMEnrolledDeviceDetail.aspx?id=" + $(item).children("DeviceID").text() + "\"><img class=\"dashboard-avatar\" alt=\"" + $(item).children("DeviceID").text() + "\" src=\"img/white, without circle/flag.png\"></a><strong>Device <span class=\"hidden-phone\">ID</span>:</strong> <a href=\"MDMEnrolledDeviceDetail.aspx?id=" + $(item).children("DeviceID").text() + "\">" + $(item).children("DeviceID").text() + "</a><br><strong><span class=\"hidden-phone\">Enrolled Date:</span></strong>" + $(item).children("EnrolledDate").text() + "<br><strong>Status:</strong> <span class=\"label label-warning\">" + $(item).children("OnlineStatus").text() + "</span></li>");
        }
        
    });
}
function GenerateTodayLists(args) {

    $(args).find("Device").each(function (i, item) {
        if ($(item).children("OnlineStatus").text() == "Online") {
            $("#ultodayenrolllist").prepend("<li><a href=\"MDMEnrolledDeviceDetail.aspx?id=" + $(item).children("DeviceID").text() + "\"><img class=\"dashboard-avatar\" alt=\"" + $(item).children("DeviceID").text() + "\" src=\"img/white/flag.png\"></a><strong>Device <span class=\"hidden-phone\">ID</span>:</strong> <a href=\"MDMEnrolledDeviceDetail.aspx?id=" + $(item).children("DeviceID").text() + "\">" + $(item).children("DeviceID").text() + "</a><br><strong><span class=\"hidden-phone\">Enrolled Date:</span></strong>" + $(item).children("EnrolledDate").text() + "<br><strong>Status:</strong> <span class=\"label label-success\">" + $(item).children("OnlineStatus").text() + "</span></li>");
        }
        else {
            $("#ultodayenrolllist").prepend("<li><a href=\"MDMEnrolledDeviceDetail.aspx?id=" + $(item).children("DeviceID").text() + "\"><img class=\"dashboard-avatar\" alt=\"" + $(item).children("DeviceID").text() + "\" src=\"img/white, without circle/flag.png\"></a><strong>Device <span class=\"hidden-phone\">ID</span>:</strong> <a href=\"MDMEnrolledDeviceDetail.aspx?id=" + $(item).children("DeviceID").text() + "\">" + $(item).children("DeviceID").text() + "</a><br><strong><span class=\"hidden-phone\">Enrolled Date:</span></strong>" + $(item).children("EnrolledDate").text() + "<br><strong>Status:</strong> <span class=\"label label-warning\">" + $(item).children("OnlineStatus").text() + "</span></li>");
        }

    });
}
function GenerateCountlist(args)
{
    $("#sptodaycount").html($(args).find("DeviceTodayEnrolled").text());
    $("#sptotalcount").html($(args).find("DeviceAllCount").text());
    $("#sponline").html($(args).find("DeviceTodayEnrolled").text());
}