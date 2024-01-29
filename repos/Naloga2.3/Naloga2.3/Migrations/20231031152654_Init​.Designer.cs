﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Naloga2._3;

#nullable disable

namespace Naloga2._3.Migrations
{
    [DbContext(typeof(Program.KavarneDbContext))]
    [Migration("20231031152654_Init​")]
    partial class Init​
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Naloga2._3.Program+Kavarna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("kraj")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("letoUstanovitve")
                        .HasColumnType("INTEGER");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Kavarne");
                });

            modelBuilder.Entity("Naloga2._3.Program+Natakar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("letoRojstva")
                        .HasColumnType("INTEGER");

                    b.Property<string>("priimek")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Natakari");
                });

            modelBuilder.Entity("Naloga2._3.Program+NatakarVKavarni", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("kavarnaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("letoDo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("letoOd")
                        .HasColumnType("INTEGER");

                    b.Property<int>("natakarId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("kavarnaId");

                    b.HasIndex("natakarId");

                    b.ToTable("NatakariKavarn");
                });

            modelBuilder.Entity("Naloga2._3.Program+NatakarVKavarni", b =>
                {
                    b.HasOne("Naloga2._3.Program+Kavarna", "kavarna")
                        .WithMany("NatakariKavarn")
                        .HasForeignKey("kavarnaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Naloga2._3.Program+Natakar", "natakar")
                        .WithMany("NatakariKavarn")
                        .HasForeignKey("natakarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kavarna");

                    b.Navigation("natakar");
                });

            modelBuilder.Entity("Naloga2._3.Program+Kavarna", b =>
                {
                    b.Navigation("NatakariKavarn");
                });

            modelBuilder.Entity("Naloga2._3.Program+Natakar", b =>
                {
                    b.Navigation("NatakariKavarn");
                });
#pragma warning restore 612, 618
        }
    }
}
