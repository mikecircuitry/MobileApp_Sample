using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SkDemo1.Pages
{
    public class MDPage : MasterDetailPage
    {
        public MDPage()
        {

            Master = new MenuPage(this);

            Detail =
                new NavigationPage(new CompanyListPage())
                {
                    BackgroundColor = Color.White,
                    BarTextColor = Color.Black,
                };

            MasterBehavior = MasterBehavior.Default;
        }
    }
}