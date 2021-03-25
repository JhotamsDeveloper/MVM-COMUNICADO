using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.DTOs
{
    public class UserSystemDto
    {
        public UserSystemDto()
        {
            AuditSystem = new HashSet<AuditSystem>();
            CompanyStatementDestinataryNavigation = new HashSet<CompanyStatement>();
            CompanyStatementRemitentNavigation = new HashSet<CompanyStatement>();
            UserSystemRoles = new HashSet<UserSystemRoles>();
        }
        public int ID { get; set; }
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
