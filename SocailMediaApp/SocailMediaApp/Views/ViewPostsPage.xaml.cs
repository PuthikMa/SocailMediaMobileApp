using SocailMediaApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocailMediaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewPostsPage : ContentPage
    {
        ViewPostsPageViewModel ViewPostsPageViewModel;
        public ViewPostsPage()
        {
            InitializeComponent();
            ViewPostsPageViewModel = new ViewPostsPageViewModel();
            BindingContext = ViewPostsPageViewModel;
        }

        protected override async void OnAppearing()
        {
           // await App.StartConnectSignalR();
        }
      
    }
}