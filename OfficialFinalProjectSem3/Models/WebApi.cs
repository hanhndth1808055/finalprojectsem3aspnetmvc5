using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OfficialFinalProjectSem3.Models
{
    public class WebApi
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }

    public class WebApiDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }
    }

    public class WebApiDetailDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }
    }
}
