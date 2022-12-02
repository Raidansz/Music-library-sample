using ATWSMF_ADT_2022_23_1.Data;
using ATWSMF_ADT_2022_23_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Repository
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(DbContext context) : base(context)
        {
        }

        public void AddNewArtist(Artist artist)
        {
            context.Add(artist);
            context.SaveChanges();
        }

        public void DeleteArtistById(int id)
        {
            var toDelete = GetOne(id);
            context.Remove(toDelete);
            context.SaveChanges();
        }

        public void DeleteArtistByName(string name)
        {
            var toDelete = GetOneByName(name);
            context.Remove(toDelete);
            context.SaveChanges();
        }

        public override Artist GetOne(int id)
        {
            return (base.context as SongContext).Artists.FirstOrDefault(c => c.Id == id);
        }

        public override Artist GetOneByName(string title)
        {
            return (base.context as SongContext).Artists.FirstOrDefault(c => c.Name == title);
        }

        public void UpdateArtist(Artist artist)
        {
            var toUpdate = GetOne(artist.Id);

            toUpdate = artist;

            context.SaveChanges();
        }
    }
}
