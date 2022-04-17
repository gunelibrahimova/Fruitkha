using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IFreshServices
    {
        List<Fresh> GetAll();
        List<Fresh> GetFreshAll();
        List<Fresh> GetFreshById(int id);
        Fresh GetById(int? id);
        void Create(Fresh fresh);
        void Edit(Fresh fresh);
        void Delete(Fresh fresh);
    }
}
