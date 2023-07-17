using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuestaEnneagram.DbLayer.DBModel;
using QuestaEnneagram.DbLayer.Model;
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
            modelBuilder.Entity<DbCandidateModel>().HasOne(x=>x.State).WithMany(x=>x.Candidates).HasForeignKey(x=>x.StateId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<DbHrMapToCompanyModel>().HasOne(x => x.HumanResource).WithMany(x => x.HrMapToCompanies).HasForeignKey(x => x.HrId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<DbCandidateTestDetailModel>().Property(x => x.TestId).UseIdentityColumn(seed: 10000, increment: 1);
            modelBuilder.Entity<DbModuleWiseStatusModel>().HasOne(x => x.CandidateTestDetails).WithMany(x => x.ModuleWiseStatus).HasForeignKey(x => x.TestId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DbModuleWiseStatusModel>().HasOne(x => x.AssessmentModules).WithMany(x => x.ModuleWiseStatus).HasForeignKey(x => x.ModuleId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DbAttachSetToModuleModel>().HasOne(x => x.AssessmentModules).WithMany(x => x.AttachSetToModules).HasForeignKey(x => x.ModuleId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DbQuestionModel>().HasOne(x => x.QuestionTypeModels).WithMany(x => x.QuestionModels).HasForeignKey(x => x.TypeId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DbQuestionModel>().HasOne(x => x.AssessmentModuleModel).WithMany(x => x.QuestionModels).HasForeignKey(x => x.ModuleId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DbQuestionModel>().HasOne(x => x.QuestionReponseType).WithMany(x => x.QuestionModels).HasForeignKey(x => x.ResponseTypeId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DbQuestionResponseModel>().HasOne(x => x.QuestionModel).WithMany(x => x.QuestionResponseModels).HasForeignKey(x => x.QuestionId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DbQuestionResponseModel>().HasOne(x => x.QuestionModel).WithMany(x => x.QuestionResponseModels).HasForeignKey(x => x.QuestionId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DbTransactionQuestionModel>().HasOne(x => x.QuestionModel).WithMany(x => x.transactionQuestions).HasForeignKey(x => x.QuestionId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<DbTransactionQuestionModel>().HasOne(x => x.CandidateTestDetailModel).WithMany(x => x.transactionQuestions).HasForeignKey(x => x.TestId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<DbTransactionQuestionModel>().HasOne(x => x.AssessmentModuleModel).WithMany(x => x.transactionQuestions).HasForeignKey(x => x.ModuleId).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<DbTransactionQuestionResponseModel>().HasOne(x => x.QuestionModel).WithMany(x => x.transactionQuestionResponses).HasForeignKey(x => x.QuestionId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<DbTransactionQuestionResponseModel>().HasOne(x => x.QuestionResponseModel).WithMany(x => x.transactionQuestionResponses).HasForeignKey(x => x.ResponseId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<DbTransactionQuestionResponseModel>().HasOne(x => x.transactionQuestion).WithMany(x => x.transactionQuestionResponses).HasForeignKey(x => x.TxnQuestionId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<DbTransactionQuestionResponseModel>().HasOne(x => x.CandidateTestDetailModel).WithMany(x => x.transactionQuestionResponses).HasForeignKey(x => x.TestId).OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }
     //   public DbSet<Department> departments { get; set; }
     //  public DbSet<Employee> employees { get; set; }
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
    }
}
