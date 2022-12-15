using ADO.NET_Task4.Commands;
using ADO.NET_Task4.DataAccess;
using ADO.NET_Task4.Helpers;
using ADO.NET_Task4.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ADO.NET_Task4.ViewModels
{
    public class EnterYourIdUCViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }
        public RelayCommand ContinueCommand { get; set; }

        public string StudentId { get; set; }

        public EnterYourIdUCViewModel()
        {
            BackCommand = new RelayCommand((b) =>
            {
                App.ExecuteBackCommand();
            });

            ContinueCommand = new RelayCommand((c) =>
            {
                var student = DatabaseHelper.StudentExists(int.Parse(StudentId));
                if (student != null)
                {
                    if (App.ShowRents)
                    {
                        var myRentsUC = new ShowMyRentsUC();
                        var myRentUCViewModel = new ShowMyRentsUCViewModel(student.Id);
                        myRentsUC.DataContext = myRentUCViewModel;
                        App.Pages.Remove(App.Pages.Last());
                        App.ChangePage(myRentsUC);
                    }
                    else
                    {
                        var returnBookPage = new ReturnBookUC();
                        var returnBookPageViewModel = new ReturnBookUCViewModel(student.Id);
                        returnBookPage.DataContext = returnBookPageViewModel;
                        App.ChangePage(returnBookPage);
                    }
                }
                else
                {
                    MessageBox.Show("Student does not exists!");
                }
            });
        }
        private static readonly Regex OnlyNumberRegex = new Regex("[0-9]+");
        public void IsAllowedInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static bool IsTextAllowed(string text)
        {
            return OnlyNumberRegex.IsMatch(text);
        }
    }
}
