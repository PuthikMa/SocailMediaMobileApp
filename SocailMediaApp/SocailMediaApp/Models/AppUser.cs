using SocailMediaApp.ViewModel.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocailMediaApp.Models
{
    public class AppUser : BaseViewModel
    {
        private string displayName;

        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; OnPropertyChange(); }
        }
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChange(); }
        }
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChange(); }
        }

        private Photo photo;

        public Photo Photo
        {
            get { return photo; }
            set { photo = value; OnPropertyChange(); }
        }

    }
}
