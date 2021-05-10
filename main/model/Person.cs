using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace main.model
{
    public class Person
    {
        #region properties
        // dung dung vo :v
        //private int _id;

        //public int id
        //{
        //    get { return id; }
        //    set { id = value; }
        //}
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _address;

        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _email;

        public string email
        {
            get { return _email; }
            set { 
                if(validateEmail(value))
                    _email = value; 
                //else thow err
            }
        }
        private string _phone;

        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        #endregion

        public Person(string name, string address, string email, string phone)
        {
            this.name = name;
            this.address = address;
            this.email = email;
            this.phone = phone;
        }
        public Person(Person source)
        {
            this.address = source.address;
            this.name = source.name;
            this.email = source.email;
            this.phone = source.phone;
        }
        public void modifyInfo(Person info) {
            this.name = info.name;
            this.address = info.address;
            this.phone = info.phone;
            this.email = info.email;
        }

        #region input check
        public bool validateEmail(string email)
        {
            var regex = new Regex(@"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;]{0,1}\s*)+$");
            return regex.Match(email).Success;
        }
        #endregion

        //test region
        public Person(string email)
        {
            this.email = email;
        }

       
       

    }
}
