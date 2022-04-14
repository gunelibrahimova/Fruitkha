using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IDealServices
    {
        List<Deal> GetAll();
        Deal GetById(int? id);
        void Create(Deal deal);
        void Edit(Deal deal);
        void Delete(Deal deal);
    }
}
