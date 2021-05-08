using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.model
{
    //position of a book
    class Rack
    {
        #region properties
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        //rack number
        private int _number;

        public int number
        {
            get { return _number; }
            set { _number = value; }
        }
        //description for location, e.x: floor 2,..
        private string _location;

        public string location
        {
            get { return _location; }
            set { _location = value; }
        }
        #endregion
        #region method
        public Rack(int id, int number, string location)
        {
            this.id = id;
            this.number = number;
            this.location = location;
        }
        #endregion
    }
}
