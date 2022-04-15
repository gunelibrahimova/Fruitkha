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
    public class OwnerServices : IOwnerServices
    {
        private readonly FruitkhaDbContext _context;

        public OwnerServices(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Owner owner)
        {
            _context.Owners.Add(owner);
            _context.SaveChanges();
        }

        public void Delete(Owner owner)
        {
            _context.Owners.Remove(owner);
            _context.SaveChanges();
        }

        public void Edit(Owner owner)
        {
            _context.Owners.Update(owner);
            _context.SaveChanges();
        }

        public List<Owner> GetAll()
        {
            return _context.Owners.ToList();
        }

        public Owner GetById(int? id)
        {
            return _context.Owners.FirstOrDefault(x => x.Id == id);
        }
    }
}
