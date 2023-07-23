using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("TxnHrMapToCompany")]
    public class DbHrMapToCompanyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CMapHId { get; set; }
        public int CompanyId { get; set; }
        public DbCompanyModel Company { get; set; }
        public int HrId { get; set; }
        public DbHumanResourceModel HumanResource { get; set; }

        public int AssessmentId { get; set; }
        public DbAssessmentModel dbAssessmentModel { get; set; }
        public int? InitialMailId { get; set; }
        public int? FinalMailId { get; set; }
        public bool IsReportSentToCandidate { get; set; }
        public bool IsReportSentToHr { get; set; }
        public bool IsBulkLinkGenerationReq { get; set; }
        public int? CountOfLink { get; set; }

        [StringLength(200)]
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        [StringLength(200)]
        public string? LastModifiedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public bool IsActive { get; set; }

    }
}
