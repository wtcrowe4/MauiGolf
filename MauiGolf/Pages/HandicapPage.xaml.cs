using MauiGolf.Models;
using MauiGolf.ViewModels;
using MauiGolf.Data;

namespace MauiGolf.Pages
{
    public partial class HandicapPage : ContentPage
    {
        private readonly User _currentUser;
        public HandicapPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
            _currentUser = vm.CurrentUser;
        }

        protected async override void OnNavigatedTo(NavigatedToEventArgs args)
        {
           
            var handicap = await App.Database.GetHandicap(_currentUser.Id);
            CurIndexVal.Text = handicap.CurrentIndex.ToString();
            LowIndexVal.Text = handicap.LowIndex.ToString();
            HighIndexVal.Text = handicap.HighIndex.ToString();
            var roundsCountTask = handicap.CalculateRoundsPlayed();
            var roundsCount = await roundsCountTask;
            RoundsPlayedVal.Text = roundsCount.ToString();
            base.OnNavigatedTo(args);
        }
    }
}
