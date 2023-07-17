using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("mstAssessmentModule")]
    public class DbAssessmentModuleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModuleId { get; set; }

        [StringLength(100)]
        public string? ModuleName { get; set; }

        [StringLength(100)]
        public string? PartialModuleName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }

        [StringLength(100)]
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        [StringLength(100)]
        public string? LastModifiedBy { get; set; }
        public ICollection<DbModuleWiseStatusModel> ModuleWiseStatus { get; set; }
        public ICollection<DbAttachSetToModuleModel> AttachSetToModules { get; set; }
        public ICollection<DbQuestionModel> QuestionModels { get; set; }
        public ICollection<DbTransactionQuestionModel> transactionQuestions { get; set; }
        public ICollection<DbTransactionQuestionResponseModel> TransactionQuestionResponses { get; set; }
    }

    [Table("txnModuleWiseStatus")]
    public class DbModuleWiseStatusModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamId { get; set; }
        public int TestId { get; set; }
        public DbCandidateTestDetailModel CandidateTestDetails { get; set; }

        public int ModuleId { get; set; }
        public DbAssessmentModuleModel AssessmentModules { get; set; }

        [StringLength(10)]
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }

        public DateTime? LastModifiedAt { get; set; }
    }

    [Table("TxnAttachSetToModule")]
    public class DbAttachSetToModuleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SetToModuleId { get; set; }

        public int AssessmentId { get; set; }
        public DbAssessmentModel Assessment { get; set; }
        public int ModuleId { get; set; }
        public DbAssessmentModuleModel AssessmentModules { get; set; }

        public DateTime? CreatedAt { get; set; }

        [StringLength(100)]
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        [StringLength(100)]
        public string? LastModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
