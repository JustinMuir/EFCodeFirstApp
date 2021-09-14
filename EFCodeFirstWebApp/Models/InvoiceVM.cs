using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFCodeFirstWebApp.DataLayer;

namespace EFCodeFirstWebApp.Models
{
    public class InvoiceVM
    {
        public HeaderVM Header { get; set; }
        public FooterElement Footer { get; set; }
        public Order CurrentOrder { get; set; }
    }
}