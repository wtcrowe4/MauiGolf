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

        protected async override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            var handicap = await App.Database.GetHandicap(_currentUser.Id);
            var scores = await App.Database.GetScores(_currentUser.Id);
            lblName.Text = _currentUser.Name + "'s Scores";
            lblHandicap.Text = "Current Index: " + handicap.CurrentIndex;

            //order scores by date with most recent first
            scores = scores.OrderByDescending(s => s.Date).ToList();

            lstScores.ItemsSource = scores;
            lstScores.ItemTemplate = new DataTemplate(typeof(TextCell));
            lstScores.ItemTemplate.SetBinding(TextCell.TextProperty, "Value");
            lstScores.ItemTemplate.SetBinding(TextCell.DetailProperty, "Date");


            base.OnNavigatedTo(args);
            
        }

    
    }
}
