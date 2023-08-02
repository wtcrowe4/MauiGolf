using MauiGolf.Data;
using MauiGolf.Models;


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
            var db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mauigolf.db3"));
            var name = NameEntry.Text;
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;
            var homeCourse = HomeCourseEntry.Text;


            var user = new User
            {
                Name = name,
                Email = email,
                Password = password,
                HomeCourse = homeCourse,
            };

            var handicap = new Handicap
            {
                CurrentIndex = 0,
                PlayerId = user.Id
            };

            user.HandicapId = handicap.Id;

            await db.CreateUser(user, handicap);
            
            Application.Current.MainPage = new LoginPage();
        }
    }
}
