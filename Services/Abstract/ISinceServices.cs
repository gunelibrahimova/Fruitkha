using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ISinceServices
    {
        List<Since> GetAll();
        Since GetById(int? id);
        void Create(Since since);
        void Edit(Since since);
        void Delete(Since since);
    }
}
