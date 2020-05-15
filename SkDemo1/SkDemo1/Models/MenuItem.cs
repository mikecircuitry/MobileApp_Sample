using SkDemo1.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SkDemo1.Models
{
    public class SkookumMenuItem
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public Page AppPage { get; set; }

        public static List<SkookumMenuItem> GetMenus() => new List<SkookumMenuItem>()
        {
            new SkookumMenuItem{ Icon = Icons.Material.Home, Name = "Home", AppPage = new CompanyListPage() },
            new SkookumMenuItem { Icon = Icons.Material.Logout, Name = "Log Out", AppPage = new LoginPage()}

        };
    }

   
}
