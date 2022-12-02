using ATWSMF_ADT_2022_23_1.Models;
using ATWSMF_ADT_2022_23_1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Logic
{
    public class ArtistLogic : IArtistLogic
    {

        IArtistRepository ArtistRepository;

        public ArtistLogic(IArtistRepository ArtistRepository)
        {
            this.ArtistRepository = ArtistRepository;
        }


        public IList<Artist> GetAllArtist()
        {
            return ArtistRepository.GetAll().ToList();
        }

        public Artist GetOneArtist(int id)
        {
            return this.ArtistRepository.GetOne(id);
        }

        public void AddArtist(Artist newArtist)
        {
            ArtistRepository.AddNew(newArtist);
        }

        public Artist GetArtistByName(string name)
        {
           return ArtistRepository.GetOneByName(name);
        }

        public void UpdateArtist(Artist artist)
        {
             ArtistRepository.UpdateArtist(artist);
        }

        public void DeleteArtist(int id)
        {
            ArtistRepository.DeleteArtistById(id);
        }
    }
}
