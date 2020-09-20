using SocailMediaApp.ViewModel.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocailMediaApp.Models
{
    public class Photo : BaseViewModel
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value;  OnPropertyChange(); }
        }

        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; OnPropertyChange(); }
        }


    }
}
