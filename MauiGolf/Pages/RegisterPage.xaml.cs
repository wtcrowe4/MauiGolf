using MauiGolf.Data;
using MauiGolf.Models;
using MauiGolf.Services;
using MauiGolf.ViewModels;

namespace MauiGolf.Pages
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        //Register Functionality
        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            //var db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mauigolf.db3"));
            var name = NameEntry.Text;
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;
            var homeCourse = HomeCourseEntry.Text;

            var newUser = new User();
            var newHandicap = new Handicap();

            (newUser, newHandicap) = await DBService.Register(name, email, password, homeCourse);

            var mainViewModel = new MainViewModel(newUser);

            Application.Current.MainPage = new AuthAppShell(newUser);
            
        }
    }
}
