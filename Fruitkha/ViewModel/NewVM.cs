using Core.Helper;
using Entities;

namespace Fruitkha.ViewModel
{
    public class NewVM
    {
        public New NewSingle { get; set; }
        public List<New> News { get; set; }
        public K205User User { get; set; }
        public List<Comment> Comments { get; set; }
        public Comment Comment { get; set; }
        public List<Fresh> FreshNews { get; set; }
        public Pager Pager { get; set; }
    }
}
