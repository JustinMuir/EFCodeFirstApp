using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFCodeFirstWebApp.DataLayer;

namespace EFCodeFirstWebApp.Models
{
    public class Invoice:IInvoiceElement
    {
        
        private List<IInvoiceElement> _invoiceElements;

        public Invoice(Order o){        
            InitInvoice(o);
        }

        //For the Top of the invoice to display our Company Info
        private HeaderVM InitHeader(){
            HeaderVM vm = new HeaderVM
            {
                Name = "Justins Company",
                Address1 = "18 Riverview Drive",
                Address2 = "Randburg",
                City = "Johannesburg",
                Province = "Gauteng",
                Country = "South Africa",
                Email = "justin@mytest.co.za",
                Website="thisplace@mysite.co.za"
            };
            
            return vm;
        }

        private void InitInvoice(Order o)
        {
 	        _invoiceElements = new List<IInvoiceElement>();

            HeaderElement header= new HeaderElement(InitHeader());
            _invoiceElements.Add(header);

            OrderElement orderElemt = new OrderElement(o);
            _invoiceElements.Add(orderElemt);

            FooterElement footElement = new FooterElement("Thank you for doing Business with us!");
            _invoiceElements.Add(footElement);
        }
        
        public void Admit(IVisitor visitor)
        {     
            _invoiceElements.ForEach(ie => ie.Admit(visitor));
        }
    }

    public class HeaderElement : IInvoiceElement
    {
        readonly HeaderVM _header;

        public HeaderVM Header { get { return _header; } }

        public HeaderElement(HeaderVM header) {
            _header = header;
        }

        public void Admit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
  

    public class OrderElement : IInvoiceElement {
        readonly Order _order;

        public Order CurrentOrder { get { return _order; } }

        public OrderElement(Order o) {
            _order = o;
        }

        public void Admit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class FooterElement : IInvoiceElement
    {
        string _footer;

        public string Footer { get { return _footer; } }

        public FooterElement(string footer)
        {
            _footer=footer;
        }

        public void Admit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

}