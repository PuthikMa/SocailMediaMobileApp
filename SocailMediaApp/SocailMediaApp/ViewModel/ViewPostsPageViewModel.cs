using Newtonsoft.Json;
using SocailMediaApp.Helper;
using SocailMediaApp.HttpRequest;
using SocailMediaApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SocailMediaApp.ViewModel
{
    public class ViewPostsPageViewModel : RestService
    {
        public ObservableCollection<Post> posts { get; set; }
        public ObservableCollection<Post> Posts
        {
            get { return posts; }
            set { posts = value; OnPropertyChange(); }
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

        public ICommand RefreshCommand => new Command(RefreshingLoad);
        public ViewPostsPageViewModel()
        {
            Posts = new ObservableCollection<Post>();
            LoadPosts();
        }

        public void RefreshingLoad()
        {
            isRefreshing = true;
            LoadPosts();
            isRefreshing = false;
        }
        public async void LoadPosts()
        {
           Posts =  await Post.GetPosts();
          
        }

    }
}
