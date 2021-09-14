using System.Web.Mvc;
using EFCodeFirstWebApp.DataLayer;
using EFCodeFirstWebApp.Utilities;

namespace EFCodeFirstWebApp.Controllers
{
    public class OrderController : Controller
    {

        private Queries myDB = new Queries();
        private PagedList<Order> _pagedOrders = null;
        private int _pageSize = 8;

        private void InitOrders(int id)
        {
            var orders = myDB.GetOrders(id);
            _pagedOrders = new PagedList<Order>(orders, _pageSize);
        }

        //
        // GET: /Order/
        public ActionResult Index(string id, int page = 1)
        {
            if (string.IsNullOrEmpty(id))
                return HttpNotFound();

            if (_pagedOrders == null)
                InitOrders(int.Parse(id));

            ViewBag.CustomerID = id;
            _pagedOrders.CurrentPage = page;

            return View(_pagedOrders);
        }

        public ActionResult ShowInvoice(int id)
        {
            return RedirectToAction("Index", "Invoice", new { id });
        }


    }
}