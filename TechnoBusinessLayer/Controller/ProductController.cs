using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechnoDataBase.Interface;
using TechnoEntity.Entities;

namespace TechnoBusinessLayer.Controller
{
    public class ProductController
    {
        private readonly IRepository<Product> _productRepo;
        public ProductController(IRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }
        public int AddProduct(Product product)
        {
            return _productRepo.Add(product);
        }
        public int UpdateProduct(Product product, Guid id)
        {
            return _productRepo.Update(product, id);
        }
        public int DeleteProduct(Guid id)
        {
            return _productRepo.Delete(id);
        }
        public List<Product> GetAllProducts()
        {
            return _productRepo.GetAll();
        }
        public List<Product> DeleteAllProducts()
        {
            return _productRepo.DeleteAll();
        }
        public List<Product> FindProducts(Expression<Func<Product, bool>> where)
        {
            return _productRepo.Find(where);
        }
    }
}
