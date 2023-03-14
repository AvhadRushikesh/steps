using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steps.API
{
    public class LoginService : ILoginRepository
    {
        public async Task<UserInfo> Login(string username, string password)
        {
            try
            {
                var userInfo = new List<UserInfo>();
                var client = new HttpClient();
                string url = "https://localhost:7025/api/UsersAuth/login/" + username + "/" + password + "";
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    userInfo = JsonConvert.DeserializeObject<List<UserInfo>>(content);
                    return await Task.FromResult(userInfo.FirstOrDefault());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}