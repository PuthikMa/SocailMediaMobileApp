using Newtonsoft.Json;
using SocailMediaApp.HttpRequest;
using SocailMediaApp.ViewModel.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocailMediaApp.Models
{
    public class Login : RestService
    {
        public string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChange();
            }
        }
        public string password { get; set; }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChange();
            }
        }


        public static async Task UserLogin(Login login)
        {
            var json = JsonConvert.SerializeObject(login);
            string url = "User/login";
            var response = await PostMethod(url, json);

            if (!string.IsNullOrEmpty(response))
            {
                var result = JsonConvert.DeserializeObject<User>(response);
                App.user = result;
                App.Current.MainPage = new AppShell();
                await AppShell.Current.GoToAsync("//DashBoard");
            }
        }
    }
}
