using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("mstProfessional")]
    public class DbProfessionalModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfessionalId { get; set; }

        [StringLength(100)]
        public string? ProfessionalName { get; set; }
        public bool IsActive { get; set; }
    }
}
