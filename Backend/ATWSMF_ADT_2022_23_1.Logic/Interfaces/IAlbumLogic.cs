using ATWSMF_ADT_2022_23_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Logic.Interfaces
{
    public interface IAlbumLogic
    {
        Album GetOneAlbum(int id);
        IList<Album> GetAllAlbums();
        void AddNewAlbum(Album album);
        void DeleteAlbum(int id);

        void ChangeAlbumTitle(int id, string newTitle);


        void UpdateAlbum(Album album);



    }
}
