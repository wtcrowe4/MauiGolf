using MauiGolf.Models;
using System.Diagnostics;
using MauiGolf.Data;
using MauiGolf.Services;
using SQLite;
using MauiGolf.Pages;

namespace MauiGolf
{
    public partial class MainPage : ContentPage
    {
        private User _currentUser;   
        public MainPage (User user)
        {
            _currentUser = user;
            InitializeComponent();
            OnAppearing();
           

        }

        protected override void OnAppearing()
        {
            lblWelcome.Text = $"Welcome {_currentUser.Name}!";
        }




        public async void Btn_Clicked(object sender, EventArgs e)
        {
            //var db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mauigolf.db3"));
            //var user = await db.GetUser(1);
            //var handicap = await db.GetHandicap(1);
            //var scores = await db.GetScores(1);

            var handicap = await App.Database.GetHandicap(_currentUser.HandicapId);
            var scores = await App.Database.GetScores(_currentUser.Id);
            lblHomeCourse.Text = _currentUser.HomeCourse;
            lblHandicap.Text = handicap.CurrentIndex.ToString();
            lstScores.ItemsSource= scores;
            lstScores.ItemTemplate = new DataTemplate(typeof(TextCell));
            lstScores.ItemTemplate.SetBinding(TextCell.TextProperty, "Value");
            lstScores.ItemTemplate.SetBinding(TextCell.DetailProperty, "Date");

            //Collection View
            ScoresCV.ItemsSource = scores;
        }


        public void Logout_Clicked(object sender, EventArgs e)
        {
            
         
            Application.Current.MainPage = new LoginPage();
            _currentUser = null;

        }

        
        

        
        
        



    }
}