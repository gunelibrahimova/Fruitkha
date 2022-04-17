using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IProductServices
    {
        List<Product> GetAll();
        Product GetById(int id);
        List<Product> GetSingleProduct(int id);
        void Create(Product product);
        void Edit(Product product);
        void Delete(Product product);
    }
}
