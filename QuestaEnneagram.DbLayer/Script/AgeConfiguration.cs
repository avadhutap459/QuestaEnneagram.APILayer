using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuestaEnneagram.DbLayer.DBModel;
using System.Linq;

namespace QuestaEnneagram.DbLayer.Script
{
    public class AgeConfiguration : IEntityTypeConfiguration<DbAgeModel>
    {
        public void Configure(EntityTypeBuilder<DbAgeModel> builder)
        {

            builder.ToTable("mstAge");

            builder.Property(x => x.AgeId).UseIdentityColumn();
            builder.Property(s => s.IsActive).HasDefaultValue(true);
            builder.HasData(
                new DbAgeModel {AgeId = 1, AgeName = "18-21" },
                new DbAgeModel { AgeId = 2, AgeName = "22-24" },
                new DbAgeModel { AgeId = 3, AgeName = "25-34" },
                new DbAgeModel { AgeId = 4, AgeName = "35-44" },
                new DbAgeModel { AgeId = 5, AgeName = "45-54" },
                new DbAgeModel { AgeId = 6, AgeName = "55-64" },
                new DbAgeModel { AgeId = 7, AgeName = "65-74" },
                new DbAgeModel { AgeId = 8, AgeName = "75 and above" }
            );

        }
    }



}
