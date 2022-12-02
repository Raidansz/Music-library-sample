using ATWSMF_ADT_2022_23_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Repository.Interfaces
{
    public interface IAlbumRepository : IRepository<Album>
    {
        void ChangeTitle(int id, string newTitle);
        void AddNewAlbum(Album album);
        void UpdateAlbum(Album album);
        void DeleteAlbumById(int id);
    }
}
