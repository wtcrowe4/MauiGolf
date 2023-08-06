using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiGolf.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string HomeCourse { get; set; }
        public int HandicapId { get; set; }
        
        [ForeignKey("HandicapId")]
        public Handicap Handicap { get ; set; }

        //Get the scores where playerid = this.id
        public List<Score> Scores { get; set; } 

        public IEnumerable<Score> GetScores()
        {
            return Scores.Where(s => s.PlayerId == this.Id);
        }

        
    }
}
