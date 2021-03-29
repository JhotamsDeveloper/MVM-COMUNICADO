using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CORE.Entities
{
    public partial class UserSystem : BaseEntity
    {
        public UserSystem()
        {
            AuditSystem = new HashSet<AuditSystem>();
            CompanyStatementDestinataryNavigation = new HashSet<CompanyStatement>();
            CompanyStatementRemitentNavigation = new HashSet<CompanyStatement>();
            UserSystemRoles = new HashSet<UserSystemRoles>();
        }
        public string NameUser { get; set; }
        public int TypeDocument { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AddressUser { get; set; }

        public virtual ICollection<AuditSystem> AuditSystem { get; set; }
        public virtual ICollection<CompanyStatement> CompanyStatementDestinataryNavigation { get; set; }
        public virtual ICollection<CompanyStatement> CompanyStatementRemitentNavigation { get; set; }
        public virtual ICollection<UserSystemRoles> UserSystemRoles { get; set; }
    }
}
