using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Markup;
using SkDemo1.ViewModels;
using Autofac;

namespace SkDemo1.Pages
{
    public class NewProjectPage : ContentPage
    {
        private NewProjectViewModel _viewModel;
        private Color textColor = Device.RuntimePlatform == Device.iOS ? Color.Black : App.Colors.White;

        public NewProjectPage()
        {
            _viewModel = App.Container.Resolve<NewProjectViewModel>();

            BindingContext = _viewModel;
            BuildUI();
        }

        void BuildUI()
        {
            Title = "New Client";
            BackgroundColor = App.Colors.DarkBlue;
          
            
            Content = new StackLayout
            {
                Padding = new Thickness(15),
                Spacing = 25,
                
                Children = {
                    new Label { Text = "Please enter the information below to add a new client", FontSize = 18, TextColor = App.Colors.White },

                  new Entry { Placeholder = "Company Name",
                                PlaceholderColor = App.Colors.LightOrange,
                                TextColor =textColor,
                        }.Bind(Entry.TextProperty, nameof(_viewModel.CompanyName)),

                    new Entry { Placeholder = "Project Name",
                                PlaceholderColor = App.Colors.LightOrange,
                                TextColor =textColor, 
                        }.Bind(Entry.TextProperty, nameof(_viewModel.ProjectName)),

                    new Editor { Placeholder = "Project Description",
                                PlaceholderColor = App.Colors.LightOrange,
                                TextColor = textColor,
                                HeightRequest = 200
                        }.Bind(Editor.TextProperty,nameof(_viewModel.Description)),

                    new Button{ Text = "Save", BackgroundColor = App.Colors.DarkOrange, 
                                TextColor = App.Colors.White,
                                CornerRadius = 20
                    }.Bind(Button.CommandProperty, nameof(_viewModel.SaveNewProjectCommand))
                    .Invoke( b => b.Clicked += button_clicked),
                }
            };
        }

        public async void button_clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new CompanyListPage());
            await Navigation.PopAsync();
        }
      
    }
}