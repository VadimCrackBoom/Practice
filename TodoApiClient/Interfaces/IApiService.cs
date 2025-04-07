using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Http;

namespace TodoApiClient.Interfaces
{
    public interface IApiService
    {
        Task<bool> LoginAsync(string email, string password);

        Task<bool> RegisterAsync(string name, string email, string password);

        string GetCurrentUserEmail();

        bool IsAuthenticated();
    }
}
