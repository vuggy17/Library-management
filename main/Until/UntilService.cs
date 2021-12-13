using LibraryManagement.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryManagement.Until
{
    public class UntilService
    {
        public  bool validateEmail(string email)
        {
            if (String.IsNullOrEmpty(email)) return false;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }

        public  bool validatePhone(string phone)
        {
            if (String.IsNullOrEmpty(phone)) return false;
            Regex _regex = new Regex("(03|05|07|08|09)+([0-9])");
            return _regex.IsMatch(phone);
        }

        public string createHash(string input)
        {
            return PasswordHash.CreateHash(input);
        }

    }
}
