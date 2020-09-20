using System;
using System.Collections.Generic;
using System.Text;

namespace SocailMediaApp.Helper
{
    public class ErrorHandler
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Option { get; set; } = "Okay";
        public static bool validationResponse(string response, ErrorHandler errorMessage)
        {
            if (!string.IsNullOrEmpty(response))
            {
                return true;
            }
            else
            {
                App.Current.MainPage.DisplayAlert(errorMessage.Title, errorMessage.Body, errorMessage.Option);
                return false;
            }
        }
    }
}
