﻿// <auto-generated />
using System;
using Fest.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fest.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230313123145_Inittt")]
    partial class Inittt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Fest.Entities.Concrate.ArtistEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstagramUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAcvtive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LinkedInUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TwitterUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YoutubeUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists", (string)null);
                });

            modelBuilder.Entity("Fest.Entities.Concrate.ArtistMusicTypeEntity", b =>
                {
                    b.Property<int>("MusicTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.HasKey("MusicTypeId", "ArtistId");

                    b.HasIndex("ArtistId");

                    b.ToTable("ArtistMusicTypeEntities");
                });

            modelBuilder.Entity("Fest.Entities.Concrate.BlogEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAcvtive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LikeCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReadCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Blogs", (string)null);
                });

            modelBuilder.Entity("Fest.Entities.Concrate.CityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAcvtive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities", (string)null);
                });

            modelBuilder.Entity("Fest.Entities.Concrate.CommentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Dislike")
                        .HasColumnType("int");

                    b.Property<int>("FestId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAcvtive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("Like")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FestId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("Fest.Entities.Concrate.CountryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAcvtive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Countries", (string)null);
                });

            modelBuilder.Entity("Fest.Entities.Concrate.FestArtistEntity", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("FestId")
                        .HasColumnType("int");

                    b.HasKey("ArtistId", "FestId");

                    b.HasIndex("FestId");

                    b.ToTable("FestArtistEntities");
                });

            modelBuilder.Entity("Fest.Entities.Concrate.FestEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FestName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAcvtive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("TicketPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Fests", (string)null);
                });

            modelBuilder.Entity("Fest.Entities.Concrate.MusicTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAcvtive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MusicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("MusicTypes", (string)null);
                });

            modelBuilder.Entity("Fest.Entities.Concrate.PaymentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CardExpirationMonth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardExpirationYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardHolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cvv")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAcvtive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<int>("TicketId1")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.HasIndex("TicketId1");

                    b.ToTable("Payments", (string)null);
                });

            modelBuilder.Entity("Fest.Entities.Concrate.TicketEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FestEntityId")
                        .HasColumnType("int");

                    b.Property<int>("FestId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAcvtive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<decimal?>("TicketPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ValidityDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FestEntityId");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets", (string)null);
                });

            modelBuilder.Entity("Fest.Entities.Concrate.UserDetailEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsAcvtive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserDetails", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Yok",
                            CreatedDate = new DateTime(2023, 3, 13, 15, 31, 45, 579, DateTimeKind.Local).AddTicks(2003),
                            Gender = 0,
                            IsAcvtive = true,
                            IsDeleted = false,
                            LastName = "Admin",
                            Name = "Fest",
                            Phone = "00000000000",
                            UserId = 1,
                            UserType = 2
                        });
                });

            modelBuilder.Entity("Fest.Entities.Concrate.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<bool>("IsAcvtive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 3, 13, 15, 31, 45, 579, DateTimeKind.Local).AddTicks(1970),
                            Email = "Admin@hotmail.com",
                            IsAcvtive = true,
                            IsDeleted = false,
                            Password = "CfDJ8HtxLC5AM4BLvs12g-VlVgbS2a4c_wulPQaukz1_pLqpWERSWy4sQs9FO7cwEEximwxfgST0juzExgJt4RzxjhPDcOCZALYCLVYGhKohJKVjCZAGCM2oY0m-b2nJR31baA"
                        });
                });

            modelBuilder.Entity("Fest.Entities.Concrate.ArtistMusicTypeEntity", b =>
                {
                    b.HasOne("Fest.Entities.Concrate.ArtistEntity", "Artist")
                        .WithMany("MusicTypes")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fest.Entities.Concrate.MusicTypeEntity", "MusicType")
                        .WithMany("Artists")
                        .HasForeignKey("MusicTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("MusicType");
                });

            modelBuilder.Entity("Fest.Entities.Concrate.CityEntity", b =>
                {
                    b.HasOne("Fest.Entities.Concrate.CountryEntity", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Fest.Entities.Concrate.CommentEntity", b =>
                {
                    b.HasOne("Fest.Entities.Concrate.FestEntity", "Fest")
                        .WithMany("Comments")
                        .HasForeignKey("FestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fest.Entities.Concrate.UserEntity", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Fest.Entities.Concrate.FestArtistEntity", b =>
                {
                    b.HasOne("Fest.Entities.Concrate.ArtistEntity", "Artist")
                        .WithMany("Fests")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fest.Entities.Concrate.FestEntity", "Fest")
                        .WithMany("Artists")
                        .HasForeignKey("FestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Fest");
                });

            modelBuilder.Entity("Fest.Entities.Concrate.FestEntity", b =>
                {
                    b.HasOne("Fest.Entities.Concrate.CityEntity", "City")
                        .WithMany("Fests")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Fest.Entities.Concrate.PaymentEntity", b =>
                {
                    b.HasOne("Fest.Entities.Concrate.UserEntity", "User")
                        .WithMany("Payments")
                        .HasForeignKey("TicketId")
                        .IsRequired();

                    b.HasOne("Fest.Entities.Concrate.TicketEntity", "Ticket")
                        .WithMany("Payments")
                        .HasForeignKey("TicketId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Fest.Entities.Concrate.TicketEntity", b =>
                {
                    b.HasOne("Fest.Entities.Concrate.FestEntity", "FestEntity")
                        .WithMany("Tickets")
                        .HasForeignKey("FestEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fest.Entities.Concrate.UserEntity", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FestEntity");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Fest.Entities.Concrate.UserDetailEntity", b =>
                {
                    b.HasOne("Fest.Entities.Concrate.UserEntity", "User")
                        .WithOne("UserDetail")
                        .HasForeignKey("Fest.Entities.Concrate.UserDetailEntity", "UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Fest.Entities.Concrate.ArtistEntity", b =>
                {
                    b.Navigation("Fests");

                    b.Navigation("MusicTypes");
                });

            modelBuilder.Entity("Fest.Entities.Concrate.CityEntity", b =>
                {
                    b.Navigation("Fests");
                });

            modelBuilder.Entity("Fest.Entities.Concrate.CountryEntity", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Fest.Entities.Concrate.FestEntity", b =>
                {
                    b.Navigation("Artists");

                    b.Navigation("Comments");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Fest.Entities.Concrate.MusicTypeEntity", b =>
                {
                    b.Navigation("Artists");
                });

            modelBuilder.Entity("Fest.Entities.Concrate.TicketEntity", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Fest.Entities.Concrate.UserEntity", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Payments");

                    b.Navigation("Tickets");

                    b.Navigation("UserDetail")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
