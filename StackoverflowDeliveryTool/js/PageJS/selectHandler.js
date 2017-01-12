

function addScenariosToSetting() {
    var settings;
    $.ajax({
        url: 'js/PageJS/scenarioSetting.json',
        async: false,
        dataType: 'json',
        success: function (json) {
            settings = json;

        },
        error: function (error) {

        }
    });
    console.log(1);
    GetServiceFunctions("GET", "ThreadsGeneration.svc/GetScenarios").then(function (args) {

        if (args.length > 0) {
            var options = settings.selectoptions;
            // console.log(options);
            $.each(args, function (i, item) {
                for (var i = 0 ; i < options.length; i++) {
                    var arr = options[i].category.split(',');
                    for (var j = 0; j < arr.length; j++) {
                        if (item.Category == arr[j]) {
                            options[i].scenarios.push(item);
                        }
                    }


                }
            });

            addScenariosToSelect(options);
            //  loadDefaultValue();
        }

    },
    function (JQresponse, err) {
        alert(CallSerivceError(JQresponse, err));
    });
}

function addScenariosToSelect(options) {
    var target = $('#selectSs');
    target.empty();
    $.each(options, function (i, item) {
        //console.log(item.groupname);
        var groupItem = $("<optgroup label='" + item.groupname + "'>");
        var childitems = item.scenarios;
        // console.log(childitems);
        //if (child.Category == 'DocumentDB') { console.log(childitems); }
        $.each(childitems, function (i, child) {
            // if (child.Category == "DocumentDB") { console.log(child);}
            if (child.ScenarioName == undefined) {
                groupItem.append($("<option scenario=\"" + child.id + "\" value=\"" + child.id + "\">" + child.Name + "</option>"));
            }
            else {
                groupItem.append($("<option scenario=\"" + child.id + "\" value=\"" + child.id + "\">" + child.ScenarioName + "</option>"));

            }
        });

        groupItem.append($("<option scenario=\"" + item.selectall.scenario + "\" value=\"" + item.selectall.scenario + "\">" + item.selectall.text + "</option>"));
        target.append(groupItem);
        target.trigger("liszt:updated");
    })


}


function SaveLoadDefault(from, to, owner, status, scenario, delivery) {

    $.ajax({
        url: 'Handler/SaveDefaultHandler.ashx',
        async: false,
        method: 'POST',
        dataType: 'json',
        data: { 'from': from, 'to': to, 'owner': owner, 'status': status, 'scenario': scenario, 'delivery': delivery },
        success: function (response) {
            console.log(response);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function loadDefaultValue() {
    $.ajax({
        url: 'Handler/ReadDefaultHandler.ashx',
        async: false,
        method: 'Get',
        dataType: 'json',
        success: function (initJson) {
            if (initJson != null) {
                $("#txbFromDate").val(initJson.from);
                $("#txbToDate").val(initJson.to);
                $("#txbOwner").val(initJson.owner);
                $("#selectSs").val(initJson.scenario).trigger("liszt:updated");

                $("#selectTS").val(initJson.status).trigger("liszt:updated");

                $('#selectDelivery').val(initJson.delivery).trigger("liszt:updated");


            }
            var fromdate = $("#txbFromDate").val();
            var todate = $("#txbToDate").val();
            var onwer = $("#txbOwner").val();
            var tags = $("#selectSs").find("option:selected").val();
            var status = $("#selectTS").find("option:selected").text();
            var statusVal = $("#selectTS").find("option:selected").val();
            var scenarioId = $("#selectSs").find("option:selected").attr("scenario");
            var delivery = $("#selectDelivery").find("option:selected").val();
            if (!IsQueryConditionEmpty(fromdate, todate, onwer, scenarioId, status, delivery)) {
                LoadQuestionList(fromdate, todate, onwer, scenarioId, status, delivery)
            }
            else {
                var options = $.parseJSON($(this).attr('data-noty-options'));
                noty(options);
            }

        },
        error: function (error) {
            console.log(error);
        }
    });
}

