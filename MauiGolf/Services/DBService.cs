using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiGolf.Models;
using MauiGolf.Data;
using MauiGolf.Pages;


namespace MauiGolf.Services
{
    public class DBService
    {
        //Login Functionality
        public async static Task<User> Login(string email, string password)
        {
            var db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mauigolf.db3"));
            var user = await db.GetUser(email);

            if(user != null && user.Password == password) return user;
            
            else if(user == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email doesn't match one in our database please register to continue.", "Ok");
                return null;
            } 
            else if(user.Password != password)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Password is incorrect please try again.", "Ok");
                return null;
            }
            
        }

        //Register Functionality
        public async static Task<(User, Handicap)> Register(string name, string email, string password, string homeCourse)
        {
            var db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mauigolf.db3"));
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

            App.Current.MainPage = new LoginPage();
            return (user, handicap);
        }

    
    }

       

}

