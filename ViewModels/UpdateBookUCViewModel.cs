using ADO.NET_Task4.Commands;
using ADO.NET_Task4.DataAccess;
using ADO.NET_Task4.Helpers;
using ADO.NET_Task4.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task4.ViewModels
{
    public class UpdateBookUCViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }

        private Book selectedBook;

        public Book SelectedBook
        {
            get { return selectedBook; }
            set { 
                selectedBook = value; 
                OnPropertyChanged();
                SelectionChanged();
                }
        }

        private ObservableCollection<Book> books;

        public ObservableCollection<Book> Books
        {
            get { return books; }
            set { books = value; OnPropertyChanged(); }
        }

        public void SelectionChanged()
        {
            var editBookPage = new EditBookUC();
            var editBookPageViewModel = new EditBookUCViewModel(SelectedBook);
            editBookPage.DataContext = editBookPageViewModel;
            App.ChangePage(editBookPage);
        }

        public UpdateBookUCViewModel()
        {
            Books = new ObservableCollection<Book>(DatabaseHelper.GetBooks());

            BackCommand = new RelayCommand((a) => 
            {
                App.ExecuteBackCommand();
            });
        }
    }
}
