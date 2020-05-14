using LiveSharp.Runtime;
using SkDemo1.Models;
using SkDemo1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace SkDemo1.Pages
{
    public class CompanyListPage : ContentPage
    {
        private CompanyListViewModel vm;
        private List<Project> _projects;
        public CompanyListPage()
        {
            vm = new CompanyListViewModel();
            Task.Run(async () => { await vm.LoadProjects(); });

            BindingContext = vm;

            BuildUI();
        }

        void BuildUI()
        {
            Title = "Company List ";
            BackgroundColor = App.Colors.DarkBlue;

            IconImageSource = new FontImageSource { Glyph = Icons.Material.Menu, FontFamily = Icons.Material.FontFamily, Size = 60 };

            Content = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = GridLength.Auto}
                },
                 ColumnDefinitions = new ColumnDefinitionCollection
                 {
                     new ColumnDefinition { Width = GridLength.Auto}
                 },


                Children ={
                    new ListView
                    {
                        HasUnevenRows = true,
                        SeparatorVisibility = SeparatorVisibility.None,
                        BackgroundColor = Color.FromHex("064971"),

                        ItemTemplate = new DataTemplate( () => {
                           return new ViewCell{ View =
                               new Frame
                               {
                                   Margin = new Thickness(15,10),
                                   CornerRadius = 5,

                                   Content = new StackLayout {
                                   BackgroundColor = Color.White,
                                   //Spacing = 30,
                                   // Padding = new Thickness(15),
                                   Children = {
                                    new Label{TextColor = Color.Black }.Bind(Label.TextProperty, "Company")
                                   }
                                }
                               }
                           };
                        })
                    }.Bind(ListView.ItemsSourceProperty, nameof(vm.Projects))
                    .Row(0).Column(0),

                    new Button
                    {
                        FontFamily = Icons.Material.FontFamily,
                        Text = Icons.Material.Plus,
                          HorizontalOptions = LayoutOptions.End,
                           VerticalOptions = LayoutOptions.End,
                           Margin = new Thickness(0,0,30,30),
                           BackgroundColor = Color.FromHex("eda42e"),
                           TextColor = Color.White,
                           FontSize = 35,
                           CornerRadius = 35,
                           WidthRequest = 70, HeightRequest = 70
                    }.Invoke( b => b.Clicked += btnAddCompany_Clicked)
                    .Row(0).Column(0)
                 }
            };
        }

        private async void btnAddCompany_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewProjectPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}