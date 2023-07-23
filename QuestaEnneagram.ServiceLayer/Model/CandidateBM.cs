using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestaEnneagram.ServiceLayer.Model
{
    public class CandidateBM
    {
        public int CandidateId { get; set; }
        public int? TestId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
        public Nullable<int> GenderId { get; set; }
        public string GenderTxt { get; set; }
        public Nullable<int> AgeId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> QualificationId { get; set; }
        public string QualificationTxt { get; set; }
        public Nullable<int> ProfessionalId { get; set; }
        public Nullable<int> MaritalStatusId { get; set; }
        public Nullable<int> EmployeeStatusId { get; set; }
        public Nullable<int> ExperienceId { get; set; }
        public string[] Industry { get; set; }
        public string IndustryTxt { get; set; }
        public Nullable<bool> IsConnectedViaMobile { get; set; }
        public Nullable<bool> IsConnectedViaDesktop { get; set; }
        public Nullable<bool> IsConnectedViaTab { get; set; }
        public string BrowserName { get; set; }
        public Nullable<bool> IsOTPRequire { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsLogin { get; set; }
        public int? MainType { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> LastModified { get; set; }
        public int AssessmentId { get; set; }
        public int CMapHId { get; set; }

    }
}
