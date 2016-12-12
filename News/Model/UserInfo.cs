using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserInfo
    {
        public int ID { get; set; }

        public int RoleId { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string Phone { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime LastLoginTime { get; set; }

    }
}
