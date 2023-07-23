using QuestaEnneagram.ServiceLayer.Model;


namespace QuestaEnneagram.ServiceLayer.Interface
{
    public interface IMaster
    {
        MasterBM GetMasterDetails();
        string[] GetIndustryDataByCandidateId(int CandidateId);
        Task<IList<StateBM>> GetStateDetailByCountryId(int CountryId);
        Tuple<bool, string> IsCompanyAndHrExist(int CompanyNHrId);
        string GetConfigurationValueById(string ConfigName);
        bool IsAssessmentExist(int AssessmentId);
    }
}
