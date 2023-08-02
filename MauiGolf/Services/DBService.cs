using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiGolf.Models;
using MauiGolf.Data;


namespace MauiGolf.Services
{
    public class DBService
    {
        //Login Functionality
        public static User Login(string email, string password)
        {
            var db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mauigolf.db3"));
            var user = db.GetUser(email);
            if(user != null && user.Password == password)
            {
                return user;
            }
            return null;
        }

    
    }

       

}

