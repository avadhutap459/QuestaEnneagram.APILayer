using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("txnCandidateTestDetails")]
    public class DbCandidateTestDetailModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestId { get; set; }
        public int CandidateId { get; set; }
        public DbCandidateModel Candidate { get; set; }

        [StringLength(100)]
        public string? status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        public ICollection<DbModuleWiseStatusModel> ModuleWiseStatus { get; set; }
        public ICollection<DbTransactionQuestionModel> transactionQuestions { get; set; }
        public ICollection<DbTransactionQuestionResponseModel> transactionQuestionResponses { get; set; }
        public ICollection<DbRefreshTokenModel> dbRefreshTokenModels { get; set; }
    }
}
