﻿// <auto-generated />
using System;
using APAdmin.Infra.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APAdmin.Infra.Database.Migrations
{
    [DbContext(typeof(APAdminDbContext))]
    partial class APAdminDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("APAdmin.Domain.ClassAttendanceModule.ClassAttendance", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Present")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Week")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeamId");

                    b.ToTable("TBClassAttendance", (string)null);
                });

            modelBuilder.Entity("APAdmin.Domain.StudentModule.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MeetingName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("TBStudent", (string)null);
                });

            modelBuilder.Entity("APAdmin.Domain.TeamModule.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TBTeam", (string)null);
                });

            modelBuilder.Entity("APAdmin.Domain.ClassAttendanceModule.ClassAttendance", b =>
                {
                    b.HasOne("APAdmin.Domain.StudentModule.Student", "Student")
                        .WithMany("ClassesAttendances")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("APAdmin.Domain.TeamModule.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("APAdmin.Domain.StudentModule.Student", b =>
                {
                    b.HasOne("APAdmin.Domain.TeamModule.Team", "Team")
                        .WithMany("Students")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("APAdmin.Domain.StudentModule.Student", b =>
                {
                    b.Navigation("ClassesAttendances");
                });

            modelBuilder.Entity("APAdmin.Domain.TeamModule.Team", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
