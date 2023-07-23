using QuestaEnneagram.DbLayer;


namespace QuestaEnneagram.ServiceLayer.EF.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        QuestaDbContext dbContext { get; }

    }
}
