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

        public MainViewModel(User user)
        {
            currentUser = user;
            Debug.WriteLine("MainViewModel User: " + currentUser.Name);
        }
    
    }

 }

