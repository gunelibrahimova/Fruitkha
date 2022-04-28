using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Check : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string Message { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
