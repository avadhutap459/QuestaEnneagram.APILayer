using QuestaEnneagram.DbLayer;
using QuestaEnneagram.ServiceLayer.EF.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestaEnneagram.ServiceLayer.EF.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuestaDbContext _dbContext;
        public IEmployeeRepository Employees { get; }
        public IDepartmentRepository Departments { get; }

        public UnitOfWork(QuestaDbContext DbContext,
                            IEmployeeRepository employees,
                            IDepartmentRepository departments)
        {
            _dbContext = DbContext;
            Employees = employees;
            Departments = departments;
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
