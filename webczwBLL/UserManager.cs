using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webczw.DAL;
using webczw.Models;

namespace webczw.BLL
{
    /// <summary>
    /// 用户业务逻辑类
    /// </summary>
    public class UserManager
    {
        //创建数据访问对象
        private UserService userService = new UserService();

        public List<UserModels> findUserList(UserModels queryUserModels)
        {
            return userService.findUserList(queryUserModels);
        }

        public List<UserModels> findAllUserList() {
            return userService.findAllUserList();
        }
    }
}
