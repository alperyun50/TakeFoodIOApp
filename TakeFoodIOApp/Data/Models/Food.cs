using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TakeFoodIOApp.Data.Models
{
    public class Food
    {
        public int FoodId { get; set; }

        [Required(ErrorMessage = "Please enter valid food name!..")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter valid description!..")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter valid price!..")]
        public double Price { get; set; }

        //[Required(ErrorMessage = "Please enter valid image!..")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Please enter valid stock!..")]
        public int Stock { get; set; }

        //FKey
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
