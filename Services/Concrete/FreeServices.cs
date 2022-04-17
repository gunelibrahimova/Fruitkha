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
    public class FreeServices : IFreeServices
    {
        private readonly FruitkhaDbContext _context;

        public FreeServices(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Free free)
        {
            _context.Frees.Add(free);
            _context.SaveChanges();
        }

        public void Delete(Free free)
        {
            _context.Frees.Remove(free);
            _context.SaveChanges();
        }

        public void Edit(Free free)
        {
            _context.Frees.Update(free);
            _context.SaveChanges();
        }

        public List<Free> GetAll()
        {
            return _context.Frees.ToList();
        }

        public Free GetById(int? id)
        {
            return _context.Frees.FirstOrDefault(x => x.Id == id);
        }

        public List<Free> GetFreeAll()
        {
            return _context.Frees.Take(3).ToList();
        }

        public List<Free> GetFreeById(int id)
        {
            return _context.Frees.Where(x=>x.Id == id).ToList();
        }
    }
}
