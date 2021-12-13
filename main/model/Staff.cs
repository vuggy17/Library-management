using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using LibraryManagement.controller;
using LibraryManagement.db;

namespace LibraryManagement.model
{
    public class Staff
    {
        #region properties
        #region id 
        #endregion

        private string _id;

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _password;

        public string password
        {
            get => _password;
            set
            {
                _password = value;
                //update ondb
            }

        }
        private Person _info;
        public Person info
        {
            get { return _info; }
            set { _info = value; }
        }

        public IDatabase database;
        #endregion

        #region method
        public Staff(Person accountInfo, string id, string password)
        {
            if (accountInfo != null)
            {
                this.info = accountInfo;
            }
            this.id = id;
            this.password = password;
        }
        public Staff()
        {

        }

        public Staff(IDatabase mydb)
        {
            this.database = mydb;
        }
        public bool ChangeInfo(Person input)
        {
            try
            {
                this.info.modifyInfo(input);
                Db.getInstace().updateInfo(input);
                Db.getInstace().insertImageData(input);
                return true;
            }
            catch 
            {
                return false;
            }

        }
        public void changePassWord(string oldPassword, string newPassword, string confirmPwd)
        {
            // old passord is correct
            if (!PasswordHash.ValidatePassword(oldPassword, this.password))
                throw new Exception("WRONG_PASS");
            // newpassword & confirmPwd is < 8 character
            if (newPassword.Length < 8 || confirmPwd.Length < 8)
                throw new Exception("INVALID_PASS");
            // new and confirm password not match
            if (newPassword != confirmPwd)
                throw new Exception("NOT_MATCH");
            // db error
            if (!Db.getInstace().updatePassword(this.id, this.password))
                throw new Exception("DB_ERROR");
            Console.WriteLine("CHANGE PASSWORD SUCCESS");
        }
        public void changePassWord1(string oldPassword, string newPassword, string confirmPwd)
        {
            // old passord is correct
            if (!PasswordHash.ValidatePassword(oldPassword, this.password))
                throw new Exception("WRONG_PASS");
            // newpassword & confirmPwd is < 8 character
            if (newPassword.Length < 8 || confirmPwd.Length < 8)
                throw new Exception("INVALID_PASS");
            // new and confirm password not match
            if (newPassword != confirmPwd)
                throw new Exception("NOT_MATCH");
            // db error
            //if (!database.updatePassword(this.id, this.password))
            //    throw new Exception("DB_ERROR");
            Console.WriteLine("CHANGE PASSWORD SUCCESS");
        }

        public bool updateInfo(string id, string name, string address, string phone, string mail, string imagename)
        {


            if (String.IsNullOrEmpty(id) || String.IsNullOrEmpty(name) || String.IsNullOrEmpty(address) || String.IsNullOrEmpty(phone) || String.IsNullOrEmpty(mail))
                throw new Exception("BAD_INPUT");
            if (isValidEmail(mail) && isVietnamesePhoneNumber(phone) && isValidName(name))
            {
                Person newInfo = new Person(name, address, mail, phone); ;
                if (imagename != "")
                {
                    byte[] imageData = File.ReadAllBytes(imagename);
                    string base64String = Convert.ToBase64String(imageData, 0, imageData.Length);
                    newInfo.imgSource = base64String;
                }
                this.info.modifyInfo(info);
                return this.ChangeInfo(info);
            }
            return false;
        }
        public bool updateInfo1(string id, string name, string address, string phone, string mail, string imagename)
        {
            if (String.IsNullOrEmpty(id) || String.IsNullOrEmpty(name) || String.IsNullOrEmpty(address) || String.IsNullOrEmpty(phone) || String.IsNullOrEmpty(mail))
                throw new Exception("BAD_INPUT");
            if (isValidEmail(mail) && isVietnamesePhoneNumber(phone) && isValidName(name))
            {
                Person newInfo = new Person(name, address, mail, phone);
                var updateResult = updateOuterInfo(newInfo, imagename);
                if (updateResult)
                    updateInternalInfo(newInfo);
                return updateResult;
            }
            return false;
        }
        public void updateInternalInfo(Person info)
        {
            if (this.info != null)
                this.info.modifyInfo(info);
        }

        //call db to update info
        public bool updateOuterInfo(Person info, string imagename)
        {
            if (imagename != "")
            {
                byte[] imageData = File.ReadAllBytes(imagename);
                string base64String = Convert.ToBase64String(imageData, 0, imageData.Length);
                info.imgSource = base64String;
            }
            try
            {
                this.database.insertImageData(info);
                this.database.updateInfo(info);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool isValidName(string name)
        {
            if (String.IsNullOrEmpty(name)) return false;
            var regexItem = new Regex("^[a-zA-Z ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]*$");
            return regexItem.IsMatch(name);
        }
        public bool isValidEmail(string emailaddress)
        {
            if (String.IsNullOrEmpty(emailaddress)) return false;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(emailaddress);
            return match.Success;

        }
        public bool isVietnamesePhoneNumber(string number)
        {
            if (String.IsNullOrEmpty(number)) return false;
            Regex _regex = new Regex("(03|05|07|08|09)+([0-9])");
            return _regex.IsMatch(number);
        }

        #endregion
    }
}
