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
            
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(ScoresPage), typeof(ScoresPage));

            
            //This line is causing navigation not to go from Homepage back to MainPage
            Debug.WriteLine("AuthAppShell User: " + _currentUser.Name);
            Current.GoToAsync($"{nameof(HomePage)}", new Dictionary<string, object> { ["CurrentUser"] = _currentUser });
            Current.GoToAsync($"{nameof(MainPage)}", new Dictionary<string, object> { ["CurrentUser"] = _currentUser });
            Current.GoToAsync($"{nameof(ScoresPage)}", new Dictionary<string, object> { ["CurrentUser"] = _currentUser });

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
