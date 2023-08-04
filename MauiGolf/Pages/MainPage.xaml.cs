using MauiGolf.Models;
using System.Diagnostics;
using MauiGolf.Data;
using MauiGolf.Services;
using SQLite;
using MauiGolf.Pages;
using MauiGolf.ViewModels;

namespace MauiGolf.Pages
{
    public partial class MainPage : ContentPage
    {
        private User _currentUser;   
        public MainPage (MainViewModel viewModel)
        {

            InitializeComponent();
            BindingContext = viewModel;
            _currentUser = viewModel.CurrentUser;
            Debug.WriteLine("MainPage User: " + _currentUser.Name);
            lblWelcome.Text = $"Welcome {_currentUser.Name}!";
           
        }

        
        public async void Btn_Clicked(object sender, EventArgs e)
        {
            var handicap = await App.Database.GetHandicap(_currentUser.HandicapId);
            var scores = await App.Database.GetScores(_currentUser.Id);
            lblHomeCourse.Text = _currentUser.HomeCourse;
            lblHandicap.Text = handicap.CurrentIndex.ToString();
            lstScores.ItemsSource= scores;
            lstScores.ItemTemplate = new DataTemplate(typeof(TextCell));
            lstScores.ItemTemplate.SetBinding(TextCell.TextProperty, "Value");
            lstScores.ItemTemplate.SetBinding(TextCell.DetailProperty, "Date");

            //Collection View
            ScoresCV.ItemsSource = scores;
        }


        public void Logout_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
            _currentUser = null;
        }

    }
}