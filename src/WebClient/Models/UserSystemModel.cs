using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class UserSystemModel
    {
        public int Id { get; set; }
        public string NameUser { get; set; }
        public int TypeDocument { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AddressUser { get; set; }
        public string UserExistRemitent { get; set; }
    }
}
