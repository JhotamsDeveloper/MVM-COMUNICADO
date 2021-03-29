using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.ModelResponse
{
    public class UserSystemResponse
    {
        public string msg { get; set; }
        public UserSystemModel data { get; set; }
        public object meta { get; set; }
    }

    public class CompanyStatementConvertJsonResponse
    {
        public string msg { get; set; }
        public ICollection<CompanyStatementConvertJson> data { get; set; }
        public object meta { get; set; }
    }
}
