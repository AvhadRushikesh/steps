using steps.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steps.API.Service
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDto objToCreate);
        Task<T> RegisterAsync<T>(RegistrationRequestDto objToCreate);
    }
}