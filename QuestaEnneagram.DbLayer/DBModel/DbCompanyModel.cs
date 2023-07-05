using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("mstCompany")]
    public class DbCompanyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }

        [StringLength(200)]
        public string CompanyName { get; set; }

        public ICollection<DbHumanResourceModel> HumanResources { get; set; }

        [StringLength(200)]
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        [StringLength(200)]
        public string? LastModifiedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public ICollection<DbHrMapToCompanyModel> HrMapToCompanies { get; set; }
    }
}
