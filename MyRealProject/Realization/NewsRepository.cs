using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MyRealProject.Models;
using MyRealProject.Repository;

namespace MyRealProject.Realization
{
    public class NewsRepository : INewsRepository
    {
        private readonly NewsDbContext context = new NewsDbContext();


        public IEnumerable<News> GetAll()
        {
            return context.News;
        }

        public News GetById(int id)
        {
            return context.News.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(News obj)
        {
            context.News.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(News obj)
        {
            context.News.AddOrUpdate(obj);
        }


        public int Count()
        {
            return context.News.Count();
        }

        public void Delete(int id)
        {
            var n = GetById(id);
            if (n != null)
            {
                context.News.Remove(n);
            }
        }

        public News Get(Expression<Func<News, bool>> expression)
        {
            return context.News.FirstOrDefault(expression);
        }

        public IEnumerable<News> GetMany(Expression<Func<News, bool>> expression)
        {
            return context.News.Where(expression);
        }

        public void Dispose()
        {
            if(context == null) return;
            context.Dispose();
        }
    }
}