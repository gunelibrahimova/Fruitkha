using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class CheckServices : ICheckServices
    {
        private readonly FruitkhaDbContext _context;

        public CheckServices(FruitkhaDbContext context)
        {
            _context = context;
        }
        public void Create(Check check)
        {
            throw new NotImplementedException();
        }

        public void Delete(Check check)
        {
            throw new NotImplementedException();
        }

        public void Edit(Check check)
        {
            throw new NotImplementedException();
        }

        public List<Check> GetAll()
        {
            var check = _context.Checks.Include(x=>x.Product).ToList();
            return check;
        }

        public Check GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Check> GetCheckById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
