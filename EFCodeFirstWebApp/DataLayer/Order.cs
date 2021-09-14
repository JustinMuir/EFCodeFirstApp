using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstWebApp.DataLayer
{

    public partial class Order
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string City { get; set; }
        public string Province { get; set; } 

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Order_Detail> Order_Details { get; set; }
    }
}
