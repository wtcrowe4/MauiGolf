using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiGolf.Models;


namespace MauiGolf.Services
{
    internal class DBService
    {
        static SQLiteAsyncConnection db; 
        public static async Task Init()
        {
            if(db != null)
            {
                return;
            }
            var DBPath = Path.Combine(FileSystem.AppDataDirectory, "mauigolf.db3");
            db = new SQLiteAsyncConnection(DBPath);

            await db.CreateTableAsync<Handicap>();
            await db.CreateTableAsync<Score>();
            await db.CreateTableAsync<User>();
            
            if(await db.Table<User>().CountAsync() == 0)
            {
                Seed();
            };
        }

        public static async void Seed()
        {
            await db.InsertAsync(new User
            {
                Id = 1,
                Name = "Thomas Crowe",
                Email = "tc@email.com",
                Password = "Thomas1234",
                HomeCourse = "Furman University Golf Club",
                HandicapId = 1
            });
            await db.InsertAsync(new Handicap
            {
                Id=1,
                CurrentIndex = 2.3f,
                LowIndex = 0.5f,
                HighIndex = 4.9f,
                RoundsPlayed = 10,
                PlayerId = 1
            });
            await db.InsertAsync(new Score
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
            await db.InsertAsync(new Score
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
            await db.InsertAsync(new Score
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
            await db.InsertAsync(new Score
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
            await db.InsertAsync(new Score
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
            await db.InsertAsync(new Score
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
            await db.InsertAsync(new Score
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
            await db.InsertAsync(new Score
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
            await db.InsertAsync(new Score
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
            await db.InsertAsync(new Score
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
        }

        public static async Task<User> GetUser(string email, string password)
        {
            await Init();
            var user = await db.Table<User>().Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
            return user;
        }

        public static async Task<User> GetUser(int id)
        {
            await Init();
            var user = await db.Table<User>().Where(u => u.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public static async Task<List<Score>> GetScores(int playerId)
        {
            await Init();
            var scores = await db.Table<Score>().Where(s => s.PlayerId == playerId).ToListAsync();
            return scores;
        }

        public static async Task<Handicap> GetHandicap(int playerId)
        {
            await Init();
            var handicap = await db.Table<Handicap>().Where(h => h.PlayerId == playerId).FirstOrDefaultAsync();
            return handicap;
        }

        


       

    }
}
