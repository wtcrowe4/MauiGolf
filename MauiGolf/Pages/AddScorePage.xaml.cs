using MauiGolf.Models;
using MauiGolf.Data;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiGolf.ViewModels;


namespace MauiGolf.Pages
{
    public partial class AddScorePage : ContentPage
    {
        private User _currentUser;
        public AddScorePage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
            _currentUser = vm.CurrentUser;
        
        }

        private async void OnAddScore_Clicked(object sender, EventArgs e)
        {
            var score = new Score();
            score.Value = Convert.ToInt32(ScoreEntry.Text);
            //just using current date for now
            score.Date = DateTime.Now;
            score.PlayerId = _currentUser.Id;
            await App.Database.AddScore(score);
            //navigate to scores page
            await Shell.Current.GoToAsync("ScoresPage");
        }
    }
}
