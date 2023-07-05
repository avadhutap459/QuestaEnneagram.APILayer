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
        public DbGenderModel Gender { get; set; }

        //Foreign key of Age
        public int AgeId { get; set; }
        public DbAgeModel Age { get; set; }

        //Foreign key of State
        public int StateId { get; set; }
        public DbStateModel State { get; set; }

        //Foreign key of Country
        public int CountryId { get; set; }
        public DbCountryModel Country { get; set; }

        //Foreign key of Qualification
        public int QualificationId { get; set; }
        public DbQualificationModel Qualification { get; set; }

        //Foreign key of Professional
        public int ProfessionalId { get; set; }
        public DbProfessionalModel Professional { get; set; }

        //Foreign key of MaritalStatusId
        public int MaritalStatusId { get; set; }
        public DbMaritalStatusModel MaritalStatus { get; set; }

        //Foreign key of EmployeeStatusId
        public int EmployeeStatusId { get; set; }
        public DbEmployeeStatusModel EmployeeStatus { get; set; }

        //Foreign key of ExperienceId
        public int ExperienceId { get; set; }
        public DbExperenceModel Experience { get; set; }
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
        public ICollection<DbTxnIndustryModel> Industries { get; set; }

        //Foreign key of Assessement
        public int AssessmentId { get; set; }
        public DbAssessmentModel Assessment { get; set; }

        //Foreign key of TxnHrMapToCompany
        public int CMapHId { get; set; }
        public DbHrMapToCompanyModel HrMapToCompanies { get; set; }

    }
}
