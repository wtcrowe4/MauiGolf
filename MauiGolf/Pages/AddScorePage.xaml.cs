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
            //checking if the date is valid
            DateTime selectedDate;
            if (DateTime.TryParse(DateEntry.Date.ToString(), out selectedDate))
            {
                score.Date = selectedDate;
            }
            else
            {
                score.Date = DateTime.Now;
            }


            score.Course = CourseEntry.Text;
            score.Rating = Convert.ToSingle(RatingEntry.Text);
            score.Slope = Convert.ToInt32(SlopeEntry.Text);
            score.HandicapId = _currentUser.HandicapId;
            score.PlayerId = _currentUser.Id;
            await App.Database.AddScore(score);
            
            //navigate to scores page
            Application.Current.MainPage = new AuthAppShell(_currentUser);
            
        }
    }
}
