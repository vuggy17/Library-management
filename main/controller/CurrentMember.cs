using LibraryManagement.model;
using LibraryManagement.model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.controller
{
    class CurrentMember
    {
        private static CurrentMember instance;

        private Account account;

        

        CurrentMember()
        {
            account = null;
        }
        public static CurrentMember getInstance()
        {
            if(instance == null)
            {
                instance = new CurrentMember();
            }
            return instance;
        }
        public Account GetAccount()
        {
            return instance.account;
            
        }
        public void setAccount(Account account)
        {
            instance.account = account;
        }
        

        



    }
}
