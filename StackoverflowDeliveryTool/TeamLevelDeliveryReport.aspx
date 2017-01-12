<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamLevelDeliveryReport.aspx.cs" Inherits="StackoverflowDeliveryTool.TeamLevelDeliveryReport" %>

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
   <%-- <link href='css/custom.css' rel='stylesheet'>
   <link href='css/bootstrap.min.css' rel='stylesheet'>--%>
   <link href="css/animate.min.css" rel="stylesheet">
    <link href="css/bannerNum.css" rel="stylesheet">
    
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
                    <ul class="dropdown-menu" style="list-style:none;">
                        <li><a id="btnMP" href="#">MyProfile</a></li>
                        <li class="divider"></li>
                    </ul>
                </div>
                <!-- user dropdown ends -->

                <div class="top-nav nav-collapse">
                    <ul class="nav">
                        <li><a href="#">Search on StackOverFlow Via Tags</a></li>
                        <li>
                            <input id="txbSearchForSOF" style="margin-top:5px;" placeholder="Search" class="span2" onkeydown="SearchOnSOF();" type="text" data-source='["Azure","Express","WordPress","Windows Phone","WP","Linux","Connecticut","openSUSE","Oracle Linux","Ubuntu","Joomla","node.js","Django","MediaWiki","Apache Tomcat","PHP","MySQL","Python","Java","C#","WP"]' data-items="10" data-provide="typeahead">
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
                        <li><a class="ajax-link" href="index.aspx" style="cursor: pointer"><i class="icon-home"></i><span class="hidden-tablet"> Threads List</span></a></li>
                        <li class="nav-header hidden-tablet">Reporting sys</li>
                        <li><a class="ajax-link" href="TeamLevelDeliveryReport.aspx"><i class="icon-eye-open"></i><span class="hidden-tablet"> Team Level Reports</span></a></li>
                        <li><a class="ajax-link" href="IndividualPerformance.aspx"><i class="icon-user"></i><span class="hidden-tablet"> Individual Performance</span></a></li>
                         <li><a class="ajax-link" href="MBUScoreCard.aspx"><i class="icon-flag"></i><span class="hidden-tablet"> MBU Trend</span></a></li>
                        <li><a class="ajax-link" href="WeeklyUpdate.aspx"><i class="icon-retweet"></i><span class="hidden-tablet"> Weekly Update</span></a></li>
                        <li class="nav-header hidden-tablet">Settings</li>
                        <li><a class="ajax-link" href="Settings.aspx"><i class="icon-wrench"></i><span class="hidden-tablet"> Tool Settings</span></a></li>
                    </ul>
                    <label id="for-is-ajax" class="hidden-tablet" style="font-size: 11px" for="is-ajax">Design By MSDN Forum Support Team</label>
                </div>
                <!--/.well -->
            </div>
            <!--/span-->
            <!-- left menu ends -->

            <noscript>
                <div class="alert alert-block span10">
                    <h4 class="alert-heading">Warning!</h4>
                    <p>You need to have <a href="http://en.wikipedia.org/wiki/JavaScript" target="_blank">JavaScript</a> enabled to use this site.</p>
                </div>
            </noscript>

            <div id="content" class="span10">
                <!-- content starts -->


                <div>
                    <ul class="breadcrumb" style="margin-bottom:0px;">
                        <li>
                            <a href="#">Stackoverflow Tool</a> <span class="divider">/</span>
                        </li>
                        <li>
                            <a href="#">Team Level Reports</a>
                        </li>
                    </ul>
                </div>
                <div class="row-fluid">
                    <div class="box span12">
                                <div class="box-content" style="float: left;">
                                    <div class="control-group">
                                        <label class="control-label" for="txbFromDate">From:</label>
                                        <div class="controls">
                                            <input style="width:70px;" type="text" class="input-xlarge datepicker" id="txbFromDate" value="<%=this.initialFromdate %>">
                                        </div>
                                    </div>
                                </div>
                                <div class="box-content" style="float: left">
                                    <div class="control-group">
                                        <label class="control-label" for="txbToDate">To:</label>
                                        <div class="controls">
                                            <input type="text" style="width:70px;" class="input-xlarge datepicker" id="txbToDate" value="<%=this.initialTodate%>">
                                        </div>
                                    </div>
                                </div>
                                  <div class="box-content" style="float: left">
                                    <div class="control-group">
                                        <label class="control-label" for="selectTS">Scope:</label>
                                        <div class="controls">
                                            <select id="selectScope" data-rel="chosen">
                                                <option value="EngLock">Eng Locked Only</option>
									            <option value="All" selected>All Threads</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="box-content" style="float: left">
                                    <div class="control-group">
                                        <label class="control-label" for="selectDevliery">Sub Group:</label>
                                        <div class="controls">
                                            <select data-placeholder="Groups among Azure, UWP, VSO"  id="selectSs" data-rel="chosen">
                                                <option value=""></option>
                                                <optgroup label="Tech Scenario">
                                                    <option value="0">OSS on Azure</option>
                                                    <option value="1">UWP</option>
                                                    <option value="2">VSO</option>
                                                    <option value="3">TFS</option>
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
                        <!--/row-->
                    </div>
                </div>
                <div class="row tile_count">
                     <div class="animated flipInY col-md-2 col-sm-4 col-xs-4 tile_stats_count">
                            <div class="left"></div>
                            <div class="right">
                                <span class="count_top"><i class="icon icon-color icon-messages"></i> Questions Volume</span>
                                <div class="count green" id="questionvolume">322</div>
                                <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i>15% </i> Increased </span>
                            </div>
                        </div>
                        <div id="test1" class="animated flipInY col-md-2 col-sm-4 col-xs-4 tile_stats_count">
                            <div class="left"></div>
                            <div class="right">
                                <span class="count_top"><i class="icon icon-color icon-clock"></i> Initial Response Time (hours)</span>
                                <div class="count yellow" id="irt">18.93</div>
                                <span class="count_bottom"><i class="green"> 15 times </i> Improved </span>
                            </div>
                        </div>
                        <div class="animated flipInY col-md-2 col-sm-4 col-xs-4 tile_stats_count">
                            <div class="left"></div>
                            <div class="right">
                                <span class="count_top"><i class="icon icon-color icon-check"></i> Answers + Helpful Voted</span>
                                <div class="count green" id="AHR">84%</div>
                                <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i>45% </i> Trend Higher </span>
                            </div>
                        </div>
                         <div class="animated flipInY col-md-2 col-sm-4 col-xs-4 tile_stats_count">
                            <div class="left"></div>
                            <div class="right">
                                <span class="count_top"><i class="icon icon-blue icon-users"></i> Response by us</span>
                                <div class="count blue" id="rrbyus">84%</div>
                                <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i>15% </i> Increased </span>
                            </div>
                        </div>
                          <div class="animated flipInY col-md-2 col-sm-4 col-xs-4 tile_stats_count">
                            <div class="left"></div>
                            <div class="right">
                                <span class="count_top"><i class="icon icon-black icon-flag"></i> Reputation Points</span>
                                <div class="count" id="Reputation">7677</div>
                                <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i>430 </i> per Engineer </span>
                            </div>
                        </div>
                          <div class="animated flipInY col-md-2 col-sm-4 col-xs-4 tile_stats_count">
                            <div class="left"></div>
                            <div class="right">
                                <span class="count_top"><i class="icon icon-color icon-heart"></i> People Reach</span>
                                <div class="count red" id="PeopleReach">103437</div>
                                <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i>1240 </i> per Engineer </span>
                            </div>
                        </div>
                    </div>
                <div class="row-fluid">
				<div class="box span8">
					<div class="box-content">
                  	<div class="row-fluid">
                        <div class="x_panel">
                                <div class="x_title">
                                    <h2><i class="icon32 icon-color icon-messages"></i> Coverage - Total Questions </h2>
                                    <ul class="nav navbar-right panel_toolbox">
                                        <li><i class="icon icon-color icon-calendar"></i> 2015-01-01 / 2015-10-30
                                        </li>
                                    </ul>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="x_content">
                                    <div id="mainb" style="height: 350px;"></div>
                                </div>
                            </div>
                    </div>                   
                  </div>

				</div>
                   <div class="box span4">
					<div class="box-content">
                  	<div class="row-fluid">
                        <div class="x_panel">
                                <div class="x_title">
                                    <h2><i class="icon32 icon-color icon-profile"></i> Coverage - Distribution </h2>
                                    <ul class="nav navbar-right panel_toolbox">
                                        <li><i class="icon icon-color icon-calendar"></i> 2015-01-01 / 2015-10-30
                                        </li>
                                    </ul>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="x_content">
                                    <div id="echart_techdistribution" style="height: 350px;"></div>
                                </div>
                            </div>
                    </div>                   
                  </div>

				</div>
                    <!--/span-->
			</div>
                <div class="row-fluid">
                      <div class="box span4">
					<div class="box-content">
                  	<div class="row-fluid">
                       <div class="x_panel">
                                <div class="x_title">
                                    <h2><i class="icon32 icon-color icon-bookmark"></i> Impact - Contribution Hero </h2>
                                    <ul class="nav navbar-right panel_toolbox">
                                        <li><i class="icon icon-color icon-calendar"></i> 2015-01-01 / 2015-10-30
                                        </li>
                                    </ul>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="x_content">
                                    <div id="echart_hero" style="height: 350px;"></div>
                                </div>
                            </div>
                    </div>                   
                  </div>

				</div>
				
                    <div class="box span4">
					<div class="box-content">
                  	<div class="row-fluid">
                       <div class="x_panel">
                                <div class="x_title">
                                    <h2><i class="icon32 icon-color icon-replyall"></i> Impact - Response Ratio </h2>
                                    <ul class="nav navbar-right panel_toolbox">
                                        <li><i class="icon icon-color icon-calendar"></i> 2015-01-01 / 2015-10-30
                                        </li>
                                    </ul>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="x_content">
                                    <div id="echart_RepliedRatio" style="height: 350px;"></div>
                                </div>
                            </div>
                    </div>                   
                  </div>

				</div>
                       <div class="box span4">
					<div class="box-content">
                  	<div class="row-fluid">
                       <div class="x_panel">
                                <div class="x_title">
                                    <h2><i class="icon32 icon-color icon-lightbulb"></i> Impact - Time To AH </h2>
                                    <ul class="nav navbar-right panel_toolbox">
                                        <li><i class="icon icon-color icon-calendar"></i> 2015-01-01 / 2015-10-30
                                        </li>
                                    </ul>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="x_content">
                                    <div id="echart_agentbehavior" style="height: 350px;"></div>
                                </div>
                            </div>
                    </div>                   
                  </div>

				</div>
                    <!--/span-->
			</div>
                <div class="row-fluid">
                      <div class="box span6">
					<div class="box-content">
                  	<div class="row-fluid">
                       <div class="x_panel">
                                <div class="x_title">
                                    <h2><i class="icon32 icon-color icon-check"></i> Results - Answered OR Helpful Voted </h2>
                                    <ul class="nav navbar-right panel_toolbox">
                                        <li><i class="icon icon-color icon-calendar"></i> 2015-01-01 / 2015-10-30
                                        </li>
                                    </ul>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="x_content">
                                    <div id="echart_AH" style="height: 350px;"></div>
                                </div>
                            </div>
                    </div>                   
                  </div>

				</div>
				
                    <div class="box span6">
					<div class="box-content">
                  	<div class="row-fluid">
                       <div class="x_panel">
                                <div class="x_title">
                                    <h2><i class="icon32 icon-color icon-check"></i> Results - AHR Tech Scope Breakdown </h2>
                                    <ul class="nav navbar-right panel_toolbox">
                                        <li><i class="icon icon-color icon-calendar"></i> 2015-01-01 / 2015-10-30
                                        </li>
                                    </ul>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="x_content">
                                    <div id="echart_AHRBreakDown" style="height: 350px;"></div>
                                </div>
                            </div>
                    </div>                   
                  </div>

				</div>
                       
                    <!--/span-->
			</div>
                <div class="row-fluid">
                      <div class="box span12">
					<div class="box-content">
                  	<div class="row-fluid">
                       <div class="x_panel">
                                <div class="x_title">
                                    <h2><i class="icon32 icon-color icon-clock"></i> Results - Initial Response Time </h2>
                                    <ul class="nav navbar-right panel_toolbox">
                                        <li><i class="icon icon-color icon-calendar"></i> 2015-01-01 / 2015-10-30
                                        </li>
                                    </ul>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="x_content">
                                    <div id="echart_IRT" style="height: 350px;"></div>
                                </div>
                            </div>
                    </div>                   
                  </div>

				</div>
                       
                    <!--/span-->
			</div>
                <div class="row-fluid">
                      <div class="box span6">
					<div class="box-content">
                  	<div class="row-fluid">
                       <div class="x_panel">
                                <div class="x_title">
                                    <h2><i class="icon32 icon-black icon-flag"></i> Results - Engineers' Reputation Points </h2>
                                    <ul class="nav navbar-right panel_toolbox">
                                        <li><i class="icon icon-color icon-calendar"></i> 2015-01-01 / 2015-10-30
                                        </li>
                                    </ul>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="x_content">
                                    <div id="echart_EngRP" style="height: 350px;"></div>
                                </div>
                            </div>
                    </div>                   
                  </div>

				</div>
				
                    <div class="box span6">
					<div class="box-content">
                  	<div class="row-fluid">
                       <div class="x_panel">
                                <div class="x_title">
                                    <h2><i class="icon32 icon-black icon-flag"></i> Results - Monthly Reputation Points </h2>
                                    <ul class="nav navbar-right panel_toolbox">
                                        <li><i class="icon icon-color icon-calendar"></i> 2015-01-01 / 2015-10-30
                                        </li>
                                    </ul>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="x_content">
                                    <div id="echart_RPTrend" style="height: 350px;"></div>
                                </div>
                            </div>
                    </div>                   
                  </div>

				</div>
                       
                    <!--/span-->
			</div>
                <div class="row-fluid">
                      <div class="box span12">
					<div class="box-content">
                  	<div class="row-fluid">
                       <div class="x_panel">
                                <div class="x_title">
                                    <h2><i class="icon32 icon-color icon-heart"></i> Results - People Reach </h2>
                                    <ul class="nav navbar-right panel_toolbox">
                                        <li><i class="icon icon-color icon-calendar"></i> 2015-01-01 / 2015-10-30
                                        </li>
                                    </ul>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="x_content">
                                    <div id="echart_peoplereach" style="height: 350px;"></div>
                                </div>
                            </div>
                    </div>                   
                  </div>

				</div>
                    <!--/span-->
			</div>
                <!-- content ends -->
            </div>
            <!--/#content.span10-->
        </div>
        <!--/fluid-row-->
        <hr>
        <div class="modal hide fade" id="myModalUT">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" id="btnCloseUTModel">×</button>
                <h3>UT Logging</h3>
            </div>
            <div class="modal-body">
                 <div class="row-fluid sortable">
				<div class="box span12">
					<div class="box-content">
						<form class="form-horizontal">
						  <fieldset>
							<legend>UT Data</legend>
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
						  </fieldset>
						</form>   

					</div>
				</div><!--/span-->

			</div><!--/row-->
            </div>
            <div class="modal-footer">
                <a href="#" class="btn" data-dismiss="modal">Close</a>
                <a href="#" class="btn btn-primary" id="btnSaveUILog">Save changes</a>
            </div>
        </div>

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
				</div><!--/span-->

			</div><!--/row-->

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
						<form class="form-horizontal" style="height:200px;">
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
				</div><!--/span-->

			</div><!--/row-->
            </div>
            <div class="modal-footer">
                <a href="#" class="btn" data-dismiss="modal">Close</a>
                <a href="#" class="btn btn-primary" id="btnSaveSE">Save changes</a>
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
    <script src="js/pagejs/tldr.js"></script>
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
    <!-- chart js -->
    <script src="js/chartjs/chart.min.js"></script>
     <!-- echart -->
    <script src="js/echart/echarts-all.js"></script>
    <script src="js/echart/green.js"></script>
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


</body>

</html>
