using ADO.NET_Task4.Commands;
using ADO.NET_Task4.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task4.ViewModels
{
    public class HomePageUCViewModel : BaseViewModel
    {
        public RelayCommand AdminCommand { get; set; }
        public RelayCommand UserCommand { get; set; }

        public HomePageUCViewModel()
        {
            AdminCommand = new RelayCommand((a) => 
            {
                var adminPage = new AdminPageUC();
                var adminPageViewModel = new AdminPageUCViewModel();
                adminPage.DataContext = adminPageViewModel;
                App.ChangePage(adminPage);
            });

            UserCommand = new RelayCommand((u) =>
            {
                var userPage = new UserPageUC();
                var userPageViewModel = new UserPageUCViewModel();
                userPage.DataContext = userPageViewModel;
                App.ChangePage(userPage);
            });
        }
    }
}
