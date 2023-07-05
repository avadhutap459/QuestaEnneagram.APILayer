using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("mstQualification")]
    public class DbQualificationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QualificationId { get; set; }

        [StringLength(100)]
        public string? QualificationName { get; set; }
        public bool IsActive { get; set; }
        public ICollection<DbCandidateModel> Candidates { get; set; }
    }
}
