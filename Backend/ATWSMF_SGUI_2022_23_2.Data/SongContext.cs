using ATWSMF_SGUI_2022_23_2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.InteropServices;

namespace ATWSMF_SGUI_2022_23_2.Data
{
    public class SongContext : DbContext
    {
        public SongContext()
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging().UseLazyLoadingProxies();



            // if we're running on windows use localDB otherwise use regular mssql server
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // This requires a working mssql server configured with the supplied parameters 
                optionsBuilder.UseSqlServer("Server=localhost;Database=songdb;User=sa;Password=RandomPas$word;");
            }
            else
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\songsdb.mdf;Integrated Security=True; MultipleActiveResultSets=true");
            }


            base.OnConfiguring(optionsBuilder);



        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

     

            modelBuilder.Entity<Artist>(e =>
            {
                e.HasKey(v => v.Id);
                e.Property(b => b.Id).ValueGeneratedOnAdd();
                
            });




            modelBuilder.Entity<Song>(e =>
            {

                e.HasKey(c => c.Id);
                e.HasOne(c => c.Artist).WithMany(v => v.Songs);
                e.Property(v => v.Id).ValueGeneratedOnAdd();

            });





            modelBuilder.Entity<Album>(e =>
            {
                e.HasKey(v => v.Id);
                e.Property(b => b.Id).ValueGeneratedOnAdd();
                e.HasMany(a => a.Songs).WithOne(e => e.Album);
               


            });

            modelBuilder.Entity<Song>(e =>
            {

                e.HasKey(c => c.Id);
                e.HasOne(c => c.Album).WithMany(v => v.Songs);
                e.Property(v => v.Id).ValueGeneratedOnAdd();
               
            });


            InitialDbSeed dbSeed = new InitialDbSeed();
            dbSeed.OnModelCreating(modelBuilder);


            base.OnModelCreating(modelBuilder);
        }



    }
}
