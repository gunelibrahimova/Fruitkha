using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ISaleServices
    {
        List<Sale> GetAll();
        Sale GetById(int? id);
        void Create(Sale sale);
        void Edit(Sale sale);
        void Delete(Sale sale);
    }
}
