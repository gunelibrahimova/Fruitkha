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
    public class FreshServices : IFreshServices
    {
        private readonly FruitkhaDbContext _context;

        public FreshServices(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Fresh fresh)
        {
            _context.Freshes.Add(fresh);
            _context.SaveChanges();
        }

        public void Delete(Fresh fresh)
        {
            _context.Freshes.Remove(fresh);
            _context.SaveChanges();
        }

        public void Edit(Fresh fresh)
        {
            _context.Freshes.Update(fresh);
            _context.SaveChanges();
        }

        public List<Fresh> GetAll()
        {
            return _context.Freshes.ToList();
        }

        public Fresh GetById(int? id)
        {
            return _context.Freshes.FirstOrDefault(x => x.Id == id);

        }

        public List<Fresh> GetFreshAll()
        {
           return _context.Freshes.Take(3).ToList();
        }

        public List<Fresh> GetFreshById(int id)
        {
            return _context.Freshes.Where(x=>x.Id == id).ToList();
        }
    }
}
