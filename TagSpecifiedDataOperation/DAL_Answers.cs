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
    public class DAL_Answers
    {
        public void UpdateAnswer(Answer[] answers)
        {
            foreach (var answer in answers)
            {
                if (!IfAnswerExist(answer.Answer_id.ToString()))
                {
                    AddNewAnswer(answer);
                }
                else
                {
                    EditAnswer(answer);
                }
            }
        }

        public int AddNewAnswer(Answer answer)
        {
            new DAL_Users().UpdateUser(answer.Owner);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Answers (answer_id, question_id, creation_date, last_edit_date, last_activity_date, score, is_accepted, owner_id) ");
            strSql.Append(" values (@answer_id, @question_id, @creation_date, @last_edit_date, @last_activity_date, @score, @is_accepted, @owner_id)");
            SqlParameter[] parameters = {
					new SqlParameter("@answer_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@question_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@creation_date", SqlDbType.NVarChar,50),
                    new SqlParameter("@last_edit_date", SqlDbType.NVarChar,50),
                    new SqlParameter("@last_activity_date", SqlDbType.NVarChar,50),
                    new SqlParameter("@score", SqlDbType.NVarChar,50),
                    new SqlParameter("@is_accepted", SqlDbType.Int,4),
                     new SqlParameter("@owner_id",  SqlDbType.NVarChar,50),
                                        };
            parameters[0].Value = answer.Answer_id;
            parameters[1].Value = answer.Question_id;
            parameters[2].Value = answer.Creation_date;
            parameters[3].Value = answer.Last_edit_date;
            parameters[4].Value = answer.Last_activity_date;
            parameters[5].Value = answer.Score;
            parameters[6].Value = answer.Is_accepted;
            parameters[7].Value = answer.Owner.User_id;

            return SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);

        }

        public int EditAnswer(Answer answer)
        {
            new DAL_Users().UpdateUser(answer.Owner);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Answers set score = @score, is_accepted = @is_accepted, ");
            strSql.Append(" last_edit_date= @last_edit_date, last_activity_date = @last_activity_date where answer_id = @answer_id");
            SqlParameter[] parameters = {
					new SqlParameter("@score", SqlDbType.NVarChar,50),
                    new SqlParameter("@is_accepted", SqlDbType.NVarChar,50),
                    new SqlParameter("@last_edit_date", SqlDbType.NVarChar,50),
                    new SqlParameter("@last_activity_date", SqlDbType.NVarChar,50),
                    new SqlParameter("@answer_id", SqlDbType.NVarChar,50),
                                        };
            parameters[0].Value = answer.Score;
            parameters[1].Value = answer.Is_accepted;
            parameters[2].Value = answer.Last_edit_date;
            parameters[3].Value = answer.Last_activity_date;
            parameters[4].Value = answer.Answer_id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
        }

        public bool IfAnswerExist(string answer_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select answer_id from [Answers] where answer_id=@answer_id");
            SqlParameter[] parameters = {
					new SqlParameter("@answer_id", SqlDbType.NVarChar,50),
                                        };
            parameters[0].Value = answer_id;
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
