using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoungsDrumStoreDAL.Models
{
    public class AccountDO
    {
        public int RoleId { get; set; }
        public int AccountID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
