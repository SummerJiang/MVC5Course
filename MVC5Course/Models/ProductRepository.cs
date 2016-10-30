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
            return base.All().Where(p=>p.is�R��==false);
        }
        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }

        public IQueryable<Product> Get�Ҧ����_�̾�ProductId�Ƨ�(int takeSize)
        {

            return this.All().OrderByDescending(p => p.ProductId).Take(takeSize);
        }

        public override void Delete(Product product)
        {
            product.is�R�� = true;
        }
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    //if (this.Stock < 100 & this.Price > 20)
        //    //{
        //    //    yield return new ValidationResult("�w�s�P�ӫ~���B��������~", new string[] { "Price" });
        //    //}
        //}


    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}