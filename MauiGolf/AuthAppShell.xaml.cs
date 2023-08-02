using MauiGolf.Models;
using MauiGolf.Pages;

namespace MauiGolf.Pages
{
    public partial class AuthAppShell : Shell
    {
        public AuthAppShell(User user)
        {
            User _currentUser = user;
            InitializeComponent();
            //make main page the home page and pass it user
            BindingContext = _currentUser;
            Application.Current.MainPage = new MainPage(_currentUser); 
            
            Routing.RegisterRoute("main", typeof(MainPage));
            Routing.RegisterRoute("scores", typeof(ScoresPage));


            
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
