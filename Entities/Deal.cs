using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Deal : Base
    {
        public string PhotoRURL { get; set; }
        public string Title { get; set; }
        public string Decription { get; set; }
        public string Info { get; set; }
        public int Count { get; set; }
    }
}
