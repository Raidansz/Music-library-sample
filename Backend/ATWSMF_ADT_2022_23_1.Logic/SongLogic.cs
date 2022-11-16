using ATWSMF_ADT_2022_23_1.Models;
using ATWSMF_ADT_2022_23_1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Logic
{
    public class SongLogic : ISongLogic
    {
        ISongRepository SongRepository;

        public SongLogic(ISongRepository songRepository)
        {
            SongRepository = songRepository;
        }

        public void DeleteSong(int id)
        {
            SongRepository.Delete(GetOneSong(id));
        }

        public IList<Song> GetAllSongs()
        {
            return this.SongRepository.GetAll().ToList();
        }

        public Song GetOneSong(int id)
        {
            return this.SongRepository.GetOne(id);
        }

     

        IList<Song> ISongLogic.GetSongsByNameOfArtist(string name)
        {
            IList<Song> songs = new List<Song>();

            foreach (Song song in SongRepository.GetAll())
            {
                if (song.Artist.Name.Contains(name))
                {
                    songs.Add(song);
                }
            }
            return songs;
        }
    }
}
