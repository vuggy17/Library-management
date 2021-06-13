using main.model;
using main.model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.model.form
{
    class ReturnFullInforViewModel : BaseViewModel
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String BorrowedBook { get; set; }
        public String OverDue { get; set; }
        public Boolean BlackList { get; set; }

        public ReturnFullInforViewModel(Account account)
        {
            Id = "ID: "+ account.id.ToString();
            Name = account.info.name;
            Address = account.info.address;
            Phone = account.info.phone;
            Email = account.info.email;
            BorrowedBook = account.totalBookLoan.ToString();            
            OverDue = account.TotalOverDueBook.ToString();
            if(account.status == AccountStatus.BLACKLISTED)
            {
                BlackList = true;
            }
            else
            {
                BlackList = false;
            }

        }

    }
}
