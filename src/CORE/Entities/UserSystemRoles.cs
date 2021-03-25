using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CORE.Entities
{
    public partial class UserSystemRoles : BaseEntity
    {
        public int? UserSystem { get; set; }
        public int? Roles { get; set; }

        public virtual Roles RolesNavigation { get; set; }
        public virtual UserSystem UserSystemNavigation { get; set; }
    }
}
