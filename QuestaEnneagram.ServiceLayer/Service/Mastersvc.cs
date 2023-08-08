//using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QuestaEnneagram.ServiceLayer.EF.Interface;
using QuestaEnneagram.ServiceLayer.Interface;
using QuestaEnneagram.ServiceLayer.Model;
using System.Data;

namespace QuestaEnneagram.ServiceLayer.Service
{

    public class Mastersvc : IMaster, IDisposable
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        public IUnitOfWork _unitOfWork;

        public Mastersvc(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        ~Mastersvc()
        {
            Dispose(false);
        }
        public MasterBM GetMasterDetails()
        {
            MasterBM objmastermodel = new MasterBM();
            DataSet dataSet = null;
            var command = _unitOfWork.dbContext.Database.GetDbConnection().CreateCommand();
            try
            {
                command.CommandText = "[dbo].[UspGetMasterDetails]";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = (SqlCommand)command;

                    dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    objmastermodel.lstCountries = dataSet.Tables[0].AsEnumerable().Select(r => new Model.MasterModel
                    {
                        Id = r.Field<int>("Id"),
                        Name = r.Field<string>("Name"),
                        IsActive = r.Field<bool>("IsActive")
                    }).ToList();
                    objmastermodel.lstQualifications = dataSet.Tables[1].AsEnumerable().Select(r => new Model.MasterModel
                    {
                        Id = r.Field<int>("Id"),
                        Name = r.Field<string>("Name"),
                        IsActive = r.Field<bool>("IsActive")
                    }).ToList();
                    objmastermodel.lstProfessionals = dataSet.Tables[2].AsEnumerable().Select(r => new Model.MasterModel
                    {
                        Id = r.Field<int>("Id"),
                        Name = r.Field<string>("Name"),
                        IsActive = r.Field<bool>("IsActive")
                    }).ToList();
                    objmastermodel.lstAge = dataSet.Tables[3].AsEnumerable().Select(r => new Model.MasterModel
                    {
                        Id = r.Field<int>("Id"),
                        Name = r.Field<string>("Name"),
                        IsActive = r.Field<bool>("IsActive")
                    }).ToList();
                    objmastermodel.lstGenders = dataSet.Tables[4].AsEnumerable().Select(r => new Model.MasterModel
                    {
                        Id = r.Field<int>("Id"),
                        Name = r.Field<string>("Name"),
                        IsActive = r.Field<bool>("IsActive")
                    }).ToList();
                    objmastermodel.lstMaritalStatus = dataSet.Tables[5].AsEnumerable().Select(r => new Model.MasterModel
                    {
                        Id = r.Field<int>("Id"),
                        Name = r.Field<string>("Name"),
                        IsActive = r.Field<bool>("IsActive")
                    }).ToList();
                    objmastermodel.lstEmployeeStatus = dataSet.Tables[6].AsEnumerable().Select(r => new Model.MasterModel
                    {
                        Id = r.Field<int>("Id"),
                        Name = r.Field<string>("Name"),
                        IsActive = r.Field<bool>("IsActive")
                    }).ToList();
                    //objmastermodel.lstIndustries = dataSet.Tables[7].AsEnumerable().Select(r => new Model.MasterModel
                    //{
                    //    Id = r.Field<int>("Id"),
                    //    Name = r.Field<string>("Name"),
                    //    IsActive = r.Field<bool>("IsActive")
                    //}).ToList();

                    objmastermodel.Industry = dataSet.Tables[7].AsEnumerable().Select(r => r.Field<string>("Name")).ToList();

                    objmastermodel.lstExperences = dataSet.Tables[8].AsEnumerable().Select(r => new Model.MasterModel
                    {
                        Id = r.Field<int>("Id"),
                        Name = r.Field<string>("Name"),
                        IsActive = r.Field<bool>("IsActive")
                    }).ToList();
                }
                return objmastermodel;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public string[] GetIndustryDataByCandidateId(int CandidateId)
        {
            try
            {
                return _unitOfWork.dbContext.Industries.Join(_unitOfWork.dbContext.CandidateWiseIndustries, i => i.IndustryId, j => j.IndustryId, (i, j) => new { i, j })
                    .Where(x => x.j.CandidateId == CandidateId).Select(y => y.i.IndustryName).ToArray();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<IList<StateBM>> GetStateDetailByCountryId(int CountryId)
        {
            try
            {
                return await _unitOfWork.dbContext.States.Where(x => x.CountryId == CountryId && x.IsActive == true).Select(y => new StateBM
                {
                    Id = y.StateId,
                    Name = y.StateName,
                    IsActive = y.IsActive,
                    CountryId = y.CountryId,
                }).ToListAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        //public async Task<IList<StateBM>> GetStateDetailByCountryIdDapper(int CountryId)
        //{
        //    try
        //    {
        //        List<StateBM> state = new List<StateBM>();
        //        using (var cn = new Microsoft.Data.SqlClient.SqlConnection("Data Source=questadb.cirpbpm7tkaa.ap-south-1.rds.amazonaws.com;initial catalog=QuestaEnneagram;user id=questaLive;password=Welcome2020;MultipleActiveResultSets=True"))
        //        {
        //            cn.Open();
        //            state = cn.Query<StateBM>("select StateId As Id,StateName As Name,IsActive As IsActive,CountryId As CountryId from [dbo].[mstState] where CountryId = 1").ToList();
        //        }
        //        return state;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public Tuple<bool,string> IsCompanyAndHrExist(int CompanyNHrId)
        {
            try
            {
                if(!_unitOfWork.dbContext.HrMapToCompanies.Any(x=>x.CMapHId == CompanyNHrId))
                {
                    return new Tuple<bool, string>(false, "Company and human resource does not map with each other");
                }

                var _CompanyNHrMap = _unitOfWork.dbContext.HrMapToCompanies.Where(x => x.CMapHId == CompanyNHrId).FirstOrDefault();

                if(!_unitOfWork.dbContext.Companies.Any(x=>x.CompanyId == _CompanyNHrMap.CompanyId))
                {
                    return new Tuple<bool, string>(false, "Company does not avaiable in current context");
                }

                if(!_unitOfWork.dbContext.HumanResources.Any(x=>x.HrId == _CompanyNHrMap.HrId))
                {
                    return new Tuple<bool, string>(false, "Human resource does not avaiable in current context");
                }

                if(!_unitOfWork.dbContext.Assessments.Any(x=>x.AssessmentId == _CompanyNHrMap.AssessmentId))
                {
                    return new Tuple<bool, string>(false, "Assessment does not avaiable in current context");
                }

                return new Tuple<bool, string>(true, "Success");
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public string GetConfigurationValueById(string ConfigName)
        {
            try
            {
                return _unitOfWork.dbContext.MstConfigs.Where(x=>x.ConfigName == ConfigName).Select(y=>y.ConfigValue).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public bool IsAssessmentExist(int AssessmentId)
        {
            try
            {
                if(_unitOfWork.dbContext.Assessments.Any(x=>x.AssessmentId == AssessmentId))
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
