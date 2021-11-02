using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.model
{
    class Author
    {
        #region properties
        #region id
        // dung dung vo :v
        //private int _id;

        //public int id
        //{
        //    get { return _id; }
        //    set { _id = value; }
        //} 
        #endregion
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _desciption;

        public string description
        {
            get { return _desciption; }
            set { _desciption = value; }
        }
        #endregion

        #region method
        public Author(int id, string name, string description)
        {
            //this.id = id;
            this.name = name;
            this.description = description;
        }
        #endregion
    }
}
