using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HelloApp
{
    class StartPage : ContentPage
    {
        public StartPage()
        {
            Label header = new Label() { Text = "Hello from Xamarin Forms" };
            this.Content = header;
        }
    }
}
