using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public class UserManagement
    {
        public List<UserInfo> UserShow()
        {
            string str = $"select UserInfo.UserId,UserInfo.UserName,UserInfo.UserNickname,UserInfo.Pwd,UserInfo.Email,UserInfo.Tel,UserInfo.Sex,Dept.DeptName,UserInfo.IsOK,UserInfo.CreateDate,UserInfo.ModifiedDate,RoleInfo.RoleName from Dept join UserInfo on Dept.DeptId = UserInfo.DeptId join RoleInfo on UserInfo.RoleId = RoleInfo.RoleId";
            return DBHelper.GetToList<UserInfo>(str);
        }

        public int UptUser(UserInfo u)
        {
            string str = $"Update UserInfo set IsOK=0 where UserId='{u.UserId}' and UserName<>'zk'";
            return DBHelper.ExecuteNonQuery(str);
        }

        public int UptUser1(UserInfo u)
        {
            string str = $"Update UserInfo set IsOK=1 where UserId='{u.UserId}'";
            return DBHelper.ExecuteNonQuery(str);
        }

        public List<Dept> DeptShow()
        {
            string str = $"select * from Dept";
            return DBHelper.GetToList<Dept>(str);
        }

        public int UptDept(Dept d)
        {
            string str = $"Update Dept set IsOK=0 where DeptId='{d.DeptId}'";
            return DBHelper.ExecuteNonQuery(str);
        }

        public int UptDept1(Dept d)
        {
            string str = $"Update Dept set IsOK=1 where DeptId='{d.DeptId}'";
            return DBHelper.ExecuteNonQuery(str);
        }
    }
}
