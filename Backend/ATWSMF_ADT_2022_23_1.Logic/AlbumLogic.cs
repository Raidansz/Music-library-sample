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

        public IList<Album> GetAllAlbums()
        {
            return AlbumRepository.GetAll().ToList();
        }

        public Album GetOneAlbum(int id)
        {
            return this.AlbumRepository.GetOne(id);
        }
    }
}
