using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFCodeFirstWebApp.Models
{
    public class HeaderVM
    {
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

    }
}