using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.DTOs
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Permissions> PermissionsRoles { get; set; }
    }
}
