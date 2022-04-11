using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ICategoryServices
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Create(Category category);
        void Edit(Category category);
        void Delete(Category category);
    }
}
