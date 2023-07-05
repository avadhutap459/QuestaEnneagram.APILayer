using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("mstIndustry")]
    public class DbIndustryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IndustryId { get; set; }

        [StringLength(100)]
        public string? IndustryName { get; set; }
        public bool IsActive { get; set; }
        public ICollection<DbTxnIndustryModel> Industry { get; set; }
    }

    [Table("txnIndustry")]
    public class DbTxnIndustryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //The Following Property Exists in the Standard Entity
        public int IndustryId { get; set; }
        //To Create a Foreign Key it should have the Standard Navigational Property
        public DbIndustryModel Industry { get; set; }

        //The Following Property Exists in the Standard Entity
        public int CandidateId { get; set; }
        //To Create a Foreign Key it should have the Standard Navigational Property
        public DbCandidateModel Candidate { get; set; }
    }
}
