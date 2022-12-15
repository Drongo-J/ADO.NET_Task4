using ADO.NET_Task4.Commands;
using ADO.NET_Task4.DataAccess;
using ADO.NET_Task4.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task4.ViewModels
{
    public class AllBooksUCViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }

        private ObservableCollection<Book> books;

        public ObservableCollection<Book> Books
        {
            get { return books; }
            set { books = value; OnPropertyChanged(); }
        }

        public AllBooksUCViewModel()
        {
            Books = new ObservableCollection<Book>(DatabaseHelper.GetBooks());

            BackCommand = new RelayCommand((b) =>
            {
                App.ExecuteBackCommand();
            });
        }
    }
}
