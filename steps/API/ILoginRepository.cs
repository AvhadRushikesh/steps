using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steps.API
{
    public interface ILoginRepository
    {
        Task<UserInfo> Login(string username, string password);
    }
}
