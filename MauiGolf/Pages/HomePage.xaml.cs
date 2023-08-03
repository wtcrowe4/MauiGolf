using MauiGolf.Services;
using MauiGolf.Models;
using MauiGolf.Data;
using System.Diagnostics;

namespace MauiGolf.Pages
{
    public partial class HomePage : ContentPage
    {
        private readonly User _currentUser;
        public HomePage(User user)
        {
            _currentUser = user;
            Debug.WriteLine("HomePage User: " + _currentUser.Name);
            InitializeComponent();
        }

        private void OnAppearing()
        {
            lblWelcome.Text = $"Welcome {_currentUser.Name}!";
            base.OnAppearing();
        }
    }
}
