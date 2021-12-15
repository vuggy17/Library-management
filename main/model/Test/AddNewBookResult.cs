using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.model.Test
{
    public class AddNewBookResult
    {
        public bool returnResult { get; set; }
        public bool isAddBookInDatabase { get; set; }
        public bool isAddBookItemInDatabase { get; set; }
        public string logMessage { get; set; }
       

        public AddNewBookResult(bool _returnResult, bool _isAddBookInDatabase, bool _isAddBookItemInDatabase, string _logMessage)
        {
            returnResult = _returnResult;
            isAddBookInDatabase = _isAddBookInDatabase;
            isAddBookItemInDatabase = _isAddBookItemInDatabase;
            logMessage = _logMessage;          
        }
        public bool compare(AddNewBookResult addNewBookResult)
        {
            if(this.returnResult == addNewBookResult.returnResult && this.isAddBookInDatabase == addNewBookResult.isAddBookInDatabase && this.isAddBookItemInDatabase == addNewBookResult.isAddBookItemInDatabase && this.logMessage == addNewBookResult.logMessage)
            {
                return true;
            }
            return false;
        }
    }
}
