using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("txnCandidate")]
    public class DbCandidateModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateId { get; set; }
        
        [StringLength(50)]
        public string? Title { get; set; }

        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(150)]
        public string? Email { get; set; }

        [StringLength(50)]
        public string? PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        //Foreign key of gender
        public int GenderId { get; set; }

        //Foreign key of Age
        public int AgeId { get; set; }

        //Foreign key of State
        public int StateId { get; set; }

        //Foreign key of Country
        public int CountryId { get; set; }

        //Foreign key of Qualification
        public int QualificationId { get; set; }

        //Foreign key of Professional
        public int ProfessionalId { get; set; }

        //Foreign key of MaritalStatusId
        public int MaritalStatusId { get; set; }

        //Foreign key of EmployeeStatusId
        public int EmployeeStatusId { get; set; }

        //Foreign key of ExperienceId
        public int ExperienceId { get; set; }
        public bool? IsConnectedViaMobile { get; set; }
        public bool? IsConnectedViaDesktop { get; set; }
        public bool? IsConnectedViaTab { get; set; }

        [StringLength(50)]
        public string? BrowserName { get; set; }
        public bool? IsOTPRequire { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsLogin { get; set; }
        public int? MainType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
        
        //Foreign key of Assessement
        public int AssessmentId { get; set; }

        //Foreign key of TxnHrMapToCompany
        public int CMapHId { get; set; }

        public ICollection<DbTxnIndustryModel> Industries { get; set; }

        public ICollection<DbCandidateTestDetailModel> CandidateTestDetails { get; set; }

    }
}
