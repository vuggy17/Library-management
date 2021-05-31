using main.layout;
using main.model;
using main.model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.controller
{
    class DataLoadFromDB
    {
        private static DataLoadFromDB dataLoadFromDB;
        private DataLoadFromDB() {
            members = new List<Account>();
            loadMembersFromDB();
        }
        private List<Account> members;

        public static List<Account> getAllMembers()
        {
            if(dataLoadFromDB == null)
            {
                dataLoadFromDB = new DataLoadFromDB();
            }
            return dataLoadFromDB.members;
        }
        private void loadMembersFromDB()
        {
            //fake load to test
            members.Add(new Account("Pham Minh Tân","Long An","pmt@gmail.com","0343027600", 1307,"123456789", AccountStatus.ACTIVE, new DateTime(2019,12,31),0));
            members.Add(new Account("Pham Minh Tân1", "Long An", "pmt1@gmail.com", "0343027601",1412 , "123456789", AccountStatus.ACTIVE, new DateTime(2019, 12, 31), 1));
            members.Add(new Account("Pham Minh Tân2", "Long An", "pmt2@gmail.com", "0343027602", 1111, "123456789", AccountStatus.ACTIVE, new DateTime(2019, 12, 31), 2));
            members.Add(new Account("Pham Minh Tân3", "Long An", "pmt3@gmail.com", "0343027603", 8266, "123456789", AccountStatus.ACTIVE, new DateTime(2019, 12, 31), 3));
            members.Add(new Account("Pham Minh Tân4", "Long An", "pmt4@gmail.com", "0343027604", 1530, "123456789", AccountStatus.ACTIVE, new DateTime(2019, 12, 31), 4));
        }

    }
}
