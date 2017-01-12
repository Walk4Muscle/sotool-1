using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagSpecifiedDataOperation
{
    public class DAL_Tags
    {
        public void UpdateTags(string[] tags)
        {
            for (int co = 0; co < tags.Count(); co++)
            {
                if (!IfTagsExist(tags[co]))
                {
                    AddNewTags(tags[co]);
                }


            }
            
        }
        public int AddNewTags(string tagname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tags (tagname) values (@tagname)");
            SqlParameter[] parameters = {
					new SqlParameter("@tagname", SqlDbType.NVarChar,50),
                                        };
            parameters[0].Value = tagname;
            return SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
        }

        public void AddTagQuestionRelationShip(string[] tags, string question_id)
        {
            for (int co = 0; co < tags.Count(); co++)
            {
                if (!IfRelationExist(tags[co],question_id))
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into Question_TagsRelation (tagname, question_id) values (@tagname, @question_id)");
                    SqlParameter[] parameters = {
					new SqlParameter("@tagname", SqlDbType.NVarChar,50),
                    new SqlParameter("@question_id", SqlDbType.NVarChar,50),
                                        };
                    parameters[0].Value = tags[co];
                    parameters[1].Value = question_id;
                    SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
                }
            }
        }

        public bool IfTagsExist(string tagname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select tagname from [Tags] where tagname=@tagname");
            SqlParameter[] parameters = {
					new SqlParameter("@tagname", SqlDbType.NVarChar,100),
                                        };
            parameters[0].Value = tagname;
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
        public bool IfRelationExist(string tagname, string question_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select tagname from [Question_TagsRelation] where tagname=@tagname and question_id=@question_id");
            SqlParameter[] parameters = {
					new SqlParameter("@tagname", SqlDbType.NVarChar,50),
                    new SqlParameter("@question_id", SqlDbType.NVarChar,50),
                                        };
            parameters[0].Value = tagname;
            parameters[1].Value = question_id;
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
    }
}
