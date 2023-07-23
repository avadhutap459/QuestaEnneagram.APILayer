using AutoMapper;
using QuestaEnneagram.DbLayer.DBModel;
using QuestaEnneagram.ServiceLayer.Model;

namespace QuestaEnneagram.ServiceLayer.AutoMapper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<DbHrMapToCompanyModel, HrMapToCompanyBM>();
            CreateMap<DbMailTemplateModel, MailBM>();
            CreateMap<DbRefreshTokenModel, RefreshTokenBM>();
            CreateMap<RefreshTokenBM, DbRefreshTokenModel>();
        }
        
    }
}
