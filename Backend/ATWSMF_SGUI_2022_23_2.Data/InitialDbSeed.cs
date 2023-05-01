
using ATWSMF_SGUI_2022_23_2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_SGUI_2022_23_2.Data
{
    public class InitialDbSeed : SongContext
    {


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // ARTISTS
            Artist Billie = new Artist { Id = 1, Name = "Billie Eilish", Nationality = "American" };
            Artist Ava = new Artist { Id = 2, Name = "Ava Max", Nationality = "Albanian" };
            Artist Taylor = new Artist { Id = 3, Name = "Taylor Swift", Nationality = "American" };

            // more
            // ARTISTS
           
            Artist artist4 = new Artist { Id = 4, Name = "The Rolling Stones", Nationality = "British" };
            Artist artist5 = new Artist { Id = 5, Name = "Pink Floyd", Nationality = "British" };
            Artist artist6 = new Artist { Id = 6, Name = "The Beatles", Nationality = "British" };
            Artist artist7 = new Artist { Id = 7, Name = "Elton John", Nationality = "British" };
            Artist artist8 = new Artist { Id = 8, Name = "David Bowie", Nationality = "British" };
            Artist artist9 = new Artist { Id = 9, Name = "Bruce Springsteen", Nationality = "American" };
            Artist artist10 = new Artist { Id = 10, Name = "Michael Jackson", Nationality = "American" };
            Artist artist11 = new Artist { Id = 11, Name = "Madonna", Nationality = "American" };
            Artist artist12 = new Artist { Id = 12, Name = "Prince", Nationality = "American" };
            Artist artist13 = new Artist { Id = 13, Name = "Whitney Houston", Nationality = "American" };
            Artist artist14 = new Artist { Id = 14, Name = "Tina Turner", Nationality = "American" };
            Artist artist15 = new Artist { Id = 15, Name = "Beyoncé", Nationality = "American" };
            Artist artist16 = new Artist { Id = 16, Name = "Rihanna", Nationality = "Barbadian" };
            Artist artist17 = new Artist { Id = 17, Name = "Eminem", Nationality = "American" };
            Artist artist18 = new Artist { Id = 18, Name = "Dr. Dre", Nationality = "American" };
            Artist artist19 = new Artist { Id = 19, Name = "Snoop Dogg", Nationality = "American" };
            Artist artist20 = new Artist { Id = 20, Name = "N.W.A", Nationality = "American" };
            Artist artist21 = new Artist { Id = 21, Name = "Metallica", Nationality = "American" };
            Artist artist22 = new Artist { Id = 22, Name = "Guns N' Roses", Nationality = "American" };
            Artist artist23 = new Artist { Id = 23, Name = "Nirvana", Nationality = "American" };
            Artist artist24 = new Artist { Id = 24, Name = "Pearl Jam", Nationality = "American" };
            Artist artist25 = new Artist { Id = 25, Name = "Red Hot Chili Peppers", Nationality = "American" };
            Artist artist26 = new Artist { Id = 26, Name = "Radiohead", Nationality = "British" };
            Artist artist27 = new Artist { Id = 27, Name = "Coldplay", Nationality = "British" };
            Artist artist28 = new Artist { Id = 28, Name = "Oasis", Nationality = "British" };
            Artist artist29 = new Artist { Id = 29, Name = "Blur", Nationality = "British" };
            Artist artist1 = new Artist { Id = 30, Name = "Queen", Nationality = "British" };
            Artist artist2 = new Artist { Id = 31, Name = "Led Zeppelin", Nationality = "British" };
            Artist artist3 = new Artist { Id = 32, Name = "AC/DC", Nationality = "Australian" };

            Artist Rihanna = new Artist { Id = 146, Name = "Rihanna", Nationality = "Barbadian" };
            Artist Beyonce = new Artist { Id = 157, Name = "Beyonce", Nationality = "American" };
            Artist EdSheeran = new Artist { Id = 148, Name = "Ed Sheeran", Nationality = "English" };
            Artist Adele = new Artist { Id = 149, Name = "Adele", Nationality = "English" };
            Artist Ariana = new Artist { Id = 230, Name = "Ariana Grande", Nationality = "American" };
            Artist Harry = new Artist { Id = 321, Name = "Harry Styles", Nationality = "English" };
            Artist Coldplay = new Artist { Id = 252, Name = "Coldplay", Nationality = "British" };
            Artist Drake = new Artist { Id = 243, Name = "Drake", Nationality = "Canadian" };
            Artist KendrickLamar = new Artist { Id = 234, Name = "Kendrick Lamar", Nationality = "American" };
            Artist TheWeeknd = new Artist { Id = 245, Name = "The Weeknd", Nationality = "Canadian" };

            // ALBUMS
            Album A1 = new Album { Id = 1, Name = "Speak Now", ArtistId = Taylor.Id };
            Album A2 = new Album { Id = 2, Name = " Common Culture, Vol. V by Connor Franta", ArtistId = Billie.Id };
            Album A3 = new Album { Id = 3, Name = "Future Nostalgia", ArtistId = Ava.Id };
            Album A4 = new Album { Id = 4, Name = "Speak Now", ArtistId = Taylor.Id };
            //more
            Album R1 = new Album { Id = 21, Name = "Anti", ArtistId = Rihanna.Id };
            Album R2 = new Album { Id = 22, Name = "Loud", ArtistId = Rihanna.Id };
            Album B1 = new Album { Id = 23, Name = "Lemonade", ArtistId = Beyonce.Id };
            Album B2 = new Album { Id = 24, Name = "B'Day", ArtistId = Beyonce.Id };
            Album E1 = new Album { Id = 25, Name = "÷ (Divide)", ArtistId = EdSheeran.Id };
            Album E2 = new Album { Id = 26, Name = "+ (Plus)", ArtistId = EdSheeran.Id };
           
            Album AG1 = new Album { Id = 29, Name = "My Everything", ArtistId = Ariana.Id };
            Album AG2 = new Album { Id = 30, Name = "Thank U, Next", ArtistId = Ariana.Id };
            Album H1 = new Album { Id = 31, Name = "Fine Line", ArtistId = Harry.Id };
            Album H2 = new Album { Id = 32, Name = "Harry Styles", ArtistId = Harry.Id };
            Album C1 = new Album { Id = 33, Name = "Parachutes", ArtistId = Coldplay.Id };
            Album C2 = new Album { Id = 34, Name = "A Head Full of Dreams", ArtistId = Coldplay.Id };
            Album D1 = new Album { Id = 35, Name = "Views", ArtistId = Drake.Id };
            Album D2 = new Album { Id = 36, Name = "Take Care", ArtistId = Drake.Id };
            Album KL1 = new Album { Id = 37, Name = "DAMN.", ArtistId = KendrickLamar.Id };
            Album KL2 = new Album { Id = 38, Name = "To Pimp a Butterfly", ArtistId = KendrickLamar.Id };
           

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

            // Billie Eilish - Happier Than Ever
            Song gB1 = new Song { Id = 1, Name = "Getting Older", Duration = 248 };
            Song Bg2 = new Song { Id = 2, Name = "I Didn't Change My Number", Duration = 162 };
            Song B3 = new Song { Id = 3, Name = "Billie Bossa Nova", Duration = 191};
            Song B4 = new Song { Id = 4, Name = "my future", Duration = 210 };
            Song B5 = new Song { Id = 5, Name = "Oxytocin", Duration = 191 };
            Song B6 = new Song { Id = 6, Name = "GOLDWING", Duration = 163 };
            Song B7 = new Song { Id = 7, Name = "Lost Cause", Duration = 201 };
            Song B8 = new Song { Id = 8, Name = "Halley's Comet", Duration = 238 };
            Song B9 = new Song { Id = 9, Name = "Not My Responsibility", Duration = 69 };
            Song B10 = new Song { Id = 10, Name = "OverHeated", Duration = 217 };
            Song B11 = new Song { Id = 11, Name = "Everybody Dies", Duration = 174 };
            Song B12 = new Song { Id = 12, Name = "Your Power", Duration = 242 };
            Song B13 = new Song { Id = 13, Name = "NDA", Duration = 205 };
            Song B14 = new Song { Id = 14, Name = "Therefore I Am", Duration = 174 };
            Song B15 = new Song { Id = 15, Name = "Happier Than Ever", Duration = 304 };

            // Taylor Swift - evermore
            Song Tg1 = new Song { Id = 16, Name = "willow", Duration = 215,  };
            Song Tg2 = new Song { Id = 17, Name = "champagne problems", Duration = 244 };
            Song Tg3 = new Song { Id = 18, Name = "gold rush", Duration = 212 };
            Song Tg4 = new Song { Id = 19, Name = "'tis the damn season", Duration = 221 };
            Song Tg5 = new Song { Id = 20, Name = "tolerate it", Duration = 254 };
            Song Tg6 = new Song { Id = 21, Name = "no body, no crime", Duration = 221 };
            Song Tg7 = new Song { Id = 22, Name = "happiness", Duration = 256 };
            Song T8 = new Song { Id = 23, Name = "dorothea", Duration = 232 };
           
            



            modelBuilder.Entity<Artist>().HasData(Billie, Ava, Taylor);
            modelBuilder.Entity<Album>().HasData(A1, A2, A3, A4);
            modelBuilder.Entity<Song>().HasData(T1, T2, T4, T5, T6, T7);









        }
    }
}