using main.controller;
using main.layout.HomeAndFeature.form;
using main.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace main.model.features
{
    class ResearveBookFormViewModel: BaseViewModel
    {
        private ObservableCollection<BookToReserve> filterList;

        public ObservableCollection<BookToReserve> FilterList
        {
            get => filterByInfo();
            set => filterList = value;
        }


        private String searchKey;
        private List<Book> allBooks;
        private ObservableCollection<BookToReserve> allbookToReserves;

        public String SearchKey
        {
            get => searchKey;
            set
            {
                searchKey = value;
                OnPropertyChanged("SearchKey");
                OnPropertyChanged("FilterList");
            }
        }
        public ICommand Add { get; set; }
        public ICommand Remove { get; set; }
        public ICommand AddToReseverList { get; set; }        
        public ICommand Done { get; set; }


        public static event AddItemToReserveHandler addItemToReserve;


        public BookToReserve selectedItem { get; set; }




        public ResearveBookFormViewModel(ObservableCollection<BookToReserve> alreadyAddBookToReserves)
        {
            allBooks = new List<Book>();
            allBooks = DataLoadFromDB.getBooks();
            allbookToReserves = new ObservableCollection<BookToReserve>();
            searchKey = "";
            filterList = new ObservableCollection<BookToReserve>();
            convertBookListToBookToReseverList(alreadyAddBookToReserves);
            Add = new RelayCommand<object>((p) => { return true; }, (p) => { increaseCount(); });
            Remove = new RelayCommand<object>((p) => { return true; }, (p) => { decreaseCount(); });              
            AddToReseverList = new RelayCommand<object>((p) => { return true; }, (p) => { addToReseverList(); });           
        }

        private void convertBookListToBookToReseverList(ObservableCollection<BookToReserve> alreadyAddBookToReserves)
        {
            foreach (var book in allBooks)
            {
                allbookToReserves.Add(new BookToReserve(book));
            }
            foreach (var alreadyBook in alreadyAddBookToReserves)
            {
                foreach (var book in allbookToReserves)
                {
                    if(alreadyBook.id == book.id)
                    {
                        book.AddAble = alreadyBook.AddAble;
                        book.Count = alreadyBook.Count;
                    }
                }
            }
        }
        private void addToReseverList()
        {          
            if(selectedItem.AvalableCopies > 0)
            {
                if(selectedItem.Count > 0)
                {
                    selectedItem.AddAble = false;
                    addItemToReserve(selectedItem);
                    foreach (var book in allbookToReserves)
                    {
                        if(selectedItem.id == book.id)
                        {
                            book.AddAble = selectedItem.AddAble;
                            book.Count = selectedItem.Count;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You try to add 0 copies of this book!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                
            }
            else
            {
                MessageBox.Show("This book don't have any available copies!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
                    
        }


        private void increaseCount()
        {
            if (selectedItem.Count < 5 && selectedItem.Count < selectedItem.AvalableCopies && selectedItem.AddAble)
            {
                selectedItem.Count++;              
            }
           
        }

        private void decreaseCount()
        {
            if (selectedItem.Count > 0 && selectedItem.AddAble)
            {
                selectedItem.Count--;               
            }
        }

        private ObservableCollection<BookToReserve> filterByInfo()
        {
            ObservableCollection<BookToReserve> filterList = new ObservableCollection<BookToReserve>();

            foreach (var book in allbookToReserves)
            {
                
                foreach (PropertyInfo prop in book.GetType().GetProperties())
                {
                    var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                    if (type == typeof(string) || type == typeof(int) || type == typeof(DateTime))
                    {
                        var book_field = prop.GetValue(book, null);
                        if (book_field != null)
                        {
                            String book_data = book_field.ToString().Trim().ToLower();
                            String keyWord = searchKey.ToLower();
                            if (book_data != null && keyWord != null)
                            {
                                if (book_data.Contains(keyWord))
                                {
                                    filterList.Add(book);
                                    break;
                                }
                            }
                        }
                    }
                   
                }
            }
            return filterList;
        }

    }
}
