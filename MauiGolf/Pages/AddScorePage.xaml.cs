using MauiGolf.Models;
using MauiGolf.Data;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiGolf.ViewModels;
using MauiGolf.Services;

namespace MauiGolf.Pages
{
    public partial class AddScorePage : ContentPage
    {
        private readonly User _currentUser;
        public AddScorePage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
            _currentUser = vm.CurrentUser;
        
        }

        private async void OnAddScore_Clicked(object sender, EventArgs e)
        {
            var score = new Score
            {
                Value = Convert.ToInt32(ScoreEntry.Text)
            };
            //checking if the date is valid
            if (DateTime.TryParse(DateEntry.Date.ToString(), out DateTime selectedDate))
            {
                score.Date = selectedDate;
            }
            else
            {
                score.Date = DateTime.Now;
            }


            score.Course = CourseEntry.Text;
            score.Rating = Convert.ToSingle(RatingEntry.Text);
            score.Slope = Convert.ToInt32(SlopeEntry.Text);
            score.HandicapId = _currentUser.HandicapId;
            score.PlayerId = _currentUser.Id;
            await App.Database.AddScore(score);
            
            //navigate to scores page
            Application.Current.MainPage = new AuthAppShell(_currentUser);
            
        }

        //Method to find nearby courses using APIService and current location
        private static async Task<List<string>> GetNearbyCourses()
        {
            string radius = "29";
            var location = await Geolocation.GetLocationAsync();
            string latitude = location.Latitude.ToString();
            string longitude = location.Longitude.ToString();
            var courses = await APIService.FindCoursesNearMe(radius, latitude, longitude);
            Debug.WriteLine("Find Courses: " + courses);
            return courses;
        }

        //Method to search selected course and populate tee entries
        private static async Task<CourseDetail> OnCourseSelectionGetDetails(string courseName)
        {
            var courseDetails = await APIService.GetCourseDetailsByName(courseName);
            return courseDetails;
        }

        //Method to populate tee entries
        private static void PopulateTeeEntries(CourseDetail courseDetails)
        {
            
        }
    }
}
