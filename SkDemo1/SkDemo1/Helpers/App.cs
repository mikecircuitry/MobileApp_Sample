using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SkDemo1
{
    public partial class App
    {
        public static class ImageResource
        {
            //public readonly static string SkookumLogo = "SkDemo1.Assets.Images.skookum_logo.png";
            public readonly static ImageSource SkookumLogo = ImageSource.FromResource("SkDemo1.Assets.Images.skookum_logo.png");

        }

        public static class Colors
        {
            public readonly static Color DarkBlue = Color.FromHex("084367");
            public readonly static Color DarkOrange = Color.FromHex("e05e2a");
            public readonly static Color LightOrange = Color.FromHex("eda42e");
            public readonly static Color White = Color.White;
            public readonly static Color Yellow = Color.FromHex("fada3b");
        }
    }
}
