using ADO.NET_Task4.Commands;
using ADO.NET_Task4.DataAccess;
using ADO.NET_Task4.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task4.ViewModels
{
    public class ShowMyRentsUCViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }

        private ObservableCollection<S_Card> rents;

        public ObservableCollection<S_Card> Rents
        {
            get { return rents; }
            set { rents = value; }
        }

        public ShowMyRentsUCViewModel(int studentId)
        {
            Rents = new ObservableCollection<S_Card>(DatabaseHelper.GetSCardsById(studentId));

            BackCommand = new RelayCommand((b) => 
            {
                App.ExecuteBackCommand();
            }); 
        }
    }
}
