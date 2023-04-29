using ATWSMF_SGUI_2022_23_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_SGUI_2022_23_2.Logic.Interfaces
{
    public interface ISongLogic
    {
        Song GetOneSong(int id);
        void DeleteSong(int id);
        IList<Song> GetAllSongs();
        IList<Song> GetSongsByNameOfArtist(string name);
        void AddNewSong(Song song);


        void ChangeSongTitle(int id, string newTitle);


        void UpdateSong(Song song);


    }
}
