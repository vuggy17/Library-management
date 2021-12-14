using LibraryManagement.controller;
using LibraryManagement.db;
using LibraryManagement.model;
using LibraryManagement.Until;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryManagement.viewmodel.Login
{
    public class LoginViewModel
    {
        List<Staff> stafflist;
        UntilService _until;
        public LoginViewModel(IDatabase dbService, UntilService until)
        {
            stafflist = dbService.getAllStaffs();
            _until = until;
        }

        

        // if credential valid, process to login, if not throw exception
        public bool login(string username, string password)
        {
            if (String.IsNullOrEmpty(password)) throw new Exception("Please enter password");
            if (String.IsNullOrEmpty(username)) throw new Exception("Please enter username");

            var found = findStaffCredential(username);
            if (found != null && PasswordHash.ValidatePassword(password, found.password))
            {
                CurrentStaff.setCurrentStaff(found);
                return true;
            }
            else
            {
                throw new Exception("Credential not found");
            }
        }

        public Staff findStaffCredential(string username)
        {
            if (username.Contains('@'))
            {
                if (_until.validateEmail(username))
                    throw new Exception("Email invalid");
                return getStaffWithEmail(username);
            }
            else
            {
                return getStaffWithId(username);
            }
        }

        public Staff getStaffWithEmail(string email)
        {
            Staff staff = null;
            foreach (Staff item in stafflist)
            {
                if (item.info.email == email)
                {
                    staff = item;
                    break;
                }
            }
            return staff;
        }
        public Staff getStaffWithId(string id)
        {
            Staff staff = null;

            foreach (Staff item in stafflist)
            {
                if (item.id.ToString() == id)
                {
                    staff = item;
                }
            }
            return staff;
        }

    }
}
