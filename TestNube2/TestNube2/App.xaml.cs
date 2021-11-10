using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestNube2
{
    public partial class App : Application
    {
        public static string url;
        public App()
        {
            //url = "http://192.168.1.10/webservice2/";
            url = "https://uthprograweb2.000webhostapp.com/webservice/";
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
