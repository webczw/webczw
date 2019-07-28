using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webczw.Models
{
    [Serializable] //表示可以序列化
    public class UserModels
    {
        public String Id { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String PasswordHash { get; set; }
        public String PhoneNumber { get; set; }
    }
}
