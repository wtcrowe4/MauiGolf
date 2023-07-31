using System;
using System.Collections.Generic;
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
        public int RoundsPlayed { get; set; }
        public List<Score> Scores { get; set; }
        public int PlayerId { get; set; }

        //Add a method to calculate the handicap index
        
    }
}
