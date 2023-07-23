using Microsoft.EntityFrameworkCore;
using QuestaEnneagram.DbLayer.DBModel;


namespace QuestaEnneagram.DbLayer.Script
{
    public static class ClsForeignKeyAdd
    {
        public static void AddForeignKey(ref ModelBuilder modelBuilder)
        {
            try
            {
               
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
                modelBuilder.Entity<DbQuestionResponseModel>().HasOne(x=>x.dbQuestionSubTypeModel).WithMany(x=>x.QuestionResponseModel).HasForeignKey(x=>x.SubTypeId).OnDelete(DeleteBehavior.ClientSetNull);
                modelBuilder.Entity<DbHrMapToCompanyModel>().HasOne(x => x.dbAssessmentModel).WithMany(x => x.dbHrMapToCompanyModels).HasForeignKey(x => x.AssessmentId).OnDelete(DeleteBehavior.ClientSetNull);

                modelBuilder.Entity<DbRefreshTokenModel>().HasOne(x => x.dbCandidateTestDetailModel).WithMany(x => x.dbRefreshTokenModels).HasForeignKey(x => x.TestId).OnDelete(DeleteBehavior.ClientSetNull);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
