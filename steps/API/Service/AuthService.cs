using Microsoft.Extensions.Configuration;
using steps.API.Dto;
using steps.API.Type;
using steps.API.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace steps.API.Service
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string _Url;
        public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            // _Url = configuration.GetValue<string>("ServiceUrls:VillaAPI");
            // _Url = "https://localhost:7025";
            _Url = "https://localhost:7001";
        }
        public Task<T> LoginAsync<T>(LoginRequestDto obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                // Url = _Url + "/api/UsersAuth/login"
                // Url = _Url + "/api/UsersAuth/login/admin/Password1"
                Url = _Url + "/api/v1/UsersAuth/login"
            });
        }

        public Task<T> RegisterAsync<T>(RegistrationRequestDto obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                // Url = _Url + "/api/UsersAuth/register"
                Url = _Url + "/api/v1/UsersAuth/register"
            });
        }
    }
}
