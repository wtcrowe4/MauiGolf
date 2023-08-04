using MauiGolf.Models;
using MauiGolf.Pages;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;


namespace MauiGolf.ViewModels
{
    [QueryProperty(nameof(CurrentUser), nameof(CurrentUser))]
    public partial class MainViewModel : ObservableObject 
    {
        [ObservableProperty]
        User currentUser;

        [ObservableProperty]
        List<Score> scores;

        [ObservableProperty]
        Handicap handicap;

        public MainViewModel(User user)
        {
            currentUser = user;
            Debug.WriteLine("MainViewModel User: " + currentUser.Name);
            //var data = GetCurrentUserData(currentUser);
            //scores = data.Result.Item1;
            //handicap = data.Result.Item2;



        }

        private async Task<(List<Score>, Handicap)> GetCurrentUserData(User user)
        {
            var handicap = await App.Database.GetHandicap(user.Id);
            var scores = await App.Database.GetScores(user.Id);
            return (scores, handicap);
        }
    
    }

 }

