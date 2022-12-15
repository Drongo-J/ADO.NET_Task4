using ADO.NET_Task4.ViewModels;
using ADO.NET_Task4.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ADO.NET_Task4
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Grid MyGrid { get; internal set; }

        public static List<UIElement> Pages { get; set; } = new List<UIElement>();

        public static bool ShowRents { get; set; } = false;

        public static void ChangePage(UIElement newPage, bool addNewPage = true)
        {
            if (addNewPage)
                Pages.Add(newPage);
            MyGrid.Children.RemoveAt(0);
            MyGrid.Children.Add(Pages.Last());
        }

        public static void ExecuteBackCommand()
        {
            Pages.Remove(Pages.Last());
            App.ChangePage(Pages.Last(),false);
        }
    }
}
