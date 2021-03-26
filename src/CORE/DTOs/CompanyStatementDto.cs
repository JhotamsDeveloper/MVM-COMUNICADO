using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.DTOs
{
    public class CompanyStatementDto
    {
        public int Id { get; set; }
        public string NameFile { get; set; }
        public int? Remitent { get; set; }
        public int? Destinatary { get; set; }
        public string FilingNumber { get; set; }
        public bool IsItInternally { get; set; }
        public int TotalReleases { get; set; }
    }
}
