using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using EFCodeFirstWebApp.DataLayer;
using EFCodeFirstWebApp.Models;

namespace EFCodeFirstWebApp.Controllers
{
    public class InvoiceController : Controller,IVisitor
    {

        private EFContext _dbContext = new EFContext();
     
        private List<string> _htmlsectionList = new List<string>();

        /// <summary>
        ///  GET: /Invoice/
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(int id=0)
        {
            Order od = _dbContext.Orders.Find(id);
            if (od == null)
                return HttpNotFound();

            Invoice newInvoice = new Invoice(od);
            ViewBag.CustomerID = od.CustomerID;
            newInvoice.Admit(this);
            ViewBag.OrderID = id;

            return View(_htmlsectionList);
        }


        public ActionResult BackToOrder(string id, int page = 1)
        {
            return RedirectToAction("Index", "Order", new { id, page });
        }

        ///// <summary>
        ///// Method:Save
        ///// Purpose:Handler to save the Invoice in XML format
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public ActionResult Save(int id=0)
        //{
        //    Order od = _dbContext.Orders.Find(id);
        //    if (od == null)
        //        return HttpNotFound();
        //    Invoice newInvoice = new Invoice(od);
        //    SaveInvoiceInXML saveVisitor = new SaveInvoiceInXML();
        //    newInvoice.Admit(saveVisitor);
        //    string filePath = string.Format("{0}Order_{1}_{2}.xml", Request.PhysicalApplicationPath, od.CustomerID, od.OrderID);
        //    try
        //    {
        //        if(System.IO.File.Exists(filePath))
        //        {
        //            System.IO.File.Delete(filePath);
        //        }
        //        saveVisitor.InvoiceRoot.Save(filePath);
        //    }
        //    catch (Exception ex) {

        //        throw ex;
        //    }
        //    return View(od);
        //}

        public void Visit(HeaderElement headerElement)
        {
            _htmlsectionList.Add(RenderRazorViewToString("_Header", headerElement.Header));
        }

        public void Visit(OrderElement orderElement)
        {
            _htmlsectionList.Add(RenderRazorViewToString("_Order", orderElement.CurrentOrder));
        }

        public void Visit(FooterElement footerElement)
        {
            _htmlsectionList.Add(RenderRazorViewToString("_Footer", footerElement));
        }

        public void Visit(IInvoiceElement invoiceElement)
        {
            //Do nothing...  //throw new NotImplementedException();
        }

        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;

            try
            {
                using (var sw = new StringWriter())
                {
                    var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                    var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);

                    viewResult.View.Render(viewContext, sw);
                    viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);

                    return sw.GetStringBuilder().ToString();
                }
            }
            catch (Exception ex)
            {

                Response.Write("Exception: " + ex.Message);
                //throw;
                return "Error " + ex.Message;
            }
        }
    }
}