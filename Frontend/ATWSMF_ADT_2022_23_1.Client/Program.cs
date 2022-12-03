
using ATWSMF_ADT_2022_23_1.Logic.Classes;
using ATWSMF_ADT_2022_23_1.Logic.Interfaces;
using ATWSMF_ADT_2022_23_1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace ATWSMF_ADT_2022_23_1.Client
{

    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(5000);
            RestService service = new RestService("http://localhost:4671");


            //POST DOESN'T WORK  
            #region Testing
            //Before
            service.Get<Artist>("api/Artist").ToProcess("GetAll Artists before POST");


            Artist Celine = new Artist { Id = 4, Name = "Celine Dion", Nationality = "Canadian" };
            Album A = new Album { Id = 5, Name = "Let's Talk About Love", ArtistId = Celine.Id };
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



            //songLogic.ToProcess("Songs");
            //albumLogic.ToProcess("Albums");
            //artistLogic.ToProcess("Artists");

            #endregion

        }

    }

   
    #region Extension
    static class Extension
    {
        public static void ToProcess<T>(this T query, string headline)
        {
            Console.WriteLine($"\n:: {headline} ::\n");

            if (query is IEnumerable)
            {
               
                foreach (var item in query as IEnumerable )
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
                    Console.WriteLine("\n");
                }

            }
            //ThickClientApproach
            else if (query is ILogic)
            {
                if (query is SongLogic)
                {
                    var song = query as SongLogic;
                    

                    song.GetAllSongs()
                        .ToList()
                        .ForEach(x => Console.WriteLine("\t" + x.Name));
                }
                else if (query is AlbumLogic)
                {
                    var album = query as AlbumLogic;
                  

                    album.GetAllAlbums()
                        .ToList()
                        .ForEach(x => Console.WriteLine("\t" + x.Name));
                }
                else
                {
                    var artist = query as ArtistLogic;
                  

                    artist.GetAllArtists()
                        .ToList()
                        .ForEach(x => Console.WriteLine("\t" + x.Name));
                }




            } 
        } } }

#endregion



