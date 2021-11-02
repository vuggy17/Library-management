using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.model.enums
{
    //book type
    //lending status
    public enum LendingStatus
    {
        AVAI,RESV,LOANED,LOST,RENEWED,READY
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
