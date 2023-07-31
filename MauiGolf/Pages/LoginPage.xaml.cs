﻿using MauiGolf.Services;
using MauiGolf.Models;
using MauiGolf.Data;
using System.Diagnostics;

namespace MauiGolf.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        //Login Functionality
        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            var db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mauigolf.db3"));
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;
            
            var success = DBService.Login(email, password);
            if (success)
            {
                Debug.WriteLine("Login Successful");
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                DisplayAlert("Error", "Invalid Email or Password", "Ok");
            }
            

        }

        

        
    }
}