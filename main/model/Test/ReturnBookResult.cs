using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.model.Test
{
    public class ReturnBookResult
    {
        public string newBookItemStatus { get; set; }
        public bool returnResult { get; set; }
        public string logMessage { get; set; }

        public ReturnBookResult(string newStatus, bool returnResult, string logMessage)
        {
            this.newBookItemStatus = newStatus;
            this.returnResult = returnResult;
            this.logMessage = logMessage;
        }
        public bool compare( ReturnBookResult returnBook)
        {
            return this.newBookItemStatus == returnBook.newBookItemStatus && this.returnResult == returnBook.returnResult && this.logMessage == returnBook.logMessage;
        }

    }
}
