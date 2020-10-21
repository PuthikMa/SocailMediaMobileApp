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
    public partial class ViewComment : ContentPage
    {
        ViewCommentPageViewModel ViewCommentPageViewModel;
        public ViewComment(string postId)
        {
            InitializeComponent();
            ViewCommentPageViewModel = new ViewCommentPageViewModel(postId);
            BindingContext = ViewCommentPageViewModel;
        }

   
    }
}