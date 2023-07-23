using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("mstMaritalStatus")]
    public class DbMaritalStatusModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaritalId { get; set; }

        [StringLength(100)]
        public string? MaritalName { get; set; }
        public bool IsActive { get; set; }
    }
}
