using System;
using System.Collections.Generic;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class BllUserInfo
    {
        DalUserInfo dui = new DalUserInfo();
        public void InsertUserInfo(UserInfo model)
        {
            dui.InsertUserInfo(model);
        }

        public UserInfo SelectUserInfo(string userName)
        {
            UserInfo mod = null;
            DataSet ds = dui.SelectUserPWByUserName(userName);
            DataTable dt = new DataTable();
            if(ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            if (dt.Rows.Count != 0)
            {
                DataRow dr = dt.Rows[0];
                mod = new UserInfo();
                mod.PassWord = Convert.ToString(dr["PassWord"]);
                mod.UserName = Convert.ToString(dr["UserName"]);
                mod.Phone = Convert.ToString(dr["Phone"]);
                mod.RoleId = Convert.ToInt32(dr["RoleId"]);
                mod.CreatedTime = Convert.ToDateTime(dr["CreatedTime"]);
                mod.LastLoginTime = Convert.ToDateTime(dr["LastLoginTime"]);
            }

            return mod;
        }

        public void UpdatePassWord(string passWord,string userName)
        {
            dui.UpdatePassWord(passWord, userName);
        }

        public void UpdateLastUerName(string lastUserName,int id)
        {
            dui.UpdateLastUserName(lastUserName, id);
        }
    }
}
