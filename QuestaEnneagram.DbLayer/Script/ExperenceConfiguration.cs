using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuestaEnneagram.DbLayer.DBModel;
using System.Linq;

namespace QuestaEnneagram.DbLayer.Script
{
    public class ExperenceConfiguration : IEntityTypeConfiguration<DbExperenceModel>
    {
        public void Configure(EntityTypeBuilder<DbExperenceModel> builder)
        {

            builder.ToTable("mstExperence");

            builder.Property(x => x.ExperienceId).HasColumnName("ExperienceId")
                    .HasColumnType("int").ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(s => s.IsActive).HasDefaultValue(true);
            builder.HasData(
                new DbExperenceModel { ExperenceName = "0–4 yrs" },
                new DbExperenceModel { ExperenceName = "5-10yrs" },
                new DbExperenceModel { ExperenceName = "10-15yrs" },
                new DbExperenceModel { ExperenceName = "15-20yrs" },
                new DbExperenceModel { ExperenceName = "20-25yrs" },
                new DbExperenceModel { ExperenceName = "25yrs and above" }
            );

        }
    }



}
