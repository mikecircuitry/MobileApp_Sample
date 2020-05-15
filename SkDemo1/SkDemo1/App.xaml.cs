using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkDemo1.Pages;
using System.Collections.Generic;
using SkDemo.Models;
using SkDemo1.Helpers;
using SkDemo1.Configuration;

[assembly: ExportFont("materialdesign.ttf", Alias = "Material")]
namespace SkDemo1
{
    
    public partial class App : Application
    {
       

        public App()
        {
            InitializeComponent();
            Container = IoCContainer.Initialize();
           
            MainPage = new LoginPage();
           
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
