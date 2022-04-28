using Core.Helper;
using Entities;

namespace Fruitkha.ViewModel
{
    public class HomeVM
    {
        public List<New> News { get; set; }
        public K205User User { get; set; }
        public List<Fresh> Freshs { get; set; } 
        public List<Free> Frees { get; set; }
        public List<Deal> Deals { get; set; }
        public List<Owner> Owners { get; set; }
        public List<Product> Products { get; set; }
        public List<Since> Since { get; set; }
        public List<Sale> Sales { get; set; }
        public List<Category> Categories { get; set; }
        public Pager Pager { get; set; }
        public List<Check> Check { get; set; }
        
    }
}
