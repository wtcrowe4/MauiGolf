using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiGolf.Models
{
    public class Score
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public string Course { get; set; }
        public float Rating { get; set; }
        public int Slope { get; set; }
        public int HandicapId { get; set; }
        public int PlayerId { get; set; }
    }
}
