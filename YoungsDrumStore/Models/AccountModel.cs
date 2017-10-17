using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YoungsDrumStore.Models
{
    public class AccountModel
    {
        public AccountPO aAccount { get; set; }
        public List<AccountPO> accountList { get; set; }

        public AccountModel()
        {
            aAccount = new AccountPO();
            accountList = new List<AccountPO>();
        }
    }
}