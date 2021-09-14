using EFCodeFirstWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFCodeFirstWebApp.DataLayer
{
    /// <summary>
    /// This is to populate the database with some data when the application runs.
    /// </summary>
    public class DBInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EFContext>
    {
        protected override void Seed(EFContext context)
        {

            var customers = new List<Customer>
            {
                new Customer{FirstName="Joe", LastName="Waring", TelNo="0734429475", Address="17 Riverbend Drive", City="Johannesburg", PostalCode="2000", Province="Gauteng"},
                new Customer{FirstName="Ronald", LastName="Charms", TelNo="0823752919", Address="353 Seaside View", City="Cape Town", PostalCode="4000", Province="Cape"},
                new Customer{FirstName="Sarah", LastName="Jones", TelNo="0847248011", Address="99 Oak Avenue", City="Rustenburg", PostalCode="3500", Province="North West"},
                new Customer{FirstName="Shane", LastName="Donaldson", TelNo="0114759800", Address="450 Umhlanga Road", City="Durban", PostalCode="3000", Province="KZN"},
            };

            customers.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category{ CategoryName="Shoes 1", Description="Cross Trainers" },
                new Category{ CategoryName="Shoes 2", Description="Running Shoes" },
                new Category{ CategoryName="Appliances", Description="Houseware" },
            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product{Description="Nike running shoes", UnitPrice=(decimal)1003.78, CategoryID=1 },
                new Product{Description="Nike cross trainers", UnitPrice=(decimal)120.00, CategoryID=2 },
                new Product{Description="Russel Hobbs Kettle", UnitPrice=(decimal)895.75, CategoryID=3 },
            };
            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();

            var orders = new List<Order>
            {
                new Order{ CustomerID=1, OrderDate=DateTime.Parse("2021-09-07"), DeliveryDate=DateTime.Parse("2021-09-15"), DeliveryAddress="219 Pine Street", City="Randburg", Province="Gauteng" },  
                new Order{ CustomerID=1, OrderDate=DateTime.Parse("2021-07-18"), DeliveryDate=DateTime.Parse("2021-07-20"), DeliveryAddress="219 Pine Street", City="Randburg", Province="Gauteng" },
                new Order{ CustomerID=1, OrderDate=DateTime.Parse("2021-04-22"), DeliveryDate=DateTime.Parse("2021-04-27"), DeliveryAddress="219 Pine Street", City="Randburg", Province="Gauteng" },
            };
            orders.ForEach(s => context.Orders.Add(s));
            context.SaveChanges();

            var orderDetails = new List<Order_Detail>
            {
                new Order_Detail{OrderID=1, ProductID=2, Quantity=3, UnitPrice=(decimal)120.00 },
                new Order_Detail{OrderID=1, ProductID=1, Quantity=5, UnitPrice=(decimal)1367.55 },
                new Order_Detail{OrderID=1, ProductID=3, Quantity=1, UnitPrice=(decimal)2045.98 }
            };
            orderDetails.ForEach(s => context.Order_Details.Add(s));
            context.SaveChanges();
            
        }
    }
}