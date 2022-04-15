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
    public class SaleServices : ISaleServices
    {
        private readonly FruitkhaDbContext _context;

        public SaleServices(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }

        public void Delete(Sale sale)
        {
            _context.Sales.Remove(sale);
            _context.SaveChanges();
        }

        public void Edit(Sale sale)
        {
            _context.Sales.Update(sale);
            _context.SaveChanges();
        }

        public List<Sale> GetAll()
        {
            return _context.Sales.ToList();
        }

        public Sale GetById(int? id)
        {
            var sale = _context.Sales.FirstOrDefault(x => x.Id == id);
            return sale;
        }

       
    }
}
