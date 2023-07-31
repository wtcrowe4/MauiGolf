using AndroidX.Core.Content.Resources;
using MauiGolf.Models;
using MauiGolf.Services;
using System.Diagnostics;

namespace MauiGolf
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();

            
            
            //lblName.Text = GetUser().Result.Name;
            //lblHomeCourse.Text = GetUser().Result.HomeCourse;
            //lblHandicap.Text = GetHandicap().Result.CurrentIndex.ToString();
            //lstScores.ItemsSource = GetScores().Result;

        }

        public void Btn_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Button Clicked");
            var name = "Thomas Crowe";
            //var homeCourse = GetUser().Result.HomeCourse;
            //var handicap = GetHandicap().Result.CurrentIndex.ToString();
            //List<Score> Scores = GetScores().Result;
            

            Debug.WriteLine(name);
            //Debug.WriteLine(homeCourse);
            //Debug.WriteLine(handicap);
            //Debug.WriteLine(scores);

            lblName.Text = name;
            //lblHomeCourse.Text = homeCourse;
            //lblHandicap.Text = handicap;
            //lstScores.ItemsSource = scores;
        }

        static async Task<User> GetUser()
        {
           User user = await DBService.GetUser(1);
           return user;
        }

        static async Task<Handicap> GetHandicap()
        {
            Handicap handicap = await DBService.GetHandicap(1);
            return handicap;
        }

        static async Task<List<Score>> GetScores()
        {
            List<Score> scores = await DBService.GetScores(1);
            return scores;
        }
     



    }
}