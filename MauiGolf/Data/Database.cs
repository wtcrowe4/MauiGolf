using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiGolf.Models;
using System.Diagnostics;

namespace MauiGolf.Data
{
    public class Database
    {
        private readonly SQLiteAsyncConnection db;

        public Database(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<User>().Wait();
            db.InsertAsync(new User
            {
                Id = 1,
                Name = "Thomas Crowe",
                Email = "tc@email.com",
                Password = "Thomas1234",
                HomeCourse = "Furman University Golf Club",
                HandicapId = 1
            });
            
            //Seed(db);
            //Debug.WriteLine(dbPath);

            //async void Seed(SQLiteAsyncConnection db)
            //{
            //    await db.InsertAsync(new User
            //    {
            //        Id = 1,
            //        Name = "Thomas Crowe",
            //        Email = "tc@email.com",
            //        Password = "Thomas1234",
            //        HomeCourse = "Furman University Golf Club",
            //        HandicapId = 1
            //    });
            //    await db.InsertAsync(new Handicap
            //    {
            //        Id = 1,
            //        CurrentIndex = 2.3f,
            //        LowIndex = 0.5f,
            //        HighIndex = 4.9f,
            //        RoundsPlayed = 10,
            //        PlayerId = 1
            //    });
            //    await db.InsertAsync(new Score
            //    {
            //        Id = 1,
            //        Value = 72,
            //        Date = DateTime.Now,
            //        Course = "Furman University Golf Club",
            //        Rating = 72.1f,
            //        Slope = 130,
            //        HandicapId = 1,
            //        PlayerId = 1
            //    });
            //    await db.InsertAsync(new Score
            //    {
            //        Id = 2,
            //        Value = 75,
            //        Date = DateTime.Now,
            //        Course = "Furman University Golf Club",
            //        Rating = 72.1f,
            //        Slope = 130,
            //        HandicapId = 1,
            //        PlayerId = 1
            //    });
            //    await db.InsertAsync(new Score
            //    {
            //        Id = 3,
            //        Value = 74,
            //        Date = DateTime.Now,
            //        Course = "Furman University Golf Club",
            //        Rating = 72.1f,
            //        Slope = 130,
            //        HandicapId = 1,
            //        PlayerId = 1
            //    });
            //    await db.InsertAsync(new Score
            //    {
            //        Id = 4,
            //        Value = 73,
            //        Date = DateTime.Now,
            //        Course = "Furman University Golf Club",
            //        Rating = 72.1f,
            //        Slope = 130,
            //        HandicapId = 1,
            //        PlayerId = 1
            //    });
            //    await db.InsertAsync(new Score
            //    {
            //        Id = 5,
            //        Value = 72,
            //        Date = DateTime.Now,
            //        Course = "Furman University Golf Club",
            //        Rating = 72.1f,
            //        Slope = 130,
            //        HandicapId = 1,
            //        PlayerId = 1
            //    });
            //    await db.InsertAsync(new Score
            //    {
            //        Id = 6,
            //        Value = 71,
            //        Date = DateTime.Now,
            //        Course = "Furman University Golf Club",
            //        Rating = 72.1f,
            //        Slope = 130,
            //        HandicapId = 1,
            //        PlayerId = 1
            //    });
            //    await db.InsertAsync(new Score
            //    {
            //        Id = 7,
            //        Value = 70,
            //        Date = DateTime.Now,
            //        Course = "Furman University Golf Club",
            //        Rating = 72.1f,
            //        Slope = 130,
            //        HandicapId = 1,
            //        PlayerId = 1
            //    });
            //    await db.InsertAsync(new Score
            //    {
            //        Id = 8,
            //        Value = 79,
            //        Date = DateTime.Now,
            //        Course = "Furman University Golf Club",
            //        Rating = 72.1f,
            //        Slope = 130,
            //        HandicapId = 1,
            //        PlayerId = 1
            //    });
            //    await db.InsertAsync(new Score
            //    {
            //        Id = 9,
            //        Value = 75,
            //        Date = DateTime.Now,
            //        Course = "Furman University Golf Club",
            //        Rating = 72.1f,
            //        Slope = 130,
            //        HandicapId = 2,
            //        PlayerId = 1
            //    });
            //    await db.InsertAsync(new Score
            //    {
            //        Id = 10,
            //        Value = 77,
            //        Date = DateTime.Now,
            //        Course = "Furman University Golf Club",
            //        Rating = 72.1f,
            //        Slope = 120,
            //        HandicapId = 2,
            //        PlayerId = 1
            //    });
            //}
        }

        //Get User with Id
        public async Task<User> GetUser(int id)
        {
            User user = await db.Table<User>().Where(u => u.Id == id).FirstOrDefaultAsync();
            Debug.WriteLine("GetUser: " + user.Name);
            return user;
        }
    }
}