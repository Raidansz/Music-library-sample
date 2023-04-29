using ATWSMF_SGUI_2022_23_2.Logic.Interfaces;
using ATWSMF_SGUI_2022_23_2.Models;
using ATWSMF_SGUI_2022_23_2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_SGUI_2022_23_2.Logic.Classes
{
    public class AlbumLogic : IAlbumLogic,ILogic
    {

        IAlbumRepository AlbumRepository;

        public AlbumLogic(IAlbumRepository albumRepository)
        {
            AlbumRepository = albumRepository;
        }

        public void AddNewAlbum(Album album)
        {
            AlbumRepository.AddNew(album);

        }

        public void ChangeAlbumTitle(int id, string newTitle)
        {
            if (newTitle == "")
                throw new Exception("[ERR] Title can't be empty!");

            AlbumRepository.ChangeTitle(id, newTitle);
        }

        public void DeleteAlbum(int id)
        {
            AlbumRepository.DeleteAlbumById(id);
        }

        public IList<Album> GetAllAlbums()
        {
            return AlbumRepository.GetAll().ToList();
        }

        public Album GetOneAlbum(int id)
        {
            return AlbumRepository.GetOne(id);
        }

        public void UpdateAlbum(Album album)
        {
            AlbumRepository.UpdateAlbum(album);
        }
    }
}
