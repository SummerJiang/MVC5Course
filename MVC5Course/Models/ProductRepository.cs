using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override IQueryable<Product> All()
        {
            return base.All().Where(p=>p.is刪除==false);
        }
        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }

        public IQueryable<Product> Get所有資料_依據ProductId排序(int takeSize)
        {

            return this.All().OrderByDescending(p => p.ProductId).Take(takeSize);
        }

        public override void Delete(Product product)
        {
            product.is刪除 = true;
        }
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    //if (this.Stock < 100 & this.Price > 20)
        //    //{
        //    //    yield return new ValidationResult("庫存與商品金額的條件錯誤", new string[] { "Price" });
        //    //}
        //}


    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}