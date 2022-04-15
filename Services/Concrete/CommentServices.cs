using DataAccess;
using Entities;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class CommentServices : ICommentServices
    {
        private readonly FruitkhaDbContext _context;

        public CommentServices(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void AddComment(Comment comment)
        {
            comment.PublishDate = DateTime.Now;
            _context.Add(comment);
            _context.SaveChanges();
        }

        public List<Comment> GetNewComment(int newId)
        {
            var newComment = _context.Comments.Where(x => x.NewId == newId).ToList();
            return newComment;
        }
    }
}
