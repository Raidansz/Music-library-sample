﻿using ATWSMF_ADT_2022_23_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Data
{
    public class DbSeed : SongContext
    {


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
                // ARTISTS
                Artist Billie = new Artist { Id = 1, Name = "Billie", Country = "USA" };
                Artist Ava = new Artist { Id = 2, Name = "Ava Max", Country = "USA" };
                Artist Taylor = new Artist { Id = 3, Name = "Taylor Swift", Country = "KU" };

                // ALBUMS
                //Album A1 = new Album { Id = 1, Name = "Speak Now", ArtistId = Taylor.Id };
                //Album A2 = new Album { Id = 2, Name = " Common Culture, Vol. V by Connor Franta", ArtistId = Billie.Id };
                //Album A3 = new Album { Id = 3, Name = "Future Nostalgia", ArtistId = Ava.Id };
                //Album A4 = new Album { Id = 4, Name = "Speak Now", ArtistId = Taylor.Id };
                Album A1 = new Album { Id = 1, Name = "Speak Now" };
                Album A2 = new Album { Id = 2, Name = " Common Culture, Vol. V by Connor Franta" };
                Album A3 = new Album { Id = 3, Name = "Future Nostalgia" };
                Album A4 = new Album { Id = 4, Name = "Speak Now" };

                //SONGS
                // Billie
                Song T1 = new Song { Id = 1, Name = "Ocean Eyes", Duration = 160, ArtistId = Billie.Id, AlbumId = A2.Id };
                //Ava Max
                Song T2 = new Song { Id = 2, Name = "Levitating ", Duration = 150, ArtistId = Ava.Id, AlbumId = A3.Id };
                //Taylor Swift
                Song T4 = new Song { Id = 8, Name = "Speak Now", Duration = 150, ArtistId = Taylor.Id, AlbumId = A1.Id };
                Song T5 = new Song { Id = 5, Name = "Sparks Fly", Duration = 150, ArtistId = Taylor.Id, AlbumId = A1.Id };
                Song T6 = new Song { Id = 6, Name = "Mine", Duration = 150, ArtistId = Taylor.Id, AlbumId = A1.Id };
                Song T7 = new Song { Id = 7, Name = "Mean", Duration = 150, ArtistId = Taylor.Id, AlbumId = A1.Id };


                modelBuilder.Entity<Artist>().HasData(Billie, Ava, Taylor);
                modelBuilder.Entity<Album>().HasData(A1, A2, A3, A4);
                modelBuilder.Entity<Song>().HasData(T1, T2, T4, T5, T6, T7);



                //modelBuilder.Entity<Album>(e =>
                //{

                //    e.HasKey(c => c.Id);
                //    e.HasOne(c => c.Artist).WithMany(v => v.Albums);
                //    e.Property(v => v.Id).ValueGeneratedOnAdd();
                //    e.HasData(A1,A2,A3, A4);

                //});







            
        }
    }
}
