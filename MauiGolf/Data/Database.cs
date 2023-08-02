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
            
            //Seeding the database with some data
            if (db == null)
            {
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

                db.CreateTableAsync<Score>().Wait();
                db.InsertAsync(new Score
                {
                    Id = 1,
                    Value = 72,
                    Date = DateTime.Now,
                    Course = "Furman University Golf Club",
                    Rating = 72.1f,
                    Slope = 130,
                    HandicapId = 1,
                    PlayerId = 1
                });
                db.InsertAsync(new Handicap
                {
                    Id = 11,
                    CurrentIndex = 2.3f,
                    LowIndex = 0.5f,
                    HighIndex = 4.9f,
                    RoundsPlayed = 10,
                    PlayerId = 1
                });
                db.InsertAsync(new Score
                {
                    Id = 12,
                    Value = 72,
                    Date = DateTime.Now,
                    Course = "Furman University Golf Club",
                    Rating = 72.1f,
                    Slope = 130,
                    HandicapId = 1,
                    PlayerId = 1
                });
                db.InsertAsync(new Score
                {
                    Id = 2,
                    Value = 75,
                    Date = DateTime.Now,
                    Course = "Furman University Golf Club",
                    Rating = 72.1f,
                    Slope = 130,
                    HandicapId = 1,
                    PlayerId = 1
                });
                db.InsertAsync(new Score
                {
                    Id = 3,
                    Value = 74,
                    Date = DateTime.Now,
                    Course = "Furman University Golf Club",
                    Rating = 72.1f,
                    Slope = 130,
                    HandicapId = 1,
                    PlayerId = 1
                });
                db.InsertAsync(new Score
                {
                    Id = 4,
                    Value = 73,
                    Date = DateTime.Now,
                    Course = "Furman University Golf Club",
                    Rating = 72.1f,
                    Slope = 130,
                    HandicapId = 1,
                    PlayerId = 1
                });
                db.InsertAsync(new Score
                {
                    Id = 5,
                    Value = 72,
                    Date = DateTime.Now,
                    Course = "Furman University Golf Club",
                    Rating = 72.1f,
                    Slope = 130,
                    HandicapId = 1,
                    PlayerId = 1
                });
                db.InsertAsync(new Score
                {
                    Id = 6,
                    Value = 71,
                    Date = DateTime.Now,
                    Course = "Furman University Golf Club",
                    Rating = 72.1f,
                    Slope = 130,
                    HandicapId = 1,
                    PlayerId = 1
                });
                db.InsertAsync(new Score
                {
                    Id = 7,
                    Value = 70,
                    Date = DateTime.Now,
                    Course = "Furman University Golf Club",
                    Rating = 72.1f,
                    Slope = 130,
                    HandicapId = 1,
                    PlayerId = 1
                });
                db.InsertAsync(new Score
                {
                    Id = 8,
                    Value = 79,
                    Date = DateTime.Now,
                    Course = "Furman University Golf Club",
                    Rating = 72.1f,
                    Slope = 130,
                    HandicapId = 1,
                    PlayerId = 1
                });
                db.InsertAsync(new Score
                {
                    Id = 9,
                    Value = 75,
                    Date = DateTime.Now,
                    Course = "Furman University Golf Club",
                    Rating = 72.1f,
                    Slope = 130,
                    HandicapId = 2,
                    PlayerId = 1
                });
                db.InsertAsync(new Score
                {
                    Id = 10,
                    Value = 77,
                    Date = DateTime.Now,
                    Course = "Furman University Golf Club",
                    Rating = 72.1f,
                    Slope = 120,
                    HandicapId = 2,
                    PlayerId = 1
                });

                db.CreateTableAsync<Handicap>().Wait();
                db.InsertAsync(new Handicap
                {
                    Id = 1,
                    CurrentIndex = 2.3f,
                    LowIndex = 0.5f,
                    HighIndex = 4.9f,
                    RoundsPlayed = 10,
                    PlayerId = 1
                });
            }

            

          
        }

        //Get All Users
        public async Task<List<User>> GetUsers()
        {
            List<User> users = await db.Table<User>().ToListAsync();
            Debug.WriteLine("GetUsers: " + users.Count);
            return users;
        }

        //Get User with Id
        public async Task<User> GetUser(int id)
        {
            User user = await db.Table<User>().Where(u => u.Id == id).FirstOrDefaultAsync();
            Debug.WriteLine("GetUser: " + user.Name);
            return user;
        }
        //Get User with Email
        public User GetUser(string email)
        {
            User user = db.Table<User>().Where(u => u.Email == email).FirstOrDefaultAsync().Result;
            Debug.WriteLine("GetUser: " + user.Name);
            return user;
        }

        //Get Handicap with Player Id
        public async Task<Handicap> GetHandicap(int playerId)
        {
            Handicap handicap = await db.Table<Handicap>().Where(h => h.PlayerId == playerId).FirstOrDefaultAsync();
            Debug.WriteLine("GetHandicap: " + handicap.CurrentIndex);
            return handicap;
        }

        //Get Scores with Player Id
        public async Task<List<Score>> GetScores(int playerId)
        {
            List<Score> scores = await db.Table<Score>().Where(s => s.PlayerId == playerId).ToListAsync();
            Debug.WriteLine("GetScores: " + scores.Count);
            return scores;
        }
    
        //Create New User
        public async Task<(int,int)> CreateUser(User user, Handicap handicap)
        {
            int playerId = await db.InsertAsync(user);
            int handicapId = await db.InsertAsync(handicap);


            Debug.WriteLine("CreatedUser: " + playerId);
            Debug.WriteLine("CreatedHandicap: " + handicapId);
            return (playerId, handicapId);
        }
    }
}