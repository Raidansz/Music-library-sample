using ATWSMF_ADT_2022_23_1.Data;
using ATWSMF_ADT_2022_23_1.Models;
using System;

namespace testdb
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var DbConnection = new SongContext();

            //foreach (var Artist in DbConnection.Artists)
            //{
            //    Console.WriteLine("Artist Name :   "+ Artist.Name);

            //    foreach (Album album in Artist.Albums)
            //    {
            //        Console.WriteLine("Artist Albums :   " + album.Name);

            //        foreach (Song song in album.Songs)
            //        {
            //            Console.WriteLine("Artist Songs :   " + song.Name);
            //        }
            //    }

            //}




            foreach (var Artist in DbConnection.Artists)
            {
                Console.WriteLine("Artist Name :   " + Artist.Name);

                foreach (Song song in Artist.Songs)
                {
                    Console.WriteLine("Artist Songs :   " + song.Name);


                }

            }




            foreach (var Album in DbConnection.Albums)
            {
                Console.WriteLine("Album Name :   " + Album.Name);

                foreach (Song song in Album.Songs)
                {
                    Console.WriteLine("Album Songs :   " + song.Name);


                }

            }





        }
    }
}
