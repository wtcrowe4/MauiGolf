using MauiGolf.Data;
using MauiGolf.Models;
using MauiGolf.Pages;
using MauiGolf.Services;
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
                database ??= new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mauigolf.db3"));
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            //Preferences.Clear();
            MainPage = new AppShell();
        }

    }
}