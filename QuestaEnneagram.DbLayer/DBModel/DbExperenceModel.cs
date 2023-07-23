using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("mstExperence")]
    public class DbExperenceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExperienceId { get; set; }

        [StringLength(100)]
        public string? ExperenceName { get; set; }
        public bool IsActive { get; set; }
    }
}
