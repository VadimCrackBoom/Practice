using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApiClient.Models.Requests
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

    }
}
