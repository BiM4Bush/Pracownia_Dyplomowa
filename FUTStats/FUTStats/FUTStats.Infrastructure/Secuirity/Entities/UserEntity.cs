﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Infrastructure.Secuirity.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public ICollection<UserRoleEntity>? UserRoles { get; set; }

    }
}