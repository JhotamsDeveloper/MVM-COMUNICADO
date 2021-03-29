using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class RolesModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public List<PermissionsRoles> PermissionsRolesList { get; set; }
    }

    public class PermissionsRoles
    {
        public int IdRoles { get; set; }
        public int NameRol { get; set; }
    }
}
