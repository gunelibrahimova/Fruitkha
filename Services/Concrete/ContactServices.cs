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
    public class ContactServices : IContectServices
    {
        private readonly FruitkhaDbContext _context;

        public ContactServices(FruitkhaDbContext context)
        {
            _context = context;
        }

        public List<Contact> GetAll()
        {
           return _context.Contacts.ToList();
        }

        public void Post(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }
    }
}
