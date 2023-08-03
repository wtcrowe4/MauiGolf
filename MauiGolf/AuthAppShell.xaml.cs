using MauiGolf.Models;
using MauiGolf.Pages;
using System.Diagnostics;


namespace MauiGolf
{
    public partial class AuthAppShell : Shell
    {
        private readonly User _currentUser;

        public AuthAppShell(User user)
        {
            _currentUser = user;
            InitializeComponent();
            Debug.WriteLine("AuthAppShell: " + _currentUser.Name);
            Application.Current.MainPage = new MainPage(_currentUser);
            
            
            //MainPage is rendering twice, first time with user, second time without user
            //Navigate to MainPage by default passing it user object
            
            //MainPage mainPage = new MainPage(_currentUser); 
            //Debug.WriteLine("AuthAppShell: " + _currentUser.Name);
            ////Application.Current.MainPage = new MainPage(_currentUser);     
            //Application.Current.MainPage = mainPage;
            
           
        
        }

        // UnComment the below method to handle Shell Menu item click event
        // And ensure appropriate page definitions are available for it work as expected
        /*
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Current.GoToAsync("//login");
        }
        */
    }
}
