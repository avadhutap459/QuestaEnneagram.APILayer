using QuestaEnneagram.DbLayer;
using QuestaEnneagram.ServiceLayer.EF.Interface;


namespace QuestaEnneagram.ServiceLayer.EF.Service
{
    public class UnitofWorkRepo : IUnitOfWork
    {
        private readonly QuestaDbContext _dbContext;

        public UnitofWorkRepo(QuestaDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public QuestaDbContext dbContext
        {
            get { return _dbContext; }
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
