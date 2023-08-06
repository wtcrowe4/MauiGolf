using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiGolf.Models
{
    public class Handicap
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public float CurrentIndex { get; set; }
        public float LowIndex { get; set; }
        public float HighIndex { get; set; }
        public int RoundsPlayed { get; set; } = 0;
        [ForeignKey("PlayerId")]
        public int PlayerId { get; set; }

        //Add a method to calculate the handicap index
        //Add a method to calculate the low index
        //Add a method to calculate the high index
        //Add a method to calculate the rounds played
        public async Task<int> CalculateRoundsPlayed()
        {
            var rounds = await App.Database.GetScores(PlayerId);
            return rounds.Count;
        }
        
        //Set playerid to the current user's id

    }
}
