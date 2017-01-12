$(document).ready(function () {
    InitQueryService();
    LoadScenarioDropdown();
   
    LoadInitialChartData();
    LoadHeroChartData();
    LoadTechDistrubtionData()
    LoadrepliedRatioData();
    LoadAgentBehaviorData();
    LoadAHData();
    LoadAHBreakDownData();
    LoadIRTData();
    LoadReputationEngData();
    LoadReputationMonthlyData();
    LoadPeopleReachData();
});

function InitQueryService()
{
    $("#btnQuery").click(function()
    {
        var fromdate = $("#txbFromDate").val();
        var todate = $("#txbToDate").val();        
        var Scope = $("#selectScope").find("option:selected").val();       
        var cateNames = $("#selectSs").find("option:selected").attr("scenario");
      
        if (!IsQueryConditionEmpty(fromdate, todate, cateNames, Scope)) {
            LoadOverAllMetrics(fromdate, todate, cateNames, Scope);
        }
        else {
            var options = $.parseJSON($(this).attr('data-noty-options'));
            noty(options);
        }

    }
    );

}

function LoadOverAllMetrics(fromdate, todate, cateNames, Scope)
{

    GetServiceFunctions("GET", "ThreadsGeneration.svc/GetScenarioMetricsByDate?fromdate=" + fromdate + "&todate=" + todate + "&cateNames=" + cateNames + "&Scope=" + Scope).then(function (args) {
        parseMetricsList(args);
    }, function (JQresponse, err) {
        alert(CallSerivceError(JQresponse, err));
    });
}
function LoadOverAllReputation()
{



}


function parseMetricsList(args)
{
    if (args == null || args.length == 0) return;
    InitTagsData(args);
    FormatTags(args);




}

function InitTagsData(args)
{

    var _topTagsData = $.grep(args, function (value) {
        return value.Scenario == "ALL" && value.Year == 0 && value.Month == 0;
    });
    $("#questionvolume").html(_topTagsData[0].Volume);
    $("#irt").html((parseFloat(_topTagsData[0].AveragetIRT)/60).toFixed(2));
    $("#AHR").html(((parseFloat(_topTagsData[0].OverallAHR)*100).toFixed(2))+"%");
    $("#rrbyus").html((_topTagsData[0].OverallRR*100).toFixed(2)+"%");
   // $("#Reputation").html(_topTagsData[0].AveragetIRT);
   // $("#PeopleReach").html(_topTagsData[0].AveragetIRT);

}
var tagsArray = [];
var tagsTypeArray = {};
function FormatTags(data)
{
    tagsTypeArray = {}; tagsArray = [];
    // object instead of array
    $.each(data, function (i, item) {
        if (tagsTypeArray[item.Scenario] == null || tagsTypeArray[item.Scenario] == undefined)
            tagsTypeArray[item.Scenario] = [];
        tagsTypeArray[item.Scenario].push(item);
        if ($.inArray(item.Scenario, tagsArray) < 0)
            tagsArray.push(item.Scenario);
    });
    FormatMonthList();
    FormatQuestionChartData();
}
var MonthList = [];
function FormatMonthList()
{
    MonthList = [];
    if (tagsArray[0] != "ALL") {
        $.each(tagsTypeArray[tagsArray[0]], function (index, value) {
            MonthList.push(value.MonthName);

        });
    } else
    {
        $.each(tagsTypeArray[tagsArray[1]], function (index, value) {
            MonthList.push(value.MonthName);

        });
    }
    //var i=0;
    //while (i<=tagsArray.length) {       
    //        tagsTypeArray[tagsArray[i]].sort(
    //            function (a, b) {
    //                return a.Year <= b.Year && a.Month <= b.Month;
    //            }
    //            );
            
    //    i++;
    //}

}
var questionChartDataArray = [];

var questionChartDataArrayItem = {
    name: "",
    type: "",
    data:[],
    markLine: {
        itemStyle: {
            normal: {
                label: {
                    show: true,
                    formatter: '{c}'
                }
            }
        },
        data: [
            {
                type: 'average',
                name: 'average available rate',

            }
        ]
    }
}
function FormatQuestionChartData()
{
    questionChartDataArray = [];
    for (var i = 0; i < tagsArray.length; i++)
    {
        questionChartDataArrayItem = {
            name: "",
            type: "",
            data: [],
            markLine: {
                itemStyle: {
                    normal: {
                        label: {
                            show: true,
                            formatter: '{c}'
                        }
                    }
                },
                data: [
                    {
                        type: 'average',
                        name: 'average available rate',

                    }
                ]
            }
        };
        questionChartDataArrayItem.name = tagsArray[i];
        questionChartDataArrayItem.type = 'line';
        var itemdata = [];
        $.each(MonthList, function (index, value)
        {
            $.each(tagsTypeArray[tagsArray[i]], function (index2, value2) {

                if (MonthList[index] == value2.MonthName)
                    itemdata.push(value2.Volume);
             
            });

        });
        questionChartDataArrayItem.data = itemdata;
        //questionChartDataArrayItem.data=
        
        questionChartDataArray.push(questionChartDataArrayItem);
    }

    LoadInitialChartData();

}

 
function LoadScenarioDropdown() {
    $("#selectSs").empty();
    var optionTop = $("<option value=\"\">");
    var optionAzureAll = $("<option scenario=\"Azure\" value=\"Azure All\">Azure All</option>");
    var optionMobilityAll = $("<option scenario=\"Mobility\" value=\"Mobility All\">Mobility All</option>");
    var optionVSALMAll = $("<option scenario=\"VSALM\" value=\"VSALM All\">VSALM All</option>");
    var optionVSOAll = $("<option scenario=\"VSO\" value=\"VSO All\">VSO All</option>");
    var optionWinTenAll = $("<option scenario=\"WIN10\" value=\"Win10 All\">Win10 All</option>");
    var optionUWPAll = $("<option scenario=\"UWP\" value=\"UWP All\">UWP All</option>");
    var optionQ2PannedAll = $("<option scenario=\"O365\" value=\"O365 All\">Office 365 All</option>");
    var optionCordovaall = $("<option scenario=\"VSForCordova\" value=\"cordovaall\">Cordova All</option>");
    var optionHockeydAll = $("<option scenario=\"Hockey\" value=\"Hockey All\">Hockey All</option>");

    $("#selectSs").append(optionTop);
    $("#selectSs").append(optionAzureAll);
    $("#selectSs").append(optionMobilityAll);
    $("#selectSs").append(optionVSALMAll);
    $("#selectSs").append(optionVSOAll);
    $("#selectSs").append(optionWinTenAll);
    $("#selectSs").append(optionUWPAll);
    $("#selectSs").append(optionQ2PannedAll);
    $("#selectSs").append(optionCordovaall);
    //var optionAllGroup = $("<optgroup label=\"All\"><option scenario=\"all\">All</option></optgroup>");
    $("#selectSs").append(optionHockeydAll);
    $("#selectSs").trigger('liszt:updated');


    //GetServiceFunctions("GET", "ThreadsGeneration.svc/GetScenarios").then(function (args) { LoadScenarioDropdownCallBack(args) }, function (JQresponse, err) { alert(CallSerivceError(JQresponse, err)); });
}

function IsQueryConditionEmpty(fromdate, todate, scenarioId, Scope) {
    if (fromdate.trim() == "") {
        $("#btnQuery").attr("data-noty-options", '{"text":"Please fill date in [From]","layout":"top","type":"error","closeButton":"true"}');
        return true;
    }
    if (todate.trim() == "") {
        $("#btnQuery").attr("data-noty-options", '{"text":"Please fill date in [To]","layout":"top","type":"error","closeButton":"true"}');
        return true;
    }

    if (typeof (scenarioId) == "undefined") {
        $("#btnQuery").attr("data-noty-options", '{"text":"Please select scenario you wanna query", "layout":"top","type":"error","closeButton":"true"}');
        return true;
    }
    if (Scope.trim() == "") {
        $("#btnQuery").attr("data-noty-options", '{"text":"Please select delivery type","layout":"top","type":"error","closeButton":"true"}');
        return true;
    }
    return false;
}

function LoadInitialChartData()
{
    var myChart9 = echarts.init(document.getElementById('mainb'), theme);
    myChart9.setOption({
        title: {
            text: 'Monthly Breakdown',
            subtext: 'Supported Scenarios'
        },
        tooltip: {
            trigger: 'axis',
            show: true,
            //formatter: function (params) {
            //    if (params.length > 1) {
            //        return params[0].name + "<br/>" + params[0].seriesName + ': ' + params[0].value + ' <br>' + params[1].seriesName + ': ' + params[1].value ;
            //    } else {
            //        return params[0].name + "<br/>" + params[0].seriesName + ': ' + params[0].value ;
            //    }
            //}
        },
        legend: {
            data: tagsArray
        },
        toolbox: {
            show: true,
            feature: {
                //mark: { show: true },
                //dataView: { show: true, readOnly: false },
                restore: { show: true },

                //saveAsImage: { show: true }
            }
        },
        calculable: false,
        xAxis: [
            {
                type: 'category',
                data: MonthList

            }
        ],
        yAxis: [
            {
                type: 'value',
                axisLabel: {
                    formatter: '{value}'
                }
            }
        ],
        series: questionChartDataArray
        //series: [
        //    {
        //        name: 'PHP',
        //        type: 'line',
        //        data: [31, 26, 18, 54, 25, 37, 54, 48, 38, 26],
        //        markLine: {
        //            itemStyle: {
        //                normal: {
        //                    label: {
        //                        show: true,
        //                        formatter: '{c}'
        //                    }
        //                }
        //            },
        //            data: [
        //                {
        //                    type: 'average',
        //                    name: 'average available rate',

        //                }
        //            ]
        //        }
        //    },
        //     {
        //         name: 'Node.JS',
        //         type: 'line',
        //         data: [51, 36, 28, 14, 35, 27, 14, 38, 28, 16],
        //         markLine: {
        //             itemStyle: {
        //                 normal: {
        //                     label: {
        //                         show: true,
        //                         formatter: '{c}'
        //                     }
        //                 }
        //             },
        //             data: [
        //                 {
        //                     type: 'average',
        //                     name: 'average available rate',

        //                 }
        //             ]
        //         }
        //     },
        //      {
        //          name: 'Python',
        //          type: 'line',
        //          //smooth: true,
        //          //itemStyle: {
        //          //      normal: {
        //          //          areaStyle: {
        //          //              type: 'default'
        //          //          }
        //          //      }
        //          //  },
        //          data: [11, 16, 18, 14, 15, 17, 14, 18, 18, 20],
        //          markLine: {
        //              itemStyle: {
        //                  normal: {
        //                      label: {
        //                          show: true,
        //                          formatter: '{c}'
        //                      }
        //                  }
        //              },
        //              data: [
        //                  {
        //                      type: 'average',
        //                      name: 'average available rate',

        //                  }
        //              ]
        //          }
        //      },
               
        //    {
        //        name: 'Java',
        //        type: 'line',
        //        data: [31, 9, 10, 16, 16, 24, 31, 17, 27, 11],
        //        markPoint: {
        //            data: [
        //                {
        //                    name: 'Joined the support since 5.25',
        //                    value: 4,
        //                    xAxis: 4,
        //                    yAxis: 16,
        //                    symbolSize: 18
        //                },
        //                //{
        //                //    name: 'Java',
        //                //    value: 2.3,
        //                //    xAxis: 11,
        //                //    yAxis: 3
        //                //}
        //            ]
        //        },
        //        markLine: {
        //            itemStyle: {
        //                normal: {
        //                    label: {
        //                        show: true,
        //                        formatter: '{c}'
        //                    }
        //                }
        //            },
        //            data: [
        //                {
        //                    type: 'average',
        //                    name: 'average available rate'
        //                }
        //            ]
        //        }
        //    },
        //    {
        //        name: 'Azure All',
        //        type: 'line',
        //        data: [81, 86, 88, 94, 85, 87, 74, 68, 98, 126],
        //        markLine: {
        //            itemStyle: {
        //                normal: {
        //                    label: {
        //                        show: true,
        //                        formatter: '{c}'
        //                    }
        //                }
        //            },
        //            data: [
        //                {
        //                    type: 'average',
        //                    name: 'average available rate',

        //                }
        //            ]
        //        }
        //    },
        //]
    });
}
function LoadHeroChartData()
{
    var myChart = echarts.init(document.getElementById('echart_hero'), theme);
    myChart.setOption({
        title: {
            text: 'Contribution',
            subtext: 'Hero Namelist'
        },
        tooltip: {
            trigger: 'axis',
            axisPointer: {
                type: 'shadow'
            }
        },
        toolbox: {
            show: true,
            feature: {
                restore: {
                    show: true
                },
            }
        },
        legend: {
            data: ['Owned', 'Replied', 'Answered', 'Helpful Voted'],
            y: 'bottom',
        },
        xAxis: [
        {
            type: 'value'
        }
        ],
        yAxis: [
            {
                type: 'category',
                data: ['dxu', 'wshao', 'v-agent', 'v-agent2',
                 'v-agent3', 'v-agent4', 'v-agent5']
            }
        ],
        calculable: true,
        series: [
       {
           name: 'Owned',
           type: 'bar',
           stack: 'qualified',
           itemStyle: { normal: { label: { show: true, position: 'insideRight' } } },
           data: [18, 5, 6, 9, 6, 9, 20, 9, 14, 5, 17, 8, 24, 3, 20, 6, 6, 4, 17, 12, 26, 4, 7, 12],
       },
       {
           name: 'Replied',
           type: 'bar',
           stack: 'qualified',
           itemStyle: { normal: { label: { show: true, position: 'insideRight' } } },
           data: [13, 4, 4, 7, 10, 15, 11, 8, 11, 13, 10, 9, 11, 12, 10, 18, 15, 9, 12, 13, 20, 17],
       },
       {
           name: 'Answered',
           type: 'bar',
           stack: 'qualified',
           itemStyle: { normal: { label: { show: true, position: 'insideRight' } } },
           data: [13, 4, 4, 7, 10, 15, 11, 8, 11, 13, 10, 9, 11, 12, 10, 18, 15, 9, 12, 13, 20, 17],
       },
        {
            name: 'Helpful Voted',
            type: 'bar',
            stack: 'qualified',
            itemStyle: { normal: { label: { show: true, position: 'insideRight' } } },
            data: [13, 4, 4, 7, 10, 15, 11, 8, 11, 13, 10, 9, 11, 12, 10, 18, 15, 9, 12, 13, 20, 17],
        },
        ]
    });
}
function LoadTechDistrubtionData()
{
    var myChart = echarts.init(document.getElementById('echart_techdistribution'), theme);
    myChart.setOption({
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} ({d}%)"
        },
        calculable: true,
        legend: {
            show: true,
            orient: 'horizontal',
            //x: 'left',
            x: 'center',
            y: 'top',
            data: ['PHP', 'Java', 'Python', 'Node.JS']
        },
        toolbox: {
            show: true,
            feature: {
                magicType: {
                    show: false,
                    type: ['pie', 'funnel'],
                    option: {
                        funnel: {
                            x: '25%',
                            width: '50%',
                            funnelAlign: 'center',
                            max: 1548
                        }
                    }
                },
                restore: {
                    show: true
                },
                saveAsImage: {
                    show: false
                }
            }
        },
        series: [
            {
                name: 'Tech Scope Distribution',
                type: 'pie',
                radius: ['35%', '55%'],
                itemStyle: {
                    normal: {
                        label: {
                            show: true
                        },
                        labelLine: {
                            show: true
                        }
                    },
                    emphasis: {
                        label: {
                            show: true,
                            position: 'center',
                            textStyle: {
                                fontSize: '14',
                                fontWeight: 'normal'
                            }
                        }
                    }
                },
                data: [
                    {
                        value: 131,
                        name: 'PHP'
                    },
                    {
                        value: 69,
                        name: 'Java'
                    },
                    {
                        value: 40,
                        name: 'Python'
                    },
                    {
                        value: 156,
                        name: 'Node.JS'
                    },
                ]
            }
        ]
    });
}
function LoadrepliedRatioData()
{
    var myChart9 = echarts.init(document.getElementById('echart_RepliedRatio'), theme);
    myChart9.setOption({
        title: {
            text: 'CSS Replied Ratio',
            subtext: 'During Seleted Date'
        },
        tooltip: {
            trigger: 'axis',
            show: true,
            formatter: function (params) {
                if (params.length > 1) {
                    return params[0].name + "<br/>" + params[0].seriesName + ': ' + params[0].value + '% <br/>' + params[1].seriesName + ': ' + params[1].value + '% <br/>'
                    + params[2].seriesName + ': ' + params[2].value + '% <br/>'
                    + params[3].seriesName + ': ' + params[3].value + '% <br/>'
                    + params[4].seriesName + ': ' + params[4].value + '% <br/>'
                } else {
                    return params[0].name + "<br/>" + params[0].seriesName + ': ' + params[0].value + '% ';
                }
            }
        },
        legend: {
            data: ['PHP', 'Java', 'Python', 'Node.JS', 'Azure All'],
            y:'bottom',
        },
        toolbox: {
            show: true,
            feature: {
                restore: {
                    show: true
                },
            }
        },
        calculable: false,
        xAxis: [
            {
                type: 'category',
                data: ['During Selected Date']

            }
        ],
        yAxis: [
            {
                type: 'value',
                axisLabel: {
                    formatter: '{value} %'
                }
            }
        ],
        series: [
            {
                name: 'PHP',
                type: 'bar',
                smooth: true,
                itemStyle: {
                      normal: {
                          areaStyle: {
                              type: 'default'
                          }
                      }
                  },
                data: [50,],
                markLine: {
                    itemStyle: {
                        normal: {
                            label: {
                                show: true,
                                formatter: '{c} %'
                            }
                        }
                    },
                    data: [
                        {
                            type: 'average',
                            name: 'average available rate',

                        }
                    ]
                }
            },
            {
                name: 'Java',
                type: 'bar',
                smooth: true,
                itemStyle: {
                    normal: {
                        areaStyle: {
                            type: 'default'
                        }
                    }
                },
                data: [32],
                markLine: {
                    itemStyle: {
                        normal: {
                            label: {
                                show: true,
                                formatter: '{c} %'
                            }
                        }
                    },
                    data: [
                        {
                            type: 'average',
                            name: 'average available rate'
                        }
                    ]
                }
            },
              {
                  name: 'Python',
                  type: 'bar',
                  smooth: true,
                  itemStyle: {
                      normal: {
                          areaStyle: {
                              type: 'default'
                          }
                      }
                  },
                  data: [41],
                  markLine: {
                      itemStyle: {
                          normal: {
                              label: {
                                  show: true,
                                  formatter: '{c} %'
                              }
                          }
                      },
                      data: [
                          {
                              type: 'average',
                              name: 'average available rate'
                          }
                      ]
                  }
              },
               {
                   name: 'Node.JS',
                   type: 'bar',
                   smooth: true,
                   itemStyle: {
                       normal: {
                           areaStyle: {
                               type: 'default'
                           }
                       }
                   },
                   data: [61],
                   markLine: {
                       itemStyle: {
                           normal: {
                               label: {
                                   show: true,
                                   formatter: '{c} %'
                               }
                           }
                       },
                       data: [
                           {
                               type: 'average',
                               name: 'average available rate'
                           }
                       ]
                   }
               },
                {
                    name: 'Azure All',
                    type: 'bar',
                    smooth: true,
                    itemStyle: {
                        normal: {
                            areaStyle: {
                                type: 'default'
                            }
                        }
                    },
                    data: [71],
                    markLine: {
                        itemStyle: {
                            normal: {
                                label: {
                                    show: true,
                                    formatter: '{c} %'
                                }
                            }
                        },
                        data: [
                            {
                                type: 'average',
                                name: 'average available rate'
                            }
                        ]
                    }
                },
        ]
    });
}
function LoadAgentBehaviorData()
{
    var myChart = echarts.init(document.getElementById('echart_agentbehavior'), theme);
    myChart.setOption({
        title: {
            text: 'CSS Involved - Impact Time to AH',
            subtext: 'Replies Qualification'
        },
        tooltip: {
            trigger: 'axis',
            showDelay: 0,
            axisPointer: {
                type: 'cross',
                lineStyle: {
                    type: 'dashed',
                    width: 1
                }
            }
        },
        legend: {
            data: ['dxu', 'wshao', 'Community Only'],
            y:'bottom',
        },
        toolbox: {
            show: true,
            feature: {
                restore: {
                    show: true
                }
            }
        },
        xAxis: [
            {
                type: 'value',
                scale: true,
                axisLabel: {
                    formatter: '{value} h'
                }
            }
        ],
        yAxis: [
            {
                type: 'value',
                scale: true,
                axisLabel: {
                    formatter: '{value} h'
                }
            }
        ],
        series: [
            {
                name: 'dxu',
                type: 'scatter',
                tooltip: {
                    trigger: 'item',
                    formatter: function (params) {
                        if (params.value.length > 1) {
                            return params.seriesName + ' <br/> IRT - ' + params.value[0] + 'h <br/> TimeToAH - ' + params.value[1] + 'h ';
                        } else {
                            return params.seriesName + ' :<br/>' + params.name + ' : ' + params.value + 'h ';
                        }
                    }
                },
                data: [[4.0, 5.6], [5.3, 1.8], [3.5, 0.7], [6.5, 2.6], [7.2, 8.8],
                    [1.5, 14.8], [14.0, 16.4], [14.5,28.4], [25.0, 32.0], [14.0, 31.6],
                    [0.0, 16.6], [17.8, 13.6], [12.0,20.0], [26.0, 34.6], [14.0, 31.0],
                    [4.0, 19.6], [12.7, 13.8], [11.5,20.0], [23.0, 32.4], [16.0, 35.9],
                    [6.0, 18.8], [10.5, 17.8], [12.7,26.2], [26.0, 36.4], [13.5, 31.8],
                    [8.0, 19.6], [10.3, 12.8], [10.3,26.4], [24.5, 33.2], [13.0, 30.9],
                    [3.5, 14.8], [15.5, 10.0], [18.0,22.4], [29.2, 34.1], [12.8, 39.1],
                    [0.0, 19.5], [12.0, 17.2], [10.0,21.3], [27.8, 38.6], [14.2, 30.1],
                    [6.7, 17.8], [11.4, 14.7], [12.7,23.4], [25.3, 32.1], [10.3, 32.6],
                    [2.9, 18.7], [18.0, 14.1], [17.2,24.1], [22.1, 34.9], [17.0, 39.1],
                    [9.5, 15.6], [14.0, 16.2], [12.7,25.3], [22.2, 37.1], [14.1, 35.2],
                    [3.0, 17.0], [11.5, 11.4], [14.2,26.8], [24.0, 36.8], [14.0, 32.2],
                    [7.0, 11.6], [16.0, 14.8], [17.0,28.2], [21.8, 36.1], [12.0, 32.0],
                    [7.0, 14.6], [17.8, 14.8], [14.5,20.0], [22.0, 31.6], [15.5, 33.2],
                    [1.2, 19.1], [11.6, 18.9], [17.4,27.7], [21.1, 36.0], [17.0, 38.2],
                    [4.5, 13.9], [17.5, 12.0], [10.5,26.8], [22.4, 34.5], [17.1, 30.9],
                    [0.1, 13.0], [15.5, 10.9], [10.6,22.7], [24.4, 38.0], [15.5, 30.9],
                    [0.6, 12.5], [17.0, 12.5], [17.1,23.4], [21.6, 35.5], [16.5, 33.0],
                    [5.0, 11.2], [14.0, 13.4], [15.1,20.5], [27.0, 38.9], [12.0, 32.3],
                    [6.5, 18.4], [19.4, 15.9], [12.1,25.7], [29.8, 34.5], [15.3, 37.7],
                    [4.9, 16.4], [17.3, 13.2], [17.4,23.9], [28.1, 32.0], [18.9, 35.5],
                    [7.2, 18.4], [10.3, 13.2], [10.2,22.7], [27.8, 34.1], [12.7, 32.3],
                    [5.1, 15.0], [16.7, 16.4], [15.1,25.0], [24.0, 38.6], [15.3, 34.1],
                    [5.4, 16.8], [17.8, 15.5], [10.3,23.2], [20.3, 32.7], [17.8, 38.0],
                    [7.8, 19.5], [17.8, 18.6], [17.8,21.8], [27.8, 38.4], [13.8, 32.2],
                    [8.0, 13.6], [18.1, 15.5], [15.3,20.9], [26.4, 35.9], [10.5, 39.1],
                    [6.4, 15.0], [17.8, 17.7], [19.7,26.4], [22.7, 30.9], [10.5, 33.6],
                    [5.4, 16.4], [18.9, 19.1], [17.6,24.5], [25.3, 34.5], [10.2, 39.1],
                    [0.5, 18.6], [17.8, 16.4], [10.5,20.9], [27.8, 37.7], [14.2, 34.5],
                    [6.5, 10.2], [17.8, 12.0], [10.3,21.4], [21.4, 32.7], [12.7, 34.1],
                    [2.7, 16.8], [17.8, 13.6], [17.8,20.9], [22.9, 30.9], [10.2, 35.5],
                    [7.6, 18.6], [15.3, 17.7], [15.1,26.4], [25.4, 32.3], [11.6, 30.5],
                    [2.7, 15.9], [10.5, 14.1], [19.1,27.3], [25.3, 31.8], [10.2, 35.9],
                    [3.0, 15.9], [11.4, 11.4], [17.8,21.8], [27.8, 36.8], [17.6, 39.1],
                    [7.6, 12.7], [10.3, 15.5], [12.9,29.5], [26.5, 33.6], [16.7, 31.8],
                    [8.0, 14.1], [18.0, 15.9], [17.8,21.8], [24.0, 32.5], [17.8, 30.5],
                    [1.4, 10.0], [15.4, 18.8], [15.4,24.1], [28.0, 30.5], [18.0, 31.4],
                    [2.9, 19.1], [16.5, 15.0], [15.3,29.1], [25.3, 33.6], [18.0, 30.5],
                    [8.0, 12.7], [15.3, 16.4], [10.5,27.7], [29.1, 32.7], [17.8, 33.6],
                    [5.3, 10.9], [12.9, 15.0], [10.8,23.2], [28.0, 33.2], [10.3, 37.7],
                    [7.8, 11.4], [15.4, 14.1], [18.9,25.0], [25.4, 33.6], [10.3, 35.5],
                    [4.0, 13.9], [17.6, 16.8], [12.9,27.3], [20.0, 32.3], [10.3, 38.6],
                    [7.6, 15.5], [16.7, 18.4], [15.3,21.1], [25.3, 37.3], [15.9, 37.7],
                    [5.3, 11.8], [19.1, 15.5], [11.6,24.5], [27.8, 36.6], [12.9, 35.0],
                    [7.8, 12.5], [14.2, 17.3], [19.1,21.8], [26.5, 37.9], [18.0, 34.3],
                    [4.0, 10.9], [17.6, 14.5], [10.2,27.3], [27.6, 32.3], [18.0, 37.3],
                    [4.0, 10.0], [16.5, 12.3], [10.3,23.6], [27.6, 34.1], [18.0, 35.9],
                    [0.3, 13.2], [17.6, 16.3], [13.0,25.9], [23.0, 30.9], [19.1, 39.1],
                    [0.2, 12.3], [17.8, 12.7], [19.1,29.1], [20.5, 38.2], [17.8, 34.1],
                    [0.3, 13.2], [10.3, 13.2]
                ],
                //markPoint: {
                //    data: [
                //        {
                //            type: 'max',
                //            name: 'Max'
                //        },
                //        {
                //            type: 'min',
                //            name: 'Min'
                //        }
                //    ]
                //},
                markLine: {
                    data: [
                        {
                            type: 'average',
                            name: 'Mean'
                        }
                    ]
                }
            },
            {
                name: 'wshao',
                type: 'scatter',
                tooltip: {
                    trigger: 'item',
                    formatter: function (params) {
                        if (params.value.length > 1) {
                            return params.seriesName + ' <br/> IRT - ' + params.value[0] + 'h <br/> TimeToAH - ' + params.value[1] + 'h ';
                        } else {
                            return params.seriesName + ' :<br/>' + params.name + ' : ' + params.value + 'h ';
                        }
                    }
                },
                data: [[4.0, 5.6], [5.3, 1.8], [3.5, 0.7], [6.5, 2.6], [7.2, 8.8],
                    [11.5, 24.8], [24.0, 36.4], [34.5, 48.4], [25.0, 32.0], [14.0, 31.6],
                    [10.0, 26.6], [27.8, 33.6], [32.0, 40.0], [26.0, 34.6], [14.0, 31.0],
                    [14.0, 29.6], [22.7, 33.8], [31.5, 40.0], [23.0, 32.4], [16.0, 35.9],
                    [16.0, 28.8], [20.5, 37.8], [32.7, 46.2], [26.0, 36.4], [13.5, 31.8],
                    [18.0, 29.6], [20.3, 32.8], [30.3, 46.4], [24.5, 33.2], [13.0, 30.9],
                    [13.5, 24.8], [25.5, 30.0], [38.0, 42.4], [29.2, 34.1], [12.8, 39.1],
                    [10.0, 29.5], [22.0, 37.2], [30.0, 41.3], [27.8, 38.6], [14.2, 30.1],
                    [16.7, 27.8], [21.4, 34.7], [32.7, 43.4], [25.3, 32.1], [10.3, 32.6],
                    [12.9, 28.7], [28.0, 34.1], [37.2, 44.1], [22.1, 34.9], [17.0, 39.1],
                    [19.5, 25.6], [24.0, 36.2], [32.7, 45.3], [22.2, 37.1], [14.1, 35.2],
                    [13.0, 27.0], [21.5, 31.4], [34.2, 46.8], [24.0, 36.8], [14.0, 32.2],
                    [17.0, 21.6], [26.0, 34.8], [37.0, 48.2], [21.8, 36.1], [12.0, 32.0],
                    [17.0, 24.6], [27.8, 34.8], [34.5, 40.0], [22.0, 31.6], [15.5, 33.2],
                    [11.2, 29.1], [21.6, 38.9], [37.4, 47.7], [21.1, 36.0], [17.0, 38.2],
                    [14.5, 23.9], [27.5, 32.0], [30.5, 46.8], [22.4, 34.5], [17.1, 30.9],
                    [10.1, 23.0], [25.5, 30.9], [30.6, 42.7], [24.4, 38.0], [15.5, 30.9],
                    [10.6, 22.5], [27.0, 32.5], [37.1, 43.4], [21.6, 35.5], [16.5, 33.0],
                    [15.0, 21.2], [24.0, 33.4], [35.1, 40.5], [27.0, 38.9], [12.0, 32.3],
                    [16.5, 28.4], [29.4, 35.9], [32.1, 45.7], [29.8, 34.5], [15.3, 37.7],
                    [14.9, 26.4], [27.3, 33.2], [37.4, 43.9], [28.1, 32.0], [18.9, 35.5],
                    [17.2, 28.4], [20.3, 33.2], [30.2, 42.7], [27.8, 34.1], [12.7, 32.3],
                    [15.1, 25.0], [26.7, 36.4], [35.1, 45.0], [24.0, 38.6], [15.3, 34.1],
                    [15.4, 26.8], [27.8, 35.5], [30.3, 43.2], [20.3, 32.7], [17.8, 38.0],
                    [17.8, 29.5], [27.8, 38.6], [37.8, 41.8], [27.8, 38.4], [13.8, 32.2],
                    [18.0, 23.6], [28.1, 35.5], [35.3, 40.9], [26.4, 35.9], [10.5, 39.1],
                    [16.4, 25.0], [27.8, 37.7], [39.7, 46.4], [22.7, 30.9], [10.5, 33.6],
                    [15.4, 26.4], [28.9, 39.1], [37.6, 44.5], [25.3, 34.5], [10.2, 39.1],
                    [10.5, 28.6], [27.8, 36.4], [30.5, 40.9], [27.8, 37.7], [14.2, 34.5],
                    [16.5, 20.2], [27.8, 32.0], [30.3, 41.4], [21.4, 32.7], [12.7, 34.1],
                    [12.7, 26.8], [27.8, 33.6], [37.8, 40.9], [22.9, 30.9], [10.2, 35.5],
                    [17.6, 28.6], [25.3, 37.7], [35.1, 46.4], [25.4, 32.3], [11.6, 30.5],
                    [12.7, 25.9], [20.5, 34.1], [39.1, 47.3], [25.3, 31.8], [10.2, 35.9],
                    [13.0, 25.9], [21.4, 31.4], [37.8, 41.8], [27.8, 36.8], [17.6, 39.1],
                    [17.6, 22.7], [20.3, 35.5], [32.9, 49.5], [26.5, 33.6], [16.7, 31.8],
                    [18.0, 24.1], [28.0, 35.9], [37.8, 41.8], [24.0, 32.5], [17.8, 30.5],
                    [11.4, 20.0], [25.4, 38.8], [35.4, 44.1], [28.0, 30.5], [18.0, 31.4],
                    [12.9, 29.1], [26.5, 35.0], [35.3, 49.1], [25.3, 33.6], [18.0, 30.5],
                    [18.0, 22.7], [25.3, 36.4], [30.5, 47.7], [29.1, 32.7], [17.8, 33.6],
                    [15.3, 20.9], [22.9, 35.0], [30.8, 43.2], [28.0, 33.2], [10.3, 37.7],
                    [17.8, 21.4], [25.4, 34.1], [38.9, 45.0], [25.4, 33.6], [10.3, 35.5],
                    [14.0, 23.9], [27.6, 36.8], [32.9, 47.3], [20.0, 32.3], [10.3, 38.6],
                    [17.6, 25.5], [26.7, 38.4], [35.3, 41.1], [25.3, 37.3], [15.9, 37.7],
                    [15.3, 21.8], [29.1, 35.5], [31.6, 44.5], [27.8, 36.6], [12.9, 35.0],
                    [17.8, 22.5], [24.2, 37.3], [39.1, 41.8], [26.5, 37.9], [18.0, 34.3],
                    [14.0, 20.9], [27.6, 34.5], [30.2, 47.3], [27.6, 32.3], [18.0, 37.3],
                    [14.0, 20.0], [26.5, 32.3], [30.3, 43.6], [27.6, 34.1], [18.0, 35.9],
                    [10.3, 23.2], [27.6, 36.3], [33.0, 45.9], [23.0, 30.9], [19.1, 39.1],
                    [10.2, 22.3], [27.8, 32.7], [39.1, 49.1], [20.5, 38.2], [17.8, 34.1],
                    [10.3, 23.2], [20.3, 33.2]
                ],
                //markPoint: {
                //    data: [
                //        {
                //            type: 'max',
                //            name: 'Max'
                //        },
                //        {
                //            type: 'min',
                //            name: 'Min'
                //        }
                //    ]
                //},
                markLine: {
                    data: [
                        {
                            type: 'average',
                            name: 'Mean'
                        }
                    ]
                }
            },
            {
                name: 'Community Only',
                type: 'scatter',
                tooltip: {
                    trigger: 'item',
                    formatter: function (params) {
                        if (params.value.length > 1) {
                            return params.seriesName + ' <br/> IRT - ' + params.value[0] + 'h <br/> TimeToAH - ' + params.value[1] + 'h ';
                        } else {
                            return params.seriesName + ' :<br/>' + params.name + ' : ' + params.value + 'h ';
                        }
                    }
                },
                data: [[10.2, 10.2], [10.3, 10.3], [0.7, 20.2], [19, 19], [27.3, 53.6],
                [21.3, 59.0], [19.4, 47.6], [14.9, 69.8], [12.2, 12.2], [8.9, 75.2],
                [22.3, 55.2], [19.4, 54.2], [14.9, 62.5], [12.2, 12.2], [8.9, 50.0],
                [23.3, 49.8], [19.4, 49.2], [14.9, 73.2], [12.2, 12.2], [8.9, 68.8],
                [24.3, 50.6], [19.4, 82.5], [14.9, 57.2], [12.2, 12.2], [8.9, 72.8],
                [25.3, 54.5], [19.4, 59.8], [14.9, 67.3], [12.2, 12.2], [8.9, 47.0],
                [26.3, 46.2], [19.4, 55.0], [14.9, 83.0], [12.2, 12.2], [8.9, 45.8],
                [24.3, 53.6], [19.4, 73.2], [14.9, 52.1], [12.2, 12.2], [8.9, 56.6],
                [24.3, 62.3], [19.4, 58.5], [14.9, 54.5], [12.2, 12.2], [8.9, 60.3],
                ],
                //markPoint: {
                //    data: [
                //        {
                //            type: 'max',
                //            name: 'Max'
                //        },
                //        {
                //            type: 'min',
                //            name: 'Min'
                //        }
                //    ]
                //},
                markLine: {
                    data: [
                        {
                            type: 'average',
                            name: 'Mean'
                        }
                    ]
                }
            },
        ]
    });
}
function LoadAHData()
{
    var myChart9 = echarts.init(document.getElementById('echart_AH'), theme);
    myChart9.setOption({
        title: {
            text: 'AHR Monthly Trend',
            subtext: 'Overall Status'
        },
        tooltip: {
            trigger: 'axis',
            show: true,
            formatter: function (params) {
                if (params.length > 1) {
                    return params[0].name + "<br/>" + params[0].seriesName + ': ' + params[0].value + '% <br/>' + params[1].seriesName + ': ' + params[1].value + '% <br/>'
                     + params[2].seriesName + ': ' + params[2].value + '% <br/>'
                    + params[3].seriesName + ': ' + params[3].value + '% <br/>'
                    + params[4].seriesName + ': ' + params[4].value + '% <br/>'
                     + params[5].seriesName + ': ' + params[5].value + '% <br/>'
                } else {
                    return params[0].name + "<br/>" + params[0].seriesName + ': ' + params[0].value + '% ';
                }
            }
        },
        legend: {
            data: ['3DayAR', 'OverallAR', '3DayHR', 'OverallHR', '3DayAHR', 'OverallAHR'],
            y: 'bottom',
        },
        toolbox: {
            show: true,
            feature: {
                restore: {
                    show: true
                },
            }
        },
        calculable: false,
        xAxis: [
            {
                type: 'category',
                data: ['Jan', 'Feb', 'Mar', 'Apri',
                'May', 'Jun', 'Jul', 'Aug',
                'Sept', 'Oct']

            }
        ],
        yAxis: [
            {
                type: 'value',
                axisLabel: {
                    formatter: '{value} %'
                }
            }
        ],
        series: [
            {
                name: '3DayAHR',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal: {
                        areaStyle: {
                            type: 'default'
                        }
                    }
                },
                data: [50,30,34,37,40,43,47,44,43,39 ],
                markLine: {
                    itemStyle: {
                        normal: {
                            label: {
                                show: true,
                                formatter: '{c} %'
                            }
                        }
                    },
                    data: [
                        {
                            type: 'average',
                            name: 'average available rate',

                        }
                    ]
                }
            },
            {
                name: 'OverallAHR',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal: {
                        areaStyle: {
                            type: 'default'
                        }
                    }
                },
                data: [62.3, 65, 67,68,68,73,75,82,81,80],
                markLine: {
                    itemStyle: {
                        normal: {
                            label: {
                                show: true,
                                formatter: '{c} %'
                            }
                        }
                    },
                    data: [
                        {
                            type: 'average',
                            name: 'average available rate'
                        }
                    ]
                }
            },
             {
                 name: '3DayAR',
                 type: 'line',
                 smooth: true,
                 itemStyle: {
                     normal: {
                         areaStyle: {
                             type: 'default'
                         }
                     }
                 },
                 data: [20, 15, 14, 17, 30, 33, 27, 24, 33, 29],
                 markLine: {
                     itemStyle: {
                         normal: {
                             label: {
                                 show: true,
                                 formatter: '{c} %'
                             }
                         }
                     },
                     data: [
                         {
                             type: 'average',
                             name: 'average available rate',

                         }
                     ]
                 }
             },
            {
                name: 'OverallAR',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal: {
                        areaStyle: {
                            type: 'default'
                        }
                    }
                },
                data: [42.3, 35, 37, 38, 38, 43, 45, 32, 41, 40],
                markLine: {
                    itemStyle: {
                        normal: {
                            label: {
                                show: true,
                                formatter: '{c} %'
                            }
                        }
                    },
                    data: [
                        {
                            type: 'average',
                            name: 'average available rate'
                        }
                    ]
                }
            },
             {
                 name: '3DayHR',
                 type: 'line',
                 smooth: true,
                 itemStyle: {
                     normal: {
                         areaStyle: {
                             type: 'default'
                         }
                     }
                 },
                 data: [30, 20, 44, 47, 40, 33, 37, 46, 49, 49],
                 markLine: {
                     itemStyle: {
                         normal: {
                             label: {
                                 show: true,
                                 formatter: '{c} %'
                             }
                         }
                     },
                     data: [
                         {
                             type: 'average',
                             name: 'average available rate',

                         }
                     ]
                 }
             },
            {
                name: 'OverallHR',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal: {
                        areaStyle: {
                            type: 'default'
                        }
                    }
                },
                data: [52.3, 55, 57, 58, 58, 53, 55, 52, 61, 50],
                markLine: {
                    itemStyle: {
                        normal: {
                            label: {
                                show: true,
                                formatter: '{c} %'
                            }
                        }
                    },
                    data: [
                        {
                            type: 'average',
                            name: 'average available rate'
                        }
                    ]
                }
            },
        ]
    });
}
function LoadAHBreakDownData() {
    var myChart9 = echarts.init(document.getElementById('echart_AHRBreakDown'), theme);
    myChart9.setOption({
        title: {
            text: 'Overall AHR Monthly Breakdown',
            subtext: 'Tech Scope'
        },
        tooltip: {
            trigger: 'axis',
            show: true,
            formatter: function (params) {
                if (params.length > 1) {
                    return params[0].name + "<br/>" + params[0].seriesName + ': ' + params[0].value + '% <br/>' + params[1].seriesName + ': ' + params[1].value + '% <br/>'
                      + params[2].seriesName + ': ' + params[2].value + '% <br/>'
                    + params[3].seriesName + ': ' + params[3].value + '% <br/>'
                    + params[4].seriesName + ': ' + params[4].value + '% <br/>'
                } else {
                    return params[0].name + "<br/>" + params[0].seriesName + ': ' + params[0].value + '% ';
                }
            }
        },
        legend: {
            data: ['PHP', 'Java', 'Python', 'Node.JS', 'Azure All'],
            y: 'bottom',
        },
        toolbox: {
            show: true,
            feature: {
                restore: {
                    show: true
                },
            }
        },
        calculable: false,
        xAxis: [
            {
                type: 'category',
                data: ['Jan', 'Feb', 'Mar', 'Apri',
                'May', 'Jun', 'Jul', 'Aug',
                'Sept', 'Oct']

            }
        ],
        yAxis: [
            {
                type: 'value',
                axisLabel: {
                    formatter: '{value} %'
                }
            }
        ],
        series: [
            {
                name: 'PHP',
                type: 'bar',
                smooth: true,
                itemStyle: {
                    normal: {
                        areaStyle: {
                            type: 'default'
                        }
                    }
                },
                data: [50, 30, 34, 37, 40, 43, 47, 44, 43, 39],
                markLine: {
                    itemStyle: {
                        normal: {
                            label: {
                                show: true,
                                formatter: '{c} %'
                            }
                        }
                    },
                    data: [
                        {
                            type: 'average',
                            name: 'average available rate',

                        }
                    ]
                }
            },
             {
                 name: 'Java',
                 type: 'bar',
                 smooth: true,
                 itemStyle: {
                     normal: {
                         areaStyle: {
                             type: 'default'
                         }
                     }
                 },
                 data: [20, 15, 14, 17, 30, 33, 27, 24, 33, 29],
                 markLine: {
                     itemStyle: {
                         normal: {
                             label: {
                                 show: true,
                                 formatter: '{c} %'
                             }
                         }
                     },
                     data: [
                         {
                             type: 'average',
                             name: 'average available rate',

                         }
                     ]
                 }
             },
            {
                name: 'Python',
                type: 'bar',
                smooth: true,
                itemStyle: {
                    normal: {
                        areaStyle: {
                            type: 'default'
                        }
                    }
                },
                data: [42.3, 35, 37, 38, 38, 43, 45, 32, 41, 40],
                markLine: {
                    itemStyle: {
                        normal: {
                            label: {
                                show: true,
                                formatter: '{c} %'
                            }
                        }
                    },
                    data: [
                        {
                            type: 'average',
                            name: 'average available rate'
                        }
                    ]
                }
            },
             {
                 name: 'Node.JS',
                 type: 'bar',
                 smooth: true,
                 itemStyle: {
                     normal: {
                         areaStyle: {
                             type: 'default'
                         }
                     }
                 },
                 data: [30, 20, 44, 47, 40, 33, 37, 46, 49, 49],
                 markLine: {
                     itemStyle: {
                         normal: {
                             label: {
                                 show: true,
                                 formatter: '{c} %'
                             }
                         }
                     },
                     data: [
                         {
                             type: 'average',
                             name: 'average available rate',

                         }
                     ]
                 }
             },
                {
                    name: 'Azure All',
                    type: 'bar',
                    smooth: true,
                    itemStyle: {
                        normal: {
                            areaStyle: {
                                type: 'default'
                            }
                        }
                    },
                    data: [62.3, 65, 67, 68, 68, 73, 75, 82, 81, 80],
                    markLine: {
                        itemStyle: {
                            normal: {
                                label: {
                                    show: true,
                                    formatter: '{c} %'
                                }
                            }
                        },
                        data: [
                            {
                                type: 'average',
                                name: 'average available rate'
                            }
                        ]
                    }
                },
        ]
    });
}
function LoadIRTData()
{
    var myChart9 = echarts.init(document.getElementById('echart_IRT'), theme);
    myChart9.setOption({
        title: {
            text: 'Monthly Breakdown',
            subtext: 'Supported Scenarios'
        },
        tooltip: {
            trigger: 'axis',
            show: true,
        },
        legend: {
            data: ['PHP', 'Java', 'Python', 'Node.JS', 'Azure All']
        },
        toolbox: {
            show: true,
            feature: {
                restore: {
                    show: true
                },
            }
        },
        calculable: false,
        xAxis: [
            {
                type: 'category',
                data: ['Jan', 'Feb', 'Mar', 'Apri',
                'May', 'Jun', 'Jul', 'Aug',
                'Sept', 'Oct']

            }
        ],
        yAxis: [
            {
                type: 'value',
                axisLabel: {
                    formatter: '{value} h'
                }
            }
        ],
        series: [
            {
                name: 'PHP',
                type: 'line',
                data: [2031, 1026, 1018, 854, 725, 12, 14, 18, 18, 16],
                markLine: {
                    itemStyle: {
                        normal: {
                            label: {
                                show: true,
                                formatter: '{c}'
                            }
                        }
                    },
                    data: [
                        {
                            type: 'average',
                            name: 'average available rate',

                        }
                    ]
                }
            },
             {
                 name: 'Node.JS',
                 type: 'line',
                 data: [1051, 1036, 1028, 1014, 535, 17, 14, 18, 18, 16],
                 markLine: {
                     itemStyle: {
                         normal: {
                             label: {
                                 show: true,
                                 formatter: '{c}'
                             }
                         }
                     },
                     data: [
                         {
                             type: 'average',
                             name: 'average available rate',

                         }
                     ]
                 }
             },
              {
                  name: 'Python',
                  type: 'line',
                  //smooth: true,
                  //itemStyle: {
                  //      normal: {
                  //          areaStyle: {
                  //              type: 'default'
                  //          }
                  //      }
                  //  },
                  data: [1011, 1016, 1018, 1014, 715, 17, 14, 18, 18, 20],
                  markLine: {
                      itemStyle: {
                          normal: {
                              label: {
                                  show: true,
                                  formatter: '{c}'
                              }
                          }
                      },
                      data: [
                          {
                              type: 'average',
                              name: 'average available rate',

                          }
                      ]
                  }
              },

            {
                name: 'Java',
                type: 'line',
                data: [1031, 1009, 1010, 1016, 616, 24, 31, 17, 27, 11],
                markLine: {
                    itemStyle: {
                        normal: {
                            label: {
                                show: true,
                                formatter: '{c}'
                            }
                        }
                    },
                    data: [
                        {
                            type: 'average',
                            name: 'average available rate'
                        }
                    ]
                }
            },
            {
                name: 'Azure All',
                type: 'line',
                data: [2281, 1186, 1088, 1194, 988, 17, 14, 18, 18, 12],
                markPoint: {
                    data: [
                        {
                            name: 'Joined the support since',
                            value: 5.25,
                            xAxis: 4,
                            yAxis: 1016,
                            symbolSize: 18
                        },
                        //{
                        //    name: 'Java',
                        //    value: 2.3,
                        //    xAxis: 11,
                        //    yAxis: 3
                        //}
                    ]
                },
                markLine: {
                    itemStyle: {
                        normal: {
                            label: {
                                show: true,
                                formatter: '{c}'
                            }
                        }
                    },
                    data: [
                        {
                            type: 'average',
                            name: 'average available rate',

                        }
                    ]
                }
            },
        ]
    });
}
function LoadReputationEngData()
{
    var myChart9 = echarts.init(document.getElementById('echart_EngRP'), theme);
    myChart9.setOption({
        title: {
            text: 'Reputation Points Gained Distribution',
            subtext: 'Engineers Based'
        },
        tooltip : {
            trigger: 'axis',
            axisPointer : {            
                type : 'shadow'        
            },
            formatter: function (params) {
                var tar = params[0];
                return tar.name + '<br/>' + tar.seriesName + ' : ' + tar.value;
            }
        },
        toolbox: {
            show : true,
            feature : {
                restore : {show: true},
            }
        },
        xAxis : [
            {
                type : 'category',
                splitLine: {show:false},
                data : ['All Points','dxu','wshao','peter','gary', 'agent']
            }
        ],
        yAxis : [
            {
                type : 'value'
            }
        ],
        series : [
            {
                name:'helper',
                type:'bar',
                stack: 'total',
                itemStyle:{
                    normal:{
                        barBorderColor:'rgba(0,0,0,0)',
                        color:'rgba(0,0,0,0)'
                    },
                    emphasis:{
                        barBorderColor:'rgba(0,0,0,0)',
                        color:'rgba(0,0,0,0)'
                    }
                },
                data:[0, 1700, 1400, 1200, 300, 0]
            },
            {
                name:'Reputation Points',
                type:'bar',
                stack: 'total',
                itemStyle : { normal: {label : {show: true, position: 'inside'}}},
                data:[2900, 1200, 300, 200, 900, 300]
            }
        ]
    });
}
function LoadReputationMonthlyData()
{
    var myChart9 = echarts.init(document.getElementById('echart_RPTrend'), theme);
    myChart9.setOption({
        title: {
            text: 'Reputation Points Monthly Breakdown',
            subtext: 'Engineer Based'
        },
        tooltip: {
            trigger: 'axis',
            show: true,
        },
        legend: {
            data: ['dxu', 'wshao', 'peter', 'gary', 'total'],
            y: 'bottom',
        },
        toolbox: {
            show: true,
            feature: {
                restore: {
                    show: true
                },
            }
        },
        calculable: false,
        xAxis: [
            {
                type: 'category',
                data: ['Jan', 'Feb', 'Mar', 'Apri',
                'May', 'Jun', 'Jul', 'Aug',
                'Sept', 'Oct']

            }
        ],
        yAxis: [
            {
                type: 'value',
                axisLabel: {
                    formatter: '{value} '
                }
            }
        ],
        series: [
            {
                name: 'dxu',
                type: 'line',
                data: [850, 830, 835, 837, 840, 843, 847, 644, 243, 239],
            },
             {
                 name: 'wshao',
                 type: 'line',
                 data: [220, 315, 214, 217, 230, 233, 227, 224, 233, 229],
             },
            {
                name: 'peter',
                type: 'line',
                data: [0, 0, 0, 35, 138, 343, 545, 732, 941, 1040],
            },
             {
                 name: 'gary',
                 type: 'line',
                 data: [0, 0, 0, 47, 140, 233, 337, 446, 649, 749],
             },
                {
                    name: 'total',
                    type: 'line',
                    data: [1065, 1065, 1065, 1068, 1068, 1073, 1175, 1182, 1181, 1190],
                },
        ]
    });
}
function LoadPeopleReachData()
{
    var myChart9 = echarts.init(document.getElementById('echart_peoplereach'), theme);
    myChart9.setOption({
        tooltip: {
            trigger: 'axis',
            axisPointer: {            
                type: 'shadow'        
            }
        },
        legend: {
            data: ['dxu', 'wshao', 'peter', 'gary', 'agent', 'total']
        },
        toolbox: {
            show: true,
            feature: {
                restore: { show: true },
            }
        },
        xAxis: [
            {
                type: 'category',
                data: ['Jan', 'Feb', 'Mar', 'Apri',
                 'May', 'Jun', 'Jul', 'Aug',
                 'Sept', 'Oct']
            }
        ],
        yAxis: [
            {
                type: 'value'
            }
        ],
        series: [
            {
                name: 'dxu',
                type: 'bar',
                stack: 'reputation',
                itemStyle: { normal: { label: { show: true, position: 'inside' } } },
                data: [320, 332, 301, 334, 390, 330, 320,1300,1200,1100]
            },
            {
                name: 'wshao',
                type: 'bar',
                stack: 'reputation',
                itemStyle: { normal: { label: { show: true, position: 'inside' } } },
                data: [320, 332, 301, 334, 390, 330, 320, 220,110,130]
            },
            {
                name: 'peter',
                type: 'bar',
                stack: 'reputation',
                itemStyle: { normal: { label: { show: true, position: 'inside' } } },
                data: [320, 332, 301, 334, 390, 330, 320,500,700,900]
            },
            {
                name: 'gary',
                type: 'bar',
                stack: 'reputation',
                itemStyle: { normal: { label: { show: true, position: 'inside' } } },
                data: [320, 332, 301, 334, 390, 330, 320, 99,200,100]
            },
             {
                 name: 'agent',
                 type: 'bar',
                 stack: 'reputation',
                 itemStyle: { normal: { label: { show: true, position: 'inside' } } },
                 data: [320, 332, 301, 334, 390, 330, 320,199,300,200]
             },
             {
                 name: 'total',
                 type: 'line',
                 itemStyle: { normal: { label: { textStyle: { color: 'black' }, show: true} } },
                 data: [2320, 2332, 2301, 2334, 2390, 2330, 2320, 2599, 2500, 2500]
             },
        ]
    });
}