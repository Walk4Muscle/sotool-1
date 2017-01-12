$(document).ready(function () {
    SetIconCount();
});
function SetIconCount()
{
    GetServiceFunctions("GET", "PortalService.svc/GetEnrolledServiceCount", "application/xml").then(function (args) { GenerateIconCount(args) }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });
}
function GenerateIconCount(args)
{
    $("#DevicesSum").attr("data-original-title", $(args).find("DeviceTodayEnrolled").text() + " today new Enrolled device.");
    $("#spanTodayEnrool").html($(args).find("DeviceTodayEnrolled").text());
    $("#divTotalEnroll").html($(args).find("DeviceAllCount").text());
   // setTimeout("SetIconCount()", 2000);
}