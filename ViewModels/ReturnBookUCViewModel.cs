using ADO.NET_Task4.Commands;
using ADO.NET_Task4.DataAccess;
using ADO.NET_Task4.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ADO.NET_Task4.ViewModels
{
    public class ReturnBookUCViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }

        private S_Card selectedRent;

        public S_Card SelectedRent
        {
            get { return selectedRent; }
            set
            {
                selectedRent = value;
                OnPropertyChanged();
                SelectionChanged();
            }
        }

        private ObservableCollection<S_Card> rents;

        public ObservableCollection<S_Card> Rents
        {
            get { return rents; }
            set { rents = value; }
        }

        public void SelectionChanged()
        {
            var result = MessageBox.Show($"Are you sure you want to return this book?", "Return Book", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                DatabaseHelper.DeleteSCardById(SelectedRent.Id);
                Rents.Remove(SelectedRent);
                MessageBox.Show("Book was returned successfully");
                App.ExecuteBackCommand();
                App.ExecuteBackCommand();
            }
        }
   
        public ReturnBookUCViewModel(int student_id)       
        {
            Rents = new ObservableCollection<S_Card>(DatabaseHelper.GetSCardsById(student_id));

            BackCommand = new RelayCommand((b) =>
            {
                App.ExecuteBackCommand();
            });
        }
    }
}
