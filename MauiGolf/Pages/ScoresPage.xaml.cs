using MauiGolf.ViewModels;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiGolf.Models;
using MauiGolf.Data;


namespace MauiGolf.Pages
{
    public partial class ScoresPage : ContentPage
    {
        private User _currentUser;
        public ScoresPage(MainViewModel viewModel)
        {
            _currentUser = viewModel.CurrentUser;
            InitializeComponent();
            //BindingContext = viewModel;
            //_currentUser = viewModel.CurrentUser;
            //Debug.WriteLine("ScoresPage User: " + _currentUser.Name);
            //lblName.Text = _currentUser.Name + "'s Scores";
            //lstScores.ItemsSource = viewModel.Scores;

        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            
        }

        protected async override void OnAppearing()
        {
            var handicap = await App.Database.GetHandicap(_currentUser.HandicapId);
            var scores = await App.Database.GetScores(_currentUser.Id);
            lblName.Text = _currentUser.Name + "'s Scores";
            lstScores.ItemsSource = scores;

            base.OnAppearing();
            
        }

    }
}
