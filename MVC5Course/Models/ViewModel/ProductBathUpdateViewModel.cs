using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModel
{
    public class ProductBathUpdateViewModel:IValidatableObject
    {
     
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public Nullable<decimal> Price { get; set; }
        [Required]
        public Nullable<bool> Active { get; set; }
        [Required]
        public Nullable<decimal> Stock { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Stock < 100 & this.Price > 20)
            {
                yield return new ValidationResult("庫存與商品金額的條件錯誤", new string[] { "Price" });
            }
        }
    }
}