using MauiGolf.Models;
using System.Diagnostics;
using MauiGolf.Data;
using MauiGolf.Services;
using SQLite;

namespace MauiGolf
{
    public partial class MainPage : ContentPage
    {
        public MainPage ()
        {
            InitializeComponent ();
            
        }

        public async void Btn_Clicked(object sender, EventArgs e)
        {
            var db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mauigolf.db3"));
            var user = await db.GetUser(1);
            var handicap = await db.GetHandicap(1);
            var scores = await db.GetScores(1);
            lblName.Text = user.Name;
            lblHomeCourse.Text = user.HomeCourse;
            lblHandicap.Text = handicap.CurrentIndex.ToString();
            lstScores.ItemsSource= scores;
            lstScores.ItemTemplate = new DataTemplate(typeof(TextCell));
            lstScores.ItemTemplate.SetBinding(TextCell.TextProperty, "Value");
            lstScores.ItemTemplate.SetBinding(TextCell.DetailProperty, "Date");
        }


        
        

        
        
        



    }
}