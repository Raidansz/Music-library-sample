using ATWSMF_ADT_2022_23_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Repository
{
    public interface ISongRepository: IRepository<Song>
    {
        void ChangeTitle(int id, string newTitle);
        void AddNewSong(Song song);
        void UpdateSong(Song song);
        void DeleteSongById(int id);
        void DeleteSongByTitle(string title);
    }
}
