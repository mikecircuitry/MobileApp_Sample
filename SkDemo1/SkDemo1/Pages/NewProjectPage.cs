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

        private Color textColor;

        public NewProjectPage()
        {
            _viewModel = App.Container.Resolve<NewProjectViewModel>();
            _viewModel.Navigation = Navigation;

            BindingContext = _viewModel;
            BuildUI();
        }

        void BuildUI()
        {
            Title = "New Client";
            BackgroundColor = App.Colors.DarkBlue;

            //TODO: Fix color for both platforms
            textColor = Color.Black;

            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Padding = new Thickness(15),
                    Spacing = 25,

                    Children = {
                    new Label { Text = "Please enter the information below to add a new client", FontSize = 18, TextColor = App.Colors.White },

                  //new Entry { Placeholder = "Company Name",
                  //              PlaceholderColor = App.Colors.LightOrange,
                  //              TextColor =textColor,
                  //      }.Bind(Entry.TextProperty, nameof(_viewModel.CompanyName)),

                    EntryFormWithValidations("Company Name", nameof(_viewModel.CompanyName), nameof(_viewModel.CompanyNameValidation)),

                  new Entry { Placeholder = "First Name",
                                PlaceholderColor = App.Colors.LightOrange,
                                TextColor = textColor,
                        }.Bind(Entry.TextProperty, nameof(_viewModel.FirstName)),

                  new Entry { Placeholder = "Last Name",
                                PlaceholderColor = App.Colors.LightOrange,
                                TextColor = textColor,
                        }.Bind(Entry.TextProperty, nameof(_viewModel.LastName)),

                  //TODO: Add contact email
                 

                    new Entry { Placeholder = "Project Name",
                                PlaceholderColor = App.Colors.LightOrange,
                                TextColor = textColor,
                        }.Bind(Entry.TextProperty, nameof(_viewModel.ProjectName)),

                    new DatePicker { TextColor = textColor,
                                    }.Bind(DatePicker.DateProperty, nameof(_viewModel.ProjectDate)),

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
                }
            };
        }

        StackLayout EntryFormWithValidations(string placeHolderText, string value, string validator)
        {
            return new StackLayout
            {
                Children =
                {
                     new Entry { Placeholder = placeHolderText,
                                PlaceholderColor = App.Colors.LightOrange,
                                TextColor =textColor,
                        }.Bind(Entry.TextProperty, value, mode: BindingMode.TwoWay),

                      new Label { FontSize = 12,
                                 TextColor = App.Colors.Yellow,
                        }.Bind(Label.TextProperty,validator, mode: BindingMode.TwoWay),
                }
            };
        }

        public async void button_clicked(object sender, EventArgs e)
        {
            //await Navigation.PopAsync();
        }

    }
}