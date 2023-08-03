using MauiGolf.Services;
using MauiGolf.Models;
using MauiGolf.Data;
using System.Diagnostics;
using MauiGolf.ViewModels;

namespace MauiGolf.Pages
{
    public partial class HomePage : ContentPage
    {
        private readonly User _currentUser;
        public HomePage(MainViewModel viewModel, User user)
        {
            _currentUser = user;
            Debug.WriteLine("HomePage User: " + _currentUser.Name);
            InitializeComponent();

            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            lblWelcome.Text = $"Welcome {_currentUser.Name}!";
            base.OnAppearing();
        }
    }
}
