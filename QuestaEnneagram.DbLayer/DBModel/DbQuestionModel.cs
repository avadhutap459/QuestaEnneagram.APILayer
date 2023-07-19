using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("mstQuestionType")]
    public class DbQuestionTypeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }

        [StringLength(100)]
        public string? TypeName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }

        [StringLength(100)]
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        [StringLength(100)]
        public string? LastModifiedBy { get; set; }
        public ICollection<DbQuestionModel> QuestionModels { get; set; }

    }

    [Table("mstQuestionSubType")]
    public class DbQuestionSubTypeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubTypeId { get; set; }

        [StringLength(100)]
        public string? SubTypeName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }

        [StringLength(100)]
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        [StringLength(100)]
        public string? LastModifiedBy { get; set; }

        public ICollection<DbQuestionResponseModel> QuestionResponseModel { get; set; }

    }




    [Table("mstQuestionReponseType")]
    public class DbQuestionReponseType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResponseTypeId { get; set; }
        
        [StringLength(100)]
        public string? ResponseTypeName { get; set; }
        public DateTime? CreatedAt { get; set; }
        
        [StringLength(100)]
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        
        [StringLength(100)]
        public string? LastModifiedBy { get; set; }
        public ICollection<DbQuestionModel> QuestionModels { get; set; }

    }

    [Table("mstQuestion")]
    public class DbQuestionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        public string? Question { get; set; }
        public int TypeId { get; set; }
        public DbQuestionTypeModel QuestionTypeModels { get; set; }
        public int ModuleId { get; set; }
        public DbAssessmentModuleModel AssessmentModuleModel { get; set; }
        public int ResponseTypeId { get; set; }
        public DbQuestionReponseType QuestionReponseType { get; set; }
        public bool IsActive { get; set; }
        public DateTime?  CreatedAt { get; set; }

        [StringLength(100)]
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        [StringLength(100)]
        public string? LastModifiedBy { get; set; }
        public ICollection<DbQuestionResponseModel> QuestionResponseModels { get; set; }
        public ICollection<DbTransactionQuestionModel> transactionQuestions { get; set; }
        public ICollection<DbTransactionQuestionResponseModel> transactionQuestionResponses { get; set; }

    }

    [Table("mstQuestionResponse")]
    public class DbQuestionResponseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResponseId { get; set; }
        public int QuestionId { get; set; }
        public DbQuestionModel QuestionModel { get; set; }
        public int ResponseNumber { get; set; }
        public string? ResponseText { get; set; }
        public int weight { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }

        [StringLength(100)]
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        [StringLength(100)]
        public string? LastModifiedBy { get; set; }

        public int? SubTypeId { get; set; }
        public DbQuestionSubTypeModel dbQuestionSubTypeModel { get; set; }
        public ICollection<DbTransactionQuestionResponseModel> transactionQuestionResponses { get; set; }

    }

    [Table("txnQuestion")]
    public class DbTransactionQuestionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TxnQuestionId { get; set; }
        public int QuestionId { get; set; }
        public DbQuestionModel QuestionModel { get; set; }
        public int? ImpactScore { get; set; }
        public int TestId { get; set; }
        public DbCandidateTestDetailModel CandidateTestDetailModel { get; set; }
        public bool? IsAnswer { get; set; }
        public int ModuleId { get; set; }
        public DbAssessmentModuleModel AssessmentModuleModel { get; set; }
        public DateTime? ResponseAt { get; set; }
        public int? ResponseBy { get; set; }
        public ICollection<DbTransactionQuestionResponseModel> transactionQuestionResponses { get; set; }

    }

    [Table("txnQuestionResponse")]
    public class DbTransactionQuestionResponseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestQuestionResponseId { get; set; }
        public int QuestionId { get; set; }
        public DbQuestionModel QuestionModel { get; set; }
        public int ResponseId { get; set; }
        public DbQuestionResponseModel QuestionResponseModel { get; set; }
        public int TxnQuestionId { get; set; }
        public DbTransactionQuestionModel transactionQuestion { get; set; }
        public int TestId { get; set; }
        public DbCandidateTestDetailModel CandidateTestDetailModel { get; set; }
    }
}
