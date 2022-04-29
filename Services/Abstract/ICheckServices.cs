using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ICheckServices
    {
        List<Checkout> GetAll();

      
        void Post(Checkout checkout);
    }
}
