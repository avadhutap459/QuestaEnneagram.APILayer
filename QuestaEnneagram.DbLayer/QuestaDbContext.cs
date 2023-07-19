using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuestaEnneagram.DbLayer.DBModel;
using QuestaEnneagram.DbLayer.Model;
using QuestaEnneagram.DbLayer.Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestaEnneagram.DbLayer
{
    public class QuestaDbContext : DbContext
    {
        public QuestaDbContext(DbContextOptions<QuestaDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ClsForeignKeyAdd.AddForeignKey(ref modelBuilder);
            modelBuilder.ApplyConfiguration(new AgeConfiguration());
          //  modelBuilder.ApplyConfiguration(new ExperenceConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<DbAgeModel> Ages { get; set; }
        public DbSet<DbCountryModel> Countries { get; set; }
        public DbSet<DbGenderModel> Genders { get; set; }
        public DbSet<DbStateModel> States { get; set; }
        public DbSet<DbEmployeeStatusModel> EmployeeStatus { get; set; }
        public DbSet<DbExperenceModel> Experences { get; set; }
        public DbSet<DbMaritalStatusModel> MaritalStatus { get; set; }
        public DbSet<DbProfessionalModel> Professionals { get; set; }
        public DbSet<DbQualificationModel> Qualifications { get; set; }
        public DbSet<DbIndustryModel> Industries { get; set; }
        public DbSet<DbTxnIndustryModel> CandidateWiseIndustries { get; set; }
        public DbSet<DbCandidateModel> Candidates { get; set; }
        public DbSet<DbAssessmentModel> Assessments { get; set; }
        public DbSet<DbCompanyModel> Companies { get; set; }
        public DbSet<DbHumanResourceModel> HumanResources { get; set; }
        public DbSet<DbHrMapToCompanyModel> HrMapToCompanies { get; set; }
        public DbSet<DbAssessmentModuleModel> AssessmentModules { get; set; }
        public DbSet<DbCandidateTestDetailModel> CandidateTestDetails { get; set; }
        public DbSet<DbModuleWiseStatusModel> ModuleWiseStatus { get; set; }
        public DbSet<DbAttachSetToModuleModel> AttachSetToModules { get; set; }
        public DbSet<DbQuestionTypeModel> QuestionTypeModels { get; set; }
        public DbSet<DbQuestionReponseType> QuestionReponseTypes { get; set; }
        public DbSet<DbQuestionModel> QuestionModels { get; set; }
        public DbSet<DbQuestionResponseModel> QuestionResponseModels { get; set; }

        public DbSet<DbTransactionQuestionModel> TransactionQuestionModels { get; set; }

        public DbSet<DbTransactionQuestionResponseModel> TransactionQuestionResponseModels { get; set; }
        public DbSet<DbQuestionSubTypeModel> QuestionSubTypeModels { get; set; }
    }
}
