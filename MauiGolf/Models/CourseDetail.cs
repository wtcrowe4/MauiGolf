using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiGolf.Models
{
        public class CourseDetail
        {
            // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
        
            public List<object> likes { get; set; }
            public string _id { get; set; }
            public string name { get; set; }
            public string phone { get; set; }
            public string website { get; set; }
            public string address { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string zip { get; set; }
            public string country { get; set; }
            public string coordinates { get; set; }
            public string holes { get; set; }
            public string lengthFormat { get; set; }
            public string greenGrass { get; set; }
            public string fairwayGrass { get; set; }
            public List<Scorecard> scorecard { get; set; }
            public List<TeeBox> teeBoxes { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            public int __v { get; set; }
        }

        public class Scorecard
        {
            public int Hole { get; set; }
            public int Par { get; set; }
            public Tees tees { get; set; }
            public int Handicap { get; set; }
        }

        public class TeeBox
        {
            public string tee { get; set; }
            public int slope { get; set; }
            public double handicap { get; set; }
        }

        public class TeeBox1
        {
            public string color { get; set; }
            public int yards { get; set; }
        }

        public class TeeBox2
        {
            public string color { get; set; }
            public int yards { get; set; }
        }

        public class TeeBox3
        {
            public string color { get; set; }
            public int yards { get; set; }
        }

        public class TeeBox4
        {
            public string color { get; set; }
            public int yards { get; set; }
        }

        public class Tees
        {
            public TeeBox1 teeBox1 { get; set; }
            public TeeBox2 teeBox2 { get; set; }
            public TeeBox3 teeBox3 { get; set; }
            public TeeBox4 teeBox4 { get; set; }
        }


    
}
