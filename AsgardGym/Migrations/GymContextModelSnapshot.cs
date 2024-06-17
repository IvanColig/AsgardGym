﻿// <auto-generated />
using System;
using AsgardGym;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AsgardGym.Migrations
{
    [DbContext(typeof(GymContext))]
    partial class GymContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("AsgardGym.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AdminID");

                    b.HasIndex("KorisnickoIme")
                        .IsUnique();

                    b.ToTable("Admini");
                });

            modelBuilder.Entity("AsgardGym.Models.Korisnik", b =>
                {
                    b.Property<int>("KorisnikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DatumRodenja")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Telefon")
                        .HasColumnType("INTEGER");

                    b.HasKey("KorisnikID");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("AsgardGym.Models.Posjeta", b =>
                {
                    b.Property<int>("PosjetaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DatumPosjete")
                        .HasColumnType("TEXT");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("INTEGER");

                    b.HasKey("PosjetaID");

                    b.HasIndex("KorisnikID");

                    b.ToTable("Posjete");
                });

            modelBuilder.Entity("AsgardGym.Models.Usluga", b =>
                {
                    b.Property<int>("UslugaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cijena")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UslugaID");

                    b.ToTable("Usluge");
                });

            modelBuilder.Entity("AsgardGym.Models.UslugaKorisnika", b =>
                {
                    b.Property<int>("KorisnikID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UslugaID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DatumKoristenja")
                        .HasColumnType("TEXT");

                    b.HasKey("KorisnikID", "UslugaID", "DatumKoristenja");

                    b.HasIndex("UslugaID");

                    b.ToTable("UslugeKorisnika");
                });

            modelBuilder.Entity("AsgardGym.Models.Posjeta", b =>
                {
                    b.HasOne("AsgardGym.Models.Korisnik", "Korisnik")
                        .WithMany("Posjete")
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("AsgardGym.Models.UslugaKorisnika", b =>
                {
                    b.HasOne("AsgardGym.Models.Korisnik", "Korisnik")
                        .WithMany("UslugeKorisnika")
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AsgardGym.Models.Usluga", "Usluga")
                        .WithMany("UslugeKorisnika")
                        .HasForeignKey("UslugaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Usluga");
                });

            modelBuilder.Entity("AsgardGym.Models.Korisnik", b =>
                {
                    b.Navigation("Posjete");

                    b.Navigation("UslugeKorisnika");
                });

            modelBuilder.Entity("AsgardGym.Models.Usluga", b =>
                {
                    b.Navigation("UslugeKorisnika");
                });
#pragma warning restore 612, 618
        }
    }
}
