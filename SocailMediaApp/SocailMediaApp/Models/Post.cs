using Newtonsoft.Json;
using SocailMediaApp.Helper;
using SocailMediaApp.HttpRequest;
using SocailMediaApp.ViewModel;
using SocailMediaApp.ViewModel.BaseModel;
using SocailMediaApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SocailMediaApp.Models
{
    public class Post : RestService
    {
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; OnPropertyChange(); }
        }
        private string postContent;

        public string PostContent
        {
            get { return postContent; }
            set { postContent = value; OnPropertyChange(); }
        }
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { userId = value; OnPropertyChange(); }
        }
        private AppUser user;

        public AppUser User
        {
            get { return user; }
            set { user = value; OnPropertyChange(); }
        }
        private DateTime createDate;

        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; OnPropertyChange(); }
        }

        private ObservableCollection<Comment> comments { get; set; }
        public ObservableCollection<Comment> Comments
        {
            get { return comments; }
            set { comments = value;OnPropertyChange();}
        }
 
        public async static Task<Post> CreatePost(string post)
        {
            var url = "Posts";
            var createPost = new CreatePost
            {
                Post = post
            };
            var postdata = JsonConvert.SerializeObject(createPost);
            var response = await PostMethod(url, postdata, true);
            var error = new ErrorHandler
            {
                Title = "Error",
                Body = "Unable to Post"
            };

            if (ErrorHandler.validationResponse(response, error))
            {
                var result = JsonConvert.DeserializeObject<Post>(response);
                return result;
            }
            return null;

        }
        public async static Task<ObservableCollection<Post>> GetPosts()
        {
            var url = "Posts";
            var response = await GetMethod(url, true);
            var error = new ErrorHandler
            {
                Title = "Error",
                Body = "Unable to loading Posts"
            };

            if (ErrorHandler.validationResponse(response, error))
            {
                var results = JsonConvert.DeserializeObject<ObservableCollection<Post>>(response);

                return results;
      
           
            }
            return null;
        }

        public ICommand CommentPost => new Command(NavigateToViewCommentPost);
        private async void NavigateToViewCommentPost(object postId)
        {
            await Shell.Current.Navigation.PushAsync(new ViewComment(postId.ToString()));

        }
    }
    
}
