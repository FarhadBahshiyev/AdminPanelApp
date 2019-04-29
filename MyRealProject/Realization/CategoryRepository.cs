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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NewsDbContext _context = new NewsDbContext();

        
        public Category Get(Expression<Func<Category, bool>> expression)
        {
            return _context.Categories.FirstOrDefault(expression);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories;
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Category> GetMany(Expression<Func<Category, bool>> expression)
        {
            return _context.Categories.Where(expression);
        }

        public void Insert(Category obj)
        {
            _context.Categories.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Category obj)
        {
            _context.Categories.AddOrUpdate(obj);
        }

        public int Count()
        {
            return _context.Categories.Count();
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }
        }

        public void Dispose()
        {
            if(_context == null) return;
            _context.Dispose();
        }
    }
}


