using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("mstEmployeeStatus")]
    public class DbEmployeeStatusModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmploymentId { get; set; }

        [StringLength(100)]
        public string? EmploymentName { get; set; }
        public bool IsActive { get; set; }
        public ICollection<DbCandidateModel> Candidates { get; set; }
    }
}
