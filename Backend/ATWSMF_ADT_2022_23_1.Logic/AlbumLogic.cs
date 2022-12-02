using ATWSMF_ADT_2022_23_1.Models;
using ATWSMF_ADT_2022_23_1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Logic
{
    public class AlbumLogic : IAlbumLogic
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
            return this.AlbumRepository.GetOne(id);
        }

        public void UpdateAlbum(Album album)
        {
            AlbumRepository.UpdateAlbum(album);
        }
    }
}
