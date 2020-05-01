using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OfficialFinalProjectSem3.Models
{
    public class OrderDetail
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}