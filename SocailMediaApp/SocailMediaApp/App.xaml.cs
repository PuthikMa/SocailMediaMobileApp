using SocailMediaApp.Models;
using SocailMediaApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocailMediaApp
{
    public partial class App : Application
    {
        public static User user; 
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
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
