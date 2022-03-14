using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TakeFoodIOApp.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Please enter valid category name!..")]
        [StringLength(20, ErrorMessage ="please only enter 4-20 characters!..", MinimumLength = 4)]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Please enter valid Description!..")]
        public string CategoryDescription { get; set; }

        public bool Status { get; set; }

        // one to many relation
        public List<Food> Foods { get; set; }
    }
}
