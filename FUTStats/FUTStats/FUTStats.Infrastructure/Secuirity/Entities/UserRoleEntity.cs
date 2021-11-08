using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Infrastructure.Secuirity.Entities
{
    public class UserRoleEntity
    {
#nullable enable
        public Guid UserId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public UserEntity? User { get; set; }
        public int RoleId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public RoleEntity? Role { get; set; }

    }
}
