using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApiClient.Models.Responses
{
    public class AuthResponse
    {
        public string Token { get; set; }

        public string UserId { get; set; } 
    }
}
