using SkDemo.Models;
using SkDemo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SkDemo1.Pages
{
    public class CompanyDetailsPage : ContentPage
    {
        private readonly Project _viewModel;
        public CompanyDetailsPage(Project project)
        {
            _viewModel = project;
            BuildUI();
        }

        void BuildUI()
        {
            BackgroundColor = App.Colors.DarkBlue;
            Title = $"{_viewModel.Company} Details";

            Content = new ScrollView
            {
                Padding = new Thickness(15),
                Content = new StackLayout
                {
                    Spacing = 25,
                    Children =
                    {
                        TitleSection("Company", _viewModel.Company),
                        TitleSection("Point of Contact", $"{_viewModel.FirstName } {_viewModel.LastName}"),
                        TitleSection("Email", _viewModel.Email),
                        TitleSection("Project Date", _viewModel.ProjectDate.ToShortDateString()),
                        TitleSection("Project Name", _viewModel.Name),
                        TitleSection("Project Descriptions", _viewModel.Description)
                    }
                }
            };
        }

        StackLayout TitleSection(string title, string value)
        {
            return new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 0,

                Children =
                {
                     new Label { Text = title,
                                    FontSize = 15,
                                    TextColor = App.Colors.LightOrange},

                    new Label{ Text = value,
                                FontSize = 20,
                                TextColor = App.Colors.White},
                }
            };
        }
    }
}