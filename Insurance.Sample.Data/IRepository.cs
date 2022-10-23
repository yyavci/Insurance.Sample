using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Data
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        
        void Add(T value);

        void Update(T value);

        void Delete(int id);

        void Delete(T Entity);

        T Get(int id);
    }
}
