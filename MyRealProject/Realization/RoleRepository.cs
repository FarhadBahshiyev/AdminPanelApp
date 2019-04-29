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
    public class RoleRepository : IRoleRepository
    {
        private readonly NewsDbContext context = new NewsDbContext();

        public IEnumerable<Role> GetAll()
        {
            return context.Roles;
        }

        public Role GetById(int id)
        {
            return context.Roles.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Role obj)
        {
            context.Roles.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Role obj)
        {
            context.Roles.AddOrUpdate();
        }
        public int Count()
        {
            return context.Roles.Count();
        }

        public void Delete(int id)
        {
            var role = GetById(id);
            if (role!=null)
            {
                context.Roles.Remove(role);
            }
        }

        public Role Get(Expression<Func<Role, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetMany(Expression<Func<Role, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if(context == null) return;
            context.Dispose();
        }
    }
}