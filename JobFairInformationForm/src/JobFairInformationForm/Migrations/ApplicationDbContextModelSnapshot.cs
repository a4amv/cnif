using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using JobFairInformationForm.Database;

namespace JobFairInformationForm.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobFairInformationForm.Database.Entities.InformationForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Allocation");

                    b.Property<string>("Education");

                    b.Property<string>("Email");

                    b.Property<DateTime>("GraduationDate");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<int>("PhoneNumber");

                    b.Property<string>("PreferredJob");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("InformationForm");
                });
        }
    }
}
