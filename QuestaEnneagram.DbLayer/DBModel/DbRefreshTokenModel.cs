using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("TxnRefreshToken")]
    public class DbRefreshTokenModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RefreshTokenId { get; set; }
        public int TestId { get; set; }
        public DbCandidateTestDetailModel dbCandidateTestDetailModel { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenCreatedTime { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
