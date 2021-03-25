using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CORE.Entities
{
    public partial class Roles : BaseEntity
    {
        public Roles()
        {
            UserSystemRoles = new HashSet<UserSystemRoles>();
        }

        public string NameRoles { get; set; }

        public virtual ICollection<UserSystemRoles> UserSystemRoles { get; set; }
    }
}
