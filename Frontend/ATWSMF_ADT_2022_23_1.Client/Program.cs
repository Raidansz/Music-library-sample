﻿using ATWSMF_ADT_2022_23_1.Data;
using ATWSMF_ADT_2022_23_1.Logic;
using ATWSMF_ADT_2022_23_1.Models;
using ATWSMF_ADT_2022_23_1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading;
using System.Xml.Linq;

namespace ATWSMF_ADT_2022_23_1.Client
{
    static class Extension
    {
        public static void ToProcess<T>(this IEnumerable<T> query, string headline)
        {
            Console.WriteLine($"\n:: {headline} ::\n");

            foreach (var item in query)
                Console.WriteLine("\t" + item);

            Console.WriteLine("\n\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Seed

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

            




            

            Thread.Sleep(5000);
            RestService service = new RestService("http://localhost:4671");



            //// Post artists
            service.Post<Artist>(Billie, "api/Artist");
            service.Post<Artist>(Ava, "api/Artist");
            service.Post<Artist>(Taylor, "api/Artist");
            // Post songs
            service.Post<Song>(T1, "api/Song");
            service.Post<Song>(T2, "api/Song");
            service.Post<Song>(T4, "api/Song");
            service.Post<Song>(T5, "api/Song");
            service.Post<Song>(T6, "api/Song");
            service.Post<Song>(T7, "api/Song");
            //// Post albums
            service.Post<Album>(A1, "api/Album");
            service.Post<Album>(A2, "api/Album");
            service.Post<Album>(A3, "api/Album");
            service.Post<Album>(A4, "api/Album");

            var song = service.GetSingle<Song>("api/Song/3");
            Console.WriteLine(song);

            //service.Get<Artist>("api/Artist").ToProcess("GetAll Artists");



            #region ThickClientApproach
            //SongContext songContext = new SongContext();

            //SongRepository SongRepo = new SongRepository(songContext);
            //AlbumRepository AlbumRepo = new AlbumRepository(songContext);
            //ArtistRepository ArtistRepo = new ArtistRepository(songContext);

            //SongLogic songLogic = new SongLogic(SongRepo);
            //AlbumLogic albumLogic = new AlbumLogic(AlbumRepo);
            //ArtistLogic artistLogic = new ArtistLogic(ArtistRepo);




            //ListAll(songLogic);
            //ListAll(albumLogic);
            //ListAll(artistLogic);

           
            #endregion

        }
        #region ThickClientApproach
        //private static void ListAll(SongLogic logic)
        //{
        //    Console.WriteLine("\n:: ALL Songs ::\n");

        //    logic.GetAllSongs()
        //        .ToList()
        //        .ForEach(x => Console.WriteLine("\t" + x));
        //}

        //private static void ListAll(AlbumLogic logic)
        //{
        //    Console.WriteLine("\n:: ALL Albums ::\n");

        //    logic.GetAllAlbums()
        //        .ToList()
        //        .ForEach(x => Console.WriteLine("\t" + x));
        //}

        //private static void ListAll(ArtistLogic logic)
        //{
        //    Console.WriteLine("\n:: ALL Artists ::\n");

        //    logic.GetAllArtist()
        //        .ToList()
        //        .ForEach(x => Console.WriteLine("\t" + x));
        //}
        #endregion
    }
}
