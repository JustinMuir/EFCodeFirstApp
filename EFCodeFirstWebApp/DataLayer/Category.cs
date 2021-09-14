using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstWebApp.DataLayer
{

    public partial class Category
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }        
        public string CategoryName { get; set; }
        public string Description { get; set; }
       
        public virtual ICollection<Product> Products { get; set; }
    }
}
