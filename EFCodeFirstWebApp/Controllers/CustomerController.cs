using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using EFCodeFirstWebApp.DataLayer;
using EFCodeFirstWebApp.Utilities;

namespace EFCodeFirstWebApp.Controllers
{
    public class CustomerController : Controller
    {
        private Queries queries = new Queries();
        private PagedList<Customer> _pagedCustomers = null;
        private int _pageSize = 8;
        private EFContext db = new EFContext();

        public ActionResult ViewOrders(string id ="") {

            return RedirectToAction("Index", "Order", new { id = id });
           
        }
        
        private void InitCustomers(){

            if (_pagedCustomers == null)
            {
                var customers = queries.GetCustomers();
                _pagedCustomers = new PagedList<Customer>(customers, _pageSize);
            }
        
        }

        //
        // GET: /Customer/
        public ActionResult Index(int page=1)
        {
            InitCustomers();
            _pagedCustomers.CurrentPage = page;

            return View(_pagedCustomers);
        }

        //
        // GET: /Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // GET: /Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,TelNo,Address,City,PostalCode,Province")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        //
        // GET: /Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Customer/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,TelNo,Address,City,PostalCode,Province")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
