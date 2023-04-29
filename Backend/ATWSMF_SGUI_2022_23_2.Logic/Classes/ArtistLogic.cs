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
    public class ArtistLogic : IArtistLogic, ILogic
    {

        IArtistRepository ArtistRepository;

        public ArtistLogic(IArtistRepository ArtistRepository)
        {
            this.ArtistRepository = ArtistRepository;
        }


        public IList<Artist> GetAllArtists()
        {
            return ArtistRepository.GetAll().ToList();
        }

        public Artist GetOneArtist(int id)
        {
            return ArtistRepository.GetOne(id);
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
