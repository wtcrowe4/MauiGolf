using MauiGolf.Services;
using MauiGolf.Models;
using MauiGolf.Data;
using System.Diagnostics;
using MauiGolf.ViewModels;

namespace MauiGolf.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            CheckForPrevLogin();
        }

        private static async void CheckForPrevLogin()
        {
            var userId = Preferences.Get("UserId", 0);
            var userEmail = Preferences.Get("UserEmail", "");
            var userPassword = Preferences.Get("UserPassword", "");
            Debug.WriteLine("UserId: " + userId);
            if (userId != 0)
            {
                var user = await DBService.Login(userEmail, userPassword);
                //var mainViewModel = new MainViewModel(user);
                Application.Current.MainPage = new AuthAppShell(user);
            }
           
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;
            
            var user = await DBService.Login(email, password);
            if (user != null)
            {
                Debug.WriteLine("Login Successful");

                //Save user to preferences to bypass login
                Preferences.Set("UserId", user.Id);
                Preferences.Set("UserEmail", user.Email);
                Preferences.Set("UserPassword", user.Password);
                    
                //var mainViewModel = new MainViewModel(user);
                Application.Current.MainPage = new AuthAppShell(user);
            }
        }
    }
}
