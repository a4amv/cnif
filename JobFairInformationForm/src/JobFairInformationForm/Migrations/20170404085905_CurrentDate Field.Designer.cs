using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using JobFairInformationForm.Database;

namespace JobFairInformationForm.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170404085905_CurrentDate Field")]
    partial class CurrentDateField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobFairInformationForm.Database.Entities.InformationForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Allocation");

                    b.Property<DateTime>("CurrentDate");

                    b.Property<string>("Education");

                    b.Property<string>("Email");

                    b.Property<DateTime>("GraduationDate");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<string>("NoteString");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PreferredJob");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("InformationForm");
                });

            modelBuilder.Entity("JobFairInformationForm.Database.Entities.InformationForm2Location", b =>
                {
                    b.Property<int>("InformationFormId");

                    b.Property<int>("LocationId");

                    b.HasKey("InformationFormId", "LocationId");

                    b.HasIndex("InformationFormId");

                    b.HasIndex("LocationId");

                    b.ToTable("InformationForm2Location");
                });

            modelBuilder.Entity("JobFairInformationForm.Database.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("JobFairInformationForm.Database.Entities.InformationForm2Location", b =>
                {
                    b.HasOne("JobFairInformationForm.Database.Entities.InformationForm", "InformationForm")
                        .WithMany("InformationForm2Locations")
                        .HasForeignKey("InformationFormId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobFairInformationForm.Database.Entities.Location", "Location")
                        .WithMany("InformationForm2Locations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
