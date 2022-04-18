using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class NewServices : INewServices
    {
        private readonly FruitkhaDbContext _context;

        public NewServices(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(New news)
        {
            news.PublishDate = DateTime.Now;
            _context.News.Add(news);
            _context.SaveChanges();
        }

        public void Delete(New news)
        {
            _context.News.Remove(news);
            _context.SaveChanges();
        }

        public void Edit(New news)
        {
            news.PublishDate = DateTime.Now;
            _context.News.Update(news);
            _context.SaveChanges();
        }

        public List<New> GetAll()
        {
            return _context.News.Include(x => x.K205User).ToList();
        }

        public List<New> GetAll(int? pageNo, int recordSize)
        {
            if (pageNo == null)
            {
                pageNo = 1;
            }
            int currentPage = 6 * pageNo.Value - 6;
            var news = _context.News.Skip(currentPage).Take(recordSize).Include(x => x.K205User).ToList();
            return news;
        }

        public int GetAllCount()
        {
            var news = _context.News.ToList();
            return news.Count;
        }

        public New GetById(int? id)
        {
           var news = _context.News.Include(x=>x.K205User).FirstOrDefault(x=>x.Id == id);
            return news;
        }

        public List<New> GetNewAll()
        {
            var news = _context.News.Include(x=>x.K205User).Take(3).ToList();
            return news;
        }

        public New GetNewById(int id)
        {
            return _context.News.Include(x => x.K205UserId).FirstOrDefault(x => x.Id == id);

        }
    }
}
