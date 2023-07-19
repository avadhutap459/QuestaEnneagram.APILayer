using QuestaEnneagram.DbLayer.DBModel;
using QuestaEnneagram.ServiceLayer.EF.Interface;


namespace QuestaEnneagram.ServiceLayer.Interface
{
    public interface ICandidateRepo : IGenericRepository<DbCandidateModel>
    {
    }
}
