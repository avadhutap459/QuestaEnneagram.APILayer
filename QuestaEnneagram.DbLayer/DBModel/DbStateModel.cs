using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("mstState")]
    public class DbStateModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateId { get; set; }

        [StringLength(100)]
        public string? StateName { get; set; }
        public bool IsActive { get; set; }

        //Foreign key for country
        public int CountryId { get; set; }
        public DbCountryModel Country { get; set; }
    }
}
