using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QuestaEnneagram.DbLayer.DBModel;
using QuestaEnneagram.ServiceLayer.EF.Interface;
using QuestaEnneagram.ServiceLayer.Interface;
using QuestaEnneagram.ServiceLayer.Model;
using System.Data;

namespace QuestaEnneagram.ServiceLayer.Service
{
    public class Candidatesvc : ICandidate,IDisposable
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Candidatesvc(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        ~Candidatesvc()
        {
            Dispose(false);
        }


        public CandidateBM GetCandidateDetailsByTestId(int TestId)
        {
            try
            {
                return _unitOfWork.dbContext.Candidates.Join(_unitOfWork.dbContext.CandidateTestDetails, i => i.CandidateId, j => j.CandidateId, (i, j) => new { i, j }).
                    Where(x => x.j.TestId == TestId).Select(x => new CandidateBM
                    {
                        CandidateId = x.i.CandidateId,
                        TestId = x.j.TestId,
                        Title = x.i.Title,
                        FirstName = x.i.FirstName,
                        LastName = x.i.LastName,
                        Email = x.i.Email,
                        PhoneNumber = x.i.PhoneNumber,
                        DateOfBirth = x.i.DateOfBirth,
                        GenderId = x.i.GenderId,
                        AgeId = x.i.AgeId,
                        StateId = x.i.StateId,
                        CountryId = x.i.CountryId,
                        QualificationId = x.i.QualificationId,
                        ProfessionalId = x.i.ProfessionalId,
                        MaritalStatusId = x.i.MaritalStatusId,
                        EmployeeStatusId = x.i.EmployeeStatusId,
                        ExperienceId = x.i.ExperienceId,
                        IsConnectedViaMobile = x.i.IsConnectedViaMobile,
                        IsConnectedViaDesktop = x.i.IsConnectedViaDesktop,
                        IsConnectedViaTab = x.i.IsConnectedViaTab,
                        BrowserName = x.i.BrowserName,
                        IsOTPRequire = x.i.IsOTPRequire,
                        IsActive = x.i.IsActive,
                        IsLogin = x.i.IsLogin,
                        MainType = x.i.MainType,
                        CreatedAt = x.i.CreatedAt,
                        LastModified = x.i.LastModified,
                        AssessmentId = x.i.AssessmentId
                    }).FirstOrDefault();
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public CandidateBM GetCandidateDetailsByCandidateId(int CandidateId)
        {
            try
            {
                return _unitOfWork.dbContext.Candidates.Join(_unitOfWork.dbContext.CandidateTestDetails, i => i.CandidateId, j => j.CandidateId, (i, j) => new { i, j }).
                    Where(x => x.j.CandidateId == CandidateId).Select(x => new CandidateBM
                    {
                        CandidateId = x.i.CandidateId,
                        Title = x.i.Title,
                        FirstName = x.i.FirstName,
                        LastName = x.i.LastName,
                        Email = x.i.Email,
                        PhoneNumber = x.i.PhoneNumber,
                        DateOfBirth = x.i.DateOfBirth,
                        GenderId = x.i.GenderId,
                        AgeId = x.i.AgeId,
                        StateId = x.i.StateId,
                        CountryId = x.i.CountryId,
                        QualificationId = x.i.QualificationId,
                        ProfessionalId = x.i.ProfessionalId,
                        MaritalStatusId = x.i.MaritalStatusId,
                        EmployeeStatusId = x.i.EmployeeStatusId,
                        ExperienceId = x.i.ExperienceId,
                        IsConnectedViaMobile = x.i.IsConnectedViaMobile,
                        IsConnectedViaDesktop = x.i.IsConnectedViaDesktop,
                        IsConnectedViaTab = x.i.IsConnectedViaTab,
                        BrowserName = x.i.BrowserName,
                        IsOTPRequire = x.i.IsOTPRequire,
                        IsActive = x.i.IsActive,
                        IsLogin = x.i.IsLogin,
                        MainType = x.i.MainType,
                        CreatedAt = x.i.CreatedAt,
                        LastModified = x.i.LastModified,
                        AssessmentId = x.i.AssessmentId
                    }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public HrMapToCompanyBM GetHrNCompanyMapDetailByCMapHrId(int CMapHId)
        {
            try
            {
                HrMapToCompanyBM ObjHrMapCompanyModel = null;
                DbHrMapToCompanyModel _HrMapCompanyModel =  _unitOfWork.dbContext.HrMapToCompanies.Where(x => x.CMapHId == CMapHId).FirstOrDefault();

                if (_HrMapCompanyModel == null)
                    return ObjHrMapCompanyModel;


                return this._mapper.Map<DbHrMapToCompanyModel, HrMapToCompanyBM>(_HrMapCompanyModel);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public int SaveInitialCandidateData(int CMapHId,int AssessmentId)
        {
            DateTime DateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

            try
            {
                DbCandidateModel objCandidate = new DbCandidateModel
                {
                    IsActive = true,
                    IsOTPRequire = false,
                    CreatedAt = DateTime,
                    LastModified = DateTime,
                    AssessmentId = AssessmentId,
                    CMapHId = CMapHId
                };
                _unitOfWork.dbContext.Candidates.Add(objCandidate);
                int status = _unitOfWork.dbContext.SaveChanges();
                int CandidateId = objCandidate.CandidateId;

                int TestId = GenerateAssessmentBaseOnTestId(CandidateId, AssessmentId, null, null);
                return TestId;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public bool IsDateDifferenceForOneYear(int CandidateId)
        {
            try
            {
                DateTime DateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                DateTime _createdat = _unitOfWork.dbContext.Candidates.Where(x => x.CandidateId == CandidateId).Select(x => x.CreatedAt).FirstOrDefault();

                var daydiff = (_createdat - DateTime).TotalDays;

                if (daydiff > 365)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch(Exception ex)
            {
                throw;
            }
        }


        public async Task<Tuple<string, bool>> SaveCandidateDetails(CandidateBM CandidateData)
        {
            bool IsSuccess = false;
            string Message = string.Empty;
            DateTime DateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            var command = _unitOfWork.dbContext.Database.GetDbConnection().CreateCommand();
            try
            {
                await Task.Run(() => {

                    DataTable DTCandidateModel = CreateDataTable(CandidateData);
                    DTCandidateModel.Columns.Remove("DateOfBirth");
                    DTCandidateModel.Columns.Remove("CreatedAt");
                    DTCandidateModel.Columns.Remove("LastModified");
                    DTCandidateModel.Columns.Remove("Industry");
                    DTCandidateModel.Columns.Remove("IndustryTxt");
                    command.Connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[uspSaveCandidateData]";

                    // command.Parameters.Add(new SqlParameter("@CandidateBMTbl", SqlDbType.Structured) { Value = DTCandidateModel,TypeName= "dbo.CandidateBMTbl" });
                    command.Parameters.Add(new SqlParameter("@CandidateBMTbl", DTCandidateModel));
                    command.ExecuteNonQuery();

                    Message = "Data saved successfully";
                });
            }
            catch(Exception ex)
            {
                Message = ex.Message;
                throw;
            }
            finally
            {
                _unitOfWork.dbContext.Database.CloseConnection();
            }
            return Tuple.Create(Message, IsSuccess);
        }

        public int InsertRefreshTokenBaseOnTestId(int TestId,string RefreshToken,DateTime RefreshTokenExpiryTime)
        {
            try
            {
                DateTime DateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                DbRefreshTokenModel RefreshDbModel = new DbRefreshTokenModel()
                {
                    TestId = TestId,
                    RefreshToken = RefreshToken,
                    RefreshTokenCreatedTime = DateTime,
                    RefreshTokenExpiryTime = RefreshTokenExpiryTime
                };
                _unitOfWork.dbContext.dbRefreshTokenModels.Add(RefreshDbModel);

                return _unitOfWork.dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public RefreshTokenBM GetRefreshTokenDetailsBaseOnTestId(int TestId)
        {
            var refreshtoken = _unitOfWork.dbContext.dbRefreshTokenModels.Where(x=>x.TestId == TestId).FirstOrDefault();

            return this._mapper.Map<DbRefreshTokenModel, RefreshTokenBM>(refreshtoken);
        }

        public int UpdateRefreshToken(RefreshTokenBM refreshtokenbm)
        {
            try
            {
                var _currentRefreshToken = _unitOfWork.dbContext.dbRefreshTokenModels.Where(x=>x.TestId == refreshtokenbm.TestId).FirstOrDefault();

                DbRefreshTokenModel dbRefreshTokenModel = this._mapper.Map<RefreshTokenBM, DbRefreshTokenModel>(refreshtokenbm);

                if(_currentRefreshToken != null)
                {
                    _unitOfWork.dbContext.Entry(_currentRefreshToken).CurrentValues.SetValues(dbRefreshTokenModel);
                }
                
                return _unitOfWork.dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private int GenerateAssessmentBaseOnTestId(int CandidateId,int? AssessmentId,int? TestId,int? ModuleId)
        {
            var command = _unitOfWork.dbContext.Database.GetDbConnection().CreateCommand();
            int _TestId;
            try
            {
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[UspGenerateAssessment]";
                command.Parameters.Add(new SqlParameter("@CandidateId", SqlDbType.Int) { Value = CandidateId });
                command.Parameters.Add(new SqlParameter("@TestId", SqlDbType.Int) { Value = TestId });
                command.Parameters.Add(new SqlParameter("@ModuleId", SqlDbType.Int) { Value = ModuleId });
                command.Parameters.Add(new SqlParameter("@AssessmentId", SqlDbType.Int) { Value = AssessmentId });
                command.Parameters.Add(new SqlParameter("@OUTTestId", SqlDbType.Int) { Direction = ParameterDirection.Output });


                command.ExecuteNonQuery();


                _TestId = (int)command.Parameters["@OUTTestId"].Value;

                return _TestId;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _unitOfWork.dbContext.Database.CloseConnection();
            }
        }


        private static DataTable CreateDataTable(object ClassObject)
        {
            DataTable return_Datatable = new DataTable();
            Type t = ClassObject.GetType();
            foreach (System.Reflection.PropertyInfo info in t.GetProperties())
            {
                if (info.Name == "Industry")
                {
                    return_Datatable.Columns.Add(new DataColumn(info.Name, typeof(string)));
                }
                else
                {
                    return_Datatable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
                }

            }

            DataRow dr = return_Datatable.NewRow();
            foreach (DataColumn dc in return_Datatable.Columns)
            {
                if (dc.ColumnName == "Industry")
                {
                    string[] Industry = (string[])ClassObject.GetType().GetProperty(dc.ColumnName).GetValue(ClassObject, null);

                    dr[dc.ColumnName] = string.Join(",", Industry);
                }
                else
                {
                    dr[dc.ColumnName] = ClassObject.GetType().GetProperty(dc.ColumnName).GetValue(ClassObject, null);
                }

            }
            return_Datatable.Rows.Add(dr);


            return return_Datatable;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                // Console.WriteLine("This is the first call to Dispose. Necessary clean-up will be done!");

                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    // Console.WriteLine("Explicit call: Dispose is called by the user.");
                }
                else
                {
                    // Console.WriteLine("Implicit call: Dispose is called through finalization.");
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // Console.WriteLine("Unmanaged resources are cleaned up here.");

                // TODO: set large fields to null.

                disposedValue = true;
            }
            else
            {
                // Console.WriteLine("Dispose is called more than one time. No need to clean up!");
            }
        }



        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
