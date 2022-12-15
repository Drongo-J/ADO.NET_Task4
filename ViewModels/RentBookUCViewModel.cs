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
using System.Windows;

namespace ADO.NET_Task4.ViewModels
{
    public class RentBookUCViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }

        private Book selectedBook;

        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
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
            var result = MessageBox.Show($"Do you want to rent the book - {SelectedBook.Name}?", "Delete Book", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var takeBookPage = new TakeBookUC();
                var takeBookPageViewModel = new TakeBookUCViewModel(SelectedBook);
                takeBookPage.DataContext = takeBookPageViewModel;
                App.ChangePage(takeBookPage);
            }
        }

        public RentBookUCViewModel()
        {
            Books = new ObservableCollection<Book>(DatabaseHelper.GetBooks());

            BackCommand = new RelayCommand((b) =>
            {
                App.ExecuteBackCommand();
            });
        }
    }
}
