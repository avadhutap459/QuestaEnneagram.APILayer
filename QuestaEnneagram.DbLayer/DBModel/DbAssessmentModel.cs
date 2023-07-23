using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("mstAssessmentSet")]
    public class DbAssessmentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssessmentId { get; set; }

        [StringLength(200)]
        public string AssessmentName { get; set; }

        [StringLength(200)]
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        [StringLength(200)]
        public string? LastModifiedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public int? TotalQuestion { get; set; }
        public bool IsActive { get; set; }

        public ICollection<DbAttachSetToModuleModel> AttachSetToModules { get; set; }
        public ICollection<DbHrMapToCompanyModel> dbHrMapToCompanyModels { get; set; }

    }
}
