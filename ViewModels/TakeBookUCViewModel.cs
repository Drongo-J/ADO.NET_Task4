using ADO.NET_Task4.Commands;
using ADO.NET_Task4.DataAccess;
using ADO.NET_Task4.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ADO.NET_Task4.ViewModels
{
    public class TakeBookUCViewModel : BaseViewModel
    {
            public RelayCommand BackCommand { get; set; }
            public RelayCommand RentBookCommand { get; set; }

            public Book Book { get; set; }

            public int StudentId { get; set; }
            public int DayCount { get; set; }

            public TakeBookUCViewModel(Book _book)
            {
                Book = _book;

                BackCommand = new RelayCommand((b) =>
                {
                    App.ExecuteBackCommand();
                });

                RentBookCommand = new RelayCommand((b) =>
                {
                    if (StudentId == 0 || DayCount == 0)
                    {
                        MessageBox.Show("Value cannot be 0!");
                        return;
                    }

                    var student = DatabaseHelper.StudentExists(StudentId);
                    if (student != null)
                    {
                        var s_card = new S_Card()
                        {
                            Id = DatabaseHelper.GetIdForSCard(),
                            Book = this.Book,
                            Id_Book = Book.Id,
                            DateOut = DateTime.Now,
                            DateIn = DateTime.Now.AddDays(DayCount),
                            Id_Student = student.Id,
                            Id_Lib = DatabaseHelper.GetRandomLibrarianId()
                        };
                        DatabaseHelper.AddSCard(s_card);
                        MessageBox.Show("Book was rented successfully");
                        App.ExecuteBackCommand();
                        App.ExecuteBackCommand();
                    }
                    else
                    {
                        MessageBox.Show("Student with this ID does not exists!");
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
