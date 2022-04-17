using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IContectServices
    {
        List<Contact> GetAll();
        void Post(Contact contact);
    }
}
