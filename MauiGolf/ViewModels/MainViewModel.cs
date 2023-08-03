using MauiGolf.Models;
using MauiGolf.Pages;
using System.Diagnostics;


namespace MauiGolf.ViewModels
{
    public partial class MainViewModel
    {
        public readonly User _currentUser;

        public MainViewModel(User user)
        {
            _currentUser = user;
            Debug.WriteLine("MainViewModel User: " + _currentUser.Name);
        }
    }

 }

