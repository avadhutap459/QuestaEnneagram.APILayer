using Microsoft.EntityFrameworkCore;
using QuestaEnneagram.DbLayer;
using QuestaEnneagram.ServiceLayer.EF.Interface;


namespace QuestaEnneagram.ServiceLayer.EF.Service
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected QuestaDbContext dbContext;
        internal DbSet<T> DbSet { get; set; }
        public GenericRepository(QuestaDbContext _dbContext)
        {
            this.dbContext = _dbContext;
            this.DbSet = this.dbContext.Set<T>();
        }
        public virtual Task<bool> AddEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<T>> GetAllAsync()
        {
            return this.DbSet.ToListAsync();
        }

        public virtual Task<T> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpdateEntity(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
