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
        List<Check> GetAll();
        Check GetById(int? id);
        List<Check> GetCheckById(int id);
        void Create(Check check);
        void Edit(Check check);
        void Delete(Check check);
    }
}
