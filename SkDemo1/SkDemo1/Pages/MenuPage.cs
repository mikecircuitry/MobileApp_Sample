using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Markup;
using static Xamarin.Forms.Markup.GridRowsColumns;
using SkDemo1.Models;
using SkDemo1.Helpers;

namespace SkDemo1.Pages
{
    public class MenuPage : ContentPage
    {
        private Xamarin.Forms.MasterDetailPage _parentPage;
        public MenuPage(Xamarin.Forms.MasterDetailPage parentPage)
        {
            _parentPage = parentPage;
            BuildUI();
        }

        enum Row { Header, Title, Content }
        enum Col { Content }
        void BuildUI()
        {
            IconImageSource = new FontImageSource { Glyph = Icons.Material.Menu, Color = Color.Black, FontFamily = Icons.Material.FontFamily, Size = 28 };
            BackgroundColor = App.Colors.DarkOrange;
            this.Padding = new Thickness(0);
            Title = "Project  App";

            Content = new Grid
            {
                BackgroundColor = App.Colors.DarkOrange,
                RowDefinitions = Rows.Define(
                    (Row.Header, GridLength.Auto),
                    (Row.Title, GridLength.Auto),
                    (Row.Content, GridLength.Auto)),

                Children =
                {
                   new Frame
                   {
                       BackgroundColor = App.Colors.White,
                       Content =   new Image { Source = App.ImageResource.SkookumLogo,
                                                    Aspect = Aspect.AspectFit,
                                                    HeightRequest = 200}
                   }.Row(Row.Header).Column(Col.Content),

                   new StackLayout
                   {
                       Orientation = StackOrientation.Vertical,
                       Padding = new Thickness(10, 15),
                       Children =
                       {
                             new Label { Text = App.LoggedInUser.Name,
                                FontSize = 23,
                                FontAttributes = FontAttributes.Bold,
                                TextColor = App.Colors.White
                                },

                             new Label { Text = App.LoggedInUser.Email, FontSize = 15, TextColor = App.Colors.White}
                       }
                   }.Row(Row.Title).Column(Col.Content),
                  

                    new Xamarin.Forms.ListView { ItemsSource = SkookumMenuItem.GetMenus(),
                        BackgroundColor = Color.Transparent,
                        ItemTemplate = new DataTemplate(() => 
                        {
                            return new ViewCell
                            {
                                View = new StackLayout
                                {
                                    Orientation = StackOrientation.Horizontal,
                                    Spacing = 40,
                                    Padding = new Thickness(30,0,0,0),
                                    Children =
                                    {
                                        new Label { FontFamily = Icons.Material.FontFamily,
                                                    TextColor = App.Colors.White,
                                                    FontSize = 32,
                                                    HorizontalOptions = LayoutOptions.Center
                                        }.Bind(Label.TextProperty,"Icon"),

                                        new Label { TextColor = App.Colors.White,
                                          FontSize = 25,
                                                    HorizontalOptions = LayoutOptions.Center
                                        }.Bind(Label.TextProperty, "Name")
                                    }
                                }
                            };
                        })
                    }.Invoke(lv => lv.ItemSelected += ListviewItem_Tapped)
                    .Row(Row.Content).Column(Col.Content)

                }
            };
        }

        public void ListviewItem_Tapped(object sender, EventArgs e)
        {
            var lv = (Xamarin.Forms.ListView)sender;
            var selectedItem = (SkookumMenuItem)lv.SelectedItem;

            ((Xamarin.Forms.ListView)sender).SelectedItem = null;

            if (selectedItem == null)
                return;

            _parentPage.Detail = new Xamarin.Forms.NavigationPage(selectedItem.AppPage)
            {
                IconImageSource = new FontImageSource { Glyph = Icons.Material.Menu, Color = Color.Black, FontFamily = Icons.Material.FontFamily, Size = 60 },
                BarTextColor = Color.Black
            };

            _parentPage.IsPresented = false;
        }

        public void btnNewCompany_Clicked(object sender, EventArgs e)
        {
            _parentPage.Detail = new Xamarin.Forms.NavigationPage(new NewProjectPage());
            _parentPage.IsPresented = false;
        }
    }
}