using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class New : Base
    {
        public string PhotoURL { get; set; }
        public string Title { get; set; }
        public string K205UserId { get; set; }
        public K205User K205User { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }

    }
}
