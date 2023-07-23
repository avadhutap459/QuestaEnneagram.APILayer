

namespace QuestaEnneagram.ServiceLayer.Model
{
    public class MasterBM
    {
        public List<MasterModel> lstCountries { get; set; } = new List<MasterModel>();
        public List<MasterModel> lstQualifications { get; set; } = new List<MasterModel>();
        public List<MasterModel> lstProfessionals { get; set; } = new List<MasterModel>();
        public List<MasterModel> lstAge { get; set; } = new List<MasterModel>();
        public List<MasterModel> lstGenders { get; set; } = new List<MasterModel>();
        public List<MasterModel> lstMaritalStatus { get; set; } = new List<MasterModel>();
        public List<MasterModel> lstEmployeeStatus { get; set; } = new List<MasterModel>();
        public List<MasterModel> lstIndustries { get; set; } = new List<MasterModel>();
        public List<MasterModel> lstExperences { get; set; } = new List<MasterModel>();
        public List<string> Industry { get; set; }
    }
    public class MasterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }

    public class StateBM : MasterModel
    {
        public int CountryId { get; set; }
    }
}
