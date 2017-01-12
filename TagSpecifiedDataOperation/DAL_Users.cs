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
    public class DAL_Users
    {
        public void UpdateUser(User user)
        {
            if (!IfUserExist(user.User_id.ToString()))
            {
                AddNewUser(user);
            }
            else
            {
                EditUser(user);
            }
        }

        public int AddNewUser(User user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SOFUsers (user_id, reputation, user_type, profile_image, display_name, link, is_MSDN_support, record_update_date) ");
            strSql.Append(" values (@user_id, @reputation, @user_type, @profile_image, @display_name, @link, @is_MSDN_support, @record_update_date)");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@reputation", SqlDbType.NVarChar,50),
                    new SqlParameter("@user_type", SqlDbType.NVarChar,50),
                    new SqlParameter("@profile_image", SqlDbType.NVarChar,50),
                    new SqlParameter("@display_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@link", SqlDbType.NVarChar,50),
                    new SqlParameter("@is_MSDN_support", SqlDbType.Int,4),
                    new SqlParameter("@record_update_date", SqlDbType.NVarChar,50),
                                        };
            parameters[0].Value = user.User_id;
            parameters[1].Value = user.Reputation;
            parameters[2].Value = user.User_Type;
            parameters[3].Value = user.Profile_image;
            parameters[4].Value = user.Display_name;
            parameters[5].Value = user.Link;
            parameters[6].Value = 0;
            parameters[7].Value = new CommonOperation().DateTimetoUnixStamp(System.DateTime.Now); 

            return SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
        }

        public int EditUser(User user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SOFUsers set reputation = @reputation, user_type = @user_type, ");
            strSql.Append(" profile_image = @profile_image, display_name= @display_name, link = @link, record_update_date =@record_update_date where user_id = @user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@reputation", SqlDbType.NVarChar,50),
                    new SqlParameter("@user_type", SqlDbType.NVarChar,50),
                    new SqlParameter("@profile_image", SqlDbType.NVarChar,50),
                    new SqlParameter("@display_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@link", SqlDbType.NVarChar,50),
                    new SqlParameter("@record_update_date", SqlDbType.NVarChar,50),
                                        };
            parameters[0].Value = user.User_id;
            parameters[1].Value = user.Reputation;
            parameters[2].Value = user.User_Type;
            parameters[3].Value = user.Profile_image;
            parameters[4].Value = user.Display_name;
            parameters[5].Value = user.Link;
            parameters[6].Value = new CommonOperation().DateTimetoUnixStamp(System.DateTime.Now);

            return SqlHelper.ExecuteNonQuery(SqlHelper.strConn, CommandType.Text, strSql.ToString(), parameters);
        }

        public bool IfUserExist(string user_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select user_id from [SOFUsers] where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.NVarChar,50),
                                        };
            parameters[0].Value = user_id;
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
