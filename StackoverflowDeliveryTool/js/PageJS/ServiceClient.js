$(document).ready(function () {
    //if ($.cookie('current_user') == null) {
    //    window.location.href = "MDMLogin.aspx";
    //}
    //else {
    //    $("#userspan").html(" " + $.cookie('current_user'));
    //    $("#btnlogout").click(function () {
    //        $.cookie('current_user', null);
    //        window.location.href = "MDMLogin.aspx";
    //    });
    //}
   
});

function SetNavHighlight(index)
{
    var navlis = $(".nav-tabs li");
    for (var i = 0; i < navlis; i++) {
        navlis.removeClass("Active");
    }
    $(navlis[index]).addClass("Active");
}

function GetServiceFunctions(Type, Url,contentType) {
    return $.ajax({
        type: Type,
        contentType: contentType,
        url: Url,
        cache: false
    });
}

function PostServiceFunctions(Type, Url, actionObject, contentType) {
    return $.ajax({
        type: Type,
        contentType: contentType,
        url: Url,
        data: JSON.stringify(actionObject),
        cache: false
    });
}

function CallSerivceError(JQresponse, err) {
    var errorMessage = "Unknown";
    if (JQresponse.status === 0) {
        errorMessage = 'Not connect.\n Verify Network.';
    } else if (JQresponse.status == 404) {
        errorMessage = 'Requested page not found. [404]';
    } else if (JQresponse.status == 500) {
        errorMessage = 'Internal Server Error [500].';
    } else if (err === 'parsererror') {
        errorMessage = 'Requested JSON parse failed.';
    } else if (err === 'timeout') {
        errorMessage = 'Time out error.';
    } else if (err === 'abort') {
        errorMessage = 'Ajax request aborted.';
    } else {
        errorMessage = 'Uncaught Error.\n' + JQresponse.responseText;
    }
    return errorMessage;
}

function formatSeconds(value) {
    var theTime = parseInt(value);
    var theTime1 = 0;
    var theTime2 = 0;
    if (theTime > 60) {
        theTime1 = parseInt(theTime / 60);
        theTime = parseInt(theTime % 60);
        if (theTime1 > 60) {
            theTime2 = parseInt(theTime1 / 60);
            theTime1 = parseInt(theTime1 % 60);
        }
    }
    var result = " " + parseInt(theTime) + "s";
    if (theTime1 >= 0) {
        result = " " + parseInt(theTime1) + "m" + result;

    }
    if (theTime2 >= 0) {
        result = " " + parseInt(theTime2) + "h" + result;
    }
    return result;
}

function reLoadTable() {
    $('.datatable').dataTable().fnDestroy();
    $('.datatable').dataTable({
        "sDom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span12'i><'span12 center'p>>",
        "sPaginationType": "bootstrap",
        "oLanguage": {
            "sLengthMenu": "_MENU_ records per page"
        }
    });
}
function reLoadTable1() {
    $('.datatable1').dataTable().fnDestroy();
    $('.datatable1').dataTable({
        "sDom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span12'i><'span12 center'p>>",
        "sPaginationType": "bootstrap",
        "oLanguage": {
            "sLengthMenu": "_MENU_ records per page"
        }
    });
}