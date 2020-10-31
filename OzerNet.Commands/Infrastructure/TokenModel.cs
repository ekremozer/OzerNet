using System;
using System.Collections.Generic;
using System.Text;

namespace OzerNet.Commands.Infrastructure
{
    public class TokenModel
    {
        public Guid Token { get; set; }
        public string Ip { get; set; }
        public UserLoginModel UserLoginModel { get; set; }
    }
}
