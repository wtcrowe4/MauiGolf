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
            lblName.Text = user.Name;
            lblHomeCourse.Text = user.HomeCourse;
        }


        
        

        
        
        



    }
}