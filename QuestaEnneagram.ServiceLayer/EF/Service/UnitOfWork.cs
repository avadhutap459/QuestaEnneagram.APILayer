using QuestaEnneagram.DbLayer;
using QuestaEnneagram.ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestaEnneagram.ServiceLayer.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuestaDbContext _context;
        public UnitOfWork(QuestaDbContext context)
        {
            _context = context;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
