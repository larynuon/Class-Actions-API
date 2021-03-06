// <auto-generated />
using System;
using Class_Actions_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Class_Actions_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Class_Actions_API.Models.Claim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FencingCost")
                        .HasColumnType("float");

                    b.Property<double>("GroundsCost")
                        .HasColumnType("float");

                    b.Property<string>("Insurer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("LabourCost")
                        .HasColumnType("float");

                    b.Property<string>("NamesOnPolicy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PolicyNo")
                        .HasColumnType("int");

                    b.Property<double>("TotalClaimCost")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("Class_Actions_API.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOL")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LandOwner")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Suburb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Class_Actions_API.Models.Claim", b =>
                {
                    b.HasOne("Class_Actions_API.Models.Client", "Client")
                        .WithMany("Claims")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Class_Actions_API.Models.Client", b =>
                {
                    b.Navigation("Claims");
                });
#pragma warning restore 612, 618
        }
    }
}
