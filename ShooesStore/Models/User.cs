﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShooesStore.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}