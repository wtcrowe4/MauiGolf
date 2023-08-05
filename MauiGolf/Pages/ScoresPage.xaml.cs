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

       
        public ScoresPage(MainViewModel vm)
        {

            _currentUser = vm.CurrentUser;
            InitializeComponent();
            BindingContext = vm;
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            
        }

        protected async override void OnAppearing()
        {
            var handicap = await App.Database.GetHandicap(_currentUser.Id);
            var scores = await App.Database.GetScores(_currentUser.Id);
            lblName.Text = _currentUser.Name + "'s Scores";
            lblHandicap.Text = "Current Index: " + handicap.CurrentIndex;

            lstScores.ItemsSource = scores;
            lstScores.ItemTemplate = new DataTemplate(typeof(TextCell));
            lstScores.ItemTemplate.SetBinding(TextCell.TextProperty, "Value");
            lstScores.ItemTemplate.SetBinding(TextCell.DetailProperty, "Date");

            base.OnAppearing();
            
        }

    }
}
