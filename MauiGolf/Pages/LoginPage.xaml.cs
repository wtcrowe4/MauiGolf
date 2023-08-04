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
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;
            
            var user = await DBService.Login(email, password);
            if (user != null)
            {
                Debug.WriteLine("Login Successful");
                var mainViewModel = new MainViewModel(user);
                Application.Current.MainPage = new AuthAppShell(user);
            }
        }
    }
}
