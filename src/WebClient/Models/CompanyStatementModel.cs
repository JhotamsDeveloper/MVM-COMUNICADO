using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class CompanyStatementModel
    {
        public int Id { get; set; }
        public string NameFile { get; set; }
        public int? Remitent { get; set; }
        public int? Destinatary { get; set; }
        public bool IsItInternally { get; set; }
        public string FilingNumber { get; set; }

        public List<SelectListItem> IsItInternallyList
        {
            get
            {
                List<SelectListItem> paramTypeList = new List<SelectListItem>();
                paramTypeList.Add(new SelectListItem() { Text = "Externa", Value = "false" });
                paramTypeList.Add(new SelectListItem() { Text = "Interna", Value = "true" });
                return paramTypeList;
            }

        }

    }

    public class CompanyStatementConvertJson
    {
        public int Id { get; set; }
        public string NameFile { get; set; }
        public int? Remitent { get; set; }
        public int? Destinatary { get; set; }
        public bool IsItInternally { get; set; }
        public string FilingNumber { get; set; }
    }

}
