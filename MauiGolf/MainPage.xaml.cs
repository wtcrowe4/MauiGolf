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
        
        public MainPage ()
        {
            
            InitializeComponent();
            OnAppearing();

        }

        protected override async void OnAppearing()
        {
            var db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mauigolf.db3"));
            var currentUser = await db.GetUser(1);
            lblWelcome.Text = $"Hey {currentUser.Name}!";
        }

        


        public async void Btn_Clicked(object sender, EventArgs e)
        {
            var db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mauigolf.db3"));
            var user = await db.GetUser(1);
            var handicap = await db.GetHandicap(1);
            var scores = await db.GetScores(1);
            lblHomeCourse.Text = user.HomeCourse;
            lblHandicap.Text = handicap.CurrentIndex.ToString();
            lstScores.ItemsSource= scores;
            lstScores.ItemTemplate = new DataTemplate(typeof(TextCell));
            lstScores.ItemTemplate.SetBinding(TextCell.TextProperty, "Value");
            lstScores.ItemTemplate.SetBinding(TextCell.DetailProperty, "Date");

            //Collection View
            ScoresCV.ItemsSource = scores;
        }


        private void Logout_Clicked(object sender, EventArgs e)
        {
            //current user = null
            Application.Current.MainPage = new LoginPage();
        }

        
        

        
        
        



    }
}