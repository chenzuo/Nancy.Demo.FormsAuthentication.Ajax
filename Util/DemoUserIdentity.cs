﻿using System.Collections.Generic;
using Nancy.Security;

namespace Nancy.Demo
{    
    public class DemoUserIdentity : IUserIdentity
    {
        public string UserName { get; set; }
        public IEnumerable<string> Claims { get; set; }
    }
}