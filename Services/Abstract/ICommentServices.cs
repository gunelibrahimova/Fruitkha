using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ICommentServices
    {
        List<Comment> GetNewComment(int newId);
        void AddComment(Comment comment);
    }
}
