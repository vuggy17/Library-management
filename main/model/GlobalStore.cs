using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.model
{
    abstract class GlobalStore
    {
        private static GlobalStore _instance = null;
        public static GlobalStore instance
        {
            get
            {
                if (_instance == null)
                {
                    //Create the default configuration provider
                    _instance = new AppConfigConfiguration();
                }

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
    }
}