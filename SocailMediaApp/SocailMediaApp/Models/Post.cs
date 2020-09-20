using Newtonsoft.Json;
using SocailMediaApp.Helper;
using SocailMediaApp.HttpRequest;
using SocailMediaApp.ViewModel.BaseModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

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

        public ObservableCollection<Comment> Comments { get; set; }


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
                try
                {
                    var results = JsonConvert.DeserializeObject<ObservableCollection<Post>>(response);

                    return results;
                }
                catch (Exception ex)
                {

                    throw;
                }
           
            }
            return null;
        }
    }
    
}
