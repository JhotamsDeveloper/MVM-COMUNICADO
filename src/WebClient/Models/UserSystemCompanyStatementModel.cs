using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class UserSystemCompanyStatementModel
    {
        public UserSystemModel UserSystemRemitent { get; set; }
        public UserSystemModel UserSystemDestinate { get; set; }
        public CompanyStatementModel CompanyStatement { get; set; }
    }
}
