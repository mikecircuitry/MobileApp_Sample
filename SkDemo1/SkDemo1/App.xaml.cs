using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkDemo1.Pages;
using System.Collections.Generic;
using SkDemo.Models;
using SkDemo1.Helpers;

[assembly: ExportFont("materialdesign.ttf", Alias = "Material")]
namespace SkDemo1
{
    
    public partial class App : Application
    {
        public static List<Project> Projects;
        public static User LoggedInUser;

        public App()
        {
            InitializeComponent();
            if(LoggedInUser == null)
            {
                LoggedInUser = new User
                {
                    Name = "Johnny Test",
                    Email = "JohnnyTest@example.com"
                };
            }

            Projects = new List<Project>();
            MainPage = new LoginPage(); // new MDPage();
           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
