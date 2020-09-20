using SocailMediaApp.ViewModel.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocailMediaApp.Models
{
    public class User : BaseViewModel
    {
        private string displayName;
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; OnPropertyChange(); }
        }

        private string token;

        public string Token
        {
            get { return token; }
            set { token = value; OnPropertyChange();}
        }
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChange(); }
        }

        private string profileImage;

        public string ProfileImage
        {
            get { return profileImage; }
            set { profileImage = value; OnPropertyChange(); }
        }


    }
}
