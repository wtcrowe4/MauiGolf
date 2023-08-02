using MauiGolf.Models;

namespace MauiGolf.Pages
{
    public partial class HomePage : Shell
    {
        private User _currentUser;
        public HomePage(User user)
        {
            _currentUser = user;
            InitializeComponent();
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
