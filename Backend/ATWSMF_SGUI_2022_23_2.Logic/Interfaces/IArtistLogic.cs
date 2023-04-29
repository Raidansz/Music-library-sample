using ATWSMF_SGUI_2022_23_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_SGUI_2022_23_2.Logic.Interfaces
{
    public interface IArtistLogic
    {
        Artist GetOneArtist(int id);

        IList<Artist> GetAllArtists();
        void AddArtist(Artist newArtist);

        Artist GetArtistByName(string name);






        void UpdateArtist(Artist artist);
        void DeleteArtist(int id);

    }
}
