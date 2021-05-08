using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.model.enums
{
    //book type
    public enum BookFormat {
        HARDCOVER, PPBACK, AUDBOOK, EBOOK, NEWSPP, MAGZINE, JOURL
    }
    //lending status
    public enum LendingStatus
    {
        AVAI,RESV,LOANED,LOST
    }
    //reservation status
    public enum ReservationStatus
    {
        WAITING,PENDING,COMPLETED,CANCELED,NONE
    }
    
    public enum AccountStatus
    {
        ACTIVE,CLOSED,CANCELED,BLACKLISTED,NONE
    }
}
