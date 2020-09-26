using SocailMediaApp.Helper;
using SocailMediaApp.Models;
using SocailMediaApp.ViewModel.BaseModel;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SocailMediaApp.ViewModel
{
    public class LoginPageViewModel : BaseViewModel
    {
        public Login User { get; set; }
        public LoginPageViewModel()
        {
            User = new Login();
            User.password = "Pa$$w0rd";
            User.username = "6825531065";
        }

   

        public ICommand LoginCommand => new Command(UserLogin);
        public ICommand Register => new Command(SayHello);

        public async void SayHello()
        {
            

            await App.Current.MainPage.DisplayAlert("HI", "HI", "OK");
        }
        public async void UserLogin()
        {
            await Login.UserLogin(User);
            
        }
    }
}
