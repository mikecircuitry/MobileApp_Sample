using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Markup;
using Xamarin.Forms;
using SkDemo.Models;

namespace SkDemo1.Pages
{
    public class LoginPage : ContentPage
    {
        public LoginPage()
        {
            BuildUI();
        }

        void BuildUI()
        {
            BackgroundColor = App.Colors.DarkBlue;
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Spacing = 30,
                Padding = new Thickness(15,0),

                Children = {
                    new Image { Source = App.ImageResource.SkookumLogo,
                                                    Aspect = Aspect.AspectFit,
                                                    HeightRequest = 200},

                    new Label { Text = "SKOOKUM", 
                                TextColor = Color.White, 
                                FontAttributes = FontAttributes.Bold, 
                                FontSize = 30,
                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                },

                    new Entry { Placeholder = "Email", 
                                PlaceholderColor = App.Colors.LightOrange, BackgroundColor = App.Colors.White,
                                TextColor = App.Colors.DarkBlue},
                    
                    new Entry { Placeholder = "Password",
                                PlaceholderColor = App.Colors.LightOrange,  BackgroundColor = App.Colors.White,
                                TextColor = App.Colors.DarkBlue},

                    new Button { Text = "Login" ,
                                TextColor = App.Colors.White,
                                BackgroundColor = App.Colors.DarkOrange,
                                Margin = new Thickness(20),
                                CornerRadius = 20}.Invoke( b => b.Clicked += btnLogin_Clicked),

                    new Label { Text = "A Global Logic Company",
                                TextColor = Color.White,
                                Margin = new Thickness(0,20,0,0),
                                FontAttributes = FontAttributes.Bold,
                                FontSize = 14,
                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                VerticalOptions = LayoutOptions.CenterAndExpand }

                }
            };
        }

        public void btnLogin_Clicked(object sender, EventArgs e)
        {
            App.LoggedInUser = new User
            {
                Name = "Johnny Test",
                Email = "JohnnyTest@example.com"
            };

            App.Current.MainPage = new MDPage();
        }
    }
}