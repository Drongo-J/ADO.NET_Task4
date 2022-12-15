using ADO.NET_Task4.Commands;
using ADO.NET_Task4.DataAccess;
using ADO.NET_Task4.Helpers;
using ADO.NET_Task4.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task4.ViewModels
{
    public class UserPageUCViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }
        public RelayCommand ShowBooksCommand { get; set; }
        public RelayCommand RentBookCommand { get; set; }
        public RelayCommand ReturnBookCommand { get; set; }
        public RelayCommand MyRentsCommand { get; set; }

        public UserPageUCViewModel()
        {
            ShowBooksCommand = new RelayCommand((s) =>
            {
                var allBooks = new AllBooksUC();
                var allBooksViewModel = new AllBooksUCViewModel();
                allBooks.DataContext = allBooksViewModel;
                App.ChangePage(allBooks);
            });

            RentBookCommand = new RelayCommand((r) =>
            {
                var rentBookPage = new RentBookUC();
                var rentBookPageViewModel = new RentBookUCViewModel();
                rentBookPage.DataContext = rentBookPageViewModel;
                App.ChangePage(rentBookPage);
            });

            ReturnBookCommand = new RelayCommand((r) => 
            {
                App.ShowRents = false;
                var enterIdPage = new EnterYourIdUC();
                var enterIDPageViewModel = new EnterYourIdUCViewModel();
                enterIdPage.DataContext = enterIDPageViewModel;
                App.ChangePage(enterIdPage);
            });

            MyRentsCommand = new RelayCommand((m) =>
            {
                App.ShowRents = true;
                var enterIdPage = new EnterYourIdUC();
                var enterIDPageViewModel = new EnterYourIdUCViewModel();
                enterIdPage.DataContext = enterIDPageViewModel;
                App.ChangePage(enterIdPage);
            });

            BackCommand = new RelayCommand((b) =>
            {
                App.ExecuteBackCommand();
            });
        }
    }
}
