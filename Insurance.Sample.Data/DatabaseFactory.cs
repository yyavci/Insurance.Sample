using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Data
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private DbContext dataContext;

        public DatabaseFactory(DbContext dbContext)
        {
            this.dataContext = dbContext;
        }

        public DbContext Get()
        {
            return dataContext;
        }

        public void Dispose()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }


    }
}
