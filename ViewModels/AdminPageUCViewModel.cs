using ADO.NET_Task4.Commands;
using ADO.NET_Task4.DataAccess;
using ADO.NET_Task4.Helpers;
using ADO.NET_Task4.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task4.ViewModels
{
    public class AdminPageUCViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }
        public RelayCommand ShowBooksCommand { get; set; }
        public RelayCommand AddBookCommand { get; set; }
        public RelayCommand UpdateBookCommand { get; set; }
        public RelayCommand DeleteBookCommand { get; set; }

        public AdminPageUCViewModel()
        {
            ShowBooksCommand = new RelayCommand((s) =>
            {
                var allBooks = new AllBooksUC();
                var allBooksViewModel = new AllBooksUCViewModel();
                allBooks.DataContext = allBooksViewModel;
                App.ChangePage(allBooks);
            });

            AddBookCommand = new RelayCommand((a) => 
            {
                var addBookPage = new AddBookUC();
                var addBookViewModel = new AddBookUCViewModel();
                addBookPage.DataContext = addBookViewModel;
                App.ChangePage(addBookPage);
            });

            UpdateBookCommand = new RelayCommand(u =>
            {
                var updateBookPage = new UpdateBookUC();
                var updateBookViewModel = new UpdateBookUCViewModel();
                updateBookPage.DataContext = updateBookViewModel;
                App.ChangePage(updateBookPage);
            });

            DeleteBookCommand = new RelayCommand(d =>
            {
                var deleteBookPage = new DeleteBookUC();
                var deleteBookViewModel = new DeleteBookUCViewModel();
                deleteBookPage.DataContext = deleteBookViewModel;
                App.ChangePage(deleteBookPage);
            });

            BackCommand = new RelayCommand((b) => 
            {
                App.ExecuteBackCommand();
            });
        }
    }
}
