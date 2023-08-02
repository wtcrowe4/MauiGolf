using MauiGolf.Models;
using MauiGolf.Pages;

namespace MauiGolf
{
    public partial class AuthAppShell : Shell
    {
        public AuthAppShell(User user)
        {
            
            InitializeComponent();
            

            //Navigate to MainPage by default passing it user object
            //Ensure MainPage is defined in AppShell.xaml
            
            Application.Current.MainPage = new MainPage(user);               
        
            
           
           
            
            
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
