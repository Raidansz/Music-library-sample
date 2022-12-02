using ATWSMF_ADT_2022_23_1.Data;
using ATWSMF_ADT_2022_23_1.Models;
using ATWSMF_ADT_2022_23_1.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Repository.Classes
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {

        public AlbumRepository(DbContext context) : base(context)
        {

        }

        public void AddNewAlbum(Album album)
        {
            context.Add(album);
            context.SaveChanges();
        }

        public void ChangeTitle(int id, string newTitle)
        {
            var album = GetOne(id);
            album.Name = newTitle;
            context.SaveChanges();
        }

        public void DeleteAlbumById(int id)
        {
            var toDelete = GetOne(id);
            context.Remove(toDelete);
            context.SaveChanges();
        }

        public override Album GetOne(int id)
        {
            return (context as SongContext).Albums.FirstOrDefault(c => c.Id == id);
        }

        public override Album GetOneByName(string title)
        {
            return (context as SongContext).Albums.FirstOrDefault(c => c.Name == title);
        }

        public void UpdateAlbum(Album album)
        {
            var toUpdate = GetOne(album.Id);

            toUpdate = album;

            context.SaveChanges();
        }
    }
}
