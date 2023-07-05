using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("mstHumanResource")]
    public class DbHumanResourceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HrId { get; set; }

        [StringLength(200)]
        public string HrName { get; set; }

        [StringLength(50)]
        public string? HrMobileNo { get; set; }

        [StringLength(200)]
        public string? HrEmail { get; set; }

        public int CompanyId { get;set; }
        public DbCompanyModel Company { get; set; }

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
