﻿// <auto-generated />
using System;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(MiejscaKulturyDbContext))]
    [Migration("20240410135657_Add_UserId_To_Places")]
    partial class Add_UserId_To_Places
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Comments", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("PlaceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlacesId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlacesId");

                    b.HasIndex("UsersId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Domain.Entities.Likes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Like")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("PlaceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlacesId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlacesId");

                    b.HasIndex("UsersId");

                    b.ToTable("Like");
                });

            modelBuilder.Entity("Domain.Entities.Opens", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Fridady")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Monday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("PlaceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlacesId")
                        .HasColumnType("uuid");

                    b.Property<string>("Saturday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sunday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Thursday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tuesday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Wednesday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PlacesId");

                    b.ToTable("Open");
                });

            modelBuilder.Entity("Domain.Entities.Photos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("MinioPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("PlaceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlacesId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlacesId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("Domain.Entities.Places", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AverageRatings")
                        .HasColumnType("integer");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Localization")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("Domain.Entities.Reviews", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PlaceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlacesId")
                        .HasColumnType("uuid");

                    b.Property<int>("Review")
                        .HasColumnType("integer");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlacesId");

                    b.HasIndex("UsersId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Domain.Entities.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.Entities.Comments", b =>
                {
                    b.HasOne("Domain.Entities.Places", "Places")
                        .WithMany()
                        .HasForeignKey("PlacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Places");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.Likes", b =>
                {
                    b.HasOne("Domain.Entities.Places", "Places")
                        .WithMany()
                        .HasForeignKey("PlacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Places");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.Opens", b =>
                {
                    b.HasOne("Domain.Entities.Places", "Places")
                        .WithMany()
                        .HasForeignKey("PlacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Places");
                });

            modelBuilder.Entity("Domain.Entities.Photos", b =>
                {
                    b.HasOne("Domain.Entities.Places", "Places")
                        .WithMany()
                        .HasForeignKey("PlacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Places");
                });

            modelBuilder.Entity("Domain.Entities.Places", b =>
                {
                    b.HasOne("Domain.Entities.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.Reviews", b =>
                {
                    b.HasOne("Domain.Entities.Places", "Places")
                        .WithMany()
                        .HasForeignKey("PlacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Places");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
