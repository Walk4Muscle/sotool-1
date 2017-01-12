<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="StackoverflowDeliveryTool.Index" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Stackoverflow Threads Handling Tool</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- The styles -->
    <link id="bs-css" href="css/bootstrap-spacelab.css" rel="stylesheet">
    <style type="text/css">
        body {
            padding-bottom: 40px;
        }

        .sidebar-nav {
            padding: 9px 0;
        }

        .auto-style1 {
            text-indent: -.25in;
            line-height: 107%;
            font-size: 11.0pt;
            font-family: Calibri, sans-serif;
            margin-left: .5in;
            margin-right: 0in;
            margin-top: 0in;
            margin-bottom: .0001pt;
        }

        .auto-style2 {
            text-indent: -.25in;
            line-height: 107%;
            font-size: 11.0pt;
            font-family: Calibri, sans-serif;
            margin-left: .5in;
            margin-right: 0in;
            margin-top: 0in;
            margin-bottom: 8.0pt;
        }

        .auto-style3 {
            line-height: 107%;
            font-size: 11.0pt;
            font-family: Calibri, sans-serif;
            margin-left: .5in;
            margin-right: 0in;
            margin-top: 0in;
            margin-bottom: .0001pt;
        }
    </style>
    <link href="css/bootstrap-responsive.css" rel="stylesheet">
    <link href="css/charisma-app.css" rel="stylesheet">
    <link href="css/jquery-ui-1.8.21.custom.css" rel="stylesheet">
    <link href='css/fullcalendar.css' rel='stylesheet'>
    <link href='css/fullcalendar.print.css' rel='stylesheet' media='print'>
    <link href='css/chosen.css' rel='stylesheet'>
    <link href='css/uniform.default.css' rel='stylesheet'>
    <link href='css/colorbox.css' rel='stylesheet'>
    <link href='css/jquery.cleditor.css' rel='stylesheet'>
    <link href='css/jquery.noty.css' rel='stylesheet'>
    <link href='css/noty_theme_default.css' rel='stylesheet'>
    <link href='css/elfinder.min.css' rel='stylesheet'>
    <link href='css/elfinder.theme.css' rel='stylesheet'>
    <link href='css/jquery.iphone.toggle.css' rel='stylesheet'>
    <link href='css/opa-icons.css' rel='stylesheet'>
    <link href='css/uploadify.css' rel='stylesheet'>
    <link rel="shortcut icon" href="img/Team icon.ico">
</head>

<body>
    <!-- topbar starts -->
    <div class="navbar">
        <div class="navbar-inner">
            <div class="container-fluid">
                <a class="btn btn-navbar" data-toggle="collapse" data-target=".top-nav.nav-collapse,.sidebar-nav.nav-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </a>
                <a class="brand" href="index.aspx">
                    <span>MSDN Forum Support Team</span></a>
                <!-- user dropdown starts -->
                <div class="btn-group pull-right">
                    <a class="btn dropdown-toggle" data-toggle="dropdown" href="#">
                        <i class="icon-user"></i><span id="userspan" class="hidden-phone"><%=this.userName %></span>
                        <span class="caret"></span>
                    </a>
                    <ul class="dropdown-menu" style="list-style: none;">
                        <li><a id="btnMP" href="#">MyProfile</a></li>
                        <li class="divider"></li>
                    </ul>
                </div>
                <!-- user dropdown ends -->

                <div class="top-nav nav-collapse">
                    <ul class="nav">
                        <li><a href="#">Search on StackOverFlow Via Tags</a></li>
                        <li>
                            <input id="txbSearchForSOF" style="margin-top: 5px;" placeholder="Search" class="span2" onkeydown="SearchOnSOF();" type="text" data-source='["Azure","Express","WordPress","Windows Phone","WP","Linux","Connecticut","openSUSE","Oracle Linux","Ubuntu","Joomla","node.js","Django","MediaWiki","Apache Tomcat","PHP","MySQL","Python","Java","C#","WP"]' data-items="10" data-provide="typeahead">
                        </li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </div>
    </div>
    <!-- topbar ends -->
    <div class="container-fluid">
        <div class="row-fluid">

            <!-- left menu starts -->
            <div class="span2 main-menu-span">
                <div class="well nav-collapse sidebar-nav">
                    <ul class="nav nav-tabs nav-stacked main-menu">
                        <li class="nav-header hidden-tablet">Delivery</li>
                        <li><a class="ajax-link" href="index.aspx" style="cursor: pointer"><i class="icon-home"></i><span class="hidden-tablet">Threads List</span></a></li>
                        <li class="nav-header hidden-tablet">Reporting sys</li>
                        <li><a class="ajax-link" href="Reports.aspx"><i class="icon-eye-open"></i><span class="hidden-tablet">Insightful Reports</span></a></li>
                        <li class="nav-header hidden-tablet">Settings</li>
                        <li><a class="ajax-link" href="Settings.aspx"><i class="icon-wrench"></i><span class="hidden-tablet">Tool Settings</span></a></li>
                    </ul>
                    <label id="for-is-ajax" class="hidden-tablet" style="font-size: 11px" for="is-ajax">Design By MSDN Forum Support Team</label>
                </div>
                <div class="well nav-collapse sidebar-nav" style="padding: 10px; margin-top: 20px; background: white;">
                    <h2 style="text-align: center; border-bottom: 1px solid; border-color: #cecece; margin-bottom: 5px;">FeedBack</h2>
                    <h4>New year is arriving, happy new year and thanks for all your contributions last year!</h4>
                    <p>
                        As we work on this tool every day, how do you think about it? Does it work well, does it serve you well, does it perform well, does it really help you on your work?
                    </p>
                    <p>
                        We plan to upgrade this tool in new year, and we need your help. If you have any suggestion or idea, if you want any new feature which may improve your work efficieny, please share your idea with us!
                    </p>
                    <div>
                        <div class="form-group">
                            <label style="font-weight: bold;">Message:</label>
                            <textarea name="feedback" class="form-control" rows="5" id="txtfeedback" placeholder="Share your idea with us! ..."></textarea>
                        </div>
                        <a href="#" id="feedback" class="btn btn-default">Submit</a>
                    </div>
                </div>
                <!--/.well -->
            </div>
            <!--/span-->
            <!-- left menu ends -->

            <%--            <div>

                <div class="form-group">
                
                        <div class="form-group">
                            <label>In order to give better support, please submit this feedback if you have any idea. </label>

                        </div>
                        <div class="form-group">
                            <label for="txtfeedback">Message:</label>
                            <textarea class="form-control" id="txtfeedback" rows="3"></textarea>
                        </div>
                        <button type="submit" id="feedback" class="btn btn-primary">Submit</button>
                   
                </div>

            </div>--%>


            <noscript>
                <div class="alert alert-block span10">
                    <h4 class="alert-heading">Warning!</h4>
                    <p>You need to have <a href="http://en.wikipedia.org/wiki/JavaScript" target="_blank">JavaScript</a> enabled to use this site.</p>
                </div>
            </noscript>

            <div id="content" class="span10">
                <!-- content starts -->


                <div style="display: none">
                    <ul class="breadcrumb">
                        <li>
                            <a href="#">Stackoverflow Tool</a> <span class="divider">/</span>
                        </li>
                        <li>
                            <a href="#">Our Workload Today</a>
                        </li>
                    </ul>
                </div>
                <div class="row-fluid" style="display: none">
                    <a id="NewThreadsSum" data-rel="tooltip" class="well span3 top-block" title="New Threads" href="#">
                        <span class="icon32 icon-color icon-document"></span>
                        <div>New Threads</div>
                        <div id="divTotalNewThreadNo">
                            <img src="img/ajax-loaders/ajax-loader-1.gif">
                        </div>
                        <span id="spanMyNewThreadNo" class="notification">
                            <img src="img/ajax-loaders/ajax-loader-1.gif"></span>
                    </a>

                    <a id="FollowupSum" data-rel="tooltip" title="Required Follow up" class="well span3 top-block" href="#">
                        <span class="icon32 icon-color icon-comment-text"></span>
                        <div>Required Follow up</div>
                        <div id="divTotalRequiredFollow">
                            <img src="img/ajax-loaders/ajax-loader-1.gif">
                        </div>
                        <span id="spanMyRequiredFollow" class="notification green">
                            <img src="img/ajax-loaders/ajax-loader-1.gif"></span>
                    </a>

                    <a id="NoIRSum" data-rel="tooltip" title="No IR Threads" class="well span3 top-block" href="#">
                        <span class="icon32 icon-color icon-alert"></span>
                        <div>No IR Threads</div>
                        <div id="divTotalNoIR">
                            <img src="img/ajax-loaders/ajax-loader-1.gif">
                        </div>
                        <span id="spanMyNoIR" class="notification yellow">
                            <img src="img/ajax-loaders/ajax-loader-1.gif"></span>
                    </a>

                    <a id="RepliesSum" data-rel="tooltip" title="Reply Volume" class="well span3 top-block" href="#">
                        <span class="icon32 icon-red icon-replyall"></span>
                        <div>Reply Volume</div>
                        <div id="divTotalReplies">
                            <img src="img/ajax-loaders/ajax-loader-1.gif">
                        </div>
                        <span id="spanMyReplies" class="notification red">
                            <img src="img/ajax-loaders/ajax-loader-1.gif"></span>
                    </a>
                </div>

                <div class="row-fluid">
                    <div class="box span12">
                        <div class="box-header well">
                            <h2><i class="icon-info-sign"></i>Query Fun - Search Your Threads </h2>
                            <h3 style="padding-left: 5px; color: gray" id="hTgas"></h3>
                            <h3 style="padding-left: 5px; color: gray" id="hStatus"></h3>
                            <h3 style="padding-left: 5px; color: gray" id="hDelivery"></h3>

                            ﻿
                           
                            <%--<div class="box-icon">
                                <a class="btn btn-success" id="btnQuery" data-rel="tooltip" title="Click Me To Start Query">
                                      <i class="icon-zoom-in icon-white"></i>
									</a>

                            </div>--%>
                        </div>
                        <div class="row-fluid sortable">
                            <div class="box span12">
                                <div class="box-content" style="float: left;">
                                    <div class="control-group">
                                        <label class="control-label" for="txbFromDate">From:</label>
                                        <div class="controls">
                                            <input style="width: 70px;" type="text" class="input-xlarge datepicker" id="txbFromDate" value="<%=this.initialFromdate %>">
                                        </div>
                                    </div>
                                </div>
                                <div class="box-content" style="float: left">
                                    <div class="control-group">
                                        <label class="control-label" for="txbToDate">To:</label>
                                        <div class="controls">
                                            <input type="text" style="width: 70px;" class="input-xlarge datepicker" id="txbToDate" value="<%=this.initialTodate%>">
                                        </div>
                                    </div>
                                </div>
                                <div class="box-content" style="float: left">
                                    <div class="control-group">
                                        <label class="control-label" for="txbOwner">Owner:</label>
                                        <div class="controls">
                                            <input type="text" style="width: 70px;" class="input-xlarge" id="txbOwner" value="<%=this.alias %>">
                                        </div>
                                    </div>
                                </div>
                                <div class="box-content" style="float: left">
                                    <div class="control-group">
                                        <label class="control-label" for="selectTS">Status:</label>
                                        <div class="controls">
                                            <select data-placeholder="Thread Status" id="selectTS" data-rel="chosen">
                                                <option value=""></option>
                                                <optgroup label="Thread State">
                                                    <option value="0">New Thread</option>
                                                    <option value="1">Waiting On Customer</option>
                                                    <option value="2">Answered</option>
                                                    <option value="3">Re-Open/Follow</option>
                                                    <option value="4">Escalated</option>
                                                    <option value="5">Pending on Research</option>
                                                    <option value="6">Self-Answered</option>
                                                    <option value="7">Deleted in SO</option>
                                                    <option value="9">OffTopic</option>
                                                    <option value="8">All</option>

                                                </optgroup>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <div class="box-content" style="float: left">
                                    <div class="control-group">
                                        <label class="control-label" for="selectSs">Scenario:</label>
                                        <div class="controls">
                                            <select data-placeholder="Scenarios" id="selectSs" data-rel="chosen">
                                                <%-- <option value=""></option>

 
                                                <optgroup label="Azure">
                                                    <option scenario="1" value="Azure;PHP">PHP</option>
                                                    <option scenario="2" value="Azure;Java">Java</option>
                                                    <option scenario="3" value="Azure;Python">Python</option>
                                                    <option scenario="azureall" value="Azure All">Azure All</option>
                                                </optgroup>
                                                <optgroup label="Mobility">
                                                    <option scenario="4">IOS</option>
                                                    <option scenario="5" >Cordova</option>
                                                    <option scenario="mobilityall">Mobility All</option>
                                                </optgroup>
                                                <optgroup label="All">
                                                    <option scenario="all">All</option>

                                                </optgroup>--%>
                                            </select>
                                            <%-- <select data-placeholder="Scenarios" id="selectvt" data-rel="chosen"></select>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="box-content" style="float: left">
                                    <div class="control-group">
                                        <label class="control-label" for="selectDevliery">Delivery:</label>
                                        <div class="controls">
                                            <select data-placeholder="Delivery" id="selectDelivery" data-rel="chosen">
                                                <option value=""></option>
                                                <optgroup label="Delivery">
                                                    <option value="0">No IR</option>
                                                    <option value="1">Replied by me</option>
                                                    <option value="2">Answered by me</option>
                                                    <option value="3">All</option>
                                                </optgroup>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <div class="box-content" style="float: left; margin-top: 20px;">
                                    <a class="btn btn-success" id="btnQuery">

                                        <i class="icon-zoom-in icon-white"></i>
                                    </a>

                                </div>
                            </div>
                        </div>
                        <!--/row-->
                        <div class="row-fluid ">
                            <div class="span12">
                                <div class="tooltip-demo well">
                                    <span style="font-size: 11.0pt; line-height: 107%;">
                                        <div class="box-content">
                                            <table class="table table-striped table-bordered bootstrap-datatable datatable">
                                                <thead>
                                                    <tr>
                                                        <th style="width: 5%">Take</th>
                                                        <th style="width: 5%">Owner</th>
                                                        <th style="width: 5%">Quality Review</th>
                                                        <th style="width: 5%">Status</th>
                                                        <th style="width: 5%">Action</th>
                                                        <th style="width: 26%">Thread Title/Link</th>
                                                        <th style="width: 15%">Create date</th>
                                                        <th style="width: 15%">LastUpdateDate</th>
                                                        <th style="width: 8%">IRT</th>
                                                        <th style="width: 5%">Virtual Team</th>

                                                        <th style="width: 5%">UT</th>

                                                        <%-- <th style="width:5%">Virtual Team</th>
                                                        <th style="width:5%">Quality review</th>--%>
                                                    </tr>
                                                </thead>
                                                <tbody id="questionTBody">
                                                    <%-- <tr>
                                                        <td class="right"><span data-rel="tooltip" title="Click Me Take owner" class="icon32 icon-gray icon-unlocked" style="cursor:pointer"></span></td>
                                                        <td class="center"></td>
                                                         <td class="center">
                                                            <span class="label label-success">Active</span>
                                                        </td>
                                                        <td style="width:3%">
                                                            <div class="btn-group">
                                                               <button class="btn btn-large">Action</button>
                                                                <button class="btn dropdown-toggle" data-toggle="dropdown"><span class="caret"></span></button>
                                                                <ul class="dropdown-menu" style="list-style:none;">
                                                                    <li><a href="#"><i class="icon-star"></i>Waiting On Customer</a></li>
                                                                    <li><a href="#"><i class="icon-tag"></i>Escalated</a></li>
                                                                    <li><a href="#"><i class="icon-download-alt"></i>Researching</a></li>
                                                                    <li class="divider"></li>
                                                                    <li><a href="#"><i class="icon-tint"></i>Dispatch Owner</a></li>
                                                                </ul>
                                                            </div>
                                                        </td>
                                                        <td class="center"><a data-rel="tooltip" title="How to use Chinese search engine" href="http://www.baidu.com" target="_blank">How to use Chinese search engine</a></td>
                                                        <td class="center">2014/5/6 12:30:30 PM</td>
                                                        <td class="center">2014/5/8 12:30:30 PM</td>

                                                        <td class="center">10h 30min</td>
                                                        <td class="center">
                                                            <span style="cursor:pointer" class="btn btn-info btn-setting" data-rel="tooltip" title="Clieck Me To Add UT" >20</span></td>

                                                    </tr>--%>
                                                </tbody>
                                            </table>

                                        </div>

                                    </span>
                                    <%-- <div class="btn-group">

                                        <button class="btn btn-large">Batch Action</button>
                                        <button class="btn btn-large dropdown-toggle" data-toggle="dropdown"><span class="caret"></span></button>
                                        <ul class="dropdown-menu">
                                            <li><a href="#"><i class="icon-star"></i>Set Waiting On Customer</a></li>
                                            <li><a href="#"><i class="icon-tag"></i>Escalated</a></li>
                                            <li><a href="#"><i class="icon-download-alt"></i>Researching</a></li>
                                            <li class="divider"></li>
                                            <li><a href="#"><i class="icon-tint"></i>Change Owner & Dispatch</a></li>
                                        </ul>

                                    </div>--%>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <!-- content ends -->
            </div>
            <!--/#content.span10-->
        </div>
        <!--/fluid-row-->
        <hr>
        <div class="modal hide fade" id="myModalQR" style="width: auto">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" id="btnCloseQRModel">×</button>
                <h3>Quality Review</h3>
            </div>
            <div class="modal-body">
                <div class="row-fluid sortable">
                    <div class="box span12">
                        <div class="box-content">
                            <ul class="nav nav-tabs" role="tablist">

                                <li class="nav-item">
                                    <a class="nav-link" href="#view_qr" role="tab" data-toggle="tab" id="v_qr">View QR</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#perform_qr" role="tab" data-toggle="tab" id="p_qr">Perform QR</a>
                                </li>
                                <%--<li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#qreview" role="tab">Quality Review</a>
                          </li>--%>
                                <%-- <li class="nav-item">
                            <a class="nav-link disabled" data-toggle="tab" href="#settings" role="tab">Settings</a>
                          </li>--%>
                                <%--<li class="dropdown">
                                        <a class="dropdown-toggle" data-toggle="dropdown" role="tab" href="#qreview">Quality Review<b class="caret"></b></a>
                                        <ul class="dropdown-menu">
                                            <li><a class="nav-link"  href="#perform_qr" role="tab" data-toggle="tab" id="p_qr">Perform QR</a></li>
                                            <li><a class="nav-link"  href="#view_qr" role="tab" data-toggle="tab" id="v_qr">View QR</a></li>
                                           
                                        </ul>
                              </li>  --%>
                            </ul>

                            <!-- Tab panes -->

                            <form class="form-horizontal">
                                <fieldset>
                                    <div class="tab-content">
                                        <%--  <div class="tab-pane active" id="utdata" role="tabpanel">
                                  <div class="control-group">
							        <label class="control-label" for="txbUT">UT </label>
							            <div class="controls">
							                <input type="text" placeholder="How many mins you spent" class="span6 typeahead" id="txbUT">

							            </div>
							       </div>
							            <div class="control-group">
							                <label class="control-label" for="textareaUTComments">UT Comments </label>
							                    <div class="controls">
							                        <textarea id="textareaUTComments" rows="10" style="width:320px"></textarea>

							                    </div>
							            </div>
                              </div>
                              <div class="tab-pane" id="uthistory" role="tabpanel">
                                 <table class="table table-striped table-bordered bootstrap-datatable datatable1"  id="datatable1">
                                                <thead class="thead-inverse">
                                                    <tr>
                                                         <th style="width:20%">Question Id</th>
                                                        <th style="width:20%">Owner</th> 
                                                        <th style="width:20%">UT Logged</th>
                                                        <th style="width:20%">Created on</th>
                                                        <th style="width:20%">UT Comments</th>                                                      
                                                </thead>
                                     <tbody id="lbrdata"></tbody>

                                 </table>
                              </div>--%>
                                        <%--<div class="tab-pane" id="qreview" role="tabpanel">three</div>--%>
                                        <%--<div class="tab-pane" id="settings" role="tabpanel">four</div>--%>
                                        <div class="tab-pane" id="perform_qr">


                                            <p class="h5">Please check the options mentioned below.</p>
                                            <hr>

                                            <table id="tableqr" class="table" style="width: 465px;">
                                                <thead>
                                                    <tr>
                                                        <th style="width: 10%;">No.</th>
                                                        <th style="width: 80%;">Questions</th>
                                                        <th style="width: 10%; text-align: center">Check/Uncheck</th>

                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <th scope="row">1</th>
                                                        <td>Is this case in right direction?</td>
                                                        <td style="text-align: center">
                                                            <input type="checkbox" value="" name="qrcbox"></td>

                                                    </tr>
                                                    <tr>
                                                        <th scope="row">2</th>
                                                        <td>Is the solution helpful to resolve the problem?</td>
                                                        <td style="text-align: center">
                                                            <input type="checkbox" value="" name="qrcbox"></td>

                                                    </tr>
                                                    <tr>
                                                        <th scope="row">3</th>
                                                        <td>Did the Engineer mark the answer properly?</td>
                                                        <td style="text-align: center">
                                                            <input type="checkbox" value="" name="qrcbox"></td>

                                                    </tr>
                                                    <tr>
                                                        <th scope="row">4</th>
                                                        <td>Does it meet follow up time?</td>
                                                        <td style="text-align: center">
                                                            <input type="checkbox" value="" name="qrcbox"></td>

                                                    </tr>
                                                    <tr>
                                                        <th scope="row">5</th>
                                                        <td>Did the Engineer provide sufficient information for the benefit of customer?</td>
                                                        <td style="text-align: center">
                                                            <input type="checkbox" value="" name="qrcbox"></td>

                                                    </tr>
                                                    <tr>
                                                        <th scope="row">6</th>
                                                        <td>Does it meet initial response time(SLA)?</td>
                                                        <td style="text-align: center">
                                                            <input type="checkbox" value="" name="qrcbox"></td>

                                                    </tr>
                                                    <tr>
                                                        <th scope="row">7</th>
                                                        <td>Did the Engineer use Signature/ Disclaimer properly?</td>
                                                        <td style="text-align: center">
                                                            <input type="checkbox" value="" name="qrcbox"></td>

                                                    </tr>
                                                    <tr>
                                                        <th scope="row">8</th>
                                                        <td>Did the Engineer show effort and willing to help?</td>
                                                        <td style="text-align: center">
                                                            <input type="checkbox" value="" name="qrcbox"></td>

                                                    </tr>
                                                    <tr>
                                                        <th scope="row">9</th>
                                                        <td>Did the support person show efforts and take any proper action when the customer is unhappy?</td>
                                                        <td style="text-align: center">
                                                            <input type="checkbox" value="" name="qrcbox"></td>

                                                    </tr>
                                                    <tr>
                                                        <th scope="row">10</th>
                                                        <td>English writting?</td>
                                                        <td style="text-align: center">
                                                            <input type="checkbox" value="" name="qrcbox"></td>

                                                    </tr>


                                                </tbody>
                                            </table>
                                            <table class="table" style="width: 410px;">
                                                <tbody>

                                                    <tr>
                                                        <th scope="row"><span style="color: red">*</span> Points:
                                                   <h6 id="cntchkbox" class="label label-info" style="width: 150px">
                                                       <input type="text" class="form-control cnttxt" id="score" name="score" style="width: 30px; right: 10px" />
                                                       points out of 10</h6>

                                                        </th>
                                                        <td><span style="color: red">*</span> Select Status:
                                                  <select style="width: 130px;" title="Select Status" class='label label-info' id="statuscombo">
                                                      <option value="0" selected hidden>Select</option>
                                                      <option value="1">Pass</option>
                                                      <option value="2">Failed</option>

                                                  </select>


                                                        </td>
                                                        <td><span style="color: red">*</span> IsFixed:
                                                   <select style="width: 130px;" title="IsFixed" class='label label-info' id="isfixedcombo">
                                                       <option value="0" selected hidden>Select</option>
                                                       <option value="1">Yes</option>
                                                       <option value="2">No</option>

                                                   </select>


                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <th scope="row" colspan="3">
                                                            <label for="comment">Comment:</label>
                                                            <textarea class="form-control" rows="5" style="width: 400px" id="comment"></textarea>
                                                            <br />
                                                            <span id="err"></span>
                                                        </th>

                                                    </tr>
                                                    <tr>
                                                        <th scope="row" colspan="3"><a href="#" class="btn btn-info" id="btnSavereview">Save Review Result</a>

                                                            <br />
                                                            <span id="lblinserted"></span>
                                                        </th>



                                                    </tr>
                                                </tbody>
                                            </table>

                                        </div>
                                        <div class="tab-pane" id="view_qr">
                                            Review Results
                                           <table class="table table-striped table-bordered bootstrap-datatable datatable_review" id="datatable_review" style="width: auto">
                                               <thead class="thead-inverse">
                                                   <tr>

                                                       <th>Owner</th>
                                                       <th>Reviewed By</th>
                                                       <th>Review on</th>
                                                       <th>Comments by FTE</th>
                                                       <th>Points</th>
                                                       <th>Status</th>
                                                       <th class="td_comment">Comment</th>
                                                   </tr>
                                               </thead>
                                               <tbody id="reviewbody">
                                                   <%-- <tr>
                                            
                                              <td>101</td>
                                              <td>ABC</td>
                                              <td>XYZ</td>
                                              <td>01-01-2016</td>
                                              <td>Need to followup.</td>
                                              <td>Pass</td>
                                              <td><a href="#" class="btn btn-info" id="opcomment">Comment</a></td>
                                             
                                      </tr> --%>
                                               </tbody>

                                           </table>

                                            Comments by Support Engineer:-
                                <table class="table table-striped table-bordered bootstrap-datatable datatable_review" id="datatable_eng_comment">
                                    <thead class="thead-inverse">
                                        <tr>
                                            <th>Question Id</th>
                                            <th>Alias</th>
                                            <th>Commented on</th>
                                            <th>Comment</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tbody id="commentbody">
                                        <%-- <tr>
                                            
                                              <td>101</td>
                                              <td>ABC</td>
                                              <td>01-01-2016</td>
                                              <td>Modified based on suggestion.</td>
                                              <td>Reply Modified</td>
                                             
                                      </tr> --%>
                                    </tbody>

                                </table>
                                        </div>





                                        <%--<legend>UT Data</legend>--%>
                                    </div>
                                </fieldset>
                            </form>

                        </div>
                    </div>
                    <!--/span-->

                </div>
            </div>
            <div class="modal-footer">
                <span id="lblforscore" style="font-size: small; position: absolute; left: 10px"></span>
                <a href="#" class="btn" data-dismiss="modal">Close</a>
                <%-- <a href="#" class="btn btn-primary" id="btnSaveUILog">Save changes</a>--%>
            </div>
        </div>
        <div class="modal hide fade" id="myModalUT" style="width: auto">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" id="btnCloseUTModel">×</button>
                <h3>UT Logging</h3>
            </div>
            <div class="modal-body">

                <div class="row-fluid sortable">
                    <div class="box span12">
                        <div class="box-content">
                            <ul class="nav nav-tabs" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#utdata" role="tab" id="#utd">UT Data</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-toggle="tab" href="#uthistory" role="tab" id="lbrdtl">UT History</a>
                                </li>
                                <%--<li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#qreview" role="tab">Quality Review</a>
                          </li>--%>
                                <%-- <li class="nav-item">
                            <a class="nav-link disabled" data-toggle="tab" href="#settings" role="tab">Settings</a>
                          </li>--%>
                                <%--  <li class="dropdown">
                                        <a class="dropdown-toggle" data-toggle="dropdown" role="tab" href="#qreview">Quality Review<b class="caret"></b></a>
                                        <ul class="dropdown-menu">
                                            <li><a class="nav-link"  href="#perform_qr" role="tab" data-toggle="tab" id="p_qr">Perform QR</a></li>
                                            <li><a class="nav-link"  href="#view_qr" role="tab" data-toggle="tab" id="v_qr">View QR</a></li>
                                           
                                        </ul>
                              </li>--%>
                            </ul>

                            <!-- Tab panes -->

                            <form class="form-horizontal">
                                <fieldset>
                                    <div class="tab-content">
                                        <div class="tab-pane active" id="utdata" role="tabpanel">
                                            <div class="control-group">
                                                <label class="control-label" for="txbUT">UT </label>
                                                <div class="controls">
                                                    <input type="text" placeholder="How many mins you spent" class="span6 typeahead" id="txbUT">
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label" for="textareaUTComments">UT Comments </label>
                                                <div class="controls">
                                                    <textarea id="textareaUTComments" rows="10" style="width: 320px"></textarea>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="tab-pane" id="uthistory" role="tabpanel">
                                            <table class="table table-striped table-bordered bootstrap-datatable datatable1" id="datatable1" style="width: auto">
                                                <thead class="thead-inverse">
                                                    <tr>
                                                        <th>Question Id</th>
                                                        <th>Alias</th>
                                                        <th>UT Logged</th>
                                                        <th>Created on</th>
                                                        <th>UT Comments</th>
                                                </thead>
                                                <tbody id="lbrdata"></tbody>

                                            </table>
                                        </div>
                                        <%--<div class="tab-pane" id="qreview" role="tabpanel">three</div>--%>
                                        <%--<div class="tab-pane" id="settings" role="tabpanel">four</div>--%>
                                        <%--<div class="tab-pane" id="perform_qr">
                                       
                                         
                                       <p class="h5">Please check the options mentioned below.</p>
                                       <hr>
                                       
                                      <table class="table">
                                          <thead>
                                            <tr>
                                              <th>No.</th>
                                              <th>Questions</th>
                                              <th>Check/Uncheck</th>
                                              
                                            </tr>
                                          </thead>
                                          <tbody>
                                            <tr>
                                              <th scope="row">1</th>
                                              <td>Is this case in right direction?</td>
                                              <td><input type="checkbox" value="" name="qrcbox" ></td>
                                             
                                            </tr>
                                            <tr>
                                              <th scope="row">2</th>
                                              <td>Is the solution helpful to resolve the problem?</td>
                                              <td><input type="checkbox" value="" name="qrcbox" ></td>
                                            
                                            </tr>
                                            <tr>
                                              <th scope="row">3</th>
                                              <td>Does it meet initial response time?</td>
                                              <td><input type="checkbox" value="" name="qrcbox"></td>
                                            
                                            </tr>
                                                <tr>
                                              <th scope="row">4</th>
                                              <td>Does it meet initial response time?</td>
                                              <td><input type="checkbox" value="" name="qrcbox"></td>
                                            
                                            </tr>
                                                <tr>
                                              <th scope="row">5</th>
                                              <td>Does it meet initial response time?</td>
                                              <td><input type="checkbox" value="" name="qrcbox"></td>
                                            
                                            </tr>
                                                <tr>
                                              <th scope="row">6</th>
                                              <td>Does it meet initial response time?</td>
                                              <td><input type="checkbox" value="" name="qrcbox"></td>
                                            
                                            </tr>
                                                <tr>
                                              <th scope="row">7</th>
                                              <td>Does it meet initial response time?</td>
                                              <td><input type="checkbox" value="" name="qrcbox"></td>
                                            
                                            </tr>
                                                <tr>
                                              <th scope="row">8</th>
                                              <td>Does it meet initial response time?</td>
                                              <td><input type="checkbox" value="" name="qrcbox"></td>
                                            
                                            </tr>
                                                <tr>
                                              <th scope="row">9</th>
                                              <td>Does it meet initial response time?</td>
                                              <td><input type="checkbox" value="" name="qrcbox"></td>
                                            
                                            </tr>
                                                <tr>
                                              <th scope="row">10</th>
                                              <td>Does it meet initial response time?</td>
                                              <td><input type="checkbox" value="" name="qrcbox"></td>
                                            
                                            </tr>
                                              
                                           
                                          </tbody>
                                        </table >
                                       <table class="table" style=" width:auto">
                                           <tbody>
                                        
                                              <tr>
                                              <th scope="row"><span style="color:red">*</span> Points:
                                                   <h6 id="cntchkbox" class="label label-info" style=" width:150px">
                                                        <input type="text" class="form-control cnttxt" id="score" name="score" style="width:30px; right:10px"/> points out of 10</h6>
                                                  
                                              </th>
                                              <td><span style="color:red">*</span> Select Status:
                                                  <select style="width:130px;" title="Select Status" class='label label-info' id="statuscombo">
                                                      <option value="0" selected hidden>Select</option>
                                                      <option >Pass</option>
                                                      <option >Failed</option>
                                                     
                                                    </select>


                                              </td>
                                              <td><span style="color:red">*</span> IsFixed:
                                                   <select style="width:130px;" title="IsFixed" class='label label-info' id="isfixedcombo">
                                                      <option value="0" selected hidden>Select</option>
                                                       <option  value="1">Yes</option>
                                                      <option value="2">No</option>
                                                     
                                                    </select>

                                                
                                              </td>
                                             
                                            </tr> 
                                           <tr>
                                              <th scope="row" colspan="3" > <label for="comment">Comment:</label>
                                                <textarea class="form-control" rows="5" style="width:400px" id="comment"></textarea></th>
                                             
                                            </tr> 
                                               <tr>
                                              <th scope="row" colspan="3"> <a href="#" class="btn btn-info" id="btnSavereview">Save Review Result</a></th>
                                               
                                             
                                             
                                            </tr> 
                                          </tbody>
                                        </table>
                                      <div class="alert alert-danger alert-dismissable fade in" id="point_string_err" style="visibility:hidden">
                                      <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                      Points should be Numbers between 0 to 10.
                                      </div>
                                       <div class="alert alert-danger alert-dismissable fade in" id="point_num_err" style="visibility:hidden">
                                      <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                      You can give Minimum 0 and Maximum 10 points....
                                      </div>
                                   </div>--%>
                                        <%--<div class="tab-pane" id="view_qr">Review Results
                                           <table class="table table-striped table-bordered bootstrap-datatable datatable_review"  id="datatable_review" style="width:auto">
                                                <thead class="thead-inverse">
                                                    <tr>
                                                         <th >Question Id</th>
                                                         <th>Owner</th>
                                                        <th >Reviewed By</th> 
                                                        <th>Review on</th>
                                                        <th >Comments by FTE</th>
                                                        <th >Status</th>  
                                                        <th >Do Comment</th>  
                                                     </tr>                                                  
                                                </thead>
                                     <tbody id="reviewbody">
                                     <%-- <tr>
                                            
                                              <td>101</td>
                                              <td>ABC</td>
                                              <td>XYZ</td>
                                              <td>01-01-2016</td>
                                              <td>Need to followup.</td>
                                              <td>Pass</td>
                                              <td><a href="#" class="btn btn-info" id="opcomment">Comment</a></td>
                                             
                                      </tr> 
                                     </tbody>

                                 </table>--%>
                                        <%--  Comments by Support Engineer:-
                                <table class="table table-striped table-bordered bootstrap-datatable datatable_review"  id="datatable_eng_comment">
                                                <thead class="thead-inverse">
                                                    <tr>
                                                         <th >Question Id</th>
                                                         <th>Alias</th>
                                                        <th>Commented on</th>
                                                        <th >Comment</th>
                                                        <th >Action</th>   
                                                     </tr>                                                  
                                                </thead>
                                     <tbody id="commentbody">
                                      <tr>
                                            
                                              <td>101</td>
                                              <td>ABC</td>
                                              <td>01-01-2016</td>
                                              <td>Modified based on suggestion.</td>
                                              <td>Reply Modified</td>
                                             
                                      </tr> 
                                     </tbody>

                                 </table>
                                          </div>--%>





                                        <%--<legend>UT Data</legend>--%>
                                    </div>
                                </fieldset>
                            </form>

                        </div>
                    </div>
                    <!--/span-->

                </div>
                <!--/row-->
            </div>
            <div class="modal-footer">
                <a href="#" class="btn" data-dismiss="modal">Close</a>
                <a href="#" class="btn btn-primary" id="btnSaveUILog">Save changes</a>
            </div>
        </div>
        <%-----------------------------------------------/ comment by op popup for review /---------------------------------------%>

        <div class="modal hide fade" id="myModalcomment">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" id="">×</button>
                <h3>Make Comments for Review Result.</h3>
            </div>
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label" for="textareaUTComments">Engineer Comments </label>
                    <div class="controls">
                        <textarea id="opreviewcomment" rows="10" style="width: 500px"></textarea>
                    </div>
                    <div class="controls">
                        <label class="control-label" for="textareaUTComments">select the Action taken for this Thread:-</label>
                    </div>
                    <div class="controls">
                        <select class="selectpicker" title="Select Status" data-style="btn-info" data-width="fit" id="status_combo">
                            <option value="0" selected>Give New Reply</option>
                            <option>Modified the Reply</option>
                            <option>Delete the Reply</option>
                        </select>
                    </div>
                    <div class="controls">
                        <br />
                        <a href="#" class="btn btn-primary" id="btn_eng_comment">Send your Comment</a>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <a href="#" class="btn" data-dismiss="modal">Close</a>

            </div>
        </div>
        <%-----------------------------------------------/ comment by op popup for review ends here /---------------------------------------%>


        <%-- //-------------------------------popup for comment-------------------------------------------------%>
        <div class="modal hide fade" id="Modalcomment">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" id="">×</button>
                <h3>Comments for Review Result.</h3>
            </div>
            <div class="modal-body">
                <div class="control-group">

                    <div class="controls">
                        <span id="spancomment"></span>
                    </div>

                </div>
            </div>

        </div>
        <%-- //-------------------------------popup for comment ends here-------------------------------------------------%>


        <%-----------------------------------------------/ virtual team popup  /---------------------------------------%>

        <div class="modal hide fade" id="myModalVT" style="width: 400px">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" id="">×</button>
                <h3>Virtual Team</h3>
            </div>
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label" for="textareaUTComments">Currently Assigned Team: </label>
                    <div class="controls">
                        <span id="lblcurrteam" class="lbl lbl-primary"></span>
                    </div>
                    <div class="controls">
                        <label class="control-label" for="textareaUTComments">select the Virtual Team for this Thread:-</label>
                    </div>
                    <div class="controls">
                        <select class="selectpicker" title="Select Team" data-style="btn-info" data-width="fit" id="selectvt" data-placeholder="Virtual Team">
                            <option data-hidden="true">Choose one</option>
                        </select>
                    </div>
                    <div class="controls">
                        <br />
                        <a href="#" class="btn btn-primary" id="btn_assign_team">Assign Team</a>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <a href="#" class="btn" data-dismiss="modal">Close</a>

            </div>
        </div>

        <%-----------------------------------------------/ virtual team popup ends here /---------------------------------------%>


        <div class="modal hide fade" id="myModalProfile">
            <div class="modal-header">
                <button type="button" class="close" id="btncloseProfile" data-dismiss="modal">×</button>
                <h3 id="halias">dxu</h3>
            </div>
            <div class="modal-body">
                <div class="row-fluid sortable">
                    <div class="box span12">
                        <div class="box-content">
                            <form class="form-horizontal">
                                <fieldset>
                                    <legend>My Profile Data</legend>
                                    <div class="control-group">
                                        <label class="control-label" for="txb_sofID">StackOverFlow ID </label>
                                        <div class="controls">
                                            <input type="text" placeholder="Fill your ID" class="span6 typeahead" id="txb_sofID">
                                            <p class="help-block">You can find the ID from <a href="http://stackoverflow.com/users/" target="_blank">Stackoverflow forum</a></p>
                                        </div>
                                    </div>
                                </fieldset>
                            </form>

                        </div>
                    </div>
                    <!--/span-->

                </div>
                <!--/row-->

            </div>
            <div class="modal-footer">
                <a href="#" class="btn" data-dismiss="modal">Close</a>
                <a href="#" class="btn btn-primary" id="btnSaveProfile">Save changes</a>
            </div>
        </div>

        <div class="modal hide fade" id="myModalDispatchOwner">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" id="btnCloseDispatchModel">×</button>
                <h3>Thread Owner Dispatch</h3>
            </div>
            <div class="modal-body">
                <div class="row-fluid sortable">
                    <div class="box span12">
                        <div class="box-content">
                            <form class="form-horizontal" style="height: 200px;">
                                <fieldset>
                                    <legend>Set Thread's Owner</legend>
                                    <div class="control-group">
                                        <label class="control-label" for="selectSE">Owner MS Alias</label>
                                        <div class="controls">
                                            <select data-placeholder="Support Engineers" id="selectSE" data-rel="chosen">
                                                <option value=""></option>
                                                <optgroup label="Engineer Alias">
                                                </optgroup>
                                            </select>
                                        </div>
                                    </div>
                                </fieldset>
                            </form>

                        </div>
                    </div>
                    <!--/span-->

                </div>
                <!--/row-->
            </div>
            <div class="modal-footer">
                <a href="#" class="btn" data-dismiss="modal">Close</a>
                <a href="#" class="btn btn-primary" id="btnSaveSE">Save changes</a>
            </div>
        </div>
        <div class="modal hide fade" id="QAModel">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" id="btnCloseQAModel">×</button>
                <h3>QA</h3>
            </div>
            <div class="modal-body">
                <div class="row-fluid sortable">
                    <div class="box span12">
                        <div class="box-content">
                            <form class="form-horizontal" style="height: 200px;">
                                <fieldset>
                                    <legend>Set Thread's Owner</legend>
                                    <div class="control-group">
                                        <label class="control-label" for="selectSE">Owner MS Alias</label>
                                        <div class="controls">
                                            <select data-placeholder="Support Engineers" data-rel="chosen">
                                                <option value=""></option>
                                                <optgroup label="Engineer Alias">
                                                </optgroup>
                                            </select>
                                        </div>
                                    </div>
                                </fieldset>
                            </form>

                        </div>
                    </div>
                    <!--/span-->

                </div>
                <!--/row-->
            </div>
            <div class="modal-footer">
                <a href="#" class="btn" data-dismiss="modal">Close</a>
                <a href="#" class="btn btn-primary" id="btnSaveQA">Save changes</a>
            </div>
        </div>


        <div class="modal hide fade" id="SRModel">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" id="btnCloseSRModel">×</button>
                <h3>Solution Deliverly</h3>
            </div>
            <div class="modal-body">
                <div class="row-fluid sortable">
                    <div class="box span12">
                        <div class="box-content">
                            <form class="form-horizontal" style="height: 200px;">
                                <fieldset>
                                    <legend>Set Thread's Soluiton Delivery Status</legend>
                                    <div class="control-group">
                                        <label class="control-label" for="selectSE">Solution Confirm By</label>
                                        <div class="controls">
                                            <label class="radio-inline">
                                                <input type="radio" name="optradio">OP</label>
                                            <label class="radio-inline">
                                                <input type="radio" name="optradio">Community</label>
                                            <label class="radio-inline">
                                                <input type="radio" name="optradio">MSFT</label>
                                        </div>
                                    </div>
                                </fieldset>
                            </form>

                        </div>
                    </div>
                    <!--/span-->

                </div>
                <!--/row-->
            </div>
            <div class="modal-footer">
                <a href="#" class="btn" data-dismiss="modal">Close</a>
                <a href="#" class="btn btn-primary" id="btnSaveSE2">Save changes</a>
            </div>
        </div>

        <div class="modal hide fade" id="CCModel">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" id="btnCloseCCModel">×</button>
                <h3>Solution Deliverly</h3>
            </div>
            <div class="modal-body">
                <div class="row-fluid sortable">
                    <div class="box span12">
                        <div class="box-content">
                            <form class="form-horizontal" style="height: 200px;">
                                <fieldset>
                                    <legend>Set Confirmed Comments</legend>
                                    <div class="control-group">
                                        <label class="control-label" for="textareaSelfanswerComments">Self Comments </label>
                                        <div class="controls">
                                            <textarea id="textareaConfirmComments" rows="10" style="width: 320px"></textarea>

                                        </div>
                                    </div>
                                </fieldset>
                            </form>

                        </div>
                    </div>
                    <!--/span-->

                </div>
                <!--/row-->
            </div>
            <div class="modal-footer">
                <a href="#" class="btn" data-dismiss="modal">Close</a>
                <a href="#" class="btn btn-primary" id="btnSaveCC">Save changes</a>
            </div>
        </div>
        <footer>
            <p class="pull-left">&copy; <a href="http://msdn.microsoft.com/en-us/default.aspx" target="_blank">MSDN</a> 2014</p>
            <p class="pull-right">Foot: <a href="#">Here</a></p>
        </footer>

    </div>
    <!--/.fluid-container-->

    <!-- external javascript
	================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->

    <!-- jQuery -->
    <script src="js/jquery-1.7.2.min.js"></script>
    <!-- jQuery UI -->
    <script src="js/jquery-ui-1.8.21.custom.min.js"></script>
    <!-- Page JS -->
    <script src="js/pagejs/ServiceClient.js"></script>
    <script src="js/pagejs/indexpage.js"></script>
    <!-- transition / effect library -->
    <script src="js/bootstrap-transition.js"></script>
    <!-- alert enhancer library -->
    <script src="js/bootstrap-alert.js"></script>
    <!-- modal / dialog library -->
    <script src="js/bootstrap-modal.js"></script>
    <!-- custom dropdown library -->
    <script src="js/bootstrap-dropdown.js"></script>
    <!-- scrolspy library -->
    <script src="js/bootstrap-scrollspy.js"></script>
    <!-- library for creating tabs -->
    <script src="js/bootstrap-tab.js"></script>
    <!-- library for advanced tooltip -->
    <script src="js/bootstrap-tooltip.js"></script>
    <!-- popover effect library -->
    <script src="js/bootstrap-popover.js"></script>
    <!-- button enhancer library -->
    <script src="js/bootstrap-button.js"></script>
    <!-- accordion library (optional, not used in demo) -->
    <script src="js/bootstrap-collapse.js"></script>
    <!-- carousel slideshow library (optional, not used in demo) -->
    <script src="js/bootstrap-carousel.js"></script>
    <!-- autocomplete library -->
    <script src="js/bootstrap-typeahead.js"></script>
    <!-- tour library -->
    <script src="js/bootstrap-tour.js"></script>
    <!-- library for cookie management -->
    <script src="js/jquery.cookie.js"></script>
    <!-- calander plugin -->
    <script src='js/fullcalendar.min.js'></script>
    <!-- data table plugin -->
    <script src='js/jquery.dataTables.min.js'></script>

    <!-- chart libraries start -->
    <script src="js/excanvas.js"></script>
    <script src="js/jquery.flot.min.js"></script>
    <script src="js/jquery.flot.pie.min.js"></script>
    <script src="js/jquery.flot.stack.js"></script>
    <script src="js/jquery.flot.resize.min.js"></script>
    <!-- chart libraries end -->

    <!-- select or dropdown enhancer -->
    <script src="js/jquery.chosen.min.js"></script>
    <!-- checkbox, radio, and file input styler -->
    <script src="js/jquery.uniform.min.js"></script>
    <!-- plugin for gallery image view -->
    <script src="js/jquery.colorbox.min.js"></script>
    <!-- rich text editor library -->
    <script src="js/jquery.cleditor.min.js"></script>
    <!-- notification plugin -->
    <script src="js/jquery.noty.js"></script>
    <!-- file manager library -->
    <script src="js/jquery.elfinder.min.js"></script>
    <!-- star rating plugin -->
    <script src="js/jquery.raty.min.js"></script>
    <!-- for iOS style toggle switch -->
    <script src="js/jquery.iphone.toggle.js"></script>
    <!-- autogrowing textarea plugin -->
    <script src="js/jquery.autogrow-textarea.js"></script>
    <!-- multiple file upload plugin -->
    <script src="js/jquery.uploadify-3.1.min.js"></script>
    <!-- history.js for cross-browser state change on ajax -->
    <script src="js/jquery.history.js"></script>
    <!-- application script for Charisma demo -->
    <script src="js/charismaxm.js"></script>
    <script src="js/PageJS/selectHandler.js"></script>



    <%--  <script src="Scripts/jquery-1.10.2.js"></script>--%>
    <%--<link rel="stylesheet"  type="text/css" href="https://cdn.datatables.net/v/dt/dt-1.10.12/datatables.min.css"/>--%>



    <%--<script type="text/javascript" src="https://cdn.datatables.net/v/dt/dt-1.10.12/datatables.min.js"></script>--%>
</body>
</html>

