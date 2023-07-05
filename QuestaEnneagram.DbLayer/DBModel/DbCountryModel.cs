using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("mstCountry")]
    public class DbCountryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }

        [StringLength(100)]
        public string? CountryName { get; set; }
        public bool IsActive { get; set; }
        public ICollection<DbStateModel> states { get; set; }
        public ICollection<DbCandidateModel> Candidates { get; set; }
    }
}
