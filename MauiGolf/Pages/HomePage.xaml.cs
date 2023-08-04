using MauiGolf.Services;
using MauiGolf.Models;
using MauiGolf.Data;
using System.Diagnostics;
using MauiGolf.ViewModels;

namespace MauiGolf.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage(MainViewModel viewModel)
        {
            
            InitializeComponent();

            BindingContext = viewModel;
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            
        }
        
        
    }
}
