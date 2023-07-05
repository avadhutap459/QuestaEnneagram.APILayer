﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuestaEnneagram.DbLayer;

#nullable disable

namespace QuestaEnneagram.DbLayer.Migrations
{
    [DbContext(typeof(QuestaDbContext))]
    partial class QuestaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbAgeModel", b =>
                {
                    b.Property<int>("AgeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgeId"), 1L, 1);

                    b.Property<string>("AgeName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("AgeId");

                    b.ToTable("mstAge");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbCandidateModel", b =>
                {
                    b.Property<int>("CandidateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CandidateId"), 1L, 1);

                    b.Property<int>("AgeId")
                        .HasColumnType("int");

                    b.Property<string>("BrowserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("EmployeeStatusId")
                        .HasColumnType("int");

                    b.Property<int>("ExperienceId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsConnectedViaDesktop")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsConnectedViaMobile")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsConnectedViaTab")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsLogin")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsOTPRequire")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("MainType")
                        .HasColumnType("int");

                    b.Property<int>("MaritalStatusId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProfessionalId")
                        .HasColumnType("int");

                    b.Property<int>("QualificationId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CandidateId");

                    b.HasIndex("AgeId");

                    b.HasIndex("CountryId");

                    b.HasIndex("EmployeeStatusId");

                    b.HasIndex("ExperienceId");

                    b.HasIndex("GenderId");

                    b.HasIndex("MaritalStatusId");

                    b.HasIndex("ProfessionalId");

                    b.HasIndex("QualificationId");

                    b.HasIndex("StateId");

                    b.ToTable("txnCandidate");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbCountryModel", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"), 1L, 1);

                    b.Property<string>("CountryName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("CountryId");

                    b.ToTable("mstCountry");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbEmployeeStatusModel", b =>
                {
                    b.Property<int>("EmploymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmploymentId"), 1L, 1);

                    b.Property<string>("EmploymentName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("EmploymentId");

                    b.ToTable("mstEmployeeStatus");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbExperenceModel", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExperienceId"), 1L, 1);

                    b.Property<string>("ExperenceName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("ExperienceId");

                    b.ToTable("mstExperence");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbGenderModel", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderId"), 1L, 1);

                    b.Property<string>("GenderName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("GenderId");

                    b.ToTable("mstGender");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbIndustryModel", b =>
                {
                    b.Property<int>("IndustryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IndustryId"), 1L, 1);

                    b.Property<string>("IndustryName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("IndustryId");

                    b.ToTable("mstIndustry");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbMaritalStatusModel", b =>
                {
                    b.Property<int>("MaritalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaritalId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MaritalName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaritalId");

                    b.ToTable("mstMaritalStatus");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbProfessionalModel", b =>
                {
                    b.Property<int>("ProfessionalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfessionalId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ProfessionalName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ProfessionalId");

                    b.ToTable("mstProfessional");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbQualificationModel", b =>
                {
                    b.Property<int>("QualificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QualificationId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("QualificationName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("QualificationId");

                    b.ToTable("mstQualification");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbStateModel", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateId"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("StateName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("StateId");

                    b.HasIndex("CountryId");

                    b.ToTable("mstState");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbTxnIndustryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<int>("IndustryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("IndustryId");

                    b.ToTable("txnIndustry");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbCandidateModel", b =>
                {
                    b.HasOne("QuestaEnneagram.DbLayer.DBModel.DbAgeModel", "Age")
                        .WithMany("Candidates")
                        .HasForeignKey("AgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuestaEnneagram.DbLayer.DBModel.DbCountryModel", "Country")
                        .WithMany("Candidates")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuestaEnneagram.DbLayer.DBModel.DbEmployeeStatusModel", "EmployeeStatus")
                        .WithMany("Candidates")
                        .HasForeignKey("EmployeeStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuestaEnneagram.DbLayer.DBModel.DbExperenceModel", "Experience")
                        .WithMany("Candidates")
                        .HasForeignKey("ExperienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuestaEnneagram.DbLayer.DBModel.DbGenderModel", "Gender")
                        .WithMany("Candidates")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuestaEnneagram.DbLayer.DBModel.DbMaritalStatusModel", "MaritalStatus")
                        .WithMany("Candidates")
                        .HasForeignKey("MaritalStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuestaEnneagram.DbLayer.DBModel.DbProfessionalModel", "Professional")
                        .WithMany("Candidates")
                        .HasForeignKey("ProfessionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuestaEnneagram.DbLayer.DBModel.DbQualificationModel", "Qualification")
                        .WithMany("Candidates")
                        .HasForeignKey("QualificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuestaEnneagram.DbLayer.DBModel.DbStateModel", "State")
                        .WithMany("Candidates")
                        .HasForeignKey("StateId")
                        .IsRequired();

                    b.Navigation("Age");

                    b.Navigation("Country");

                    b.Navigation("EmployeeStatus");

                    b.Navigation("Experience");

                    b.Navigation("Gender");

                    b.Navigation("MaritalStatus");

                    b.Navigation("Professional");

                    b.Navigation("Qualification");

                    b.Navigation("State");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbStateModel", b =>
                {
                    b.HasOne("QuestaEnneagram.DbLayer.DBModel.DbCountryModel", "Country")
                        .WithMany("states")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbTxnIndustryModel", b =>
                {
                    b.HasOne("QuestaEnneagram.DbLayer.DBModel.DbCandidateModel", "Candidate")
                        .WithMany("Industries")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuestaEnneagram.DbLayer.DBModel.DbIndustryModel", "Industry")
                        .WithMany("Industry")
                        .HasForeignKey("IndustryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Industry");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbAgeModel", b =>
                {
                    b.Navigation("Candidates");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbCandidateModel", b =>
                {
                    b.Navigation("Industries");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbCountryModel", b =>
                {
                    b.Navigation("Candidates");

                    b.Navigation("states");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbEmployeeStatusModel", b =>
                {
                    b.Navigation("Candidates");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbExperenceModel", b =>
                {
                    b.Navigation("Candidates");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbGenderModel", b =>
                {
                    b.Navigation("Candidates");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbIndustryModel", b =>
                {
                    b.Navigation("Industry");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbMaritalStatusModel", b =>
                {
                    b.Navigation("Candidates");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbProfessionalModel", b =>
                {
                    b.Navigation("Candidates");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbQualificationModel", b =>
                {
                    b.Navigation("Candidates");
                });

            modelBuilder.Entity("QuestaEnneagram.DbLayer.DBModel.DbStateModel", b =>
                {
                    b.Navigation("Candidates");
                });
#pragma warning restore 612, 618
        }
    }
}
