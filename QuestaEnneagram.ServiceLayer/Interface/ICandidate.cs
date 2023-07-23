using QuestaEnneagram.ServiceLayer.Model;


namespace QuestaEnneagram.ServiceLayer.Interface
{
    public interface ICandidate
    {
        CandidateBM GetCandidateDetailsByTestId(int TestId);
        CandidateBM GetCandidateDetailsByCandidateId(int CandidateId);
        HrMapToCompanyBM GetHrNCompanyMapDetailByCMapHrId(int CMapHId);
        int SaveInitialCandidateData(int CMapHId, int AssessmentId);
        bool IsDateDifferenceForOneYear(int CandidateId);
        Task<Tuple<string, bool>> SaveCandidateDetails(CandidateBM CandidateData);
        int InsertRefreshTokenBaseOnTestId(int TestId, string RefreshToken, DateTime RefreshTokenExpiryTime);
        RefreshTokenBM GetRefreshTokenDetailsBaseOnTestId(int TestId);
        int UpdateRefreshToken(RefreshTokenBM refreshtokenbm);
    }
}
