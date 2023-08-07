using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MauiGolf.Models
{
    public class CourseDetail
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);

        [JsonPropertyName("likes")]
        public List<object> Likes { get; set; }

        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("zip")]
        public string zip { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("coordinates")]
        public string Coordinates { get; set; }

        [JsonPropertyName("holes")]
        public string Holes { get; set; }

        [JsonPropertyName("lengthFormat")]
        public string LengthFormat { get; set; }

        [JsonPropertyName("greenGrass")]
        public string GreenGrass { get; set; }

        [JsonPropertyName("fairwayGrass")]
        public string FairwayGrass { get; set; }

        [JsonPropertyName("scorecard")]
        public List<Scorecard> Scorecard { get; set; }

        [JsonPropertyName("teeBoxes")]
        public List<TeeBox> TeeBoxes { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("__v")]
        public int V { get; set; }
    }

    public class Scorecard
    {
        public int Hole { get; set; }
        public int Par { get; set; }

        [JsonPropertyName("tees")]
        public Tees Tees { get; set; }
        public int Handicap { get; set; }
    }

    public class TeeBox
    {
        [JsonPropertyName("tee")]
        public string Tee { get; set; }

        [JsonPropertyName("slope")]
        public int Slope { get; set; }

        [JsonPropertyName("handicap")]
        public double Handicap { get; set; }
    }

    public class TeeBox1
    {
        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("yards")]
        public int Yards { get; set; }
    }

    public class TeeBox2
    {
        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("yards")]
        public int Yards { get; set; }
    }

    public class TeeBox3
    {
        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("yards")]
        public int Yards { get; set; }
    }

    public class TeeBox4
    {
        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("yards")]
        public int Yards { get; set; }
    }

    public class Tees
    {
        [JsonPropertyName("teeBox1")]
        public TeeBox1 TeeBox1 { get; set; }

        [JsonPropertyName("teeBox2")]
        public TeeBox2 TeeBox2 { get; set; }

        [JsonPropertyName("teeBox3")]
        public TeeBox3 TeeBox3 { get; set; }

        [JsonPropertyName("teeBox4")]
        public TeeBox4 TeeBox4 { get; set; }
        
    }


    
}
