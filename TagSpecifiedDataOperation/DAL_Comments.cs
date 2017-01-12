using StackModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagSpecifiedDataOperation
{
    public class DAL_Comments
    {
        public void UpdateComment(Comments[] comments)
        {
            foreach (var comment in comments)
            {

                if (!IfCommentExist(comment.Comment_id.ToString()))
                {
                    AddNewComment(comment);
                }
                else
                {
                    EditComment(comment);
                }
            }
        }

        public int AddNewComment(Comments comment)
        {
            new DAL_Users().UpdateUser(comment.Owner);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Comments (comment_id, question_id, owner_id, score, creation_date) ");
            strSql.Append(" values (@comment_id, @question_id, @owner_id, @score, @creation_date)");
            SqlParameter[] parameters = {
					new SqlParameter("@comment_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@question_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@owner_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@score", SqlDbType.Int,4),
                    new SqlParameter("@creation_date", SqlDbType.NVarChar,50),
                                        };
            parameters[0].Value = comment.Comment_id;
            parameters[1].Value = comment.Post_id;
            parameters[2].Value = comment.Owner.User_id;
            parameters[3].Value = comment.Score;
            parameters[4].Value = comment.Creation_date;

            return SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
        }

        public int EditComment(Comments comment)
        {
            new DAL_Users().UpdateUser(comment.Owner);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Comments set score = @score ");
            strSql.Append("  where comment_id = @comment_id");
            SqlParameter[] parameters = {
					new SqlParameter("@score", SqlDbType.NVarChar,50),
                    new SqlParameter("@comment_id", SqlDbType.NVarChar,50),
                                        };
            parameters[0].Value = comment.Score;
            parameters[1].Value = comment.Comment_id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
        }

        public bool IfCommentExist(string comment_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select comment_id from [Comments] where comment_id=@comment_id");
            SqlParameter[] parameters = {
					new SqlParameter("@comment_id", SqlDbType.NVarChar,50),
                                        };
            parameters[0].Value = comment_id;
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
