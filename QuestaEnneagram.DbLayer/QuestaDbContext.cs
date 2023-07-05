using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuestaEnneagram.DbLayer.DBModel;
using QuestaEnneagram.DbLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestaEnneagram.DbLayer
{
    public class QuestaDbContext : DbContext
    {
        public QuestaDbContext(DbContextOptions<QuestaDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbCandidateModel>().HasOne(x=>x.State).WithMany(x=>x.Candidates).HasForeignKey(x=>x.StateId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<DbHrMapToCompanyModel>().HasOne(x => x.HumanResource).WithMany(x => x.HrMapToCompanies).HasForeignKey(x => x.HrId).OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }
     //   public DbSet<Department> departments { get; set; }
     //  public DbSet<Employee> employees { get; set; }
        public DbSet<DbAgeModel> Ages { get; set; }
        public DbSet<DbCountryModel> Countries { get; set; }
        public DbSet<DbGenderModel> Genders { get; set; }
        public DbSet<DbStateModel> States { get; set; }
        public DbSet<DbEmployeeStatusModel> EmployeeStatus { get; set; }
        public DbSet<DbExperenceModel> Experences { get; set; }
        public DbSet<DbMaritalStatusModel> MaritalStatus { get; set; }
        public DbSet<DbProfessionalModel> Professionals { get; set; }
        public DbSet<DbQualificationModel> Qualifications { get; set; }
        public DbSet<DbIndustryModel> Industries { get; set; }
        public DbSet<DbTxnIndustryModel> CandidateWiseIndustries { get; set; }
        public DbSet<DbCandidateModel> Candidates { get; set; }
        public DbSet<DbAssessmentModel> Assessments { get; set; }
        public DbSet<DbCompanyModel> Companies { get; set; }
        public DbSet<DbHumanResourceModel> HumanResources { get; set; }
        public DbSet<DbHrMapToCompanyModel> HrMapToCompanies { get; set; }
    }
}
