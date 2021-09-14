namespace EFCodeFirstWebApp.Models
{

    public interface IVisitor
    {

        void Visit(IInvoiceElement invoiceElement);
        void Visit(HeaderElement headerElement);
        void Visit(OrderElement orderElement);
        void Visit(FooterElement footerElement);
    }

    public interface IInvoiceElement
    {
        void Admit(IVisitor visitor);
    }


}
