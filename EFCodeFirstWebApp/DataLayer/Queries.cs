using System.Collections.Generic;
using System.Linq;

namespace EFCodeFirstWebApp.DataLayer
{
    public class Queries
    {

        private EFContext _dbContext = new EFContext();

        public List<Customer> GetCustomers()
        {
            var customers = from c in _dbContext.Customers
                            orderby c.CustomerID
                            select c;

            return customers.ToList<Customer>();
        }

        public List<Order> GetOrders(int customerID) {
            return _dbContext.Orders
                .Where(o => o.CustomerID == customerID)
                .OrderByDescending(o => o.OrderDate).ToList<Order>();          
        }
    }
}