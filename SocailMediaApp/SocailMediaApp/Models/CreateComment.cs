using Newtonsoft.Json;
using SocailMediaApp.Helper;
using SocailMediaApp.HttpRequest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocailMediaApp.Models
{
    public class CreateComment : RestService
    {
        public string PostId { get; set; }
        public string Comment { get; set; }

        public static async Task<string> PostComment(string postId, string content)
        {
            string url = "Posts/comment";
            var comment = new CreateComment()
            {
                PostId = postId,
                Comment = content
            };


             var commentData =JsonConvert.SerializeObject(comment);
            var response = await PostMethod(url, commentData, true);
            var error = new ErrorHandler
            {
                Title = "Error",
                Body = "Unable to Comment on this post"
            };

            if(ErrorHandler.validationResponse(response, error)){
                return "";
            }
            return content;




        }
    }
}
