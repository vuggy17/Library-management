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
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
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
                _email = value;
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
        public Person buildWithID(int id)
        {
            this.id = id;
            return this;
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
        
        #endregion

        //test region
        public Person(string email)
        {
            this.email = email;
        }

       
       

    }
}
