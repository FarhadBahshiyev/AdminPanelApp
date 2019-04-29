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
    public class PictureRepository : IPictureRepository
    {
        private readonly NewsDbContext context = new NewsDbContext();

        public IEnumerable<Picture> GetAll()
        {
            return context.Pictures;
        }

        public Picture GetById(int id)
        {
            return context.Pictures.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Picture obj)
        {
            context.Pictures.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Picture obj)
        {
            context.Pictures.AddOrUpdate(obj);
        }
        public int Count()
        {
            return context.Pictures.Count();
        }

        public void Delete(int id)
        {
            var image = GetById(id);
            if (image != null)
            {
                context.Pictures.Remove(image);
            }
        }

        public Picture Get(Expression<Func<Picture, bool>> expression)
        {
            return context.Pictures.FirstOrDefault(expression);
        }

        public IEnumerable<Picture> GetMany(Expression<Func<Picture, bool>> expression)
        {
            return context.Pictures.Where(expression);
        }

        public void Dispose()
        {
            if (context == null) return;
            context.Dispose();
        }
    }
}