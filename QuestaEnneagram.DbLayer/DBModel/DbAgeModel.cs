using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("mstAge")]
    public class DbAgeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgeId { get; set; }

        [StringLength(100)]
        public string? AgeName { get; set; }
        public bool IsActive { get; set; }
        public ICollection<DbCandidateModel> Candidates { get; set; }
    }
}
