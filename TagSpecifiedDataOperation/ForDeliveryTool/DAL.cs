using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TagSpecifiedDataOperation.ForDeliveryTool
{
    public class DAL
    {
        public DataTable GetQuestionByThreadsStatus(string fromdate, string todate, string owner, string scenarioId, string status, string delivery)
        {
            string myalias = System.Web.HttpContext.Current.User.Identity.Name.Substring(System.Web.HttpContext.Current.User.Identity.Name.IndexOf("\\") + 1);
            #region Get threads via standard threads' status
            if (scenarioId.ToLower() != "azurealltags" && scenarioId.ToLower() != "azurestorageall" && scenarioId.ToLower() != "netonazureall" &&
                scenarioId.ToLower() != "azureserviceall" && scenarioId.ToLower() != "azuretoolsall" &&
                scenarioId.ToLower() != "opensourceall" &&
                scenarioId.ToLower() != "mobilityall" &&
                scenarioId.ToLower() != "vsalmall" &&
                scenarioId.ToLower() != "vsoall" &&
                scenarioId.ToLower() != "win10all" &&
                scenarioId.ToLower() != "uwpall" &&
                scenarioId.ToLower() != "o365all" &&
                scenarioId.ToLower() != "cordovaall" &&
                scenarioId.ToLower() != "hockeyall" &&
                scenarioId.ToLower() != "iotall" &&
                scenarioId.ToLower() != "msvsbuildall" &&
                scenarioId.ToLower() != "msbuild" &&
                scenarioId.ToLower() != "installation" &&
                scenarioId.ToLower() != "debugging" &&
                scenarioId.ToLower() != "version-git" &&
                scenarioId.ToLower() != "extension" &&
                scenarioId.ToLower() != "azuremobileservice" &&
                  scenarioId.ToLower() != "documentdb" &&
                   scenarioId.ToLower() != "servicebusall" &&
                   scenarioId.ToLower() != "storedev" &&
                scenarioId.ToLower() != "intellisense" &&
                scenarioId.ToLower() != "vsall" &&
                scenarioId.ToLower() != "uwpandwin10" &&
                scenarioId.ToLower() != "uwpwin10" &&
                scenarioId.ToLower() != "nuget" &&
                scenarioId.ToLower() != "devcenterall" &&
                scenarioId.ToLower() != "azurehybridlinuxall" &&
                scenarioId.ToLower() != "azureadall" &&
                  scenarioId.ToLower() != "uwpxamarinall" &&
                      scenarioId.ToLower() != "androidxamarinall" &&
                scenarioId.ToLower() != "azuresqlall" && 
                scenarioId.ToLower() != "csonazure" && 
                scenarioId.ToLower() != "all")
            {
                string[] tags = GetTagsFromSecnario(scenarioId);
                if (tags != null)
                {
                    SqlParameter[] parameters = {
                    new SqlParameter("@alias", SqlDbType.NVarChar,50),
                    new SqlParameter("@fromdate", SqlDbType.NVarChar,50),
                    new SqlParameter("@todate", SqlDbType.NVarChar,50),
                    new SqlParameter("@status", SqlDbType.NVarChar,50),
                      };
                    parameters[0].Value = owner.ToLower() == "all" ? "all" : myalias;
                    parameters[1].Value = new CommonOperation().DateTimetoUnixStamp(Convert.ToDateTime(fromdate));
                    parameters[2].Value = new CommonOperation().DateTimetoUnixStamp(Convert.ToDateTime(todate)) + 86400;
                    parameters[3].Value = "%" + status + "%";
                    return SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, GetSqlString(tags, owner, delivery, status, true), parameters);
                }
                else
                {
                    return null;
                }
            }
            #endregion
            else
            {

                DataTable dt = null;
                string[] tags = null;
                string sqlcommand = string.Empty;
                switch (scenarioId.ToLower())
                {

                    case "msvsbuildall":
                        dt = GetAllTagsByTech("msvsbuild");
                        break;
                    case "msbuild":
                        dt = GetTagsTableFromCategory("MSBuild");
                        break;
                    case "nuget":
                        dt = GetTagsTableFromCategory("Nuget");
                        break;
                    case "installation":
                        dt = GetTagsTableFromCategory("VS-Installation");
                        break;
                    case "servicebusall":
                        dt = GetTagsTableFromCategory("ServiceBus");
                        break;
                    case "debugging":
                        dt = GetTagsTableFromCategory("Debugging");
                        break;
                    case "storedev":
                        dt = GetTagsTableFromScenariosByWhere(" ScenarioName='windows-store-apps' or ScenarioName='windows-dev-center' ");
                        break;
                    case "version-git":
                        dt = GetTagsTableFromCategory("Git-Version-Control");
                        break;
                    case "extension":
                        dt = GetTagsTableFromCategory("VS-Extension");
                        break;
                    case "intellisense":
                        dt = GetTagsTableFromCategory("VS-Intelligence");
                        break;
                    case "opensourceall":
                        dt = GetTagsTableFromCategory("Azure");
                        break;
                    case "azureadall":
                        dt = GetTagsTableFromCategory("AzureAD");
                        break;
                    case "azurealltags":
                        dt = GetAllTagsByTech("azure");
                        break;
                    case "azurestorageall":
                        dt = GetTagsTableFromCategory("AzureStorage&Data");
                        break;
                    case "netonazureall":
                        dt = GetTagsTableFromCategory("NETonAzure");
                        break;
                    case "azureserviceall":
                        dt = GetTagsTableFromCategory("AzureServices");
                        break;
                    case "azuretoolsall":
                        dt = GetTagsTableFromCategory("AzureTools");
                        break;
                    case "csonazure":
                        dt = GetTagsTableFromCategory("C#OnAzure");
                        break;
                    case "azureresourcemanager":
                        dt = GetTagsTableFromCategory("AzureResourceManager");
                        break;
                    case "azuremobileservice":
                        dt = GetTagsTableFromCategory("AzureMobileService");
                        break;
                    case "azurexamarin":
                        dt = GetTagsTableFromCategory("XamarinAzure");
                        break;
                    case "azureruby":
                        dt = GetTagsTableFromCategory("Azure&Ruby");
                        break;
                    case "mobilityall":
                        dt = GetTagsTableFromCategory("Mobility");
                        break;
                    case "iotall":
                        dt = GetTagsTableFromCategory("WindowsIOT");
                        break;
                    case "vsalmall":
                        dt = GetTagsTableFromCategory("VSALM");
                        break;
                    case "vsoall":
                        dt = GetTagsTableFromCategory("VSO");
                        break;
                    case "win10all":
                        dt = GetTagsTableFromCategory("WIN10");
                        break;
                    case "uwpall":
                        dt = GetTagsTableFromCategory("UWP");
                        break;
                    case "uwpandwin10":
                        dt = GetAllTagsByTech("uwp&w10");
                        break;
                    case "uwpwin10":
                        dt = GetTagsTableFromCategory("UWPWin10");
                        break;
                    case "o365all":
                        dt = GetTagsTableFromCategory("O365");
                        break;
                    case "vsall":
                        dt = GetTagsTableFromScenariosByWhere(" Category='MSBuild' or Category='Nuget' or Category='VS-Installation' or Category='Debugging' or Category='Git-Version-Control' or Category='VS-Extension' or Category='VS-Intelligence'  ");
                        break;
                    case "cordovaall":
                        dt = GetTagsTableFromCategory("VSForCordova");
                        break;
                    case "hockeyall":
                        dt = GetTagsTableFromCategory("Hockey");
                        break;
                    case "devcenterall":
                        dt = GetTagsTableFromCategory("DevCenter");
                        break;
                    case "azurehybridlinuxall":
                        dt = GetTagsTableFromCategory("AzureHybridLinux");
                        break;
                    case "azuresqlall":
                        dt = GetTagsTableFromScenariosByWhere(" Category='SQLAzure' or Category='AzureMySQL' ");
                        break;
                    case "uwpxamarinall":
                        dt = GetTagsTableFromCategory("XamarinUWP");
                        break;
                    case "documentdb":
                        dt = GetTagsTableFromCategory("DocumentDB");
                        break;
                        
                    case "androidxamarinall":
                        dt = GetTagsTableFromCategory("XamarinAndroid");
                        break;
                    case "all":
                        dt = GetAllTagsTable();
                        break;
         
                }
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i > 0)
                        {
                            sqlcommand += " union ";
                        }
                        tags = dt.Rows[i]["Tags"].ToString().Split(';');
                        sqlcommand += GetSqlString(tags, owner, delivery, status, false);
                    }
                }
                SqlParameter[] parameters = {
                    new SqlParameter("@alias", SqlDbType.NVarChar,50),
                    new SqlParameter("@fromdate", SqlDbType.NVarChar,50),
                    new SqlParameter("@todate", SqlDbType.NVarChar,50),
                    new SqlParameter("@status", SqlDbType.NVarChar,50),
                      };
                parameters[0].Value = owner.ToLower() == "all" ? myalias : owner;
                parameters[1].Value = new CommonOperation().DateTimetoUnixStamp(Convert.ToDateTime(fromdate));
                parameters[2].Value = new CommonOperation().DateTimetoUnixStamp(Convert.ToDateTime(todate)) + 86400;
                parameters[3].Value = "%" + status + "%";
                if (sqlcommand != string.Empty)
                {
                    sqlcommand += " order by a.creation_date desc ";
                    return SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, sqlcommand, parameters);
                }
                else
                {
                    return null;
                }
            }
        }
        public string GetSqlString(string[] tags, string owner, string delivery, string status, bool IsNotInLoop)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.question_id, a.status, a.title, a.link, a.creation_date, a.last_activity_date, a.IRT, a.tags, b.support_alias from (  ");
            strSql.Append(" select * from Question where question_id in (   ");
            strSql.Append(" select question_id from Question_TagsRelation where ");
            int orcount = 0;
            foreach (var item in tags)
            {
                if (orcount >= 1)
                {
                    strSql.Append(" or ");
                }
                strSql.Append(" tagname ='" + HttpUtility.UrlDecode(item) + "'");
                orcount++;
            }
            strSql.ToString().Remove(strSql.ToString().LastIndexOf("or"));
            strSql.Append(" group by question_id having count(*)=" + tags.Count() + " ))a left join ");
            strSql.Append(" (select * from QuestionOwnership)b on a.question_id = b.question_id ");
            if (owner.ToLower() != "all")
            {
                if (owner.ToLower() != "!null")
                {
                    strSql.Append(" inner join (select * from SupportEngineers where alias=@alias)c on b.support_alias = c.alias ");
                }
                else
                {
                    strSql.Append(" inner join (select * from SupportEngineers)c on b.support_alias = c.alias ");
                }
            }
            else
            {
                strSql.Append(" left join (select * from SupportEngineers)c on b.support_alias = c.alias ");
            }

            switch (delivery)
            {
                case "0":
                    if (status.ToLower() != "all")
                    {
                        strSql.Append(" where a.creation_date >= @fromdate and a.creation_date <= @todate and [IRT] = 'N/A' and status like @status ");
                    }

                    else
                    {
                        strSql.Append(" where a.creation_date >= @fromdate and a.creation_date <= @todate and [IRT] = 'N/A' ");
                    }
                    break;
                case "1":
                    strSql.Append(" inner join (select question_id from Answers where owner_id in (select stackoverflow_user_id from SupportEngineers where alias=@alias ) group by question_id having count(*) > 0 ");
                    // Add Commentted Recored
                    strSql.Append(" union select question_id from Comments where owner_id in (select stackoverflow_user_id from SupportEngineers where alias=@alias ) group by question_id having count(*) > 0)d on a.question_id = d.question_id ");
                    if (status.ToLower() != "all")
                    {
                        strSql.Append(" where a.creation_date >= @fromdate and a.creation_date <= @todate and status like @status ");
                    }

                    else
                    {
                        strSql.Append(" where a.creation_date >= @fromdate and a.creation_date <= @todate ");
                    }


                    break;
                case "2":
                    strSql.Append(" inner join (select question_id from Answers where owner_id in (select stackoverflow_user_id from SupportEngineers where alias=@alias and is_accepted = 'true' ) group by question_id having count(*) > 0 )d on a.question_id = d.question_id ");
                    if (status.ToLower() != "all")
                    {
                        strSql.Append(" where a.creation_date >= @fromdate and a.creation_date <= @todate and status like @status ");
                    }
                    else
                    {
                        strSql.Append(" where a.creation_date >= @fromdate and a.creation_date <= @todate ");
                    }
                    break;
                case "3":
                    if (status.ToLower() != "all")
                    {
                        strSql.Append(" where a.creation_date >= @fromdate and a.creation_date <= @todate and status like @status ");
                    }

                    else
                    {
                        strSql.Append(" where a.creation_date >= @fromdate and a.creation_date <= @todate ");
                    }
                    break;
            }
            if (IsNotInLoop)
            {
                strSql.Append(" order by a.creation_date desc ");
            }
            return strSql.ToString();
        }
        public string GetRealstatusScope(string StatusScope)
        {
            string outputString = string.Empty;
            switch (StatusScope)
            {
                case "0":
                    outputString = "New Thread";
                    break;
                case "1":
                    outputString = "Waiting On Customer";
                    break;
                case "2":
                    outputString = "Answered";
                    break;
                case "3":
                    outputString = "Re-Open/Follow";
                    break;
            }
            return outputString;
        }
        public string[] GetTagsFromSecnario(string scenarioId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Tags from Scenarios where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4),
                      };
            parameters[0].Value = scenarioId;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Tags"].ToString().Split(';');
            }
            else
            {
                return null;
            }
        }

        public DataTable GetTagsTableFromCategory(string category)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Tags from Scenarios where Category=@Category");
            SqlParameter[] parameters = {
                    new SqlParameter("@Category", SqlDbType.NVarChar,50),
                      };
            parameters[0].Value = category;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable GetTagsTableFromScenariosByWhere(string category)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Tags from Scenarios where " + category);
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), null);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        public DataTable GetLaborsListByQuestionID(string question_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select question_id,alias,UT,LogDate,UTComments from UTLogs where question_id='" + question_id + "'");
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), null);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable GetQRByQuetionID(string question_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select question_id,alias,create_by,create_time,comment,status,QR_id,points from QualityReview where question_id='" + question_id + "'");
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), null);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable GetSupportTeam()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Team_name from [SupportTeams]");
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), null);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable QualityReview_eng(string question_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select question_id,alias,create_time,eng_comment,action from QualityReview_by_eng where question_id='" + question_id + "'");
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), null);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        public DataTable GetCateIDFromCategoryName(string category)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id from Scenarios where Category=@Category");
            SqlParameter[] parameters = {
                    new SqlParameter("@Category", SqlDbType.NVarChar,50),
                      };
            parameters[0].Value = category;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        string SP_ScenarioMetrics = "[dbo].[SP_ScenarioMetrics]";
        /// <summary>
        /// get Metrics By date and cateIds
        /// </summary>
        /// <param name="fromdate"></param>
        /// <param name="todate"></param>
        /// <param name="cateIds"></param>
        /// <param name="Scope"></param>
        /// <returns></returns>
        public DataTable GetMetricsBydata(string fromdate, string todate, string cateIds, string Scope)
        {
            SqlParameter[] parameters =
                {
                new SqlParameter("@ids",cateIds),
                new SqlParameter("@startdate",Convert.ToDateTime(fromdate).ToShortDateString()),
                new SqlParameter("@enddate",Convert.ToDateTime(todate).ToShortDateString()),
                new SqlParameter("@scope",Scope)
            };

            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.StoredProcedure, SP_ScenarioMetrics, parameters);
            if (dt.Rows.Count > 0)
            {
                return dt;

            }
            else
            {
                return null;
            }

        }
        public DataTable GetAllTagsTable()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Tags from Scenarios");
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), null);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        public DataTable GetAllTagsByTech(string tech)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Tags from Scenarios");
            switch (tech)
            {
                case "azure":
                    strSql.Append(" where Category=N'Azure' or " +

                        "Category=N'AzureTools' or Category=N'AzureServices' "
                        + "or Category=N'AzureStorage&Data' "
                        + "or Category=N'DocumentDB' or Category=N'NETonAzure' "
                        + "or Category=N'AzureAD' or Category=N'ServiceBus' "
                        + "or Category=N'AzureResourceManager' or Category=N'AzureMobileService' "
                        + "or Category=N'C#OnAzure' or Category=N'XamarinAzure' or Category=N'Azure&Ruby'");

                    break;
                case "msvsbuild":
                    strSql.Append(" where Category=N'MSBuild' or Category=N'Nuget' or Category=N'VS-Installation' or Category=N'Debugging' or Category=N'Git-Version-Control' or Category=N'VS-Extension' or Category=N'VS-Intelligence'");
                    break;
                case "uwp&w10":
                    strSql.Append(" where Category=N'UWP' or Category=N'UWPWin10'");
                    break;
                default:
                    break;
            }

            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), null);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        public bool IsSupport(string alias)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SupportEngineers where alias=@alias");
            SqlParameter[] parameters = {
                    new SqlParameter("@alias", SqlDbType.NVarChar,50),
                      };
            parameters[0].Value = alias;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetThreadOwnerByQeusionID(string question_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from ");
            strSql.Append(" (select * from Question where question_id=@question_id)a inner join ");
            strSql.Append(" (select * from QuestionOwnership)b on a.question_id = b.question_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@question_id", SqlDbType.NVarChar,50),
                      };
            parameters[0].Value = question_id;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        public void LockThread(string question_id, string alias)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into QuestionOwnership (question_id, support_alias) values (@question_id, @support_alias) ");
            SqlParameter[] parameters = {
                    new SqlParameter("@question_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@support_alias", SqlDbType.NVarChar,50),
                      };
            parameters[0].Value = question_id;
            parameters[1].Value = alias;
            SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
        }

        public void UnlockThread(string question_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from QuestionOwnership where question_id = @question_id");
            SqlParameter[] parameters = {
                    new SqlParameter("@question_id", SqlDbType.NVarChar,50),
                      };
            parameters[0].Value = question_id;
            SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
        }

        public void SetThreadStatus(string status, string question_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update question set status = @status where question_id= @question_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@question_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@status", SqlDbType.NVarChar,50),
                      };
            parameters[0].Value = question_id;
            parameters[1].Value = status;
            SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
        }

        public string GetMyProfile(string alias)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select stackoverflow_user_id from SupportEngineers where alias=@alias");
            SqlParameter[] parameters = {
                    new SqlParameter("@alias", SqlDbType.NVarChar,50),
                      };
            parameters[0].Value = alias;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["stackoverflow_user_id"].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public void UpdateMyProfile(string alias, string sofID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update SupportEngineers set stackoverflow_user_id = @stackoverflow_user_id where alias= @alias ");
            SqlParameter[] parameters = {
                    new SqlParameter("@alias", SqlDbType.NVarChar,50),
                    new SqlParameter("@stackoverflow_user_id", SqlDbType.NVarChar,50),
                      };
            parameters[0].Value = alias;
            parameters[1].Value = sofID;
            SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
        }

        public void AddMyProfile(string alias, string sofID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into SupportEngineers (alias, stackoverflow_user_id) values (@alias, @stackoverflow_user_id) ");
            SqlParameter[] parameters = {
                    new SqlParameter("@alias", SqlDbType.NVarChar,50),
                    new SqlParameter("@stackoverflow_user_id", SqlDbType.NVarChar,50),
                      };
            parameters[0].Value = alias;
            parameters[1].Value = sofID;
            SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
        }

        public DataTable GetAllScenarios()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from [Scenarios] ");
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), null);
            if (dt.Rows.Count > 0)
            {
                //IEnumerator<InternalDataCollectionBase> lidc= dt.Columns.GetEnumerator();
                //DataColumnCollection
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    System.Diagnostics.Debug.WriteLine(dt.Columns[i].ColumnName);
                }
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable GetSupportEngList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from [SupportEngineers] ");
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), null);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public int GetUTDataByQuestionID(string question_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  SUM(UT) as total from UTLogs where question_id=@question_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@question_id", SqlDbType.NVarChar,50),
                      };
            parameters[0].Value = question_id;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows[0]["total"] != DBNull.Value)
            {
                return Convert.ToInt32(dt.Rows[0]["total"]);
            }
            else
            {
                return 0;
            }
        }
        public void AddUTData(string question_id, string alias, int UT, string UTComments, string LogDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into UTLogs (GUID, question_id, alias, UT, LogDate, UTComments) values (@GUID, @question_id, @alias, @UT, @LogDate, @UTComments) ");
            SqlParameter[] parameters = {
                    new SqlParameter("@GUID", SqlDbType.NVarChar,50),
                    new SqlParameter("@question_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@alias", SqlDbType.NVarChar,50),
                    new SqlParameter("@UT", SqlDbType.Int,4),
                    new SqlParameter("@LogDate", SqlDbType.NVarChar,50),
                    new SqlParameter("@UTComments", SqlDbType.Text),
                      };
            parameters[0].Value = Guid.NewGuid().ToString();
            parameters[1].Value = question_id;
            parameters[2].Value = alias;
            parameters[3].Value = UT;
            parameters[4].Value = LogDate;
            parameters[5].Value = UTComments;
            SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
        }

        public void UpdateCustomerComments(string question_id, string alias, int status, string cusomercomments)
        {
            SqlParameter[] parameters = {

                    new SqlParameter("@question_id", question_id),
                    new SqlParameter("@alias", alias),
                    new SqlParameter("@cusomercomments",cusomercomments),
                    new SqlParameter("@tatus", status),
                      }; //SP_UpdateCustomerComments
            SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.StoredProcedure, "[dbo].[SP_UpdateCustomerComments]", parameters);
        }

        public string GetCustomerComments(string question_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select cusomercomments from LogCustomerComment where question_id=@question_id and status=1 ");
            SqlParameter[] parameters = {

                    new SqlParameter("@question_id", SqlDbType.NVarChar,50),

                      };

            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["cusomercomments"].ToString();
            }
            else
            {
                return string.Empty;
            }
        }



        public string GetThreadBodyByQuestionID(string question_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  body from Question where question_id=@question_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@question_id", SqlDbType.NVarChar,50),
                      };
            parameters[0].Value = question_id;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["body"].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        public void SetQualityReview(string question_id, int points, string comment, string create_time, string create_by, string isfixed, string alias, string isnotified, string status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into QualityReview (QR_id,question_id, points, comment, create_time, create_by, isfixed, alias, isnotified, status) values (@QR_id, @question_id, @points, @comment, @create_time, @create_by, @isfixed, @alias, @isnotified, @status) ");
            SqlParameter[] parameters = {
                    new SqlParameter("@QR_id",SqlDbType.NVarChar,50),
                    new SqlParameter("@question_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@points", SqlDbType.Int),
                    new SqlParameter("@comment", SqlDbType.Text),
                    new SqlParameter("@create_time", SqlDbType.NVarChar,50),
                    new SqlParameter("@create_by", SqlDbType.NVarChar,50),
                    new SqlParameter("@isfixed", SqlDbType.NVarChar,10),
                    new SqlParameter("@alias", SqlDbType.NVarChar,50),
                    new SqlParameter("@isnotified", SqlDbType.NVarChar,10),
                    new SqlParameter("@status", SqlDbType.NVarChar,10),
                      };
            parameters[0].Value = Guid.NewGuid().ToString();
            parameters[1].Value = question_id;
            parameters[2].Value = points;
            parameters[3].Value = comment;
            parameters[4].Value = create_time;
            parameters[5].Value = create_by;
            parameters[6].Value = isfixed;
            parameters[7].Value = alias;
            parameters[8].Value = isnotified;
            parameters[9].Value = status;
            SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
        }
        public void SetVirtualTeam(string question_id, string team, string assigned_by, string assign_time)        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into VirtualTeam (Rec_id,question_id, team_name,assigned_by, assign_time) values (@Rec_id,@question_id, @team,@assigned_by,@assign_time)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Rec_id",SqlDbType.NVarChar,50),
                    new SqlParameter("@question_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@team", SqlDbType.NVarChar,50),
                    new SqlParameter("@assigned_by", SqlDbType.NVarChar,50),
                    new SqlParameter("@assign_time", SqlDbType.NVarChar,50),
                      };
            parameters[0].Value = Guid.NewGuid().ToString();
            parameters[1].Value = question_id;
            parameters[2].Value = team;
            parameters[3].Value = assigned_by;
            parameters[4].Value = assign_time;


            SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
        }
        public void SetupdatedVirtualTeam(string question_id, string team)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update VirtualTeam set team_name = @team where question_id = @question_id ");
            
            SqlParameter[] parameters = {
                    new SqlParameter("@question_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@team", SqlDbType.NVarChar,50),

                      };
            parameters[0].Value = question_id;
            parameters[1].Value = team;


            SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
        }
        public DataTable GetVirtualTeam(string question_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 question_id,team_name from VirtualTeam where question_id='" + question_id + "'order by assign_time desc");
            
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), null);
            if (dt.Rows.Count > 0)
            {
                return dt;
                //return dt.Rows[0]["question_id"].ToString();
                //return dt.Rows[0]["team_name"].ToString();
            }
            else
            {
                return null;
            }
        }
      
        public void SetQualityReview_eng(string question_id, string QR_id, string alias, string create_time, string eng_comment, string action)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into QualityReview_by_eng (QR_eng_id,question_id,QR_id,alias,create_time,eng_comment,action) values (@QR_eng_id,@question_id, @QR_id, @alias, @create_time, @eng_comment, @action) ");
            SqlParameter[] parameters = {
                    new SqlParameter("@QR_eng_id",SqlDbType.NVarChar,50),
                    new SqlParameter("@question_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@QR_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@alias", SqlDbType.NVarChar,50),
                    new SqlParameter("@create_time", SqlDbType.NVarChar,50),
                    new SqlParameter("@eng_comment", SqlDbType.Text),
                    new SqlParameter("@action", SqlDbType.NVarChar,50),
                    
                      };
            parameters[0].Value = Guid.NewGuid().ToString();
            parameters[1].Value = question_id;
            parameters[2].Value = QR_id;
            parameters[3].Value = alias;
            parameters[4].Value = create_time;
            parameters[5].Value = eng_comment;
            parameters[6].Value = action;
          
            SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
        }
    }
}
