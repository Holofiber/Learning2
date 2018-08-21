using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarketData.Public.Api.ExternalApi;
using Xamarin.Forms;

namespace HelloApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var api = new MarketDataApi(MarketDataApi.ProductionUrl);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            int i = 100;


            if (button1 != null)
            {
                Timer();



                label1.TextColor = Color.Blue;
            }
        }

        public async Task Timer()
        {

            while (true)
            {


                label1.Text = $"{DateTime.Now}";
                await Task.Delay(1000);
            }

        }


    }
}
