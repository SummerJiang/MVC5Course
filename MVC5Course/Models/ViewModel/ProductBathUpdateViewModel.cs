using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModel
{
    public class ProductBathUpdateViewModel
    {
     
        public int ProductId { get; set; }
      
        public string ProductName { get; set; }
       
        public Nullable<decimal> Price { get; set; }
       
        public Nullable<bool> Active { get; set; }
       
        public Nullable<decimal> Stock { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    throw new NotImplementedException();
        //}

       
    }
}