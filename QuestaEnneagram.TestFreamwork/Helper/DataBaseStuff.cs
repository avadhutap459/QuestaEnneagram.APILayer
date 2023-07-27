using Dapper;
using QuestaEnneagram.ServiceLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestaEnneagram.TestFreamwork.Helper
{
    public  class DataBaseStuff
    {
        public static IDbConnection connection
        {
            get
            {
                return new SqlConnection("Data Source=DESKTOP-6I56UFD;Initial Catalog=QuestaEnneagram;Integrated Security=True");
            }
        }


        public static MasterBM GetMasterDetail()
        {
            MasterBM master = new MasterBM();

            using(IDbConnection cn = connection)
            {
                cn.Open();
                var data = cn.QueryMultiple("UspGetMasterDetails", commandType: CommandType.StoredProcedure);

                master.lstCountries = data.Read<MasterModel>().ToList();
                master.lstQualifications = data.Read<MasterModel>().ToList();
                master.lstProfessionals = data.Read<MasterModel>().ToList();
                master.lstAge = data.Read<MasterModel>().ToList();
                master.lstGenders = data.Read<MasterModel>().ToList();
                master.lstMaritalStatus = data.Read<MasterModel>().ToList();
                master.lstEmployeeStatus = data.Read<MasterModel>().ToList();
                master.Industry = data.Read<MasterModel>().Select(x => x.Name).ToList();
                master.lstExperences = data.Read<MasterModel>().ToList();
            }

            return master;
        }

        public static CandidateBM GetCandidateDetailByTestId(int TestId)
        {
            CandidateBM candidate = new CandidateBM();

            using(IDbConnection cn = connection)
            {
                cn.Open();

                string SelectQry = "Select TC.CandidateId,TCT.TestId,TC.Title,TC.FirstName,TC.LastName,TC.Email,TC.PhoneNumber,TC.DateOfBirth," +
                    "TC.GenderId,TC.AgeId,TC.StateId,TC.CountryId,TC.QualificationId,TC.ProfessionalId,TC.MaritalStatusId,TC.EmployeeStatusId," +
                    "TC.ExperienceId,TC.IsConnectedViaMobile,TC.IsConnectedViaDesktop,TC.IsConnectedViaTab,TC.BrowserName,TC.IsOTPRequire," +
                    "TC.IsActive,TC.IsLogin,TC.MainType,TC.CreatedAt,TC.LastModified,TC.AssessmentId from [dbo].[txnCandidate] TC " +
                    "INNER JOIN [dbo].[txnCandidateTestDetails] TCT On TC.CandidateId = TCT.CandidateId WHERE TCT.TestId = @TestId";


                candidate = cn.Query<CandidateBM>(SelectQry,new { TestId  = TestId }).FirstOrDefault();
            }

            return candidate;
        }

        public static IList<StateBM> RetrunStateDetailsBaseOnCountryId(int CountryId)
        {
            IList<StateBM> state = new List<StateBM>();

            using (IDbConnection cn = connection)
            {
                cn.Open();

                state = cn.Query<StateBM>("select * from mstState Where CountryId = @CountryId", new { CountryId = CountryId }).ToList();

            }

                return state;
        }

        public static HrMapToCompanyBM GetHrNCompanyMapDetailByCMapHrId()
        {
            HrMapToCompanyBM ObjHrMapCompanyModel = new HrMapToCompanyBM
            {
                CMapHId = 1,
                CompanyId = 1,
                HrId = 1,
                InitialMailId = 1,
                FinalMailId = 1,
                IsReportSentToCandidate = true,
                IsReportSentToHr = false,
                CreatedBy = "Admin",
                LastModifiedBy = "Admin",
                IsActive = true,
                AssessmentId = 1,
                CountOfLink = 1,
                IsBulkLinkGenerationReq = false
            };

            return ObjHrMapCompanyModel;
        }

    }
}
