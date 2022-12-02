using ATWSMF_ADT_2022_23_1.Data;
using ATWSMF_ADT_2022_23_1.Logic;
using ATWSMF_ADT_2022_23_1.Models;
using ATWSMF_ADT_2022_23_1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Threading;
using System.Xml.Linq;

namespace ATWSMF_ADT_2022_23_1.Client
{
   
    class Program
    {
        static void Main(string[] args)
        {
    

            Thread.Sleep(5000);
            RestService service = new RestService("http://localhost:4671");


            //Testing
            #region
            //Before
            service.Get<Artist>("api/Artist").ToProcess("GetAll Artists before POST");


            Artist Celine = new Artist { Id = 4, Name = "Celine Dion", Nationality = "Canadian" };
            Album A = new Album { Id =5 , Name = "Let's Talk About Love", ArtistId = Celine.Id };
            Song S = new Song { Id = 7, Name = "My Heart Will Go On", Duration = 160, AlbumId = A.Id };

            // Post 
            service.Post<Artist>(Celine, "api/Artist");
            service.Post<Album>(A, "api/Album");
            service.Post<Song>(S, "api/Song");


            //After
            service.Get<Artist>("api/Artist").ToProcess("GetAll after POST");
            #endregion

            
           

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
        //        .ForEach(x => Console.WriteLine("\t" + x.Name));
        //}

        //private static void ListAll(AlbumLogic logic)
        //{
        //    Console.WriteLine("\n:: ALL Albums ::\n");

        //    logic.GetAllAlbums()
        //        .ToList()
        //        .ForEach(x => Console.WriteLine("\t" + x.Name));
        //}

        //private static void ListAll(ArtistLogic logic)
        //{
        //    Console.WriteLine("\n:: ALL Artists ::\n");

        //    logic.GetAllArtist()
        //        .ToList()
        //        .ForEach(x => Console.WriteLine("\t" + x.Name));
        //    }
        #endregion
    }

    // Extension
    #region
    static class Extension
    {
        public static void ToProcess<T>(this IEnumerable<T> query, string headline)
        {
            Console.WriteLine($"\n:: {headline} ::\n");

            foreach (var item in query)
            {
                if (item is Artist)
                {
                    Console.WriteLine("\t" + (item as Artist).Name);
                }
                else if (item is Song)
                {
                    Console.WriteLine("\t" + (item as Song).Name);
                }
                else
                {
                    Console.WriteLine("\t" + (item as Album).Name);
                }

            }


            Console.WriteLine("\n\n");
        }
    }
    #endregion
}
