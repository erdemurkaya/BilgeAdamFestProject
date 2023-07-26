using Fest.Entities.Concrate;
using Fest.Entities.Enums;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fest.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDataProtector _dataProtector;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDataProtectionProvider dataProtectionProvider) : base(options)
        {

            _dataProtector = dataProtectionProvider.CreateProtector("security");
        }


        #region DbSet

        public DbSet<TicketEntity> TicketEntities => Set<TicketEntity>();
        public DbSet<PaymentEntity> PaymentEntities => Set<PaymentEntity>();

        public DbSet<BlogEntity> BlogEntities =>Set<BlogEntity>();
        public DbSet<CommentEntity> CommentEntities =>Set<CommentEntity>();

        public DbSet<UserEntity> UserEntities => Set<UserEntity>();

        public DbSet<UserDetailEntity> UserDetailEntities => Set<UserDetailEntity>();

        public DbSet<CityEntity> CityEntities => Set<CityEntity>();

        public DbSet<CountryEntity> CountryEntities => Set<CountryEntity>();

        public DbSet<FestEntity> FestEntities => Set<FestEntity>();

        public DbSet<MusicTypeEntity> MusicTypeEntities => Set<MusicTypeEntity>();

        public DbSet<ArtistEntity> ArtistEntities => Set<ArtistEntity>();

        public DbSet<ArtistMusicTypeEntity> ArtistMusicTypeEntities => Set<ArtistMusicTypeEntity>();

        public DbSet<FestArtistEntity> FestArtistEntities => Set<FestArtistEntity>();

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            #region Configuration

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new UserDetailConfiguration());

            modelBuilder.ApplyConfiguration(new CountryConfiguration());

            modelBuilder.ApplyConfiguration(new CityConfiguration());

            modelBuilder.ApplyConfiguration(new ArtistConfiguration());

            modelBuilder.ApplyConfiguration(new FestConfiguration());

            modelBuilder.ApplyConfiguration(new MusicTypeConfiguration());

            modelBuilder.ApplyConfiguration(new BlogConfiguration());

            modelBuilder.ApplyConfiguration(new CommentConfiguration());

            modelBuilder.ApplyConfiguration(new TicketConfiguration());

            modelBuilder.ApplyConfiguration(new PaymentConfiguration());

            #endregion


            #region Table Name


            modelBuilder.Entity<CountryEntity>().ToTable("Countries");

            modelBuilder.Entity<CityEntity>().ToTable("Cities");

            modelBuilder.Entity<FestEntity>().ToTable("Fests");

            modelBuilder.Entity<ArtistEntity>().ToTable("Artists");

            modelBuilder.Entity<MusicTypeEntity>().ToTable("MusicTypes");

            modelBuilder.Entity<UserEntity>().ToTable("Users");

            modelBuilder.Entity<UserDetailEntity>().ToTable("UserDetails");

            modelBuilder.Entity<PaymentEntity>().ToTable("Payments");

            modelBuilder.Entity<TicketEntity>().ToTable("Tickets");

            modelBuilder.Entity<BlogEntity>().ToTable("Blogs");

            modelBuilder.Entity<CommentEntity>().ToTable("Comments");

            #endregion


            #region One To Many

            //City İle Country arasında bire çok bir ilişki kurdum.

            modelBuilder.Entity<CityEntity>().HasOne(x => x.Country).WithMany(y => y.Cities);

            modelBuilder.Entity<CommentEntity>().HasOne(x => x.Fest).WithMany(y => y.Comments);

            modelBuilder.Entity<TicketEntity>().HasOne(x => x.User).WithMany(y => y.Tickets);

            modelBuilder.Entity<PaymentEntity>().HasOne(x => x.User).WithMany(y => y.Payments);

            modelBuilder.Entity<PaymentEntity>().HasOne(x => x.Ticket).WithMany(y => y.Payments).HasForeignKey(x => x.TicketId)
                .OnDelete(DeleteBehavior.ClientSetNull);



            #endregion


            #region One To One

            modelBuilder.Entity<UserDetailEntity>().HasKey(x => x.Id);

            modelBuilder.Entity<UserEntity>().HasOne(x => x.UserDetail).WithOne(x => x.User).HasForeignKey
                <UserDetailEntity>(x => x.UserId).OnDelete(DeleteBehavior.ClientSetNull);


            #endregion


            #region Many To Many

            //Artist İle Festival arasında çoka çok bir ilişki kurdum.

            modelBuilder.Entity<FestArtistEntity>().HasKey(x => new { x.ArtistId, x.FestId });

            modelBuilder.Entity<FestArtistEntity>().HasOne(x => x.Fest).WithMany(x => x.Artists)
                .HasForeignKey(x => x.FestId);

            modelBuilder.Entity<FestArtistEntity>().HasOne(x => x.Artist).WithMany(x => x.Fests)
                .HasForeignKey(x => x.ArtistId);

            //Artist ile MusicType arasında Çoka Çok bir İlişki kurdum.

            modelBuilder.Entity<ArtistMusicTypeEntity>().HasKey(x => new { x.MusicTypeId, x.ArtistId });

            modelBuilder.Entity<ArtistMusicTypeEntity>().HasOne(x => x.Artist).WithMany(x => x.MusicTypes)
                .HasForeignKey(x => x.ArtistId);

            modelBuilder.Entity<ArtistMusicTypeEntity>().HasOne(x => x.MusicType).WithMany(x => x.Artists)
                .HasForeignKey(x => x.MusicTypeId);



            #endregion

            var pwd = "123";

            pwd = _dataProtector.Protect(pwd);


            modelBuilder.Entity<UserEntity>().HasData(new List<UserEntity>()
            {
                new UserEntity()
                {
                    Id=1,
                    Email="Admin@hotmail.com",
                    Password=pwd,
                    


                }
            });

            modelBuilder.Entity<UserDetailEntity>().HasData(new List<UserDetailEntity>()
            {
                new UserDetailEntity()
                {
                    Id = 1,
                    Name="Fest",
                    LastName="Admin",
                    UserType=UserType.admin,
                    Address="Yok",
                    Phone="00000000000",
                    UserId=1


                }
            });










        }
    }
}
