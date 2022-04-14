using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IFreeServices
    {
        List<Free> GetAll();
        Free GetById(int? id);
        void Create(Free free);
        void Edit(Free free);
        void Delete(Free free);
    }
}
