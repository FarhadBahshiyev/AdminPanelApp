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
    public class UserRepository : IUserRepository
    {

        private readonly NewsDbContext context = new NewsDbContext();

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }

        public User GetById(int id)
        {
            return context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(User obj)
        {
            context.Users.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(User obj)
        {
            context.Users.AddOrUpdate(obj);
        }

        public int Count()
        {
            return context.Users.Count();
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                context.Users.Remove(user);
            }
        }

        public User Get(Expression<Func<User, bool>> expression)
        {
            return context.Users.FirstOrDefault(expression);
        }

        public IEnumerable<User> GetMany(Expression<Func<User, bool>> expression)
        {
            return  context.Users.Where(expression);
        }

        public void Dispose()
        {
            if(context == null) return;
            context.Dispose();
        }
    }
}