using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using MauiGolf.Models;
using System.Text.Json;
using System.Diagnostics;

namespace MauiGolf.Services
{
    public class APIService
    {
        
        public static async Task<CourseDetail> GetCourseDetailsByName(string name)
        {
            var httpClientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                {
                    return true;
                }
            };

            var client = new HttpClient(httpClientHandler);
            //var client = new HttpClient();
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
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);

            //turn body into a course detail object
            CourseDetail courseDetail = JsonSerializer.Deserialize<CourseDetail>(body);
            return courseDetail;
        }


        //Get phone's location
        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;
        public async Task<Location> GetCurrentLocation()
        {
            try
            {
                _isCheckingLocation = true;

                GeolocationRequest request = new(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                _cancelTokenSource = new CancellationTokenSource();

                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                if (location != null)
                    Debug.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                return location;
            }
            // Catch one of the following exceptions:
            //   FeatureNotSupportedException
            //   FeatureNotEnabledException
            //   PermissionException
            catch (Exception ex)
            {
                // Unable to get location
                Debug.WriteLine(ex.Message);
                _isCheckingLocation = false;
                return null;
            }
            finally
            {
                _isCheckingLocation = false;
            }
        }
        public void CancelRequest()
        {
            if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
                _cancelTokenSource.Cancel();
        }

        public static async Task<List<string>> FindCoursesNearMe(string rad, string lat, string lon)
        {
            var httpClientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                {
                    return true;
                }
            };
            var client = new HttpClient(httpClientHandler);
            //var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://golf-course-finder.p.rapidapi.com/courses?radius=10&lat=36.56910381018662&lng=-121.95035631683683"),
                Headers =
                {
                    { "X-RapidAPI-Key", "" },
                    { "X-RapidAPI-Host", "golf-course-finder.p.rapidapi.com" },
                },
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);

            //var json = JsonSerializer.Deserialize<JsonElement>(body);
            //List<string> courses = new List<string>();

            //foreach (var course in json.courses)
            //{
            //    courses.Add(course.name);
            //}

            //return courses;
            return null;

        }
    }
}
