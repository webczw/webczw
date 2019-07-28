using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webczw.DBUtil;
using webczw.Models;

namespace webczw.DAL
{
    public class UserService
    {
        public List<UserModels> findUserList(UserModels queryUserModels) {
            List<UserModels> userModelsList = new List<UserModels>();
            String sql = "SELECT Id,Email,PasswordHash,PhoneNumber,UserName FROM AspNetUsers where Id=@Id and UserName=@UserName";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@Id",queryUserModels.Id),
                new SqlParameter("@UserName", queryUserModels.UserName)
            };
            SqlDataReader objReader = SqlHelper.getReader(sql, param);
            while (objReader.Read())
            {
                UserModels userModels = new UserModels();
                userModels.Id = Convert.ToString(objReader["Id"]);
                userModels.UserName = Convert.ToString(objReader["UserName"]);
                userModels.Email = Convert.ToString(objReader["Email"]);
                userModels.PasswordHash = Convert.ToString(objReader["PasswordHash"]);
                userModels.PhoneNumber = Convert.ToString(objReader["PhoneNumber"]);
                userModelsList.Add(userModels);
            }
            objReader.Close();
            return userModelsList;
        }

        public List<UserModels> findAllUserList()
        {
            List<UserModels> userModelsList = new List<UserModels>();
            String sql = "SELECT Id,Email,PasswordHash,PhoneNumber,UserName FROM AspNetUsers";
            SqlDataReader objReader = SqlHelper.getReader(sql);
            while (objReader.Read())
            {
                UserModels userModels = new UserModels();
                userModels.Id = Convert.ToString(objReader["Id"]);
                userModels.UserName = Convert.ToString(objReader["UserName"]);
                userModels.Email = Convert.ToString(objReader["Email"]);
                userModels.PasswordHash = Convert.ToString(objReader["PasswordHash"]);
                userModels.PhoneNumber = Convert.ToString(objReader["PhoneNumber"]);
                userModelsList.Add(userModels);
            }
            objReader.Close();
            return userModelsList;
        }

    }
}
