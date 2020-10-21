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
using System.Windows.Input;
using Xamarin.Forms;

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

        public ViewCommentPageViewModel(string postId)
        {
            Post = App.Posts.Where(x => x.Id == postId).FirstOrDefault();
       
        }

        private string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; OnPropertyChange(); }
        }

        public ICommand PostCommentCommand => new Command(async () => Comment = await CreateComment.PostComment(Post.Id, Comment));


    }
}
