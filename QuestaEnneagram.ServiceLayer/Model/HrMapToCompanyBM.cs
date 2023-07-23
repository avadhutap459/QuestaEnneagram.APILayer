using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestaEnneagram.ServiceLayer.Model
{
    public class HrMapToCompanyBM
    {
        public int CMapHId { get; set; }
        public int CompanyId { get; set; }
        public int HrId { get; set; }
        public int? InitialMailId { get; set; }
        public int? FinalMailId { get; set; }
        public bool IsReportSentToCandidate { get; set; }
        public bool IsReportSentToHr { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public int AssessmentId { get; set; }
        public int CountOfLink { get; set; }
        public bool IsBulkLinkGenerationReq { get; set; }
    }
}
