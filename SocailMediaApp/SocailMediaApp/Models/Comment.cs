using SocailMediaApp.ViewModel.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocailMediaApp.Models
{
    public class Comment : BaseViewModel
    {
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; OnPropertyChange(); }
        }

        private string commentContent;
        public string CommentContent
        {
            get { return commentContent; }
            set { commentContent = value;  OnPropertyChange(); }
        }

        private string postId;

        public string PostId
        {
            get { return postId; }
            set { postId = value; OnPropertyChange(); }
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


    }
}
