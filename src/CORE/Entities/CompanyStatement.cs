using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CORE.Entities
{
    public partial class CompanyStatement : BaseEntity
    {
        public string NameFile { get; set; }
        public int? Remitent { get; set; }
        public int? Destinatary { get; set; }
        public string FilingNumber { get; set; }
        public bool IsItInternally { get; set; }
        public int TotalReleases { get; set; }
        public virtual UserSystem DestinataryNavigation { get; set; }
        public virtual UserSystem RemitentNavigation { get; set; }
    }
}
