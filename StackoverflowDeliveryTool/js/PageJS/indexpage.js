var _userAlias = $("#userspan").html().substring($("#userspan").html().indexOf("\\") + 1);
 _userAlias = 'wshao';

$(document).ready(function () {

    ClearHTMLTempData();
    LoadInitialData();
    BindControlEvent();


});

function ClearHTMLTempData() {
    $("#questionTBody").empty();
    $("#selectSs").empty();
    reLoadTable();
    docReady();
}

function LoadInitialData() {
    // Load Data for Dashborad
    //LoadDashBoardData();
    // Load data for dropdownl
    LoadScenarioDropdown();
    LoadvirtualteamDropdown();
    LoadEngineerDropdown();
    $('#feedback').click(function () {
        var feedback = $('#txtfeedback').val();
        var engineer = _userAlias;
        if (feedback == '') { alert('Please input your feedback then submit...'); }
        $.ajax({
            url: 'Handler/CollectFeedbackHandler.ashx',
            async: false,
            method: 'POST',
            dataType: 'text',
            data: { 'user': engineer, 'feedback': feedback },
            success: function (response) {
                $('#txtfeedback').val('');
                $('#txtfeedback').attr('placeholder', 'Share your idea with us! ...');
                alert("Thank you!");

            },
            error: function (error) {

            }
        });
    });

}
function LoadEngineerDropdown() {
    GetServiceFunctions("GET", "ThreadsGeneration.svc/GetSElist").then(function (args) { LoadSEngineerDropdownCallBack(args) }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });

}

function LoadScenarioDropdown() {
    GetServiceFunctions("GET", "ThreadsGeneration.svc/GetScenarios").then(function (args) { LoadScenarioDropdownCallBack(args) }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });
}
function LoadvirtualteamDropdown() {
    GetServiceFunctions("GET", "ThreadsGeneration.svc/GetSupportTeam").then(function (args) { LoadvirtualteamCallBack(args) }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });
}
var vtdata = new Array();
var optionTop, optionSEAllvt;
function LoadvirtualteamCallBack(args) {

    $("#selectvt").empty();
    optionTop = $("<option value=\"Select Team\" selected hidden>Select Team</option>");
    $("#selectvt").append(optionTop);
    optionSEAllvt = $("<optgroup label=\"Team Name\">");
    $.each(args, function (i, item) {
        optionSEAllvt.append("<option value=\"" + item.Team_name + "\">" + item.Team_name + "</option>");
    });


}
function LoadSEngineerDropdownCallBack(args) {
    if (args.length > 0) {
        $("#selectSE").empty();
        var optionTop = $("<option value=\"\">");
        $("#selectSE").append(optionTop);
        var optionSEAll = $("<optgroup label=\"Engineers' Alias\">");
        $.each(args, function (i, item) {
            optionSEAll.append("<option value=\"" + item.Alias + "\">" + item.Alias + "</option>");
        });
        $("#selectSE").append(optionSEAll);
        $("#selectSE").trigger('liszt:updated');
    }
}

function LoadScenarioDropdownCallBack(args) {
    addScenariosToSetting();


}
function LoadDashBoardData() {
    GetServiceFunctions("GET", "ThreadsGeneration.svc/GetDashBoardProperties").then(function (args) { GetDashBoarddDataCallBack(args) }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });

    //GetDashBoarddData("NewThreadNo", "all", "New Thread", "3");
    //GetDashBoarddData("RequiredFollow", "all", "Re-Open/Follow", "3");
    //GetDashBoarddData("NoIR", "all", "All", "0");
    //GetDashBoarddData("Replies", "all", "All", "1");

}
function GetDashBoarddData(type, scenarioId, status, delivery) {
    GetServiceFunctions("GET", "ThreadsGeneration.svc/GetDashBoardDate?scenarioId=" + scenarioId + "&status=" + status + "&delivery=" + delivery).then(function (args) { LoadDashBoradShowDataCallBack(args, type) }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });
}
function LoadDashBoradShowDataCallBack(args, type) {
    $("#divTotal" + type).html(args.Total);
    $("#spanMy" + type).html(args.Personal);

}
function GetDashBoarddDataCallBack(args) {
    $("#NewThreadsSum").click(function () {
        QueryAuto(args.fromdate, args.todate, "all", "all", "0", "3");
        $("#NewThreadsSum").blur();
    });
    $("#FollowupSum").click(function () {
        QueryAuto(args.fromdate, args.todate, args.alias, "all", "3", "3");
        $("#FollowupSum").blur();
    });
    $("#NoIRSum").click(function () {
        QueryAuto(args.fromdate, args.todate, "all", "all", "6", "0");
        $("#NoIRSum").blur();
    });
    $("#RepliesSum").click(function () {
        QueryAuto(args.fromdate, args.todate, "all", "all", "6", "1");
        $("#RepliesSum").blur();
    });
}
function SearchOnSOF() {
    if (event.keyCode == 13) {
        window.open("http://stackoverflow.com/questions/tagged/" + $("#txbSearchForSOF").val());
    }
}
function QueryAuto(fromdate, todate, owner, scenarioId, status, delivery) {
    $("#txbFromDate").val(fromdate);
    $("#txbToDate").val(todate);
    $("#txbOwner").val(owner);
    $("#selectSs").find("option[scenario='" + scenarioId + "']").attr("selected", true).trigger('liszt:updated');
    $("#selectTS").val(status).trigger('liszt:updated');
    $("#selectDelivery").val(delivery).trigger('liszt:updated');
    $("#selectTS").change();
    $("#selectSs").change();
    $("#selectDelivery").change();
    $("#btnQuery").click();

}
function showVTModel(question_id, obj) {
    $('#myModalVT').modal('show');
    GetServiceFunctions("GET", "ThreadsGeneration.svc/GetVirtualTeam?question_id=" + question_id).then(function (args) {

        $.each(args, function (i, item) {
            $("#lblcurrteam").html("<h4 style=\"width:150px\" class=\"label label-info\">" + item.team_name + "</h4>");

        });
    }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });

    $("#selectvt").append(optionSEAllvt);
    $("#selectvt").trigger('liszt:updated');
    $("#selectvt").val('Select Team');

    $("#btn_assign_team").unbind('click');
    $("#btn_assign_team").click(function () {

        var currtm = $('select[id=selectvt]').val();
        SetVirtualTeam(question_id, currtm, _userAlias);
        $("#lblcurrteam").html("<h4 style=\"width:150px\" class=\"label label-info\">" + currtm + "</h4>");
        $("#lblvt").html(currtm);
        $('#myModalVT').modal('hide');
    });
}
function hidecol() {
    var stralias = _userAlias;
    var at = "v-"

    if (at == stralias.substring(0, 2)) {


        $('.td_comment').show();

    }
    else {

        $('.td_comment').hide();

    }
}
function clearerr() {

    $("#err").html("");
}
var ownr, tlink, mailsts, isnotified, titl;
function showQRModel(question_id, ownr, link, title, obj) {
    ownr = ownr;
    tlink = link;
    titl = title;
    if (ownr == "") {
        //alert("The Thread is not owned by any Support Engineer. You can only review the thread which has owner...");
        $("#container-fluid").addClass("error");
        $(obj).attr("data-noty-options", "{\"text\":\"The Thread is not owned by any Support Engineer. You can only review the thread which has owner...!\",\"layout\":\"top\",\"type\":\"error\",\"closeButton\":\"true\"}");
        var options = $.parseJSON($(obj).attr('data-noty-options'));
        noty(options);
        return false;
        $('#myModalQR').modal('hide');

    }
    else {
        activaTab("view_qr");
        $('#myModalQR').modal('show');
        countchkbox();
        //$("#tableqr tr").unbind('click');
        //$('#tableqr tr').click(function (event) {
        //    if (event.target.type !== 'checkbox') {
        //        $(':checkbox', this).trigger('click');
        //        //countchkbox();
        //    }
        //});
    }


    hidetab();
    GetQRByQuetionID(question_id);
    GetQR_eng_ByQuetionID(question_id);

    var q_id = question_id;
    $("#v_qr").unbind('click');
    $("#v_qr").click(function () {
        $('#lblforscore').html("");

        GetQRByQuetionID(question_id);
        GetQR_eng_ByQuetionID(question_id);

    });
    $("#btn_eng_comment").unbind('click');
    $("#btn_eng_comment").click(function () {


        var opcomment = $("#opreviewcomment").val();
        var e = document.getElementById("status_combo");
        var status = e.options[e.selectedIndex].text;
        var create_time = Date();
        var alias = _userAlias;

        function TestQRID(qrid, alias, question_id) {
            $('#myModalcomment').modal('show');
            $('#opreviewcomment').val("");


        }
        var subject = "Comment by Support Engineer for Reviewed Result"; // $("#tbSubject").val();
        var cmnt = $("#opreviewcomment").val();
        if (cmnt == "") {
            $("#container-fluid").addClass("error");
            $(obj).attr("data-noty-options", "{\"text\":\"Please write your comment in comment box...\",\"layout\":\"top\",\"type\":\"error\",\"closeButton\":\"true\"}");
            var options = $.parseJSON($(obj).attr('data-noty-options'));
            noty(options);
            return false;
        }

        var messageId = FTEalias + "@microsoft.com" // $("#hdnMessageId").val();
        //var messageId = "panchal.deepak83@yahoo.in";

        $.ajax({
            type: "POST",
            url: "mail.aspx/SendEmail",
            data: '{subject:"' + subject + '",comment:"' + cmnt + '",link:"' + tlink + '",messageId:"' + messageId + '",useralias:"' + _userAlias + '",ttitle:"' + titl + '",points:"' + pnt + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            failure: function (response) {
                // alert(response.d);
            },
            success: function (response) {
                //alert(response.d);

            }


        });

        GetServiceFunctions("GET", "ThreadsGeneration.svc/SetQualityReview_eng?question_id=" + q_id + "&QR_id=" + qr_id + "&alias=" + alias + "&create_time=" + create_time + "&eng_comment=" + opcomment + "&action=" + status).then(function (args) { LogUTDataCallBack(args, obj) }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });
        GetQR_eng_ByQuetionID(question_id);
        $('#myModalcomment').modal('hide');

    });
    $("#p_qr").unbind('click');
    $("#p_qr").click(function () {
        $("input[name=qrcbox]").each(function () {
            if ($(this).is(':checked')) {

                $(this).parent().removeClass('checked');
                $(this).attr('checked', false);
            }

        });
        $('#lblforscore').html("");
        countchkbox();
        selectcombo();

        document.getElementById('isfixedcombo').value = 0;
        document.getElementById('statuscombo').value = 0;
        $("#comment").val("");
    });
    $("#statuscombo").click(function () {


        selectcombo();
    });
    $("#btnSavereview").unbind('click');
    $("#btnSavereview").click(function () {
        $("#err").html("");

        var query = $('#score').val();
        var fix, sts;
        fix = document.getElementById('isfixedcombo').value;
        sts = document.getElementById('statuscombo').value;

        if (isNaN(parseFloat(query))) {
            $("#container-fluid").addClass("error");
            $(obj).attr("data-noty-options", "{\"text\":\"Points should be Numeric value.\",\"layout\":\"top\",\"type\":\"error\",\"closeButton\":\"true\"}");
            var options = $.parseJSON($(obj).attr('data-noty-options'));
            noty(options);
            return false;
            //document.getElementById('point_string_err').style.visibility = 'visible'
            //$("#err").html("<div class=\"alert alert-danger\"><strong>Error !</strong><a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a> Points should be Numeric value.</div>");

            //return

        } else if (query < 0 || query > 10) {
            $("#container-fluid").addClass("error");
            $(obj).attr("data-noty-options", "{\"text\":\"You can give Minimum 0 and Maximum 10 points....\",\"layout\":\"top\",\"type\":\"error\",\"closeButton\":\"true\"}");
            var options = $.parseJSON($(obj).attr('data-noty-options'));
            noty(options);
            return false;
            //document.getElementById('point_num_err').style.visibility = 'visible'

            //$("#err").html("<div class=\"alert alert-danger\"><strong>Error !</strong><a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a> You can give Minimum 0 and Maximum 10 points....</div>");

            //return

        }
        if (fix == 0 && sts == 0) {
            $("#container-fluid").addClass("error");
            $(obj).attr("data-noty-options", "{\"text\":\"Please select the value of Status and IsFixed.\",\"layout\":\"top\",\"type\":\"error\",\"closeButton\":\"true\"}");
            var options = $.parseJSON($(obj).attr('data-noty-options'));
            noty(options);
            return false;
            //$("#err").append("<div class=\"alert alert-danger\"><strong>Error !</strong><a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a> Please select the value of Status and IsFixed.</div>");
            //$("#err").attr("data-noty-options", '{"text":"Please select the value of Status and IsFixed.","layout":"top","type":"error","closeButton":"true"}');

            //return
        }
        else if (sts == 0) {
            $("#container-fluid").addClass("error");
            $(obj).attr("data-noty-options", "{\"text\":\"Please select the value of Status.\",\"layout\":\"top\",\"type\":\"error\",\"closeButton\":\"true\"}");
            var options = $.parseJSON($(obj).attr('data-noty-options'));
            noty(options);
            return false;
            //$("#err").append("<div class=\"alert alert-danger\"><strong>Error !</strong><a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a> Please select the value of Status.</div>");

            //return
        }
        else if (fix == 0) {
            $("#container-fluid").addClass("error");
            $(obj).attr("data-noty-options", "{\"text\":\"Please select the value of IsFixed.\",\"layout\":\"top\",\"type\":\"error\",\"closeButton\":\"true\"}");
            var options = $.parseJSON($(obj).attr('data-noty-options'));
            noty(options);
            return false;
            //$("#err").append("<div class=\"alert alert-danger\"><strong>Error !</strong><a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a> Please select the value of IsFixed.</div>");

            //return
        }

        ////---------------------------------------send mail-----------------
        var subject = "Review Result"; // $("#tbSubject").val();
        var cmnt = $("#comment").val();


        var messageId = ownr + "@microsoft.com" // $("#hdnMessageId").val();
        //var messageId = "panchal.deepak83@yahoo.in";

        $.ajax({
            type: "POST",
            url: "mail.aspx/SendEmail",
            data: '{subject:"' + subject + '",comment:"' + cmnt + '",link:"' + tlink + '",messageId:"' + messageId + '",useralias:"' + _userAlias + '",ttitle:"' + titl + '",points:"' + query + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            failure: function (response) {
                // alert(response.d);
            },
            success: function (response) {
                //alert(response.d);
                mailsts = response.d;
            }


        });
        if (mailsts == "mail sent") {
            isnotified = "yes";
        }
        else {
            isnotified = "No";
        }

        //return false;

        //---------------------------------------send mail ends here-----------------


        var e = document.getElementById("statuscombo");
        var f = document.getElementById("isfixedcombo");
        var points = $("#score").val();
        var comment = $("#comment").val();
        var question_id = q_id;

        var create_time = Date();
        var create_by = _userAlias;

        var isfixed = f.options[f.selectedIndex].text;

        var alis = ownr;
        var status = e.options[e.selectedIndex].text;
        //var isnotified = "yes";
        var QR_id =

        GetServiceFunctions("GET", "ThreadsGeneration.svc/SetQualityReview?question_id=" + question_id + "&points=" + points + "&comment=" + comment + "&create_time=" + create_time + "&create_by=" + create_by + "&isfixed=" + isfixed + "&alias=" + alis + "&isnotified=" + isnotified + "&status=" + status).then(function (args) { LogUTDataCallBack(args, obj) }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });



    });

}
function showModel(question_id, obj) {
    $("#txbUT").val("");
    $("#textareaUTComments").val("");
    $('#myModalUT').modal('show');
    $("#btnSaveUILog").unbind("click");

    var q_id = question_id;
    $("#btnSaveUILog").click(function () {
        var ut = $("#txbUT").val();
        var utcomments = $("#textareaUTComments").val()
        if (isErrorForLoggingUT(ut, utcomments, obj)) {
            GetServiceFunctions("GET", "ThreadsGeneration.svc/LogUTData?question_id=" + question_id + "&UT=" + ut + "&UTComments=" + utcomments).then(function (args) { LogUTDataCallBack(args, obj) }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });
        }


    });
    $("#lbrdtl").unbind("click");
    $("#lbrdtl").click(function () {


        GetLaborsByQuetionID(question_id);

    });

    activaTab("utdata");
    hidebtn();

}
function selectcombo() {

    var e = document.getElementById("statuscombo");
    var strUser = e.options[e.selectedIndex].text;
    if (strUser == "Pass") {
        document.getElementById('isfixedcombo').value = 1

    } else if (strUser == "Failed") {
        document.getElementById('isfixedcombo').value = 2
    }
}

function countchkbox() {
    var i = 0;
    $('#score').val(0);
    $('#lblforscor').val(0);

    var checkboxes = $('input[name="qrcbox"]').each(function (i, item) {

        item.onchange = function () {


            i++;
            var countCheckedCheckboxes = checkboxes.filter(':checked').length;


            $('#score').val(countCheckedCheckboxes);
            $('#lblforscore').html("<span id=\"lblscor\" style=\"font-size:small; position:absolute; left:10px\">" + countCheckedCheckboxes + " Points</span>");
            if (countCheckedCheckboxes >= 9) {
                $('#cntchkbox').attr('class', 'label label-success');
                $('#lblscor').attr('class', 'label label-success');
            }
            else if (countCheckedCheckboxes >= 7 && countCheckedCheckboxes < 9) {
                $('#cntchkbox').attr('class', 'label label-warning');
                $('#lblscor').attr('class', 'label label-warning');
            }
            else {
                $('#cntchkbox').attr('class', 'label label-important');
                $('#lblscor').attr('class', 'label label-important');
            }
            if ($('#score').val() >= 9) {
                document.getElementById('statuscombo').value = 1
            }
            else {
                document.getElementById('statuscombo').value = 2
            }
            selectcombo();
        };
    });


}
var hidden = false;
function hidebtn() {

    $('.nav-tabs a').on('shown.bs.tab', function (event) {
        var at = $(event.target).text();         // to get active tab
        if (at == "UT History") {
            $('#btnSaveUILog').attr('style', "display:none");
        }
        else if (at == "Perform QR") {
            $('#btnSaveUILog').attr('style', "display:none");
        }
        else if (at == "View QR") {
            $('#btnSaveUILog').attr('style', "display:none");
        }
        else {
            $('#btnSaveUILog').attr('style', "");//display:block
        }

    });
}
function hidetab() {
    var stralias = _userAlias;
    var at = "v-"
    if (at == stralias.substring(0, 2)) {
        $('#p_qr').attr('style', "display:none");

        $('.td_comment').show();
    }
    else {
        $('#p_qr').attr('style', "");//display:block
        $('.td_comment').hide();

    }
}

function LogUTDataCallBack(args, obj) {

    $("#btnCloseUTModel").click();
    $(obj).html(args);
}

function isErrorForLoggingUT(ut, utcomments, obj) {
    if (ut.trim() == "") {

        $("#txbUT").parent().parent().addClass("error");
        $(obj).attr("data-noty-options", "{\"text\":\"Please fill UT mins!\",\"layout\":\"top\",\"type\":\"error\",\"closeButton\":\"true\"}");
        var options = $.parseJSON($(obj).attr('data-noty-options'));
        noty(options);
        return false;
    }
    if (isNaN(ut.trim())) {
        $("#txbUT").parent().parent().addClass("error");
        $(obj).attr("data-noty-options", "{\"text\":\"Please fill UT as a number!\",\"layout\":\"top\",\"type\":\"error\",\"closeButton\":\"true\"}");
        var options = $.parseJSON($(obj).attr('data-noty-options'));
        noty(options);
        return false;
    }

    if (utcomments.trim() == "") {

        $("#textareaUTComments").parent().parent().addClass("error");
        $(obj).attr("data-noty-options", "{\"text\":\"Please fill UT's comments!\",\"layout\":\"top\",\"type\":\"error\",\"closeButton\":\"true\"}");
        var options = $.parseJSON($(obj).attr('data-noty-options'));
        noty(options);
        return false;
    }
    return true;
}

function showSRRadio() {
    $('#SRModel').modal('show');


}
function LoadProfile() {
    $("#halias").html($("#userspan").html());
    GetServiceFunctions("GET", "ThreadsGeneration.svc/GetMyProfile").then(function (args) { LoadProfileCallBack(args) }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });
}
function LoadProfileCallBack(args) {
    $("#txb_sofID").val(args);
    $("#txb_sofID").parent().parent().removeClass("error");
    $('#myModalProfile').modal('show');
}
function SetProfileCallBack(args) {
    $('#btncloseProfile').click();
}
function BindControlEvent() {

    $("#btnMP").click(function () {
        LoadProfile();
    });


    $("#SRModel").click(function () {
        showSRRadio();

    });
    $("#btndoublesave").click(function () {
        $('#btnclosealert').click();
    });
    $("#btnSaveProfile").click(function () {
        if ($("#txb_sofID").val().trim() != "") {
            GetServiceFunctions("GET", "ThreadsGeneration.svc/SetMyProfile?sofID=" + $("#txb_sofID").val().trim()).then(function (args) { SetProfileCallBack(args) }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });
        }
        else {
            $("#txb_sofID").parent().parent().addClass("error");
            $("#txb_sofID").attr("data-noty-options", "{\"text\":\"Please fill your stackoverflow id!\",\"layout\":\"top\",\"type\":\"error\",\"closeButton\":\"true\"}");
            var options = $.parseJSON($("#txb_sofID").attr('data-noty-options'));
            noty(options);
        }
    });
    $("#txb_sofID").focus(function () {
        $("#txb_sofID").parent().parent().removeClass("error");
    });
    $("#txbUT").focus(function () {
        $("#txbUT").parent().parent().removeClass("error");
    });
    $("#textareaUTComments").focus(function () {
        $("#textareaUTComments").parent().parent().removeClass("error");
    });
    $("#selectTS").change(function () {
        $("#hStatus").html(" in <u style=\"color:black;\">" + $("#selectTS").find("option:selected").text() + "</u> status ");
    });
    $("#selectSs").change(function () {

        $("#hTgas").html("under <u style=\"color:black;\">" + $("#selectSs").find("option:selected").val() + "</u> tags");
    });
    $("#selectDelivery").change(function () {
        $("#hDelivery").html("which are <u style=\"color:black;\">" + $("#selectDelivery").find("option:selected").text() + "</u> Delivery");
    });
    $("#btnQuery").click(function () {
        var fromdate = $("#txbFromDate").val();
        var todate = $("#txbToDate").val();
        var onwer = $("#txbOwner").val();
        var tags = $("#selectSs").find("option:selected").val();
        var status = $("#selectTS").find("option:selected").text();
        var statusVal = $("#selectTS").find("option:selected").val();
        var scenarioId = $("#selectSs").find("option:selected").attr("scenario");

        var delivery = $("#selectDelivery").find("option:selected").val();
        //SaveLoadDefault(fromdate, todate, onwer, statusVal, scenarioId, delivery);
        if (!IsQueryConditionEmpty(fromdate, todate, onwer, scenarioId, status, delivery)) {
            LoadQuestionList(fromdate, todate, onwer, scenarioId, status, delivery)

        }
        else {

            var options = $.parseJSON($(this).attr('data-noty-options'));
            noty(options);
        }
    });


}


function LoadQuestionsByOptions() {

}

function IsQueryConditionEmpty(fromdate, todate, owner, scenarioId, status, delivery) {
    if (fromdate.trim() == "") {



        $("#btnQuery").attr("data-noty-options", '{"text":"Please fill date in [From]","layout":"top","type":"error","closeButton":"true"}');
        return true;
    }
    if (todate.trim() == "") {
        $("#btnQuery").attr("data-noty-options", '{"text":"Please fill date in [To]","layout":"top","type":"error","closeButton":"true"}');
        return true;
    }
    if (owner.trim() == "") {
        $("#btnQuery").attr("data-noty-options", '{"text":"Please fill data in [Owner], if you wanna select all threads, simply type all","layout":"top","type":"error","closeButton":"true"}');
        return true;
    }
    if (status.trim() == "") {
        $("#btnQuery").attr("data-noty-options", '{"text":"Please select thread status","layout":"top","type":"error","closeButton":"true"}');
        return true;
    }
    if (typeof (scenarioId) == "undefined") {
        $("#btnQuery").attr("data-noty-options", '{"text":"Please select scenario you wanna query", "layout":"top","type":"error","closeButton":"true"}');
        return true;
    }
    if (delivery.trim() == "") {
        $("#btnQuery").attr("data-noty-options", '{"text":"Please select delivery type","layout":"top","type":"error","closeButton":"true"}');
        return true;
    }
    return false;
}

function LoadQuestionList(fromdate, todate, owner, scenarioId, status, delivery) {

    EmptyList();
    GetServiceFunctions("GET", "ThreadsGeneration.svc/GetAllQuestion?fromdate=" + fromdate + "&todate=" + todate + "&owner=" + owner + "&scenarioId=" + scenarioId + "&status=" + status + "&delivery=" + delivery).
        then(function (args) {

            GenerateQuestionList(args)

        }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });
}

function EmptyList() {
    $("#questionTBody").empty();
    var tr = $("<tr>");
    tr.append('<td  colspan=\"11\"> <img title="img/ajax-loaders/ajax-loader-7.gif" src="img/ajax-loaders/ajax-loader-6.gif"></td>');
    $("#questionTBody").append(tr);
}


function GenerateQuestionList(args) {
    $("#questionTBody").empty();
    $('.datatable').dataTable().fnClearTable();

    $.each(args, function (i, item) {
        var tr = $("<tr>");
        if (item.support_alias != "" && item.support_alias != undefined) {
            tr.append("<td class=\"right\"><span class=\"icon32 icon-color icon-locked seStatus\" style=\"cursor:pointer\" onclick=\"TakeOwner('" + item.question_id + "', '" + _userAlias + "', false, this)\"></span></td>");
        }
        else {
            tr.append("<td class=\"right\"><span class=\"icon32 icon-gray icon-unlocked seStatus\" style=\"cursor:pointer\" onclick=\"TakeOwner('" + item.question_id + "', '" + _userAlias + "', true, this)\"></span></td>");
        }
        tr.append("<td class=\"center tdalias\">" + item.support_alias + "</td>");
        //<span id=\"lblvt\" class=\"label label-info\"></span><br/><br/>
        tr.append("<td id=\"btnVT\" class=\"center\"><span style=\"cursor:pointer\" class=\"btn btn-info btn-setting\" data-rel=\"tooltip\" title=\"Click Me for Virtual Team\" onclick=\"showVTModel('" + item.question_id + "', this)\" >VT</span></td>");
        tr.append("<td class=\"center tdstatus\"><span class=\"" + GetbgForStatus(item.status) + "\">" + item.status + "</span></td>");

        tr.append("<td style=\"width:3%\"><div class=\"btn-group\"><button class=\"btn dropdown-toggle\" data-toggle=\"dropdown\"><span class=\"caret\"></span></button><ul class=\"dropdown-menu\" style=\"list-style:none;\"><li><a style=\"\cursor:pointer\" onclick=\"SetThreadStatus('" + item.question_id + "', 'Waiting On Customer', this)\"><i class=\"icon-retweet\"></i> Waiting On Customer</a></li><li><a style=\"\cursor:pointer\" onclick=\"SetThreadStatus('" + item.question_id + "', 'Solution Deliver', this)\"><i class=\"icon-retweet\"></i> Solution Deliver</a></li><li><a style=\"\cursor:pointer\" onclick=\"SetThreadStatus('" + item.question_id + "', 'Escalated', this)\"><i class=\"icon-share\"></i> Escalated</a></li><li><a style=\"\cursor:pointer\" onclick=\"SetThreadStatus('" + item.question_id + "', 'Pending on Research', this)\"><i class=\"icon-search\"></i> Researching</a></li><li><a style=\"\cursor:pointer\" onclick=\"SetThreadStatus('" + item.question_id + "', 'Self-Answered', this)\"><i class=\"icon-ok\"></i> Self-Answered</a></li><li><a style=\"\cursor:pointer\" onclick=\"SetThreadStatus('" + item.question_id + "', 'Deleted In SO', this)\"><i class=\"icon-remove\"></i> Deleted In SO</a></li><li><a style=\"\cursor:pointer\" onclick=\"SetThreadStatus('" + item.question_id + "', 'OffTopic', this)\"><i class=\"icon-remove\"></i> OffTopic</a></li><li class=\"divider\"></li><li><a style=\"\cursor:pointer\" onclick=\" + DispatchOwner('" + item.question_id + "', this)\"><i class=\"icon-user\"></i> Dispatch Owner</a></li><li class=\"divider\"></li><li><a style=\"\cursor:pointer\" onclick=\" + GoToAnalysisTool('" + item.question_id + "', this)\"><i class=\"icon-list-alt\"></i> Jump to Analysis</a></li></ul></div></td>");
        tr.append('<td class=\"center\"><a data-rel="popover" data-content="' + item.body + '" title="' + item.title + '" href="' + item.link + '" target="_blank">' + item.title + '</a>' + formaticTags(item.tags) + '</td>');
        tr.append("<td class=\"center\">" + item.create_date + "</td>");
        tr.append("<td class=\"center\">" + item.active_date + "</td>");
        if (item.IRT != "N/A") {
            tr.append("<td class=\"center\">" + formatSeconds(item.IRT) + "</td>");
        }
        else {
            tr.append("<td class=\"center\">" + item.IRT + "</td>");
        }
        //  GetServiceFunctions("GET", "ThreadsGeneration.svc/GetVirtualTeam?question_id=" + item.question_id).then(function (args) {

        //   $.each(args, function (i, item) { " + item.team_name + " put this in line below span lblvt

        tr.append("<td id=\"btnQR\" class=\"center\"><span style=\"cursor:pointer\" class=\"btn btn-info btn-setting\" data-rel=\"tooltip\" title=\"Click Me for Quality Review\" onclick=\"showQRModel('" + item.question_id + "','" + item.support_alias + "','" + item.link + "','" + item.title + "', this)\" >QR</span></td>");
        tr.append("<td id=\"btnlbr\" class=\"center\"><span style=\"cursor:pointer\" class=\"btn btn-info btn-setting\" data-rel=\"tooltip\" title=\"Click Me To Add UT\" onclick=\"showModel('" + item.question_id + "', this)\" >" + item.utdata + "</span></td>");
        $("#questionTBody").append(tr);
        //  });
        // }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });




    });

    //datatable

    reLoadTable();
    docReady();
    //Register table's control


}


function GetLaborsByQuetionID(question_id) {

    $("#lbrdata").empty();
    GetServiceFunctions("GET", "ThreadsGeneration.svc/GetLaborsByQuetionID?question_id=" + question_id)
        .then(function (args) {

            if (args.length > 0) {

                $("#lbrdata").empty();
                $.each(args, function (i, item) {

                    var tr = $("<tr>");

                    tr.append("<td class=\"right\"> " + item.question_id + "</td>");
                    tr.append("<td class=\"right\"> " + item.alias + "</td>");
                    tr.append("<td class=\"right\"> " + item.UT + " mins</td>");
                    tr.append("<td class=\"right\"> " + item.LogDate + "</td>");
                    tr.append("<td class=\"right\"> " + item.UTComments + "</td>");


                    $("#lbrdata").append(tr);
                    //$('.datatable1').dataTable().fnDestroy();

                });
            }
            else {
                $("#lbrdata").empty();
                var tr = $("<tr>");
                tr.append("<td colspan=\"5\" class=\"right\">No Data Available to Display...</td>");
                $("#lbrdata").append(tr);
            }
        }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });



}
function GetQRByQuetionID(question_id) {

    var strcomm;
    $("#reviewbody").empty();
    GetServiceFunctions("GET", "ThreadsGeneration.svc/GetQRByQuetionID?question_id=" + question_id)
        .then(function (args) {
            if (args.length > 0) {

                $("#reviewbody").empty();
                $.each(args, function (i, item) {

                    var tr = $("<tr>");


                    tr.append("<td class=\"right\"> " + item.alias + "</td>");
                    tr.append("<td class=\"right\"> " + item.create_by + "</td>");
                    tr.append("<td class=\"right\"> " + item.create_time + "</td>");
                    // tr.append("<td style=\"word-wrap: break-word; width:250px\" class=\"right\" onmouseover=loadcomment('" + item.comment + "') onmouseout=unloadcomment()>" + item.comment + "</td>");

                    if (item.comment.length > 35) {
                        strcomm = item.comment.substring(0, 35) + "...";
                    }
                    else {
                        strcomm = item.comment;
                    }
                    tr.append('<td style=\"word-wrap: break-word; width:250px\" class=\"right\"><a href="#" data-placement="top"  data-rel="popover" title="comment:" data-content="' + item.comment + '">' + strcomm + '</a></td>');

                    tr.append("<td class=\"right\"> " + item.points + "</td>");
                    tr.append("<td class=\"right\"> " + item.status + "</td>");
                    tr.append("<td class=\"td_comment\"name=\"td_comment\"><a href=\"#\" class=\"btn\ btn-info\"  onclick=\"TestQRID('" + item.QR_id + "','" + item.alias + "','" + item.question_id + "','" + item.create_by + "','" + item.points + "')\">Comment</a></td>");
                    $("#reviewbody").append(tr);
                    $('#reviewbody tr').find('td').find('a[data-rel=popover]').popover();

                });
                hidecol();
            }
            else {
                $("#reviewbody").empty();
                var tr = $("<tr>");
                tr.append("<td colspan=\"7\" class=\"right\">No Data Available to Display...</td>");
                $("#reviewbody").append(tr);
            }

        }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });


}
function GetQR_eng_ByQuetionID(question_id) {
    var opcmnt, strcomm1;
    $("#commentbody").empty();
    GetServiceFunctions("GET", "ThreadsGeneration.svc/GetQR_eng_ByQuetionID?question_id=" + question_id)
        .then(function (args) {
            if (args.length > 0) {

                $("#commentbody").empty();
                $.each(args, function (i, item) {
                    var tr = $("<tr>");
                    tr.append("<td class=\"right\"> " + item.question_id + "</td>");
                    tr.append("<td class=\"right\"> " + item.alias + "</td>");
                    tr.append("<td class=\"right\"> " + item.create_time + "</td>");
                    // tr.append("<td id=\"cmnt\" style=\"word-wrap: break-word; width:250px\" class=\"right\" onmouseover=loadcomment('" + item.eng_comment + "') onmouseout=unloadcomment()>" + item.eng_comment + "</td>");
                    if (item.eng_comment.length > 35) {
                        strcomm1 = item.eng_comment.substring(0, 35) + "...";
                    }
                    else {
                        strcomm1 = item.eng_comment;
                    }
                    //  tr.append('<td style=\"word-wrap: break-word; width:250px\" class=\"right\"><a href="#" data-rel="popover" title="comment:" data-content=" demooooooooo">' + strcomm1 + '</a></td>');
                    tr.append('<td style=\"word-wrap: break-word; width:250px\" class=\"right\"><a href="#" data-placement="top"  data-rel="popover" title="comment:" data-content="' + item.eng_comment + '">' + strcomm1 + '</a></td>');
                    tr.append("<td class=\"right\"> " + item.action + "</td>");
                    $("#commentbody").append(tr);
                    $('#commentbody tr').find('td').find('a[data-rel=popover]').popover();
                    opcmnt = item.eng_comment;
                });
            }
            else {
                $("#commentbody").empty();
                var tr = $("<tr>");
                tr.append("<td colspan=\"5\" class=\"right\">No Data Available to Display...</td>");
                $("#commentbody").append(tr);
            }
        }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });
    //$("#cmnt").onclick(function () {
    //    alert("dsgzrh");
    //    loadcomment(opcmnt);
    //});
}
function loadcomment(cmnt) {
    //alert("called");
    $('#Modalcomment').modal('show');
    $('#spancomment').html(cmnt);
}
function unloadcomment() {
    // alert("called");
    $('#Modalcomment').modal('hide');

}
var qr_id, alias, q_id, FTEalias, pnt;
function TestQRID(qrid, alias, question_id, create_by, pt) {
    $('#myModalcomment').modal('show');
    $('#opreviewcomment').val("");

    qr_id = qrid;
    alias = alias;
    q_id = question_id;
    FTEalias = create_by;
    pnt = pt;
}

function RestoreTable(data) {
    reLoadTable();
    $("#datatable1").dataTable(
                   {
                       "bProcessing": true,
                       "aaData":
                       {
                           "aadata": [{
                               "question_id": 1,

                               "alias": "qaw",
                               "UT": 60,
                               "LogDate": 123,
                               "UTComments": "1231"
                           }]
                       },
                       "aoColumns": [
                           { "sTitle": "Question Id", "mData": "question_id" },
                           { "sTitle": "Owner", "mData": "alias" },
                           { "sTitle": "UT Logged", "mData": "UT" },
                           { "sTitle": "Created on", "mData": "LogDate" },
                           { "sTitle": "UT Comments", "mData": "UTComments" }]//,


                   }
               );
    reLoadTable();
}
function activaTab(tab) {

    $('.nav-tabs a[href="#' + tab + '"]').tab('show');
}
function formaticTags(tags) {
    var str = "<BR/>";
    tags[0].split(";").forEach(
   function (tag) {
       str += "  <span class='label' style='background-color:#E1ECF4;color:#39739d'>" + tag + "</span> ";

   });
    return str;
}
function DispatchOwner(question_id, obj) {
    $("#selectSE").val("").trigger('liszt:updated');
    $("#selectSE").change();
    $('#myModalDispatchOwner').modal('show');
    $("#btnSaveSE").unbind("click");
    $("#btnSaveSE").click(function () {
        var seAlias = $("#selectSE").val();
        if (isErrorForSettingSE(seAlias, obj)) {
            TakeOwner(question_id, seAlias, true, $(obj).parent().parent().parent().parent().parent().find(".seStatus"));
            $("#btnCloseDispatchModel").click();
        }
    });


    //$(obj).attr("data-noty-options", "{\"text\":\"Daniel is working on this!\",\"layout\":\"top\",\"type\":\"success\",\"closeButton\":\"true\"}");
    //var options = $.parseJSON($(obj).attr('data-noty-options'));
    //noty(options);
}

function GoToAnalysisTool(question_id, obj) {
    window.open("http://analyzeit.azurewebsites.net/Redirection/Navigate/" + question_id + "?external=sotool ", '_blank');
}
function isErrorForSettingSE(seAlias, obj) {
    if (seAlias.trim() == "") {
        $(obj).attr("data-noty-options", "{\"text\":\"Please Select Engineer!\",\"layout\":\"top\",\"type\":\"error\",\"closeButton\":\"true\"}");
        var options = $.parseJSON($(obj).attr('data-noty-options'));
        noty(options);
        return false;

    }
    return true;
}
function TakeOwner(question_id, alias, isTake, obj) {
    var orgHTML = $(obj).parent().html();
    $(obj).parent().html("<img class=\"tempImg\" title=\"img/ajax-loaders/ajax-loader-1.gif\" src=\"img/ajax-loaders/ajax-loader-1.gif\">");
    GetServiceFunctions("GET", "ThreadsGeneration.svc/TakeThreadOwner?alias=" + alias + "&istake=" + isTake + "&question_id=" + question_id).then(function (args) { TakeOwnerCallBack(args, alias, question_id, orgHTML, obj, isTake) }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });
}


function TakeOwnerCallBack(args, alias, question_id, orgHTML, obj, isTake) {
    if (args.takeownerresult) {
        if (isTake) {
            $(".tempImg").parent().parent().find(".tdalias").html(alias);
            $(".tempImg").parent().html("<span class=\"icon32 icon-color icon-locked seStatus\" style=\"cursor:pointer\" onclick=\"TakeOwner('" + question_id + "', '" + alias + "', false, this)\"></span>");
        }
        else {
            $(".tempImg").parent().parent().find(".tdalias").empty();
            $(".tempImg").parent().html("<span class=\"icon32 icon-gray icon-unlocked seStatus\" style=\"cursor:pointer\" onclick=\"TakeOwner('" + question_id + "', '" + alias + "', true, this)\"></span>");
        }

    }
    else {
        $(".tempImg").parent().attr("data-noty-options", "{\"text\":\"" + args.errormessage + "\",\"layout\":\"top\",\"type\":\"error\",\"closeButton\":\"true\"}");
        var options = $.parseJSON($(".tempImg").parent().attr('data-noty-options'));
        noty(options);
        $(".tempImg").parent().html(orgHTML);


    }
}

function SetThreadSelfAnswer(question_id, status, obj) {





    $('#CCModel').modal('show');
    $("#btnSaveCC").unbind("click");
    $("#btnSaveCC").click(function () {

        var comment = $("#textareaConfirmComments").val();
        if (comment.trim() == "") {
            $("#textareaConfirmComments").parent().parent().addClass("error");
            $(obj).attr("data-noty-options", "{\"text\":\"Please fill Comments!\",\"layout\":\"top\",\"type\":\"error\",\"closeButton\":\"true\"}");
            var options = $.parseJSON($(obj).attr('data-noty-options'));
            noty(options);
            return false;
        } else {
            SetSelfAnswerComments(question_id, status, obj, comment);

        }
    });
}

function GetSelfAnswerComments(question_id, status, obj) {
    $("#textareaConfirmComments").val("");
    GetServiceFunctions("GET", "ThreadsGeneration.svc/GetCustomerComment?question_id=" + question_id + "").then(function (args) {
        if (args == null) {
            $("#textareaConfirmComments").val("");
        } else {
            $("#textareaConfirmComments").val(args);
        }
        SetThreadSelfAnswer(question_id, status, obj);
    }, function (JQresponse, err) {
        alert(CallSerivceError(JQresponse, err));
    });
}

function SetSelfAnswerComments(question_id, status, obj, comment) {
    GetServiceFunctions("GET", "ThreadsGeneration.svc/SetCustomerComment?question_id=" + question_id + "alias=" + _userAlias + "&status=1&cusomercomments=" + comment + "").then(function (args) {
        SetSelfAnswerCommentsCallBack(args, obj, status);
    }, function (JQresponse, err) {
        alert(CallSerivceError(JQresponse, err));
    });

}

function SetSelfAnswerCommentsCallBack(args, obj, status) {
    $('#CCModel').modal('show');

    SetThreadStatusCallBack(args, obj, status)
}


function SetThreadStatus(question_id, status, obj) {
    $(obj).parent().parent().parent().parent().parent().find(".tdstatus").html("<img class=\"tempImg\" title=\"img/ajax-loaders/ajax-loader-1.gif\" src=\"img/ajax-loaders/ajax-loader-1.gif\">")
    GetServiceFunctions("GET", "ThreadsGeneration.svc/SetThreadStatus?status=" + status + "&question_id=" + question_id).then(function (args) { SetThreadStatusCallBack(args, obj, status) }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });

}


function SetVirtualTeam(question_id, team, assigned_by) {


    GetServiceFunctions("GET", "ThreadsGeneration.svc/SetVirtualTeam?question_id=" + question_id + "&team=" + team + "&assigned_by=" + assigned_by).then(function (args) { }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });



}

function SetThreadStatusCallBack(args, obj, status) {
    $(obj).parent().parent().parent().parent().parent().find(".tdstatus").html("<span class=\"" + GetbgForStatus(status) + "\">" + status + "</span>");
}
function GetbgForStatus(status) {
    switch (status) {
        case "New Thread":
            return "label label-info";
            break;
        case "Waiting On Customer":
            return "label label-inverse";
            break;
        case "Answered":
            return "label label-success";
            break;
        case "Solution Deliver":
            return "label label-success";
            break;
        case "Re-Open/Follow":
            return "label label-important";
            break;
        case "Escalated":
            return "label";
            break;
        case "AnsweredByEscalation":
            return "label label-success";
            break;
        case "Pending on Research":
            return "label label-warning";
            break;
        case "Self-Answered":
            return "label label-success";
            break;
        case "Deleted In SO":
            return "label";
            break;
        case "OffTopic":
            return "label";
            break;
    }
    return "label"

}

function notification() {
    var options = $.parseJSON($(this).attr('data-noty-options'));
    noty(options);
}