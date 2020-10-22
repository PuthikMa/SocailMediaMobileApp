using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using SocailMediaApp.Helper;
using SocailMediaApp.HttpRequest;
using SocailMediaApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SocailMediaApp.ViewModel
{
    public class ViewPostsPageViewModel : RestService
    {
        //public ObservableCollection<Post> posts { get; set; }
        public ObservableCollection<Post> Posts
        {
            get { return App.Posts; }
            set { App.Posts = value; OnPropertyChange(); }
        }
        private int commentCount;

        public int CommentCount
        {
            get { return commentCount; }
            set { commentCount = value; OnPropertyChange(); }
        }
        private bool isRefreshing;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { isRefreshing = value; OnPropertyChange(); }
        }
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; OnPropertyChange(); }
        }

        private bool IsConnect = false;

        private string profilePicture;

        public string ProfilePicture
        {
            get { return profilePicture; }
            set { profilePicture = value; OnPropertyChange(); }
        }

        public ICommand RefreshCommand => new Command(RefreshingLoad);
        public ICommand PostContent => new Command(async() => await CreatePost());
        
        public ViewPostsPageViewModel()
        {
            //Posts = new ObservableCollection<Post>();
            LoadPosts();
            ProfilePicture = App.user.ProfileImage;
            StartConnectSignalR();


        }

 

        public async Task CreatePost()
        {
            try
            {
                var result = await Post.CreatePost(Content);
                //App.Posts.Add(result);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
              
            }
   
        }
        public void RefreshingLoad()
        {
            IsRefreshing = true;
            LoadPosts();
            IsRefreshing = false;
        }
        public async void LoadPosts()
        {
           Posts =  await Post.GetPosts();
        
        }
        bool isConnectToSignalR = false;

        private  HubConnection hubConnection;
        public  async void StartConnectSignalR()
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

                    hubConnection.On<string>("PrivateMessage", (messase) =>
                    {

                    });


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

    }
}
