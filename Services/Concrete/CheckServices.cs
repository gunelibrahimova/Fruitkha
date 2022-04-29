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

        public List<Checkout> GetAll()
        {
            var check = _context.Checks.ToList();
            return check;
        }

        

      
        public void Post(Checkout checkout)
        {
            _context.Checks.Add(checkout);
            _context.SaveChanges();
        }
    }
}
