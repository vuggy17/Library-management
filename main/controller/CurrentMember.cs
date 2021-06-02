using main.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.controller
{
    class CurrentMember
    {
        private static Account account;
        CurrentMember()
        {
           
        }
        public static Account GetAccount()
        {
            if (account == null)
            {
                account = new Account();
            }
            return account;
        }
        public static void setAccount(Account account)
        {
            CurrentMember.account = account;
        }
    }
}
