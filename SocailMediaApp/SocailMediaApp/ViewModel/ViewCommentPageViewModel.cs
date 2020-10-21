using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using SocailMediaApp.Helper;
using SocailMediaApp.HttpRequest;
using SocailMediaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocailMediaApp.ViewModel
{
    public class ViewCommentPageViewModel : RestService
    {
        private Post post;

        public Post Post
        {
            get { return post; }
            set { post = value; OnPropertyChange(); }
        }

        private bool isConnectToSignalR = false;
        public ViewCommentPageViewModel(string postId)
        {
            Post = App.Posts.Where(x => x.Id == postId).FirstOrDefault();
       
        }

   
     

  
    }
}
