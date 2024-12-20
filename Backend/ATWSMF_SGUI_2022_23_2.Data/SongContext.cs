﻿using ATWSMF_SGUI_2022_23_2.Models;
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

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("song");
            }





            //optionsBuilder
            //    .EnableSensitiveDataLogging().UseLazyLoadingProxies();



            //// if we're running on windows use localDB otherwise use regular mssql server
            //if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            //{
            //    // This requires a working mssql server configured with the supplied parameters 
            //    optionsBuilder.UseSqlServer("Server=localhost;Database=songdb;User=sa;Password=RandomPas$word;");
            //}
            //else
            //{
            //    optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\songsdb.mdf;Integrated Security=True; MultipleActiveResultSets=true");
            //}


            //base.OnConfiguring(optionsBuilder);



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

            // ARTISTS
            Artist Billie = new Artist { Id = 1, Name = "Billie Eilish", Nationality = "American" };
            Artist Ava = new Artist { Id = 2, Name = "Ava Max", Nationality = "Albanian" };
            Artist Taylor = new Artist { Id = 3, Name = "Taylor Swift", Nationality = "American" };
            // ALBUMS
            Album A1 = new Album { Id = 1, Name = "Speak Now", ArtistId = Taylor.Id };
            Album A2 = new Album { Id = 2, Name = " Common Culture, Vol. V by Connor Franta", ArtistId = Billie.Id };
            Album A3 = new Album { Id = 3, Name = "Future Nostalgia", ArtistId = Ava.Id };
            Album A4 = new Album { Id = 4, Name = "Speak Now", ArtistId = Taylor.Id };

            //SONGS

            // Billie
            Song T1 = new Song { Id = 1, Name = "Ocean Eyes", Duration = 160, AlbumId = A2.Id };
            //Ava Max
            Song T2 = new Song { Id = 2, Name = "Levitating ", Duration = 150, AlbumId = A3.Id };
            //Taylor Swift
            Song T4 = new Song { Id = 3, Name = "Speak Now", Duration = 150, AlbumId = A1.Id };
            Song T5 = new Song { Id = 4, Name = "Sparks Fly", Duration = 150, AlbumId = A1.Id };
            Song T6 = new Song { Id = 5, Name = "Mine", Duration = 150, AlbumId = A1.Id };
            Song T7 = new Song { Id = 6, Name = "Mean", Duration = 150, AlbumId = A1.Id };


            modelBuilder.Entity<Artist>().HasData(Billie, Ava, Taylor);
            modelBuilder.Entity<Album>().HasData(A1, A2, A3, A4);
            modelBuilder.Entity<Song>().HasData(T1, T2, T4, T5, T6, T7);

            //InitialDbSeed dbSeed = new InitialDbSeed();
            //dbSeed.OnModelCreating(modelBuilder);


            base.OnModelCreating(modelBuilder);
        }



    }
}
