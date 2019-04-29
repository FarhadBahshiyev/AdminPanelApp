using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using Expression = Microsoft.Ajax.Utilities.Expression;

namespace MyRealProject.Repository
{
    public interface IRepository<T> : IDisposable
    {
        //Butun datalari chekirik
        IEnumerable<T> GetAll();

        //Id-ye gore data
        T GetById(int id);

        T Get(Expression<Func<T, bool>> expression);

        IEnumerable<T> GetMany(Expression<Func<T, bool>> expression);

        void Insert(T obj);
        void Update(T obj);
        void Save();
        void Delete(int id);

        int Count();
    }
}
