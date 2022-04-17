using DataAccess;
using Entities;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class ProductServices : IProductServices
    {
        private readonly FruitkhaDbContext _context;

        public ProductServices(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void Edit(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(x=>x.Id == id);
            return product;

        }

        public List<Product> GetSingleProduct(int id)
        {
            return _context.Products.Where(x => x.Id == id).ToList();
        }
    }
}
