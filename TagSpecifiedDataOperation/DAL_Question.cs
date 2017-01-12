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
    public class DAL_Question
    {
        public bool IfQuestionExist(Question question)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select question_id from [Question] where question_id=@question_id");
            SqlParameter[] parameters = {
					new SqlParameter("@question_id", SqlDbType.NVarChar,100),
                                        };
            parameters[0].Value = question.Question_id;
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
        public bool IfQuestionNeedUpdate(Question question)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from [Question] where question_id=@question_id");
            SqlParameter[] parameters = {
					new SqlParameter("@question_id", SqlDbType.NVarChar,50),
                                        };
            parameters[0].Value = question.Question_id;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
            long recoredUpdateDate = Convert.ToInt32(dt.Rows[0]["record_update_date"]);
            if (recoredUpdateDate < question.Last_activity_date)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int UpdateQuestion(Question question)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Question] set title=@title, link=@link, body=@body, last_edit_date=@last_edit_date, ");
            strSql.Append(" creation_date=@creation_date, last_activity_date=@last_activity_date, record_update_date=@record_update_date, score=@score, ");
            strSql.Append(" answer_count=@answer_count, accepted_answer_id=@accepted_answer_id, up_vote_count=@up_vote_count, down_vote_count=@down_vote_count, ");
            strSql.Append(" favorite_count=@favorite_count, view_count=@view_count, is_answered=@is_answered, owner_id=@owner_id, tags=@tags where question_id=@question_id");
            SqlParameter[] parameters = {
					new SqlParameter("@question_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@title", SqlDbType.NVarChar,50),
                    new SqlParameter("@link", SqlDbType.NVarChar,50),
                    new SqlParameter("@body", SqlDbType.Text),
                    new SqlParameter("@last_edit_date", SqlDbType.NVarChar,50),
                    new SqlParameter("@creation_date", SqlDbType.NVarChar,50),
                    new SqlParameter("@last_activity_date", SqlDbType.NVarChar,50),
                    new SqlParameter("@record_update_date", SqlDbType.NVarChar,50),
                    new SqlParameter("@score", SqlDbType.Int,4),
                    new SqlParameter("@answer_count", SqlDbType.Int,4),
                    new SqlParameter("@accepted_answer_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@up_vote_count", SqlDbType.Int,4),
                    new SqlParameter("@down_vote_count", SqlDbType.Int,4),
                    new SqlParameter("@favorite_count", SqlDbType.Int,4),
                    new SqlParameter("@view_count", SqlDbType.Int,4),
                    new SqlParameter("@is_answered", SqlDbType.NVarChar,50),
                    new SqlParameter("@owner_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@tags", SqlDbType.NVarChar,50),
                                        };
            parameters[0].Value = question.Question_id;
            parameters[1].Value = question.Title;
            parameters[2].Value = question.Link;
            parameters[3].Value = question.Body;
            parameters[4].Value = question.Last_edit_date;
            parameters[5].Value = question.Creation_date;
            parameters[6].Value = question.Last_activity_date;
            parameters[7].Value = new CommonOperation().DateTimetoUnixStamp(System.DateTime.Now);
            parameters[8].Value = question.Score;
            parameters[9].Value = question.Answer_count;
            parameters[10].Value = question.Accepted_answer_id;
            parameters[11].Value = question.Up_vote_count;
            parameters[12].Value = question.Down_vote_count;
            parameters[13].Value = question.Favorite_count;
            parameters[14].Value = question.View_count;
            parameters[15].Value = question.Is_answered;
            parameters[16].Value = question.Owner.User_id;
            parameters[17].Value = getAllTagsFormCollection(question.Tags);
            return SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
        }
        public int AddNewQuestion(Question question)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [Question] (question_id, title, link, body, last_edit_date, creation_date, last_activity_date, record_update_date, score, answer_count, accepted_answer_id, up_vote_count, down_vote_count, favorite_count, view_count, is_answered, owner_id, tags)");
            strSql.Append(" values (@question_id, @title, @link, @body, @last_edit_date, @creation_date, @last_activity_date, @record_update_date, @score, @answer_count, @accepted_answer_id, @up_vote_count, @down_vote_count, @favorite_count, @view_count, @is_answered, @owner_id, @tags)");
            SqlParameter[] parameters = {
					new SqlParameter("@question_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@title", SqlDbType.NVarChar,50),
                    new SqlParameter("@link", SqlDbType.NVarChar,50),
                    new SqlParameter("@body", SqlDbType.Text),
                    new SqlParameter("@last_edit_date", SqlDbType.NVarChar,50),
                    new SqlParameter("@creation_date", SqlDbType.NVarChar,50),
                    new SqlParameter("@last_activity_date", SqlDbType.NVarChar,50),
                    new SqlParameter("@record_update_date", SqlDbType.NVarChar,50),
                    new SqlParameter("@score", SqlDbType.Int,4),
                    new SqlParameter("@answer_count", SqlDbType.Int,4),
                    new SqlParameter("@accepted_answer_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@up_vote_count", SqlDbType.Int,4),
                    new SqlParameter("@down_vote_count", SqlDbType.Int,4),
                    new SqlParameter("@favorite_count", SqlDbType.Int,4),
                    new SqlParameter("@view_count", SqlDbType.Int,4),
                    new SqlParameter("@is_answered", SqlDbType.NVarChar,50),
                    new SqlParameter("@owner_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@tags", SqlDbType.NVarChar,50),
                                        };
            parameters[0].Value = question.Question_id;
            parameters[1].Value = question.Title;
            parameters[2].Value = question.Link;
            parameters[3].Value = question.Body;
            parameters[4].Value = question.Last_edit_date;
            parameters[5].Value = question.Creation_date;
            parameters[6].Value = question.Last_activity_date;
            parameters[7].Value = new CommonOperation().DateTimetoUnixStamp(System.DateTime.Now);
            parameters[8].Value = question.Score;
            parameters[9].Value = question.Answer_count;
            parameters[10].Value = question.Accepted_answer_id;
            parameters[11].Value = question.Up_vote_count;
            parameters[12].Value = question.Down_vote_count;
            parameters[13].Value = question.Favorite_count;
            parameters[14].Value = question.View_count;
            parameters[15].Value = question.Is_answered;
            parameters[16].Value = question.Owner.User_id;
            parameters[17].Value = getAllTagsFormCollection(question.Tags);
            return SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
        }

        private string getAllTagsFormCollection(string[] tags)
        {
            if (tags != null && tags.Count() != 0)
            {
                string strtags = string.Empty;
                for (int co = 0; co < tags.Count(); co++)
                {
                    strtags += tags[co] + ";";
                }
                strtags = strtags.Remove(strtags.LastIndexOf(';'));
                return strtags;
            }
            return string.Empty;
        }
    }
}
