using MauiGolf.Data;
using MauiGolf.Models;
using MauiGolf.Pages;
using MauiGolf.ViewModels;
using SQLite;
using System.Diagnostics;

namespace MauiGolf
{
    public partial class App : Application
    {
        private static Database database;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mauigolf.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            //Temp bypass login for debugging
            //var user = BypassLogin().Result;
            //var authAppShell = new AuthAppShell(user);
            //var mainViewModel = new MainViewModel(user);
            //MainPage = authAppShell;
            
        }

        private async Task<User> BypassLogin()
        {
            var user = await App.Database.GetUser(1);
            Debug.WriteLine("BypassLogin User: " + user.Name);  
            return user;
        }
    }
}