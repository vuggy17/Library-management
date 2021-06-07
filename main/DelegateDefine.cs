using main.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    public delegate void ChangePageHandler(string page);

    //new form is show --> opacity mainform decrease
    public delegate void ToggleFormDialogNotifyHandler();

    public delegate void LibrarianBarHandler();

    public delegate void AddBookHandler();

    public delegate void DeleteBookHandler(int index);

    public delegate void EditBookHandler(int index);

    public delegate void ClearInfoNotifyHandler();

    public delegate void LoginHandler();

    public delegate void LogoutHandler();

    public delegate void SearchByIdTitleAuthorHandler();

    public delegate void AddItemToReserveHandler(BookToReserve bookToResearve);

    public delegate void UpdateLendingBookList(Account account);

    public delegate void AddReadyReservedBookToCheckOut(BookToShow bookToShow);

}
