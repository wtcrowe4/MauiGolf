using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using MauiGolf.Models;
using System.Text.Json;


namespace MauiGolf.Services
{
    public class APIService
    {

        
        public static async Task<CourseDetail> GetCourseDetailsByName(string name) {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://golf-course-api.p.rapidapi.com/search?name={name}"),
                Headers =
                    {
                        { "X-RapidAPI-Key", "" },
                        { "X-RapidAPI-Host", "golf-course-api.p.rapidapi.com" },
                    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                
                //turn body into a course detail object
                CourseDetail courseDetail = JsonSerializer.Deserialize<CourseDetail>(body);
                return courseDetail;


            }
        }

    }
}
