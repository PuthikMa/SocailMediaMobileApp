using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using SocailMediaApp.Helper;
using SocailMediaApp.HttpRequest;
using SocailMediaApp.Models;
using SocailMediaApp.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocailMediaApp
{
    public partial class App : Application ,INotifyPropertyChanged
    {
        public static User user;
        private static ObservableCollection<Post> posts { get; set; }
        private static bool isConnectToSignalR = false;
        public App()
        {
            InitializeComponent();
            posts = new ObservableCollection<Post>();

            MainPage = new LoginPage();
        }
        public static ObservableCollection<Post> Posts
        {
            get { return posts; }
            set { posts = value; OnPropertyChange(); }
        }
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public static event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        public static void OnPropertyChange([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(Posts, new PropertyChangedEventArgs(propertyName));
        }
        protected override  void OnStart()
        {
         
        }

        private static HubConnection hubConnection;
        public static async Task StartConnectSignalR()
        {
            try
            {
                if (!isConnectToSignalR)
                {
                    hubConnection = new HubConnectionBuilder().WithUrl(Constants.HubCommentUrl).Build();

                    hubConnection.On<string>("ReceiveComment", (message) =>
                    {
                        var encodeMsg = $"{message}";
                        var comment = JsonConvert.DeserializeObject<Comment>(message);
                        //var restemp = Posts.Where(x => x.Id == comment.PostId).FirstOrDefault();
                        Posts.Where(x => x.Id == comment.PostId).FirstOrDefault().Comments.Add(comment);
                    });

                    //hubConnection.On<string>("PrivateMessage", (messase) =>
                    //{

                    //});


                    await hubConnection.StartAsync();
                }
                isConnectToSignalR = true;
            }
            catch (Exception ex)
            {
                isConnectToSignalR = false;
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");

            }
      
        }
        public async static Task StopConnectionSignalR()
        {
            if (isConnectToSignalR)
            {
                await hubConnection.StopAsync();
                isConnectToSignalR = false;
            }

        }
        protected override  void OnSleep()
        {
          
        }

        protected override  void OnResume()
        {
            
        }
    }
}
