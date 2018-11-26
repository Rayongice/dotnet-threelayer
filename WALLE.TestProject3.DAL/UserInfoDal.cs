using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WALLE.TestProject3.Model;
using WALLE.TestProject.IDAL;

namespace WALLE.TestProject3.DAL
{
    public class UserInfoDal:IUserInfoDal
    {
        /// <summary>
        /// 返回一个数据列表
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetEntityList()
        {
            string sql = "select * from UserInfo";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text);
            List<UserInfo> list = null;
            if(da.Rows.Count > 0)
            {
                list = new List<UserInfo>();
                UserInfo userInfo = null;
                foreach(DataRow row in da.Rows)
                {
                    userInfo = new UserInfo();
                    LoadEntity(row, userInfo);
                    list.Add(userInfo);
                }
            }
            return list;
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="row"></param>
        /// <param name="userInfo"></param>

        public void LoadEntity(DataRow row, UserInfo userInfo)
        {
            userInfo.ID = Convert.ToInt32(row["ID"]);
            userInfo.UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : string.Empty;
            userInfo.UserPass = row["UserPass"] != DBNull.Value ? row["UserPass"].ToString() : string.Empty;
            userInfo.RegTime = Convert.ToDateTime(row["RegTime"]);
            userInfo.Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : string.Empty;

        }
        /// <summary>
        /// 返回一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfo GetEntityModel(int id)
        {
            string sql = "select * from UserInfo where ID=@ID";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new SqlParameter("@ID", id));
            UserInfo userInfo = null;
            if(da.Rows.Count > 0)
            {
                userInfo = new UserInfo();
                LoadEntity(da.Rows[0], userInfo);
            }
            return userInfo;
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public int DeleteEntityModel(int id)
        {
            string sql = "delete from UserINfo where ID=@ID";
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, new SqlParameter("@ID", id));
        }
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int InsertEntityModel(UserInfo userInfo)
        {
            string sql = "insert info UserInfo(UseName, UserPass, RegTime, Email values(@UserName, @UserPass,@RegTime, @Email)";
            SqlParameter[] pars =
            {
                new SqlParameter("@UserName", SqlDbType.NChar, 100),
                new SqlParameter("@UserPass", SqlDbType.NChar, 100),
                new SqlParameter("@RegTime", SqlDbType.DateTime),
                new SqlParameter("@Email", SqlDbType.NChar, 100)
            };
            pars[0].Value = userInfo.UserName;
            pars[1].Value = userInfo.UserPass;
            pars[2].Value = userInfo.RegTime;
            pars[3].Value = userInfo.Email;
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int UpdateEntityModel(UserInfo userInfo)
        {
            string sql = "update UserInfo set　UserName=@UserName, UserPass=@UserPass, RegTime=@RegTime, Email=@Email where ID = @ID";
            SqlParameter[] pars =
            {
                new SqlParameter("@UserName", SqlDbType.NChar, 100),
                new SqlParameter("@UserPass", SqlDbType.NChar, 100),
                new SqlParameter("@RegTime", SqlDbType.DateTime),
                new SqlParameter("@Email", SqlDbType.NChar, 100),
                new SqlParameter("@ID", SqlDbType.Int, 4)

            };
            pars[0].Value = userInfo.UserName;
            pars[1].Value = userInfo.UserPass;
            pars[2].Value = userInfo.RegTime;
            pars[3].Value = userInfo.Email;
            pars[4].Value = userInfo.ID;
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }
    }
}
