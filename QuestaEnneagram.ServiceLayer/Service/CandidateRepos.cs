using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestaEnneagram.DbLayer;
using QuestaEnneagram.DbLayer.DBModel;
using QuestaEnneagram.ServiceLayer.EF.Service;
using QuestaEnneagram.ServiceLayer.Interface;

namespace QuestaEnneagram.ServiceLayer.Service
{
    public class CandidateRepos : GenericRepository<DbCandidateModel>, ICandidateRepo
    {
        public CandidateRepos(QuestaDbContext QuestaDb) : base(QuestaDb)
        {
        }

        public override Task<List<DbCandidateModel>> GetAllAsync()
        {
            return base.GetAllAsync();
        }
        public override async Task<DbCandidateModel> GetAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(item => item.CandidateId == id);
        }

        public override async Task<bool> AddEntity(DbCandidateModel entity)
        {
            try
            {
                await DbSet.AddAsync(entity);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override async Task<bool> UpdateEntity(DbCandidateModel entity)
        {
            try
            {
                var existdata = await DbSet.FirstOrDefaultAsync(item => item.CandidateId == entity.CandidateId);
                if (existdata != null)
                {
                    existdata.FirstName = entity.FirstName;
                    existdata.PhoneNumber = entity.PhoneNumber;
                    existdata.Email = entity.Email;
                    existdata.AssessmentId = entity.AssessmentId;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<bool> DeleteEntity(int id)
        {
            var existdata = await DbSet.FirstOrDefaultAsync(item => item.CandidateId == id);
            if (existdata != null)
            {
                DbSet.Remove(existdata);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
