using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.model
{
    public class Staff
    {
        #region properties
        #region id 
        #endregion

        private int _id;

        public int id
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
        #endregion

        #region method
        public Staff(Person accountInfo, int id, string password)
        {
            if(accountInfo != null)
            {
                this.info = accountInfo;
            }
            this.id = id;
            this.password = password;           
        }
        public Staff()
        {

        }
        public bool ChangeInfo(Person input)
        {
            this.info.modifyInfo(input);
            return true;
        }       

        #endregion
    }
}
