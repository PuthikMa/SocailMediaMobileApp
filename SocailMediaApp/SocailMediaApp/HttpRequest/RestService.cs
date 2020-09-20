using SocailMediaApp.Helper;
using SocailMediaApp.ViewModel.BaseModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SocailMediaApp.HttpRequest
{
    public class RestService : BaseViewModel
    {
       public static async Task<string> GetMethod(string uri,bool isAuthRequest = false)
       {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    if (isAuthRequest)
                    {
                        client.DefaultRequestHeaders.Authorization =
                            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",$"{App.user.Token}");
                    }
                    var response = await client.GetAsync(Constants.BaseURL + uri);

                    string json = string.Empty;
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        json = await response.Content.ReadAsStringAsync();
                        return json;
                    }
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
       }

       public static async Task<string> PostMethod(string uri,string content="", bool isAuthRequest= false)
       {
            using (HttpClient client = new HttpClient())
            {
                if (isAuthRequest)
                {
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", $"{App.user.Token}");
                }
                var data = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Constants.BaseURL + uri,data);

                string json = string.Empty;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    json = await response.Content.ReadAsStringAsync();
                    return json;
                }
                return null;
            }
        }
    }
}
