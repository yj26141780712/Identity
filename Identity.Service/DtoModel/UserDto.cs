using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Service
{
    class UserDto
    {
    }

    public class UserLoginBackDto
    {
        public string username;
    }

    public class UserLoginDto
    {
        public string username;
        public string password;
    }
}
